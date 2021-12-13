﻿using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassJsonSerializerTest();
        }

        #region json序列化
        static void ClassJsonSerializerTest()
        {
            var stu = new Student { Id = 1, };
            string json = JsonSerializer.Serialize(stu);
            Console.WriteLine(json);

            var stu2 = JsonSerializer.Deserialize<Student>(json);
            Console.WriteLine(stu.Equals(stu2));
        }

        static void AnonymouseJsonSerializerTest()
        {
            var a = new { X = 1, Y = "a" };
            string json = JsonSerializer.Serialize(a);
            var b = JsonSerializer.Deserialize<object>(json);
            Console.WriteLine(a.Equals(b));
        }
        #endregion

        #region xml序列化
        static void ClassXmlSerializerTest()
        {
            var stu = new Student { Id = 1,Name="张三" };
            Console.WriteLine(ToXml(stu));
        }

        static void AnonymouseXmlSerializerTest()
        {
            var a = new { X = 1, Y = "a" };
            Console.WriteLine(ToXml(a));
        }

        #endregion


        /// <summary>
        /// 对象转换为XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string ToXml<T>(T obj)
        {
            using (StringWriter sw = new())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }

    }
}
