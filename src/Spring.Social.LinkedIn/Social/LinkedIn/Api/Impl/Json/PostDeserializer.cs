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
using System.Collections.Generic;
using System.Globalization;

using Spring.Json;

namespace Spring.Social.LinkedIn.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for LinkedIn user's profile.
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
    class PostDeserializer : IJsonDeserializer
    {
        
        public virtual object Deserialize(JsonValue json, JsonMapper mapper)
        {
            var post = new Post{
                Creator = mapper.Deserialize<LinkedInProfile>(json.GetValue("creator")), 
                ID = json.GetValue<string>("id"), 
                Title = json.GetValue<string>("title"), 
                Type = DeserializePostType(json.GetValue("type")),
                //TODO Attachment = DeserializeAttachment(json.GetValue("attachment")), 
                //TODO CreationTimestamp = json.GetValue<DateTime>("creationtimestamp"), 
                Likes = mapper.Deserialize<IList<LinkedInProfile>>(json.GetValue("likes")),
                //TODO RelationToViewer = DeserializePostRelation(json.GetValue("relation-to-viewer")),
                Summary = json.GetValueOrDefault<string>("summary") 
            };

            return post;
        }

        private static PostType DeserializePostType(JsonValue json) {
            if (json != null) {
                var code = json.GetValue<string>("code");
                switch (code.ToLowerInvariant()) {
                    case "standard": return PostType.STANDARD;
                    case "news": return PostType.NEWS;
                }
            }
            return PostType.STANDARD;
        }
    }
}