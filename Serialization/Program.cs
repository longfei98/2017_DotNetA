using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

/**************************************************************************************************

Copyright (C) 2017 company. All rights reserved.

Zhaolongfei Confidential - Internal Use Only

Module: Serialization

 * ///////////////////////////////////////////
 * 1. BinaryFormatter, includes Memory Stream and File Stream
 * 2. SoapFormatter, the file extension should be .xml
 * 3. XmlSerializer, NoSerialize attribute can not be used, instead of XmlIgnore
 * //////////////////////////////////////////

**************************************************************************************************/

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. BinaryFormatter
            //SerializeWithBinaryFormatter();

            // 2. SoapFormatter
            //SerializeWithSoapFormatter();

            // 3. XmlSerializer
            SerializeWithXmlSerializer();
        }

        ////////////////////////////////////////////
        // BinaryFormatter
        ////////////////////////////////////////////
        #region BinaryFormatter
        // ---------------------------------------------------------------------------

        private static void SerializeWithBinaryFormatter( )
        {
            Person person = new Person();
            person.m_person_name = "zhaolongfei";
            person.m_person_height = "175";
            person.PersonAge = 29;

            ////////////////////////////////////////////
            //Stream stream = SerializeMemStream(person);
            //// reset
            //stream.Position = 0;
            //person = null;
            //person = DeserializeMemStream(stream);
            //person.OutputPersonInfo();
            //Console.Read();

            ///////////////////////////////////////////
            Stream stream = SerializeFileStream(person);
            // reset
            stream.Position = 0;
            person = null;
            person = DeserializeFileStream(stream);
            person.OutputPersonInfo();
            Console.Read();
        }

        #region Memory stream
        // ---------------------------------------------------------------------------

        private static MemoryStream SerializeMemStream(Person person)
        {
            MemoryStream stream = new MemoryStream();
            // construct binary formatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, person);
            return stream;
        }

        // ---------------------------------------------------------------------------

        private static Person DeserializeMemStream(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //return (Person)binaryFormatter.Deserialize(stream);
            return binaryFormatter.Deserialize(stream) as Person;
        }
        #endregion

        #region File Stream
        // ---------------------------------------------------------------------------
        private static FileStream SerializeFileStream(Person person)
        {
            FileStream fileStream = new FileStream("c:\\temp.dat", FileMode.Create);
            // construct binary formatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, person);
            return fileStream;
        }

        // ---------------------------------------------------------------------------

        private static Person DeserializeFileStream(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //return (Person)binaryFormatter.Deserialize(stream);
            return binaryFormatter.Deserialize(stream) as Person;
        }
        #endregion

        #endregion

        ////////////////////////////////////////////
        // SoapFormatter
        ////////////////////////////////////////////
        #region SoapFormatter
        // ---------------------------------------------------------------------------

        private static void SerializeWithSoapFormatter( )
        {
            Person person = new Person();
            person.m_person_name = "zhaolongfei";
            person.m_person_height = "175";
            person.PersonAge = 29;

            ////////////////////////////////////////////
            //Stream stream = SerializeSoapMemStream(person);
            //// reset
            //stream.Position = 0;
            //person = null;
            //person = DeserializeSoapMemStream(stream);
            //person.OutputPersonInfo();
            //Console.Read();

            ///////////////////////////////////////////
            Stream stream = SerializeSoapFileStream(person);
            // reset
            stream.Position = 0;
            person = null;
            person = DeserializeSoapFileStream(stream);
            person.OutputPersonInfo();
            Console.Read();
        }

        #region Memory stream
        // ---------------------------------------------------------------------------

        private static MemoryStream SerializeSoapMemStream(Person person)
        {
            MemoryStream stream = new MemoryStream();
            // construct binary formatter
            SoapFormatter soapFormatter = new SoapFormatter();
            soapFormatter.Serialize(stream, person);
            return stream;
        }

        // ---------------------------------------------------------------------------

        private static Person DeserializeSoapMemStream(Stream stream)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            //return (Person)binaryFormatter.Deserialize(stream);
            return soapFormatter.Deserialize(stream) as Person;
        }
        #endregion

        #region File Stream
        // ---------------------------------------------------------------------------
        private static FileStream SerializeSoapFileStream(Person person)
        {
            FileStream fileStream = new FileStream("c:\\temp.xml", FileMode.Create);
            // construct binary formatter
            SoapFormatter soapFormatter = new SoapFormatter();
            soapFormatter.Serialize(fileStream, person);
            return fileStream;
        }

        // ---------------------------------------------------------------------------

        private static Person DeserializeSoapFileStream(Stream stream)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            //return (Person)binaryFormatter.Deserialize(stream);
            return soapFormatter.Deserialize(stream) as Person;
        }
        #endregion
        #endregion

        ////////////////////////////////////////////
        // XmlSerializer
        ////////////////////////////////////////////
        #region XmlSerializer
        // ---------------------------------------------------------------------------

        private static void SerializeWithXmlSerializer()
        {
            Person person = new Person();
            person.m_person_name = "zhaolongfei";
            person.m_person_height = "175";
            person.PersonAge = 29;

            XMLSerialize(person);
            XMLDeserialize();
            Console.Read();
        }

        // ---------------------------------------------------------------------------

        public static void XMLSerialize(Person person)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            Stream stream = new FileStream("c:\\temp1.xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            xs.Serialize(stream, person);
            stream.Close();
        }

        // ---------------------------------------------------------------------------

        public static void XMLDeserialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            Stream stream = new FileStream("C:\\temp1.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Person person = xs.Deserialize(stream) as Person;
            person.OutputPersonInfo();
            stream.Close();
        }
        #endregion
    }
}
