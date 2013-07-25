#region
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

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Model class representing group settings on LinkedIn
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class GroupSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSettings"/> class.
        /// </summary>
        /// <param name="allowMessagesFromMembers">if set to <c>true</c> [allow messages from members].</param>
        /// <param name="emailAnnouncementsFromManagers">if set to <c>true</c> [email announcements from managers].</param>
        /// <param name="emailDigestFrequency">The email digest frequency.</param>
        /// <param name="emailForEveryNewPost">if set to <c>true</c> [email for every new post].</param>
        /// <param name="group">The group.</param>
        /// <param name="membershipState">State of the membership.</param>
        /// <param name="showGroupLogoInProfile">if set to <c>true</c> [show group logo in profile].</param>
        public GroupSettings(bool allowMessagesFromMembers,
                             bool emailAnnouncementsFromManagers,
                             EmailDigestFrequency emailDigestFrequency, bool emailForEveryNewPost,
                             Group group, MembershipState membershipState, bool showGroupLogoInProfile)
        {
            this.AllowMessagesFromMembers = allowMessagesFromMembers;
            this.EmailAnnouncementsFromManagers = emailAnnouncementsFromManagers;
            this.EmailDigestFrequency = emailDigestFrequency;
            this.EmailForEveryNewPost = emailForEveryNewPost;
            this.Group = group;
            this.MembershipState = membershipState;
            this.ShowGroupLogoInProfile = showGroupLogoInProfile;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSettings"/> class.
        /// </summary>
        public GroupSettings() {
        }

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
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show group logo in profile]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowGroupLogoInProfile { get; set; }
    }

    public enum EmailDigestFrequency {
        None,
		Daily,
		Weekely
	}

}
