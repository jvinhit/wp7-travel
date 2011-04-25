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
    /// Represents a table that contains rows of type T
    /// </summary>
    /// <typeparam name="T">Row type</typeparam>
    public class Table<T> : ObservableCollection<T>, ITable
    {
        private string _databaseName = string.Empty;
        private bool _raiseCollectionChangedEvents = true;
        private string _password = string.Empty;
        private object _lock = new object();

        /// <summary>
        /// Constror for table - use Database.CreateTable instead
        /// </summary>
        [Obsolete("Do not use constructor - use Database.CreateTable() instead")]
        public Table() { }

        private Table(string databaseName, string password)
        {
            _databaseName = databaseName;
            _password = password;
        }

        /// <summary>
        /// Set internal variables data when a table is de-serialized
        /// </summary>
        /// <param name="databaseName">Database name that table belongs to</param>
        /// <param name="password">Password to use for encryption</param>
        public void SetTableDefinition(string databaseName, string password)
        {
            _databaseName = databaseName;
            _password = password;
        }

        /// <summary>
        /// Create new table for specified database
        /// </summary>
        /// <param name="databaseName">Database name that table belongs to</param>
        /// <param name="password">Password to use for encryption</param>
        /// <returns></returns>
        internal static Table<T> CreateTable(string databaseName, string password)
        {
            return new Table<T>(databaseName, password);
        }

        /// <summary>
        /// Save table to isolated storage
        /// </summary>
        /// <exception cref="SilverlightPhoneDatabase.Exceptions.SaveException">Thrown when an error currs during save</exception>
        public void Save()
        {
            if (!string.IsNullOrEmpty(_databaseName))
            {
                try
                {
                    using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        Save(store);
                    }
                }
                catch (Exception ex)
                {
                    throw new SaveException(ex);
                }

            }
            else
            {
                throw new TableCannotBeSavedException(DatabaseResources.TableWithoutDatabaseCannotBeSaved);
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
        /// Save table to isolated storage
        /// </summary>
        /// <param name="store">Isolated staorage file to save to</param>
        /// <exception cref="SilverlightPhoneDatabase.Exceptions.SaveException">Thrown when an error currs during save</exception>
        public void Save(IsolatedStorageFile store)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(_databaseName))
                {
                    try
                    {
                        string fileName = string.Concat(_databaseName, ".", typeof(T).FullName);
                        if (store.FileExists(fileName))
                        {
                            store.DeleteFile(fileName);
                        }
                        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate, store))
                        {
                            WriteDTableToStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new SaveException(ex);
                    }

                }
                else
                {
                    throw new TableCannotBeSavedException(DatabaseResources.TableWithoutDatabaseCannotBeSaved);
                }
            }
        }



        /// <summary>
        /// Write content of a table to a stream
        /// </summary>
        /// <param name="stream">Stream to write table to</param>
        public void WriteDTableToStream(Stream stream)
        {
            string content = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());

                serializer.Serialize(stringWriter, this);
                stringWriter.Flush();
                content = stringWriter.GetStringBuilder().ToString();
                if (!string.IsNullOrEmpty(_password))
                {
                    content = Cryptography.Encrypt(content, _password);
                }
                stringWriter.Close();
            }

            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(content);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Raises collection changed event
        /// </summary>
        /// <param name="e">Event args for collection changed event</param>
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_raiseCollectionChangedEvents)
            {
                base.OnCollectionChanged(e);
            }
        }

        /// <summary>
        /// Add a range of items to the table
        /// </summary>
        /// <param name="range">Range of items</param>
        public void AddRange(IEnumerable<T> range)
        {
            _raiseCollectionChangedEvents = false;
            try
            {
                foreach (var item in range)
                {
                    Add(item);
                }
            }
            finally
            {
                _raiseCollectionChangedEvents = true;
                OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
            }
        }

        /// <summary>
        /// Remove a range of items from the table
        /// </summary>
        /// <param name="range">Range of items to remove</param>
        public void RemoveRange(IEnumerable<T> range)
        {
            _raiseCollectionChangedEvents = false;
            try
            {
                foreach (var item in range)
                {
                    Remove(item);
                }
            }
            finally
            {
                _raiseCollectionChangedEvents = true;
                OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
            }
        }

        /// <summary>
        /// Delete a range of items from the table based on
        /// condtion being met
        /// </summary>
        /// <param name="deleteCondition">
        /// Condition that must be met to delete the items
        /// </param>
        public void RemoveRange(Func<T, bool> deleteCondition)
        {
            var deletedItems = (from oneItem in this
                                where deleteCondition(oneItem)
                                select oneItem);
            if (deletedItems != null && deletedItems.Count() > 0)
            {
                RemoveRange(deletedItems.ToArray());
            }
        }


        #region ITable Members

        /// <summary>
        /// Type of objec that this table contains
        /// </summary>
        public Type RowType
        {
            get { return typeof(T); }
        }

        #endregion
    }
}
