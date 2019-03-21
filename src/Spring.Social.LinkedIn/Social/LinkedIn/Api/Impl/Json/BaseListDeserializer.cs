#region License

/*
 * Copyright 2002-2013 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System.Collections.Generic;

using Spring.Json;

namespace Spring.Social.LinkedIn.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for list used in the api. 
    /// </summary>
    /// <author>Bruno Baia</author>
    class BaseListDeserializer<T> : IJsonDeserializer
    {
        public object Deserialize(JsonValue value, JsonMapper mapper)
        {
            IList<T> list = new List<T>();
            if (value != null)
            {
                JsonValue usersValue = value.IsObject ? value.GetValue("values") : value;
                if (usersValue != null)
                {
                    foreach (JsonValue itemValue in usersValue.GetValues())
                    {
                        list.Add(mapper.Deserialize<T>(itemValue));
                    }
                }
            }
            return list;
        }
    }
}