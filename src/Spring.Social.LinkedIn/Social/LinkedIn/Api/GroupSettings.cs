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

using System;
using System.Collections.Generic;

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Represents LinkedIn group settings.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class GroupSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether group allows messages from members.
        /// </summary>
        public bool AllowMessagesFromMembers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether group allows email announcements from managers.
        /// </summary>
        public bool EmailAnnouncementsFromManagers { get; set; }

        /// <summary>
        /// Gets or sets the email digest frequency.
        /// </summary>
        public EmailDigestFrequency EmailDigestFrequency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [email for every new post].
        /// </summary>
        public bool EmailForEveryNewPost { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the state of the membership.
        /// </summary>
        public MembershipState MembershipState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether group shows group logo in profile.
        /// <para/>
        /// <c>true</c> if [show group logo in profile]; otherwise, <c>false</c>.
        /// </summary>
        public bool ShowGroupLogoInProfile { get; set; }
    }

    /// <summary>
    /// Represents LinkedIn email digest frequencies.
    /// </summary>
    public enum EmailDigestFrequency
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Daily
        /// </summary>
        Daily,

        /// <summary>
        /// Weekly
        /// </summary>
        Weekly
    }
}
