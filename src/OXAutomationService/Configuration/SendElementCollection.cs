using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation.Configuration
{
    public class SendElementCollection : ConfigurationElementCollection, IEnumerable<SendElement>
    {
        private readonly List<SendElement> _elements;

        public SendElementCollection()
        {
            _elements = new List<SendElement>();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            var element = new SendElement();

            _elements.Add(element);

            return element;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return element.ElementInformation.LineNumber;
        }

        public new IEnumerator<SendElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }
}
