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
        /// a <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<Group> GetGroupDetailsAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Groups a User is a member of.
        /// </summary>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupMemberships> GetGroupMembershipsAsync();

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Groups a User is a member of.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return
        /// a <see cref="LinkedInProfile" /> object representing the user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupMemberships> GetGroupMembershipsAsync(int start, int count);

        /// <summary>
        /// Asynchronously retrieves the authenticated user's LinkedIn List of Group Suggestions for a User.
        /// </summary>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="LinkedInFullProfile"/> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        //Task<GroupSuggestions> GetGroupSuggestionsAsync();

        /// <summary>
        /// Asynchronously retrieves the authenticated user's LinkedIn List of Group Suggestions for a User.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="LinkedInFullProfile"/> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        //Task<GroupSuggestions> GetGroupSuggestionsAsync(int start, int count);

        /**
         * Join a Group
         * @param groupId Id of Group
         */
        //void joinGroup(int groupId);

        /**
         * Leave a Group
         * @param groupId Id of Group
         */
        //void leaveGroup(int groupId);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Posts for a group in time order by its group ID.
        /// </summary>
        /// <param name="groupId">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="LinkedInFullProfile"/> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupPosts> GetPostsByGroupIdAsync(int groupId);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of Posts for a group in time order by its group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return
        /// a <see cref="LinkedInFullProfile" /> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<GroupPosts> GetPostsByGroupIdAsync(int groupId, int start, int count);


        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of PostComments for a group in time order by its group ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="LinkedInFullProfile"/> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<PostComments> GetPostCommentsByGroupIdAsync(string id);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn List of PostComments for a group in time order by its group ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return
        /// a <see cref="LinkedInFullProfile" /> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        Task<PostComments> GetPostCommentsByGroupIdAsync(string id, int start, int count);

 //       /**
 //* Create a Post
 //* 
 //* @param groupId Group to Create Post on
 //* @param title Title of Post
 //* @param summary Text of Post
 //* @return the URI of the newly created Post
 //*/
 //       URI createPost(Integer groupId, String title, String summary);

 //       /**
 //        * Like a Post
 //        * 
 //        * @param postId Id of Post
 //        */
 //       void likePost(String postId);

 //       /**
 //        * Unlike a Post 
 //        * @param postId Id of Post
 //        */
 //       void unlikePost(String postId);

 //       /**
 //        * Follow a Post
 //        * 
 //        * @param postId Id of Post
 //        */
 //       void followPost(String postId);

 //       /**
 //        * Like a Post
 //        * 
 //        * @param postId Id of Post
 //        */
 //       void unfollowPost(String postId);

 //       /**
 //        * Flag a Post as a Job
 //        * 
 //        * @param postId Id of Post
 //        */
 //       void flagPostAsJob(String postId);

 //       /**
 //        * Flag a Post as a Promotion
 //        * 
 //        * @param postId Id of Post
 //        */
 //       void flagPostAsPromotion(String postId);

 //       /**
 //        * Delete a Post (if group administrator) or flag as inappropriate 
 //        * 
 //        * @param postId Id of Post
 //        */
 //       void deleteOrFlagPostAsInappropriate(String postId);

 //       /**
 //        * Add a Comment to a Post
 //        * 
 //        * @param postId Id of Post
 //        * @param text Text of Comment
 //        */
 //       void addCommentToPost(String postId, String text);

 //       /**
 //        * Delete a Comment (if group administrator) or flag as inappropriate 
 //        * 
 //        * @param commentId Id of Comment
 //        */
 //       void deleteOrFlagCommentAsInappropriate(String commentId);

 //       /**
 //        * Delete Group Suggestion
 //        * 
 //        * @param groupId Id of Group
 //        */
 //       void deleteGroupSuggestion(Integer groupId);
