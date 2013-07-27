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

using System.Collections.Generic;

using Spring.Json;

namespace Spring.Social.LinkedIn.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for group memberships.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
    class GroupMembershipsDeserializer : PaginatedResultDeserializer
    {
        public override object Deserialize(JsonValue json, JsonMapper mapper)
        {
            GroupMemberships groupMemberships = (GroupMemberships)base.Deserialize(json, mapper);
            groupMemberships.Memberships = DeserializeMemberships(json.GetValue("values"));
            return groupMemberships;
        }

        protected override PaginatedResult CreatePaginatedResult()
        {
            return CreateGroupMemberships();
        }

        protected virtual GroupMemberships CreateGroupMemberships()
        {
            return new GroupMemberships();
        }

        private static IList<GroupSettings> DeserializeMemberships(JsonValue valuesJson)
        {
            IList<GroupSettings> groupSettings = new List<GroupSettings>();
            if (valuesJson != null)
            {
                foreach (var itemJson in valuesJson.GetValues())
                {
                    groupSettings.Add(new GroupSettings()
                    {
                        AllowMessagesFromMembers = itemJson.GetValueOrDefault<bool>("allowMessagesFromMembers"),
                        EmailAnnouncementsFromManagers = itemJson.GetValueOrDefault<bool>("emailAnnouncementsFromManagers"),
                        EmailDigestFrequency = DeserializeEmailDigestFrequency(itemJson.GetValue("emailDigestFrequency")),
                        EmailForEveryNewPost = itemJson.GetValueOrDefault<bool>("emailForEveryNewPost"),
                        Group = DeserializeGroup(itemJson.GetValue("group")),
                        MembershipState = DeserializeMembershipState(itemJson.GetValue("membershipState")),
                        ShowGroupLogoInProfile = itemJson.GetValueOrDefault<bool>("showGroupLogoInProfile")
                    });
                }
            }
            return groupSettings;
        }

        private static EmailDigestFrequency DeserializeEmailDigestFrequency(JsonValue json)
        {
            if (json != null)
            {
                var code = json.GetValue<string>("code");
                switch (code.ToLowerInvariant())
                {
                    case "none": return EmailDigestFrequency.None;
                    case "daily": return EmailDigestFrequency.Daily;
                    case "weekly": return EmailDigestFrequency.Weekly;
                }
            }
            return EmailDigestFrequency.None;
        }

        private static Group DeserializeGroup(JsonValue json)
        {
            var group = new Group();
            if (json != null)
            {
                group.ID = json.GetValueOrDefault<int>("id");
                group.Name = json.GetValueOrDefault<string>("name");
            }
            return group;
        }

        private static MembershipState DeserializeMembershipState(JsonValue json)
        {
            if (json != null)
            {
                var code = json.GetValueOrDefault<string>("code");
                switch (code.ToLowerInvariant())
                {
                    case "awaiting-confirmation": return MembershipState.AwaitingConfirmation;
                    case "awaiting-parent-group-confirmation": return MembershipState.AwaitingParentGroupConfirmation;
                    case "blocked": return MembershipState.Blocked;
                    case "manager": return MembershipState.Manager;
                    case "member": return MembershipState.Member;
                    case "moderator": return MembershipState.Moderator;
                    case "non-member": return MembershipState.NonMember;
                    case "owner": return MembershipState.Owner;
                }
            }
            return MembershipState.NonMember;
        }
    }
}