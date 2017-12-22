using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text;

namespace Serialization
{
    [Serializable]
    public class Person
    {
        public string m_person_name;
        //[NonSerialized]
        [XmlIgnore]
        public string m_person_height;
        private int m_person_age;
        public int PersonAge
        {
            get { return m_person_age; }
            set { m_person_age = value; }
        }

        public void OutputPersonInfo()
        {
            StringBuilder str = new StringBuilder();
            FormatStr(str, new string[]{ "Person name is :", m_person_name });
            FormatStr(str, new string[] { "Person height is :", m_person_height });
            FormatStr(str, new string[] { "Person age is :", PersonAge.ToString() });
        }

        
        private void FormatStr(
            StringBuilder str,
            string[] contents
        ) {
            foreach(var content in contents){
                str.Append(content);
            }
            Console.WriteLine(str);
            str.Clear();
        }
    }
}
