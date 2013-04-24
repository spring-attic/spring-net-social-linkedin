#region

using System;
using System.Collections.Generic;

#endregion

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Model class representing a Post.
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
 #if !SILVERLIGHT
    [Serializable]
#endif
    public class Post
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Post"/> class.
        /// </summary>
        public Post()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Post"/> class.
        /// </summary>
        /// <param name="creator">The creator.</param>
        /// <param name="id">The id.</param>
        /// <param name="title">The title.</param>
        /// <param name="type">The type.</param>
        public Post(LinkedInProfile creator, String id, String title, PostType type)
        {
            Creator = creator;
            ID = id;
            Title = title;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        public LinkedInProfile Creator { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public PostType Type { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime CreationTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the relation to viewer.
        /// </summary>
        public PostRelation RelationToViewer { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public String Summary { get; set; }

        /// <summary>
        /// Gets or sets the likes.
        /// </summary>
        public List<LinkedInProfile> Likes { get; set; }

        /// <summary>
        /// Gets or sets the attachment.
        /// </summary>
        public Attachment Attachment { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PostRelation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostRelation"/> class.
        /// </summary>
        /// <param name="availableActions">The available actions.</param>
        /// <param name="isFollowing">The is following.</param>
        /// <param name="isLiked">The is liked.</param>
        public PostRelation(List<PostAvailableAction> availableActions, Boolean isFollowing, Boolean isLiked)
        {
            AvailableActions = availableActions;
            IsFollowing = isFollowing;
            IsLiked = isLiked;
        }

        /// <summary>
        /// Gets or sets the is following.
        /// </summary>
        public Boolean IsFollowing { get; set; }

        /// <summary>
        /// Gets or sets the is liked.
        /// </summary>
        public Boolean IsLiked { get; set; }

        /// <summary>
        /// Gets or sets the available actions.
        /// </summary>
        public List<PostAvailableAction> AvailableActions { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment"/> class.
        /// </summary>
        /// <param name="contentDomain">The content domain.</param>
        /// <param name="contentUrl">The content URL.</param>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="summary">The summary.</param>
        /// <param name="title">The title.</param>
        public Attachment(String contentDomain, String contentUrl, String imageUrl, String summary, String title)
        {
            ContentDomain = contentDomain;
            ContentUrl = contentUrl;
            ImageUrl = imageUrl;
            Summary = summary;
            Title = title;
        }

        /// <summary>
        /// Gets or sets the content domain.
        /// </summary>
        public String ContentDomain { get; set; }

        /// <summary>
        /// Gets or sets the content URL.
        /// </summary>
        public String ContentUrl { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        public String ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public String Summary { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public String Title { get; set; }
    }

    public enum PostCategory
    {
        DISCUSSION,
        JOB
    }

    public enum PostType
    {
        STANDARD,
        NEWS
    }

    public enum PostAvailableAction
    {
        ADD_COMMENT,
        FLAG_AS_INAPPROPRIATE,
        CATEGORIZE_AS_JOB,
        CATEGORIZE_AS_PROMOTION,
        DELETE,
        FOLLOW,
        LIKE,
        REPLY_PRIVATELY,
        UNFOLLOW
    }
}
