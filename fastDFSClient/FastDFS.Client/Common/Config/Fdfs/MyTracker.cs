using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace Common.Config.Fdfs
{
    public class MyTracker : ConfigurationElement
    {
        /// <summary>
        /// 配置后，遇到未知特性不会报错
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            return base.OnDeserializeUnrecognizedAttribute(name, value);
        }

        /// <summary>
        /// 遇到未知属性时不会报错
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            return base.OnDeserializeUnrecognizedElement(elementName, reader);
        }

        [ConfigurationProperty("Host",DefaultValue ="localhost",IsRequired =true)]
        public string Host { get { return this["Host"].ToString(); } }

        [ConfigurationProperty("Port",DefaultValue ="22122",IsRequired =true)]
        public int Port { get { return (int)this["Port"]; } }

        [ConfigurationProperty("Weight",DefaultValue ="1",IsRequired =false)]
        public int Weight { get { return (int)this["Weight"]; } }
    }
}
