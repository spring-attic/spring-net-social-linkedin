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

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Represents LinkedIn profile permissions.
    /// </summary>
    [Flags]
    public enum Permissions : int
    {
        /// <summary>
        /// Not specified, same as 'r_basicprofile'
        /// </summary>
        none = 0,

        /// <summary>
        /// Your Profile Overview (Name, photo, headline, and current positions)
        /// </summary>
        r_basicprofile = 1,

        /// <summary>
        /// Your Full Profile (Full profile including experience, education, skills, and recommendations)
        /// </summary>
        r_fullprofile = 2,

        /// <summary>
        /// Your Email Address (The primary email address you use for your LinkedIn account)
        /// </summary>
        r_emailaddress = 4,

        /// <summary>
        /// Your Connections (Your 1st and 2nd degree connections)
        /// </summary>
        r_network = 8,

        /// <summary>
        /// Your Contact Info (Address, phone number, and bound accounts)
        /// </summary>
        r_contactinfo = 16,

        /// <summary>
        /// Network Updates (Retrieve and post updates to LinkedIn as you)
        /// </summary>
        rw_nus = 32,

        /// <summary>
        /// Group Discussions (Retrieve and post group discussions as you)
        /// </summary>
        rw_groups = 64,

        /// <summary>
        /// Invitations and Messages (Send messages and invitations to connect as you)
        /// </summary>
        w_messages = 128,

        /// <summary>
        /// All permissions
        /// </summary>
        all = r_basicprofile | r_fullprofile | r_emailaddress | r_network | r_contactinfo | rw_nus | rw_groups | w_messages
    }

    /// <summary>
    /// Helper class to generate LinkedIn profile url.
    /// </summary>
    public static class ProfileUrl
    {
        /// <summary>
        /// Default profile url prefix.
        /// </summary>
        private const string BaseUrl = "people/{id}:";

        /// <summary>
        /// Default profile url postfix.
        /// </summary>
        private const string BaseFormat = "format=json";

        /// <summary>
        /// Profile fields list.
        /// </summary>
        public static List<string> ProfileFields = new List<string>
        {
            "id",
            "first-name",
            "last-name",
            "maiden-name",
            "formatted-name",
            "phonetic-first-name",
            "phonetic-last-name",
            "formatted-phonetic-name",
            "headline",
            "location",
            "industry",
            "distance",
            "relation-to-viewer",
            "current-status",
            "current-status-timestamp",
            "current-share",
            "num-connections",
            "num-connections-capped",
            "summary",
            "specialties",
            "positions",
            "picture-url",
            "site-standard-profile-request",
            "api-standard-profile-request",
            "public-profile-url",
            "email-address",
            "last-modified-timestamp",
            "proposal-comments",
            "associations",
            "interests",
            "publications",
            "patents",
            "languages",
            "skills",
            "certifications",
            "educations",
            "courses",
            "volunteer",
            "three-current-positions",
            "three-past-positions",
            "num-recommenders",
            "recommendations-received",
            "mfeed-rss-url",
            "following",
            "job-bookmarks",
            "suggestions",
            "date-of-birth",
            "member-url-resources",
            "related-profile-views",
            "phone-numbers",
            "bound-account-types",
            "im-accounts",
            "main-address",
            "twitter-accounts",
            "primary-twitter-account",
            "connections",
            "group-memberships",
            "network"
        };

        /// <summary>
        /// Decide if field is allowed to be included in the profile request under assumed permissions.
        /// </summary>
        /// <param name="index">Profile field index.</param>
        /// <param name="permissions">Permissions taken by granted.</param>
        /// <returns>True if the field is allowed; false otherwise.</returns>
        private static bool AllowedField(int index, Permissions permissions)
        {
            bool result = false;
            if (!result && ((permissions & Permissions.r_basicprofile) == Permissions.r_basicprofile))
            {
                result = (index >= 0) && (index < 25);
            }
            if (!result && ((permissions & Permissions.r_emailaddress) == Permissions.r_emailaddress))
            {
                result = (index == 25);
            }
            if (!result && ((permissions & Permissions.r_fullprofile) == Permissions.r_fullprofile))
            {
                result = (index >= 26) && (index < 49);
            }
            if (!result && ((permissions & Permissions.r_contactinfo) == Permissions.r_contactinfo))
            {
                result = (index >= 49) && (index < 55);
            }
            if (!result && ((permissions & Permissions.r_network) == Permissions.r_network))
            {
                result = (index == 55);
            }
            if (!result && ((permissions & Permissions.rw_groups) == Permissions.rw_groups))
            {
                result = (index == 56);
            }
            if (!result && ((permissions & Permissions.rw_nus) == Permissions.rw_nus))
            {
                result = (index == 57);
            }
            return result;
        }

        /// <summary>
        /// Finds the pre and post-fixed profile request string composed by the fields list allowed under assumed permissions.
        /// </summary>
        /// <param name="prefix">Prefix for profile field list.</param>
        /// <param name="postfix">Postfix for profile field list.</param>
        /// <param name="fieldIndexes">Profile field indexes.</param>
        /// <param name="permisions">Permissions taken by granted.</param>
        /// <returns>Profile request string.</returns>
        public static string Get(string prefix, string postfix, List<int> fieldIndexes, Permissions permisions)
        {
            string fieldSet = string.Empty;
            if (fieldIndexes != null)
            {
                var obsoleteIndexes = new List<int> { 13, 14 };
                for (int index = 0; index < fieldIndexes.Count; index++)
                {
                    if ((fieldIndexes[index] >= 0) && (fieldIndexes[index] < ProfileFields.Count) &&
                        (fieldIndexes.IndexOf(fieldIndexes[index], 0, index) == -1) &&
                        !obsoleteIndexes.Contains(fieldIndexes[index]) &&
                        (ProfileFields[fieldIndexes[index]][0] != '-') &&
                        AllowedField(fieldIndexes[index], permisions))
                    {
                        fieldSet += !string.IsNullOrEmpty(fieldSet) ? "," : string.Empty;
                        fieldSet += !string.IsNullOrEmpty(ProfileFields[fieldIndexes[index]]) ? ProfileFields[fieldIndexes[index]] : string.Empty;
                    }
                }
            }
            return string.IsNullOrEmpty(fieldSet) ? string.Empty : ((!string.IsNullOrEmpty(prefix) ? prefix : string.Empty) +
                                                                    ("(" + fieldSet + ")") +
                                                                    (!string.IsNullOrEmpty(postfix) ? "?" : string.Empty) +
                                                                    (!string.IsNullOrEmpty(postfix) ? postfix : string.Empty));
        }

        /// <summary>
        /// Finds the default pre and post-fixed profile request string composed by the fields list.
        /// </summary>
        /// <param name="fieldIndexes">Profile field indexes.</param>
        /// <returns>Profile request string.</returns>
        public static string Get(List<int> fieldIndexes)
        {
            return Get(BaseUrl, BaseFormat, fieldIndexes, Permissions.all);
        }

        /// <summary>
        /// Basic profile request string.
        /// </summary>
        public static string Basic
        {
            get
            {
                var indexes = new List<int> { 0, 1, 2, 8, 10, 24, 21, 18, 22, 23 };
                return Get(indexes);
            }
        }

        /// <summary>
        /// Full profile request string.
        /// </summary>
        public static string Full
        {
            get
            {
                var indexes = new List<int>();
                for (int index = 0; index < ProfileFields.Count; index++)
                {
                    indexes.Add(index);
                }
                return Get(indexes);
            }
        }
    }
}
