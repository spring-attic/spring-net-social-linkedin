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

using NUnit.Framework;
using Spring.Rest.Client.Testing;

using Spring.Http;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Unit tests for the GroupTemplate class.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
    [TestFixture]
    public class GroupTemplateTests : AbstractLinkedInOperationsTests
    {
        [Test]
        public void GetGroupMemberships()
        {
            mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people/~/group-memberships:(group:(id,name),membership-state,show-group-logo-in-profile,allow-messages-from-members,email-digest-frequency,email-announcements-from-managers,email-for-every-new-post)?format=json")
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("GroupMemberships"), responseHeaders);

            GroupMemberships memberships = linkedIn.GroupOperations.GetGroupMembershipsAsync().Result;

            Assert.AreEqual(10, memberships.Count);
            Assert.AreEqual(0, memberships.Start);
            Assert.AreEqual(30, memberships.Total);
            Assert.AreEqual(10, memberships.Memberships.Count);

            var s = memberships.Memberships[0];
            Assert.AreEqual(true, s.AllowMessagesFromMembers);
            Assert.AreEqual(false, s.EmailAnnouncementsFromManagers);
            Assert.AreEqual(EmailDigestFrequency.None, s.EmailDigestFrequency);
            Assert.AreEqual(MembershipState.Member, s.MembershipState);
            Assert.AreEqual(true, s.ShowGroupLogoInProfile);
            Assert.AreEqual(69286, s.Group.ID);
            Assert.AreEqual("Software Architect Network", s.Group.Name);
        }

        //TODO:
        //[Test]
        //public void GetGroupSuggestions()
        //{
        //}

        [Test]
        public void GetGroupDetails()
        {
            mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/groups/46964:(id,name,short-description,description,relation-to-viewer:(membership-state,available-actions),posts,counts-by-category,is-open-to-non-members,category,website-url,locale,location:(country,postal-code),allow-member-invites,site-group-url,small-logo-url,large-logo-url)?format=json")
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("Group"), responseHeaders);

            Group group = linkedIn.GroupOperations.GetGroupDetailsAsync(46964).Result;

            Assert.AreEqual(true, group.AllowMemberInvites);
            Assert.AreEqual(GroupCategory.Professional, group.Category);
            Assert.AreEqual(2, group.CountsByCategory.Count);

            Assert.AreEqual(PostCategory.Discussion, group.CountsByCategory[0].Category);
            Assert.AreEqual(11, group.CountsByCategory[0].Count);
            Assert.AreEqual(PostCategory.Job, group.CountsByCategory[1].Category);
            Assert.AreEqual(2, group.CountsByCategory[1].Count);

            Assert.AreEqual("This is a group for users of the Spring Framework and related projects (Roo, Batch, Integration, BlazeDS, Security, Web Flow etc) to meet and discuss things of common interest.", group.Description);
            Assert.AreEqual(46964, group.ID);
            Assert.AreEqual(true, group.IsOpenToNonMembers);
            Assert.AreEqual("http://media.linkedin.com/mpr/mpr/p/3/000/05d/2b8/0c75024.png", group.LargeLogoUrl);
            Assert.AreEqual("en_US", group.Locale);
            Assert.AreEqual("Spring Users", group.Name);
            Assert.AreEqual(10, group.Posts.Posts.Count);
            Assert.AreEqual(0, group.Posts.Start);
            Assert.AreEqual(10, group.Posts.Count);
            Assert.AreEqual(199, group.Posts.Total);

            AssertProfile(group.Posts.Posts[0].Creator,
                "0_Fb-UVig_",
                "Business Development Executive at HOSTINGINDIA.CO",
                "Mukesh",
                "K.",
                null,
                string.Empty);

            Assert.AreEqual("g-46964-S-88566811", group.Posts.Posts[0].ID);
            Assert.AreEqual("Tips on Choosing The Best Web Hosting Services", group.Posts.Posts[0].Title);
            Assert.AreEqual(PostType.Standard, group.Posts.Posts[0].Type);
            Assert.AreEqual(DateTime.Parse("2013-05-04 02:09:13.000"), group.Posts.Posts[0].CreationTimestamp);

            //TODO
            //Assert.AreEqual(3, group.RelationToViewer.AvailableActions.Count);
            //Assert.AreEqual(GroupAvailableAction.ADD_POST, group.RelationToViewer.AvailableActions[0]);
            //Assert.AreEqual(GroupAvailableAction.LEAVE, group.RelationToViewer.AvailableActions[1]);
            //Assert.AreEqual(GroupAvailableAction.VIEW_POSTS, group.RelationToViewer.AvailableActions[2]);
            //Assert.AreEqual(MembershipState.Member, group.RelationToViewer.MembershipState);

            Assert.AreEqual("This is a group that welcomes all users of the Spring platform, including Spring Framework, Roo, Batch, Integration, BlazeDS, Security, Web Flow etc.", group.ShortDescription);
            Assert.AreEqual("http://www.linkedin.com/groups?gid=46964&trk=api*a151944*s160233*", group.SiteGroupUrl);
            Assert.AreEqual("http://media.linkedin.com/mpr/mpr/p/2/000/05d/2b8/0cc68d3.png", group.SmallLogoUrl);
            Assert.AreEqual("http://www.springsource.org", group.WebsiteUrl);
        }
    }
}