#else
#if !SILVERLIGHT
        /// <summary>
        /// Retrieves the authenticated user's LinkedIn profile details.
	    /// </summary>
        /// <returns>
        /// A <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
	    LinkedInProfile GetUserProfile();

        /// <summary>
        /// Retrieves a specific user's LinkedIn profile details by its ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        LinkedInProfile GetUserProfileById(string id);

        /// <summary>
        /// Retrieves a specific user's LinkedIn profile details by its public url.
        /// </summary>
        /// <param name="url">The user public url for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        LinkedInProfile GetUserProfileByPublicUrl(string url);

        /// <summary>
        /// Retrieves the authenticated user's LinkedIn full profile details.
        /// </summary>
        /// <returns>
        /// A <see cref="LinkedInFullProfile"/> object representing the full user's profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        LinkedInFullProfile GetUserFullProfile();

        /// <summary>
        /// Retrieves a specific user's LinkedIn full profile details by its ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <see cref="LinkedInFullProfile"/> object representing the user's full profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        LinkedInFullProfile GetUserFullProfileById(string id);

        /// <summary>
        /// Retrieves a specific user's LinkedIn full profile details by its public url.
        /// </summary>
        /// <param name="url">The user public url for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <see cref="LinkedInFullProfile"/> object representing the user's full profile.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        LinkedInFullProfile GetUserFullProfileByPublicUrl(string url);

        /// <summary>
        /// Searches for LinkedIn profiles based on provided parameters.
        /// </summary>
        /// <param name="parameters">The profile search parameters.</param>
        /// <returns>
        /// An object containing the search results metadata and a list of matching <see cref="LinkedInProfile"/>s.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        LinkedInProfiles Search(SearchParameters parameters);
#endif

        /// <summary>
        /// Asynchronously retrieves the authenticated user's LinkedIn profile details.
	    /// </summary>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
	    RestOperationCanceler GetUserProfileAsync(Action<RestOperationCompletedEventArgs<LinkedInProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn profile details by its ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        RestOperationCanceler GetUserProfileByIdAsync(string id, Action<RestOperationCompletedEventArgs<LinkedInProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves the authenticated user's LinkedIn full profile details.
        /// </summary>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="LinkedInFullProfile"/> object representing the user's full profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        RestOperationCanceler GetUserFullProfileAsync(Action<RestOperationCompletedEventArgs<LinkedInFullProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn full profile details by its ID.
        /// </summary>
        /// <param name="id">The user ID for the user whose details are to be retrieved.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="LinkedInFullProfile"/> object representing the user's full profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        RestOperationCanceler GetUserFullProfileByIdAsync(string id, Action<RestOperationCompletedEventArgs<LinkedInFullProfile>> operationCompleted);
#if !WINDOWS_PHONE
        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn profile details by its public url.
        /// </summary>
        /// <param name="url">The user public url for the user whose details are to be retrieved.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="LinkedInProfile"/> object representing the user's profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        RestOperationCanceler GetUserProfileByPublicUrlAsync(string url, Action<RestOperationCompletedEventArgs<LinkedInProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a specific user's LinkedIn full profile details by its public url.
        /// </summary>
        /// <param name="url">The user public url for the user whose details are to be retrieved.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="LinkedInFullProfile"/> object representing the user's full profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        RestOperationCanceler GetUserFullProfileByPublicUrlAsync(string url, Action<RestOperationCompletedEventArgs<LinkedInFullProfile>> operationCompleted);
#endif

        /// <summary>
        /// Asynchronously searches for LinkedIn profiles based on provided parameters.
        /// </summary>
        /// <param name="parameters">The profile search parameters.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides an object containing the search results metadata and a list of matching <see cref="LinkedInProfile"/>s.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="LinkedInApiException">If there is an error while communicating with LinkedIn.</exception>
        RestOperationCanceler SearchAsync(SearchParameters parameters, Action<RestOperationCompletedEventArgs<LinkedInProfiles>> operationCompleted);
#endif
    }
}
