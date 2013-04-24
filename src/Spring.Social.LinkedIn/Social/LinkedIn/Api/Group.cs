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

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Model class representing a group on LinkedIn
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Group
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public Group(int id, String name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        public Group()
        {
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
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
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is open to non members.
        /// </summary>
        public bool IsOpenToNonMembers { get; set; }

        /// <summary>
        /// Gets or sets the large logo URL.
        /// </summary>
        public String LargeLogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        public String Locale { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public String Name { get; set; }

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
        public String ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the site group URL.
        /// </summary>
        public String SiteGroupUrl { get; set; }

        /// <summary>
        /// Gets or sets the small logo URL.
        /// </summary>
        public String SmallLogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the website URL.
        /// </summary>
        public String WebsiteUrl { get; set; }
    }

    /// <summary>
    /// Group Count
    /// </summary>
    public class GroupCount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCount"/> class.
        /// </summary>
        public GroupCount() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCount"/> class.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="count">The count.</param>
        public GroupCount(PostCategory category, int count) {
            Category = category;
            Count = count;
        }

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
    /// 
    /// </summary>
    public class GroupPosts : SearchResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupPosts"/> class.
        /// </summary>
        public GroupPosts() : base(0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupPosts"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="start">The start.</param>
        /// <param name="total">The total.</param>
        public GroupPosts(int count, int start, int total) : base(count, start, total)
        {
        }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        public List<Post> Posts { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GroupRelation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupRelation"/> class.
        /// </summary>
        /// <param name="availableActions">The available actions.</param>
        /// <param name="membershipState">State of the membership.</param>
        public GroupRelation(List<GroupAvailableAction> availableActions, MembershipState membershipState)
        {
            AvailableActions = availableActions;
            MembershipState = membershipState;
        }

        /// <summary>
        /// Gets or sets the available actions.
        /// </summary>
        public List<GroupAvailableAction> AvailableActions { get; set; }

        /// <summary>
        /// Gets or sets the state of the membership.
        /// </summary>
        public MembershipState MembershipState { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public enum GroupCategory
    {
        /// <summary>
        /// The ALUMNI
        /// </summary>
        Alumni,
        /// <summary>
        /// The CORPORATE
        /// </summary>
        Corporate,
        /// <summary>
        /// The CONFERENCE
        /// </summary>
        Conference,
        /// <summary>
        /// The NETWORK
        /// </summary>
        Network,
        /// <summary>
        /// The PHILANTHROPIC
        /// </summary>
        Philanthropic,
        /// <summary>
        /// The PROFESSIONAL
        /// </summary>
        Professional,
        /// <summary>
        /// The OTHER
        /// </summary>
        Other
    }

    /// <summary>
    /// 
    /// </summary>
    public enum MembershipState
    {
        /// <summary>
        /// The blocked
        /// </summary>
        Blocked,
        /// <summary>
        /// The non member
        /// </summary>
        NonMember,
        /// <summary>
        /// The awaiting confirmation
        /// </summary>
        AwaitingConfirmation,
        /// <summary>
        /// The awaiting parent group confirmation
        /// </summary>
        AwaitingParentGroupConfirmation,
        /// <summary>
        /// The member
        /// </summary>
        Member,
        /// <summary>
        /// The moderator
        /// </summary>
        Moderator,
        /// <summary>
        /// The manager
        /// </summary>
        Manager,
        /// <summary>
        /// The owner
        /// </summary>
        Owner
    }

    /// <summary>
    /// 
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