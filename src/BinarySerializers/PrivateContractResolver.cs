using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace BinarySerializers
{
    public class PrivateContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
            if (jsonProperty.Writable)
            {
                return jsonProperty;
            }

            PropertyInfo? propertyInfo = member as PropertyInfo;
            if (propertyInfo == null)
            {
                return jsonProperty;
            }

            bool writable = propertyInfo.GetSetMethod(nonPublic: true) != null;
            jsonProperty.Writable = writable;
            return jsonProperty;
        }
    }
}
