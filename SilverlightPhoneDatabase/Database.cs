using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Xml.Serialization;
using SilverlightPhoneDatabase.Core;
using SilverlightPhoneDatabase.Exceptions;
using SilverlightPhoneDatabase.Resources;

namespace SilverlightPhoneDatabase
{
    /// <summary>
    /// Database class - contains tables
    /// </summary>
    public class Database
    {
        private object _lock = new object();

        private Database() { }
        private Database(string databaseName, string password, bool useLazyLoading)
        {
            _databaseName = databaseName;
            _password = password;
            _useLazyLoading = useLazyLoading;
            _tables = new ReadOnlyCollection<ITable>(new List<ITable>());
            _loadedTables = new Dictionary<Type, bool>();
        }

        private string _password = string.Empty;

        private string _databaseName = string.Empty;

        private bool _useLazyLoading = false;

        private Dictionary<Type, bool> _loadedTables;

        /// <summary>
        /// Database name
        /// </summary>
        public string DatabaseName { get { return _databaseName; } }

        /// <summary>
        /// Password that the database is encrypted with.
        /// Blank if no password is used
        /// </summary>
        public string Password { get { return _password; } }

        private ReadOnlyCollection<ITable> _tables;
        /// <summary>
        /// List of tables that belong to this database
        /// </summary>
        public ReadOnlyCollection<ITable> Tables
        {
            get
            {
                return _tables;
            }
        }

        /// <summary>
        /// Create new database instance with specified name
        /// </summary>
        /// <param name="databaseName">Database name</param>
        /// <returns></returns>
        public static Database CreateDatabase(string databaseName)
        {
            return CreateDatabase(databaseName, string.Empty);
        }

        /// <summary>
        /// Create new database instance with specified name
        /// </summary>
        /// <param name="databaseName">Database name</param>
        /// <param name="password">Password to ecrypt database with</param>
        /// <returns></returns>
        public static Database CreateDatabase(string databaseName, string password)
        {
            if (DoesDatabaseExists(databaseName))
            {
                throw new DatabaseExistsException(string.Format(DatabaseResources.DatabaseExistsExceptionText, databaseName));
            }
            return new Database(databaseName, password, false);
        }



        /// <summary>
        /// Open database from Isolated Storage
        /// </summary>
        /// <param name="databaseName">Name of database to open</param>
        /// <exception cref="SilverlightPhoneDatabase.Exceptions.OpenException">Thrown when an error occurs</exception>
        /// <returns>Instance of the database</returns>
        public static Database OpenDatabase(string databaseName)
        {
            return OpenDatabase(databaseName, string.Empty, false);
        }

        /// <summary>
        /// Open database from Isolated Storage
        /// </summary>
        /// <param name="databaseName">Name of database to open</param>
        /// <param name="password">Password to use for encryption</param>
        /// <exception cref="SilverlightPhoneDatabase.Exceptions.OpenException">Thrown when an error occurs</exception>
        /// <returns>Instance of the database</returns>
        public static Database OpenDatabase(string databaseName, string password)
        {
            return OpenDatabase(databaseName, password, false);
        }

        /// <summary>
        /// Open database from Isolated Storage
        /// </summary>
        /// <param name="databaseName">Name of database to open</param>
        /// <param name="password">Password to use for encryption</param>
        /// <param name="useLazyLoading">If true, tables are not open immediately, but instead loaded on demend when accessed</param>
        /// <exception cref="SilverlightPhoneDatabase.Exceptions.OpenException">Thrown when an error occurs</exception>
        /// <returns>Instance of the database</returns>
        public static Database OpenDatabase(string databaseName, string password, bool useLazyLoading)
        {
            if (!DoesDatabaseExists(databaseName))
            {
                throw new DatabaseDoesNotExistsException(string.Format(DatabaseResources.DatabaseDoesNotExistsExceptionText, databaseName));
            }
            try
            {
                Database returnValue = new Database(databaseName, password, useLazyLoading);
                string[] parts;
                Type tableType = null;
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(databaseName, FileMode.Open, store))
                    {
                        StreamReader reader = new StreamReader(stream);
                        string content;
                        content = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(password))
                        {
                            content = Cryptography.Decrypt(content, password);
                        }
                        parts = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        stream.Close();
                    }

