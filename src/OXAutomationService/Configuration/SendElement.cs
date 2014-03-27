using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation.Configuration
{
    public class SendElement : ConfigurationElement
    {
        // Create a "message" attribute.
        [ConfigurationProperty("message", IsRequired = false)]
        public string Message
        {
            get { return (string)this["message"]; }
            set { this["message"] = value; }
        }

        // Create a "lparam" attribute.
        [ConfigurationProperty("lparam", IsRequired = false)]
        public string LParam
        {
            get { return (string)this["lparam"]; }
            set { this["lparam"] = value; }
        }

        // Create a "wparam" attribute.
        [ConfigurationProperty("wparam", IsRequired = false)]
        public string WParam
        {
            get { return (string)this["wparam"]; }
            set { this["wparam"] = value; }
        }

        // Create a "sleep" attribute.
        [ConfigurationProperty("sleep", IsRequired = false)]
        public int Sleep
        {
            get { return (int)this["sleep"]; }
            set { this["sleep"] = value; }
        }

        // Create a "step" attribute.
        [ConfigurationProperty("step", IsRequired = false)]
        public int Step
        {
            get { return (int)this["step"]; }
            set { this["step"] = value; }
        }

        // Create a "alt" attribute.
        [ConfigurationProperty("alt", IsRequired = false)]
        public bool Alt
        {
            get { return (bool)this["alt"]; }
            set { this["alt"] = value; }
        }

        // Create a "control" attribute.
        [ConfigurationProperty("control", IsRequired = false)]
        public bool Control
        {
            get { return (bool)this["control"]; }
            set { this["control"] = value; }
        }
    }
}
