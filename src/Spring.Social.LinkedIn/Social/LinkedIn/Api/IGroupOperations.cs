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
using System.IO;
using System.Collections.Generic;
#if NET_4_0 || SILVERLIGHT_5
using System.Threading.Tasks;
#else
using Spring.Rest.Client;
using Spring.Http;
#endif

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Interface defining the operations for retrieving and performing operations on profiles.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
    public interface IGroupOperations
    {
#if NET_4_0 || SILVERLIGHT_5
        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn details for a Group by its ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="Group"/> object representing the group.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<Group> GetGroupDetailsAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Groups a User is a member of.
        /// </summary>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="GroupMemberships"/> object representing the user's groups.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupMemberships> GetGroupMembershipsAsync();

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Groups a User is a member of.
        /// </summary>
        /// <param name="start">The starting location in the result set. Used with count for pagination.</param>
        /// <param name="count">The number of groups to return. Used with start for pagination.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return
        /// a <see cref="GroupMemberships" /> object representing the user's groups.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupMemberships> GetGroupMembershipsAsync(int start, int count);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Posts for a group in time order by its group ID.
        /// </summary>
        /// <param name="groupId">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="GroupPosts"/> object representing the group posts.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupPosts> GetPostsByGroupIdAsync(int groupId);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Posts for a group in time order by its group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="start">The starting location in the result set. Used with count for pagination.</param>
        /// <param name="count">The number of posts to return. Used with start for pagination.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return
        /// a <see cref="GroupPosts" /> object representing the group posts.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupPosts> GetPostsByGroupIdAsync(int groupId, int start, int count);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of PostComments for a group in time order by its group ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="PostComments"/> object representing the post comments.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<PostComments> GetPostCommentsByGroupIdAsync(string id);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of PostComments for a group in time order by its group ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <param name="start">The starting location in the result set. Used with count for pagination.</param>
        /// <param name="count">The number of post comments to return. Used with start for pagination.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return
        /// a <see cref="PostComments" /> object representing the post comments.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<PostComments> GetPostCommentsByGroupIdAsync(string id, int start, int count);
#endif
    }
}