                    if (parts != null)
                    {
                        for (int counter = 1; counter < parts.Length; counter++)
                        {
                            string content = string.Empty; ;
                            string rowTypeString = parts[counter];
                            Type rowType = Type.GetType(rowTypeString);
                            tableType = typeof(Table<>).MakeGenericType(new Type[] { rowType });
                            if (!useLazyLoading)
                            {
                                string fileName = string.Concat(databaseName, ".", rowType.FullName);
                                using (IsolatedStorageFileStream tableStream = new IsolatedStorageFileStream(fileName, FileMode.Open, store))
                                {
                                    returnValue.LoadTable(tableStream, tableType);
                                    tableStream.Close();
                                }
                            }
                            else
                            {
                                ITable currentTable = (ITable)Activator.CreateInstance(tableType);
                                currentTable.SetTableDefinition(returnValue._databaseName, returnValue._password);
                                List<ITable> tables = new List<ITable>(returnValue._tables);
                                tables.Add(currentTable);
                                returnValue._tables = new ReadOnlyCollection<ITable>(tables);
                                returnValue._loadedTables.Add(rowType, false);
                            }
                        }
                    }
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new OpenException(ex);
            }

        }


        internal void LoadTable(IsolatedStorageFileStream tableStream, Type tableType)
        {
            string content;
            using (StreamReader reader = new StreamReader(tableStream))
            {
                content = reader.ReadToEnd();

                if (!string.IsNullOrEmpty(_password))
                {
                    content = Cryptography.Decrypt(content, _password);
                }
                reader.Close();
            }

            using (StringReader stringReader = new StringReader(content))
            {
                XmlSerializer serializer = new XmlSerializer(tableType);
                ITable table;
                if (!string.IsNullOrEmpty(content))
                {
                    table = (ITable)serializer.Deserialize(stringReader);
                }
                else
                {
                    table = (ITable)Activator.CreateInstance(tableType);
                }
                table.SetTableDefinition(_databaseName, _password);

                List<ITable> tables = new List<ITable>(_tables);
                var tableToRemove = (from oneTable in tables
                                     where oneTable.RowType == table.RowType
                                     select oneTable).FirstOrDefault();
                tables.Remove(tableToRemove);
                tables.Add(table);
                _tables = new ReadOnlyCollection<ITable>(tables);
                stringReader.Close();
            }
        }

        /// <summary>
        /// Create new table from predenined table content
        /// This content must be created using the same table type
        /// using XmlSerializer without encryption
        /// </summary>
        /// <param name="xmlTableContent">Xml string that describes the table</param>
        /// <param name="rowType">Type of a row in the table</param>
        public void CreateNewTable(string xmlTableContent, Type rowType)
        {
            using (StringReader stringReader = new StringReader(xmlTableContent))
            {
                Type tableType = typeof(Table<>).MakeGenericType(new Type[] { rowType });
                XmlSerializer serializer = new XmlSerializer(tableType);
                ITable table = (ITable)serializer.Deserialize(stringReader);
                table.SetTableDefinition(_databaseName, _password);

                List<ITable> tables = new List<ITable>(_tables);
                tables.Add(table);
                _tables = new ReadOnlyCollection<ITable>(tables);
                stringReader.Close();
            }
        }

        internal void LoadTable(string content, Type tableType)
        {

            using (StringReader stringReader = new StringReader(content))
            {
                XmlSerializer serializer = new XmlSerializer(tableType);
                ITable table = (ITable)serializer.Deserialize(stringReader);
                table.SetTableDefinition(_databaseName, _password);

                List<ITable> tables = new List<ITable>(_tables);
                var tableToRemove = (from oneTable in tables
                                     where oneTable.RowType == table.RowType
                                     select oneTable).FirstOrDefault();
                tables.Remove(tableToRemove);
                tables.Add(table);
                _tables = new ReadOnlyCollection<ITable>(tables);
                stringReader.Close();
            }
        }

        /// <summary>
        /// Delete database
        /// </summary>
        /// <param name="databaseName">Name of database to delete</param>
        public static void DeleteDatabase(string databaseName)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string[] files = store.GetFileNames();
                if (files != null && files.Length > 0 && files[0] != null)
                {
                    foreach (var file in files)
                    {
                        if (file == databaseName)
                            store.DeleteFile(file);
                        else if (file.StartsWith(databaseName + "."))
                            store.DeleteFile(file);
                    }
                }
            }
        }

        /// <summary>
        /// Create new table inside database
        /// </summary>
        /// <typeparam name="T">ype of object that this table contains</typeparam>
        public void CreateTable<T>()
        {
            if (DoesTableExists(typeof(T)))
            {
                throw new DatabaseExistsException(string.Format(DatabaseResources.TableExistsExceptionText, typeof(T).FullName));
            }
            else
            {
                List<ITable> tables = new List<ITable>(_tables);
                tables.Add(SilverlightPhoneDatabase.Table<T>.CreateTable(_databaseName, _password));
                _tables = new ReadOnlyCollection<ITable>(tables);
            }
        }

        /// <summary>
        /// FInd instance of a table that contains specific row type
        /// </summary>
        /// <typeparam name="T">Type of object that this table contains</typeparam>
        /// <returns></returns>
        public Table<T> Table<T>()
        {
            ITable returnValue = (from oneTable in Tables
                                  where oneTable.RowType == typeof(T)
                                  select oneTable).FirstOrDefault();
            if (_useLazyLoading && !_loadedTables[typeof(T)])
            {
                Type tableType = typeof(Table<>).MakeGenericType(new Type[] { typeof(T) });
                string fileName = string.Concat(_databaseName, ".", typeof(T).FullName);
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream tableStream = new IsolatedStorageFileStream(fileName, FileMode.Open, store))
                    {
                        LoadTable(tableStream, tableType);
                        tableStream.Close();
                    }
                }
                _loadedTables[typeof(T)] = true;
                returnValue = (from oneTable in Tables
                               where oneTable.RowType == typeof(T)
                               select oneTable).FirstOrDefault();
            }
            return (Table<T>)returnValue;

        }

        /// <summary>
        /// Cancel the pending changes to a table.
        /// </summary>
        /// <typeparam name="T">Type of class that table contains</typeparam>
        public void CancelChanges<T>()
        {
            if (_useLazyLoading)
            {
                if (_loadedTables[typeof(T)])
                {
                    ReloadTable<T>();
                }
            }
            else
            {
                ReloadTable<T>();
            }
        }

        private void ReloadTable<T>()
        {
            Type tableType = typeof(Table<>).MakeGenericType(new Type[] { typeof(T) });
            string fileName = string.Concat(_databaseName, ".", typeof(T).FullName);
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream tableStream = new IsolatedStorageFileStream(fileName, FileMode.Open, store))
                {
                    LoadTable(tableStream, tableType);
                    tableStream.Close();
                }
            }
        }

        /// <summary>
        /// Save database and all tables within it to Isolated Storage
        /// </summary>
        /// <exception cref="SilverlightPhoneDatabase.Exceptions.SaveException">Thrown when an error currs during save</exception>
        public void Save()
        {
            try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {

                    if (store.FileExists(_databaseName))
                    {
                        store.DeleteFile(_databaseName);
                    }

                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(_databaseName, FileMode.OpenOrCreate, store))
                    {

                        WriteDatabaseToStream(stream);
                        stream.Close();
                    }
                }
                foreach (var item in Tables)
                {
                    if (_useLazyLoading)
                    {
                        if (_loadedTables[item.RowType])
                        {
                            item.Save();
                        }
                    }
                    else
                    {
                        item.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }


         /// <summary>
        /// Asynchornously save table le to the Isolated Storage
        /// </summary>
        /// <param name="callback">Function  to be invoked after save complete</param>
        public void BeginSave(Action<SaveResult> callback)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += (o, e) =>
            {
                SaveResult result;
                if (e.Result is Exception)
                {
                    result = new SaveResult(e.Result as Exception);
                }
                else
                {
                    result = new SaveResult(null);
                }
                callback(result);
            };
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Save();
                e.Result = null;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Write content of a database to a stream
        /// </summary>
        /// <param name="stream">Stream to write database to</param>
        public void WriteDatabaseToStream(Stream stream)
        {
            string serilizedInfo = string.Empty;
            serilizedInfo = _databaseName;
            foreach (var item in _tables)
            {
                serilizedInfo = string.Concat(
                    serilizedInfo,
                    Environment.NewLine,
                    CreateFormattedTableType(item.RowType));
            }
            if (!string.IsNullOrEmpty(_password))
            {
                serilizedInfo = Cryptography.Encrypt(serilizedInfo, _password);
            }


            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(serilizedInfo);
                writer.Flush();
                writer.Close();
            }
        }

        #region Helpers

        /// <summary>
        /// Create a string that represents a table type
        /// </summary>
        /// <param name="rowType">Type of row that is contained withing the table</param>
        /// <returns>String that represents a table type</returns>
        private string CreateFormattedTableType(Type rowType)
        {
            string returnValue = rowType.AssemblyQualifiedName.Substring(0, rowType.AssemblyQualifiedName.LastIndexOf("Version")) + "Version=..., " + rowType.AssemblyQualifiedName.Substring(rowType.AssemblyQualifiedName.LastIndexOf("Culture"));

            return returnValue;
        }
        #endregion

        #region Exists
        private bool DoesTableExists(Type rowType)
        {
            bool returnValue = false;
            foreach (var item in Tables)
            {
                if (item.RowType == rowType)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Checks for existance of a database
        /// </summary>
        /// <param name="databaseName">Database name to check</param>
        /// <returns>True if database exists, false otehrwise</returns>
        public static bool DoesDatabaseExists(string databaseName)
        {
            bool returnValue = false;
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string[] files = store.GetFileNames();
                if (files != null && files.Length > 0 && files[0] != null)
                {
                    returnValue = (from aFile in files
                                   where aFile == databaseName
                                   select aFile).Any();
                }
            }
            return returnValue;
        }
        #endregion
    }
}
