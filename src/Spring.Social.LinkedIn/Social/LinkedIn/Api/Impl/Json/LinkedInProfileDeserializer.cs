#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Globalization;

using Spring.Json;

namespace Spring.Social.LinkedIn.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for LinkedIn user's profile.
    /// </summary>
    /// <author>Bruno Baia</author>
    class LinkedInProfileDeserializer : IJsonDeserializer
    {
        public object Deserialize(JsonValue json, JsonMapper mapper)
        {
            return new LinkedInProfile()
            {
                ID = json.GetValue<string>("id"),
                FirstName = json.GetValue<string>("firstName"),
                LastName = json.GetValue<string>("lastName"),
                Headline = json.GetValue<string>("headline"),
                Industry = json.GetValue<string>("industry"),
                PictureUrl = json.GetValue<string>("pictureUrl"),
                Summary = json.GetValue<string>("summary"),
                PublicProfileUrl = json.GetValue<string>("publicProfileUrl")
                // SiteStandardProfileRequest
                // ApiStandardProfileRequest
            };
        }
    }
}