using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common.Config.Fdfs
{
    public class Trackers : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Tracker();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Tracker)element).Host;
        }
    }
}
