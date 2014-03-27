using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation.Configuration
{
    public class TaskSection : ConfigurationSection
    {
        // Create a "name" attribute.
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        // Create a "startTime" attribute.
        [ConfigurationProperty("startTime", IsRequired = true)]
        public string StartTime
        {
            get { return (string)this["startTime"]; }
            set { this["startTime"] = value; }
        }

        // Create a "arguments" attribute.
        [ConfigurationProperty("arguments", IsRequired = false)]
        public string Arguments
        {
            get { return (string)this["arguments"]; }
            set { this["arguments"] = value; }
        }

        // Create a "process" attribute.
        [ConfigurationProperty("process", IsRequired = true)]
        public string Process
        {
            get { return (string)this["process"]; }
            set { this["process"] = value; }
        }

        // Create a "restart" attribute.
        [ConfigurationProperty("restart", IsRequired = false)]
        public string Restart
        {
            get { return (string)this["restart"]; }
            set { this["restart"] = value; }
        }

        // Create a "period" attribute.
        [ConfigurationProperty("period", IsRequired = false)]
        public string Period
        {
            get { return (string)this["period"]; }
            set { this["period"] = value; }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(SendElementCollection), AddItemName = "send")]
        public SendElementCollection Elements
        {
            get { return (SendElementCollection)this[""]; }
        }
    }
}
