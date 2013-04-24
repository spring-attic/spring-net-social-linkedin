#region

using System;
using System.Threading.Tasks;
using Spring.Rest.Client;
#if NET_4_0 || SILVERLIGHT_5
#endif
#if SILVERLIGHT
using Spring.Collections.Specialized;
#else
#endif

#endregion

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Group Template
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
    public class GroupTemplate : AbstractLinkedInOperations, IGroupOperations
    {
        /// <summary>
        /// The base URL
        /// </summary>
        public static String BaseUrl = "https://api.linkedin.com/v1/";
        /// <summary>
        /// The base people URL
        /// </summary>
        public static String BasePeopleUrl = BaseUrl + "people/";
        /// <summary>
        /// The group base URL
        /// </summary>
        public static String GroupBaseUrl = BaseUrl + "groups/";
        /// <summary>
        /// The group posts base URL
        /// </summary>
        public static String GroupPostsBaseUrl = BaseUrl + "posts/";

        /// <summary>
        /// The group details URL
        /// </summary>
        public static String GroupDetailsUrl = GroupBaseUrl + "{groupId}:(id,name,short-description,description,relation-to-viewer:(membership-state,available-actions),posts,counts-by-category,is-open-to-non-members,category,website-url,locale,location:(country,postal-code),allow-member-invites,site-group-url,small-logo-url,large-logo-url)";
        /// <summary>
        /// The group join leave URL
        /// </summary>
        public static String GroupJoinLeaveUrl = BasePeopleUrl + "~/group-memberships/{groupId}";
        /// <summary>
        /// The group memberships URL
        /// </summary>
        public static String GroupMembershipsUrl = BasePeopleUrl + "~/group-memberships:(group:(id,name),membership-state,show-group-logo-in-profile,allow-messages-from-members,email-digest-frequency,email-announcements-from-managers,email-for-every-new-post)";
        /// <summary>
        /// The group suggestions URL
        /// </summary>
        public static String GroupSuggestionsUrl = BasePeopleUrl + "~/suggestions/groups:(id,name,is-open-to-non-members)";
        /// <summary>
        /// The group suggestion delete URL
        /// </summary>
        public static String GroupSuggestionDeleteUrl = BasePeopleUrl + "~/suggestions/groups/{id}";
        /// <summary>
        /// The group posts URL
        /// </summary>
        public static String GroupPostsUrl = GroupBaseUrl + "{groupId}/posts:(id,creation-timestamp,title,summary,creator:(first-name,last-name,picture-url,headline),likes,attachment:(image-url,content-domain,content-url,title,summary),relation-to-viewer)?order=recency";
        /// <summary>
        /// The group post comments URL
        /// </summary>
        public static String GroupPostCommentsUrl = GroupPostsBaseUrl + "{post-id}/comments:(creator:(first-name,last-name,picture-url),creation-timestamp,id,text)";
        /// <summary>
        /// The group create post URL
        /// </summary>
        public static String GroupCreatePostUrl = GroupBaseUrl + "{groupId}/posts";
        /// <summary>
        /// The group post like URL
        /// </summary>
        public static String GroupPostLikeUrl = GroupPostsBaseUrl + "{post-id}/relation-to-viewer/is-liked";
        /// <summary>
        /// The group post follow URL
        /// </summary>
        public static String GroupPostFollowUrl = GroupPostsBaseUrl + "{post-id}/relation-to-viewer/is-following";
        /// <summary>
        /// The group post flag URL
        /// </summary>
        public static String GroupPostFlagUrl = GroupPostsBaseUrl + "{post-id}/category/code";
        /// <summary>
        /// The group post delete URL
        /// </summary>
        public static String GroupPostDeleteUrl = GroupPostsBaseUrl + "{post-id}";
        /// <summary>
        /// The group post add comment URL
        /// </summary>
        public static String GroupPostAddCommentUrl = GroupPostsBaseUrl + "{post-id}/comments";
        /// <summary>
        /// The group post delete comment URL
        /// </summary>
        public static String GroupPostDeleteCommentUrl = BaseUrl + "comments/{comment-id}";

        private readonly RestTemplate restTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTemplate"/> class.
        /// </summary>
        /// <param name="restTemplate">The rest template.</param>
        public GroupTemplate(RestTemplate restTemplate)
        {
            this.restTemplate = restTemplate;
        }

        #region IGroupOperations Members

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
            return restTemplate.GetForObjectAsync<GroupMemberships>(GroupMembershipsUrl + "?start=" + start + "&count=" + count);
        }

        public Task<GroupPosts> GetPostsByGroupIdAsync(string groupId)
        {
            return restTemplate.GetForObjectAsync<GroupPosts>(GroupPostsUrl, groupId);
        }

        public Task<GroupPosts> GetPostsByGroupIdAsync(string groupId, int start, int count)
        {
            return restTemplate.GetForObjectAsync<GroupPosts>(GroupPostsUrl + "&start=" + start + "&count=" + count, groupId);
        }

        public Task<PostComments> GetPostCommentsByGroupIdAsync(string postId)
        {
            return restTemplate.GetForObjectAsync<PostComments>(GroupPostCommentsUrl, postId);
        }

        public Task<PostComments> GetPostCommentsByGroupIdAsync(string postId, int start, int count)
        {
            return restTemplate.GetForObjectAsync<PostComments>(GroupPostCommentsUrl + "&start=" + start + "&count=" + count, postId);
        }

        #endregion
    }
}
