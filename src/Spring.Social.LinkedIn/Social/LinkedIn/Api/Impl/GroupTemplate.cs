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
#if NET_4_0 || SILVERLIGHT_5
using System.Threading.Tasks;
#endif
#if SILVERLIGHT
using Spring.Collections.Specialized;
#else
using System.Collections.Specialized;
#endif

using Spring.Http;
using Spring.Rest.Client;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="IGroupOperations"/>, providing a binding to LinkedIn's groups-oriented REST resources.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
    class GroupTemplate : AbstractLinkedInOperations, IGroupOperations
    {
        private const string GroupDetailsUrl = "groups/{groupId}:(id,name,short-description,description,relation-to-viewer:(membership-state,available-actions),posts,counts-by-category,is-open-to-non-members,category,website-url,locale,location:(country,postal-code),allow-member-invites,site-group-url,small-logo-url,large-logo-url)?format=json";
        private const string GroupMembershipsUrl = "people/~/group-memberships:(group:(id,name),membership-state,show-group-logo-in-profile,allow-messages-from-members,email-digest-frequency,email-announcements-from-managers,email-for-every-new-post)?format=json";
        private const string GroupPostsUrl = "groups/{groupId}/posts:(id,creation-timestamp,title,summary,creator:(id,first-name,last-name,picture-url,headline),likes,attachment:(image-url,content-domain,content-url,title,summary),relation-to-viewer)?order=recency&format=json";
        private const string GroupPostCommentsUrl = "posts/{post-id}/comments:(creator:(first-name,last-name,picture-url),creation-timestamp,id,text)?format=json";

        private readonly RestTemplate restTemplate;

        public GroupTemplate(RestTemplate restTemplate)
        {
            this.restTemplate = restTemplate;
        }

        #region IGroupOperations Members

#if NET_4_0 || SILVERLIGHT_5
        public Task<Group> GetGroupDetailsAsync(int groupId)
        {
            return restTemplate.GetForObjectAsync<Group>(GroupDetailsUrl, groupId);
        }

        public Task<GroupMemberships> GetGroupMembershipsAsync()
        {
            return restTemplate.GetForObjectAsync<GroupMemberships>(GroupMembershipsUrl);
        }

        public Task<GroupMemberships> GetGroupMembershipsAsync(int start, int count)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("start", start.ToString());
            parameters.Add("count", count.ToString());
            return restTemplate.GetForObjectAsync<GroupMemberships>(this.BuildUrl(GroupMembershipsUrl, parameters));
        }

        public Task<GroupPosts> GetPostsByGroupIdAsync(int groupId)
        {
            return restTemplate.GetForObjectAsync<GroupPosts>(GroupPostsUrl, groupId);
        }

        public Task<GroupPosts> GetPostsByGroupIdAsync(int groupId, int start, int count)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("start", start.ToString());
            parameters.Add("count", count.ToString());
            return restTemplate.GetForObjectAsync<GroupPosts>(this.BuildUrl(GroupPostsUrl, parameters), groupId);
        }

        public Task<PostComments> GetPostCommentsByGroupIdAsync(string postId)
        {
            return restTemplate.GetForObjectAsync<PostComments>(GroupPostCommentsUrl, postId);
        }

        public Task<PostComments> GetPostCommentsByGroupIdAsync(string postId, int start, int count)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("start", start.ToString());
            parameters.Add("count", count.ToString());
            return restTemplate.GetForObjectAsync<PostComments>(this.BuildUrl(GroupPostCommentsUrl, parameters), postId);
        }
#else

#endif

        #endregion
    }
}
