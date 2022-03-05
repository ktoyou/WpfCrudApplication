using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        ResourceManager _manager;
        private readonly string _resourceKey;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _manager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string description = _manager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(description) ? $"[[{_resourceKey}]]" : description;
            }
        }
    }
}
