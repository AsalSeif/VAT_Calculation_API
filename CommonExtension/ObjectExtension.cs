using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CommonExtension
{
    public static class ObjectExtension
    {
        class WritablePropertiesOnlyResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
                return props.Where(p => p.Writable).ToList();
            }
        }
        public static string ToJson(this object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new WritablePropertiesOnlyResolver(),
                //  PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None

            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        }
    }
}
