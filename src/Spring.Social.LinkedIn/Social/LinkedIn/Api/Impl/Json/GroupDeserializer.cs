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

namespace Spring.Social.LinkedIn.Api.Impl.Json {
    /// <summary>
    /// JSON deserializer for group.
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
    class GroupDeserializer : IJsonDeserializer {
        public virtual object Deserialize(JsonValue json, JsonMapper mapper) {
            Group group = CreateGroup();

            group.AllowMemberInvites = json.GetValueOrDefault<bool>("allowMemberInvites");
            group.Category = DeserializeGroupCategory(json.GetValue("category"));
            group.CountsByCategory = DeserializeCountsByCategory(json.GetValue("countsByCategory"));
            group.Description = json.GetValueOrDefault<string>("description"); 
            group.ID = json.GetValue<int>("id");
            group.IsOpenToNonMembers = json.GetValueOrDefault<bool>("isOpenToNonMembers");
            group.LargeLogoUrl = json.GetValueOrDefault<string>("largeLogoUrl");
            group.Locale = json.GetValueOrDefault<string>("locale");
            group.Locale = json.GetValueOrDefault<string>("locale");
            group.Name = json.GetValueOrDefault<string>("name");
            group.Posts = mapper.Deserialize<GroupPosts>(json.GetValue("posts"));
            group.ShortDescription = json.GetValueOrDefault<string>("shortDescription");
            group.SiteGroupUrl = json.GetValueOrDefault<string>("siteGroupUrl");
            group.SmallLogoUrl = json.GetValueOrDefault<string>("smallLogoUrl");
            group.WebsiteUrl = json.GetValueOrDefault<string>("websiteUrl"); 

            return group;
        }

        private static GroupCategory DeserializeGroupCategory(JsonValue json) {
            if (json != null) {
                var code = json.GetValue<string>("code");
                switch (code.ToLowerInvariant()) {
                    case "alumni": return GroupCategory.Alumni;
                    case "conference": return GroupCategory.Conference;
                    case "corporate": return GroupCategory.Corporate;
                    case "network": return GroupCategory.Network;
                    case "other": return GroupCategory.Other;
                    case "philantropic": return GroupCategory.Philanthropic;
                    case "professional": return GroupCategory.Professional;
                }
            }
            return GroupCategory.Other;
        }

        public virtual IList<GroupCount> DeserializeCountsByCategory(JsonValue json) {
            IList<GroupCount> groupCounts = new List<GroupCount>();
            JsonValue valuesJson =  json.GetValue("values");
            if (valuesJson != null) {
                foreach (var itemJson in valuesJson.GetValues()) {
                    groupCounts.Add(new GroupCount()
                    {
                        Category = DeserializePostCategory(itemJson.GetValue("category")),
                        Count = itemJson.GetValue<int>("count")
                    });
                }
            }
            return groupCounts;
        }

        private static PostCategory DeserializePostCategory(JsonValue json) {
            if (json != null) {
                var code = json.GetValue<string>("code");
                switch (code.ToLowerInvariant()) {
                    case "discussion": return PostCategory.DISCUSSION;
                    case "job": return PostCategory.JOB;
                }
            }
            return PostCategory.DISCUSSION;
        }

        protected virtual Group CreateGroup() {
            return new Group();
        }
    }
}