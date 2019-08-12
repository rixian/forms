// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// JsonConverter that overrides the default Dictionary serializer with a StringComparer.
    /// Only works with dictionaries with a string key.
    /// </summary>
    /// <typeparam name="T">The value type of the dictionary.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public class DictionaryConverter<T> : JsonConverter
#pragma warning restore SA1649 // File name should match first type name
    {
        private static readonly Type DictionaryType = typeof(IDictionary<,>);
        private static readonly Type ReadOnlyDictionaryType = typeof(IReadOnlyDictionary<,>);
        private readonly StringComparer stringComparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryConverter{T}"/> class.
        /// </summary>
        public DictionaryConverter()
            : this(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryConverter{T}"/> class.
        /// </summary>
        /// <param name="stringComparer">The StringComparer to use for the Dictionary.</param>
        public DictionaryConverter(StringComparer stringComparer)
        {
            this.stringComparer = stringComparer;
        }

        /// <inheritdoc/>
        public override bool CanWrite => false;

        /// <inheritdoc/>
        public override bool CanRead => true;

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader is null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var jsonObject = JObject.Load(reader);
            Dictionary<string, T> originalDictionary = jsonObject.ToObject<Dictionary<string, T>>();
            return originalDictionary == null ? null : new Dictionary<string, T>(originalDictionary, this.stringComparer);
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            if (objectType is null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }

            if (IsDictionaryType(objectType))
            {
                return true;
            }

            return objectType.GetInterfaces().Any(t => IsDictionaryType(t));
        }

        private static bool IsDictionaryType(Type objectType)
        {
            if (objectType.IsGenericType)
            {
                Type genericType = objectType.GetGenericTypeDefinition();
                if (genericType == DictionaryType || genericType == ReadOnlyDictionaryType)
                {
                    Type[] genericArgs = objectType.GetGenericArguments();
                    if (genericArgs[0] == typeof(string) && genericArgs[1] == typeof(T))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
