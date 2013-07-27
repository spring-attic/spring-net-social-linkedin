#region License

/*
 * Copyright 2002-2013 the original author or authors.
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
            var post = CreatePost();

            post.ID = json.GetValue<string>("id");
            post.Creator = mapper.Deserialize<LinkedInProfile>(json.GetValue("creator"));
            post.Title = json.GetValueOrDefault<string>("title", String.Empty);
            post.Type = DeserializePostType(json.GetValue("type"));
            //TODO post.Attachment = DeserializeAttachment(json.GetValue("attachment")); 
            post.CreationTimestamp = DeserializeTimeStamp.Deserialize(json.GetValue("creationTimestamp"));
            post.Likes = mapper.Deserialize<IList<LinkedInProfile>>(json.GetValue("likes"));
            //TODO RelationToViewer = DeserializePostRelation(json.GetValue("relation-to-viewer"));
            post.Summary = json.GetValueOrDefault<string>("summary", String.Empty);

            return post;
        }

        protected virtual Post CreatePost()
        {
            return new Post();
        }

        private static PostType DeserializePostType(JsonValue json)
        {
            if (json != null)
            {
                var code = json.GetValue<string>("code");
                switch (code.ToLowerInvariant())
                {
                    case "standard": return PostType.Standard;
                    case "news": return PostType.News;
                }
            }
            return PostType.Standard;
        }
    }
}