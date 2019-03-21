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
    /// Represents a LinkedIn group.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Group
    {
        /// <summary>
        /// Gets or sets the group ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether group allows member invites.
        /// </summary>
        public bool AllowMemberInvites { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public GroupCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the counts by category.
        /// </summary>
        public IList<GroupCount> CountsByCategory { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is open to non members.
        /// </summary>
        public bool IsOpenToNonMembers { get; set; }

        /// <summary>
        /// Gets or sets the large logo URL.
        /// </summary>
        public string LargeLogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        public GroupPosts Posts { get; set; }

        /// <summary>
        /// Gets or sets the relation to viewer.
        /// </summary>
        public GroupRelation RelationToViewer { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the site group URL.
        /// </summary>
        public string SiteGroupUrl { get; set; }

        /// <summary>
        /// Gets or sets the small logo URL.
        /// </summary>
        public string SmallLogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the website URL.
        /// </summary>
        public string WebsiteUrl { get; set; }
    }

    /// <summary>
    /// Represents the number of LinkedIn groups by category.
    /// </summary>
    public class GroupCount
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public PostCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }
    }

    /// <summary>
    /// Represents LinkedIn posts for a group.
    /// </summary>
    public class GroupPosts : PaginatedResult
    {
        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        public IList<Post> Posts { get; set; }
    }

    /// <summary>
    /// Represents a LinkedIn group relation to viewer.
    /// </summary>
    public class GroupRelation
    {
        /// <summary>
        /// Gets or sets the available actions.
        /// </summary>
        public IList<GroupAvailableAction> AvailableActions { get; set; }

        /// <summary>
        /// Gets or sets the state of the membership.
        /// </summary>
        public MembershipState MembershipState { get; set; }
    }

    /// <summary>
    /// Represents LinkedIn categories for a group.
    /// </summary>
    public enum GroupCategory
    {
        /// <summary>
        /// Alumni
        /// </summary>
        Alumni,

        /// <summary>
        /// Corporate
        /// </summary>
        Corporate,

        /// <summary>
        /// Conference
        /// </summary>
        Conference,

        /// <summary>
        /// Network
        /// </summary>
        Network,

        /// <summary>
        /// Philanthropic
        /// </summary>
        Philanthropic,

        /// <summary>
        /// Professional
        /// </summary>
        Professional,

        /// <summary>
        /// Other
        /// </summary>
        Other
    }

    /// <summary>
    /// Represents LinkedIn states for a membership.
    /// </summary>
    public enum MembershipState
    {
        /// <summary>
        /// Blocked
        /// </summary>
        Blocked,

        /// <summary>
        /// Non member
        /// </summary>
        NonMember,

        /// <summary>
        /// Awaiting confirmation
        /// </summary>
        AwaitingConfirmation,

        /// <summary>
        /// Awaiting parent group confirmation
        /// </summary>
        AwaitingParentGroupConfirmation,

        /// <summary>
        /// Member
        /// </summary>
        Member,

        /// <summary>
        /// Moderator
        /// </summary>
        Moderator,

        /// <summary>
        /// Manager
        /// </summary>
        Manager,

        /// <summary>
        /// Owner
        /// </summary>
        Owner
    }

    /// <summary>
    /// Represents LinkedIn available actions for a group.
    /// </summary>
    public enum GroupAvailableAction
    {
        /// <summary>
        /// The AD d_ POST
        /// </summary>
        ADD_POST,

        /// <summary>
        /// The LEAVE
        /// </summary>
        LEAVE,

        /// <summary>
        /// The VIE w_ POSTS
        /// </summary>
        VIEW_POSTS
    }
}