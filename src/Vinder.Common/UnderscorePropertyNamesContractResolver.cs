using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Vinder.Common
{
    public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
    {
        public UnderscorePropertyNamesContractResolver() : base()
        {
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, @"(\w)([A-Z])", "$1_$2").ToLower();
        }
    }
}
