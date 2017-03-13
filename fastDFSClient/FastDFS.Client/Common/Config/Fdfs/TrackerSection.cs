using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common.Config.Fdfs
{
    public class TrackerSection:ConfigurationSection
    {
        [ConfigurationProperty("trackers",IsDefaultCollection =true)]
        public Trackers Trackers { get { return (Trackers)base["trackers"]; } }
    }
}
