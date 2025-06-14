using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DeserializeWithPrivateSetter
{
    public class PrivateSetterContracResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);

            if (!prop.Writable)
            {
                var property = member as PropertyInfo;
                if (property != null)
                {
                    // Check if the setter is non-public but exists
                    var setter = property.GetSetMethod(true);
                    if (setter != null)
                    {
                        prop.Writable = true;
                    }
                }
            }

            return prop;
        }
    }
}
