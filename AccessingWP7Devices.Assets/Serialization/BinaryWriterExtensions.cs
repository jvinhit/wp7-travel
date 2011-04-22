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
    public static class BinaryWriterExtensions
    {
        public static void WriteList<T>(this BinaryWriter writer, List<T> list) where T : ISerializable
        {
            if (list != null)
            {
                writer.Write(list.Count);
                foreach (T item in list)
                {
                    item.Serialize(writer);
                }
            }
            else
            {
                writer.Write(0);
            }
        }

        public static void WriteList(this BinaryWriter writer, List<string> list)
        {
            if (list != null)
            {
                writer.Write(list.Count);
                foreach (string item in list)
                {
                    writer.Write(item);
                }
            }
            else
            {
                writer.Write(0);
            }
        }

        public static void Write<T>(this BinaryWriter writer, T value) where T : ISerializable
        {
            if (value != null)
            {
                writer.Write(true);
                value.Serialize(writer);
            }
            else
            {
                writer.Write(false);
            }
        }

        public static void Write(this BinaryWriter writer, DateTime value)
        {
            writer.Write(value.Ticks);
        }

        public static void WriteString(this BinaryWriter writer, string value)
        {
            writer.Write(value ?? string.Empty);
        }
    }
}