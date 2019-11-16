﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickTypeCandy;
//
//    var candy = Candy.FromJson(jsonString);

namespace QuickTypeCandy
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Candy
    {
        [JsonProperty("fdcId")]
        public long FdcId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dataType")]
        public DataType DataType { get; set; }

        [JsonProperty("ndbNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? NdbNumber { get; set; }

        [JsonProperty("publishedDate")]
        public DateTimeOffset PublishedDate { get; set; }

        [JsonProperty("allHighlightFields")]
        public string AllHighlightFields { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("additionalDescriptions", NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalDescriptions { get; set; }

        [JsonProperty("foodCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FoodCode { get; set; }

        [JsonProperty("commonNames", NullValueHandling = NullValueHandling.Ignore)]
        public string CommonNames { get; set; }
    }

    public enum DataType { SrLegacy, SurveyFndds };

    public partial class Candy
    {
        public static Candy[] FromJson(string json) => JsonConvert.DeserializeObject<Candy[]>(json, QuickTypeCandy.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Candy[] self) => JsonConvert.SerializeObject(self, QuickTypeCandy.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DataTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DataTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DataType) || t == typeof(DataType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "SR Legacy":
                    return DataType.SrLegacy;
                case "Survey (FNDDS)":
                    return DataType.SurveyFndds;
            }
            throw new Exception("Cannot unmarshal type DataType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DataType)untypedValue;
            switch (value)
            {
                case DataType.SrLegacy:
                    serializer.Serialize(writer, "SR Legacy");
                    return;
                case DataType.SurveyFndds:
                    serializer.Serialize(writer, "Survey (FNDDS)");
                    return;
            }
            throw new Exception("Cannot marshal type DataType");
        }

        public static readonly DataTypeConverter Singleton = new DataTypeConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
