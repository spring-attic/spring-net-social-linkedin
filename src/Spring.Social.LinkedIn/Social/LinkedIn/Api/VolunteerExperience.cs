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

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Represents an course details for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class VolunteerExperience
    {
        /// <summary>
        /// Gets or sets the a unique identifier for this member's volunteer entries
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A string indicating the role the member has performed as a volunteer
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// the name of an organization the member has volunteered with
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// A string describing causes the member has listed
        /// </summary>
        public string CauseName { get; set; }
    }
}
