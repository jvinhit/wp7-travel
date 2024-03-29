// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.Generic;

namespace AccessingWP7Devices.Assets.Serialization
{
    public static class BinaryReaderExtensions
    {
        public static T ReadGeneric<T>(this BinaryReader reader) where T : ISerializable, new()
        {
            if (reader.ReadBoolean())
            {
                T result = new T();
                result.Deserialize(reader);
                return result;
            }
            return default(T);
        }

        public static List<string> ReadList(this BinaryReader reader)
        {
            int count = reader.ReadInt32();
            if (count > 0)
            {
                List<string> list = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(reader.ReadString());
                }
                return list;
            }

            return null;
        }

        public static List<T> ReadList<T>(this BinaryReader reader) where T : ISerializable, new()
        {
            int count = reader.ReadInt32();
            if (count > 0)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < count; i++)
                {
                    T item = new T();
                    item.Deserialize(reader);
                    list.Add(item);
                }
                return list;
            }

            return null;
        }

        public static DateTime ReadDateTime(this BinaryReader reader)
        {
            var int64 = reader.ReadInt64();
            return new DateTime(int64);
        }
    }
}