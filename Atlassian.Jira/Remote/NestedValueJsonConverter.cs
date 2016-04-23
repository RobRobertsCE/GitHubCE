﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlassian.Jira.Remote
{
    public class NestedValueJsonConverter : JsonConverter
    {
        private readonly string _innerProperty;

        public NestedValueJsonConverter(string innerProperty)
        {
            this._innerProperty = innerProperty;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var outerObject = new JObject(new JProperty(this._innerProperty, value));
            outerObject.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var outerObject = JObject.Load(reader);
            return Convert.ChangeType(outerObject[this._innerProperty], objectType);
        }
    }
}
