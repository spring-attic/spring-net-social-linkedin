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
    /// Represents a LinkedIn post.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Post
    {
        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        public LinkedInProfile Creator { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

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
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the likes.
        /// </summary>
        public IList<LinkedInProfile> Likes { get; set; }

        /// <summary>
        /// Gets or sets the attachment.
        /// </summary>
        public Attachment Attachment { get; set; }
    }

    /// <summary>
    /// Represents a LinkedIn post relation to viewer.
    /// </summary>
    public class PostRelation
    {
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
        public IList<PostAvailableAction> AvailableActions { get; set; }
    }

    /// <summary>
    /// Represents a LinkedIn post attachment.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Gets or sets the content domain.
        /// </summary>
        public string ContentDomain { get; set; }

        /// <summary>
        /// Gets or sets the content URL.
        /// </summary>
        public string ContentUrl { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// Represents LinkedIn categories for a post.
    /// </summary>
    public enum PostCategory
    {
        /// <summary>
        /// Discussion
        /// </summary>
        Discussion,

        /// <summary>
        /// Job
        /// </summary>
        Job
    }

    /// <summary>
    /// Represents LinkedIn types for a post.
    /// </summary>
    public enum PostType
    {
        /// <summary>
        /// Standard
        /// </summary>
        Standard,

        /// <summary>
        /// News
        /// </summary>
        News
    }

    /// <summary>
    /// Represents LinkedIn available actions for a post.
    /// </summary>
    public enum PostAvailableAction
    {
        /// <summary>
        /// Add comment
        /// </summary>
        AddComment,

        /// <summary>
        /// Flag as innappropriate
        /// </summary>
        FlagAsInnappropriate,

        /// <summary>
        /// Categorize as job
        /// </summary>
        CategorizeAsJob,

        /// <summary>
        /// Categorize as promotion
        /// </summary>
        CategorizeAsPromotion,

        /// <summary>
        /// Delete
        /// </summary>
        Delete,

        /// <summary>
        /// Follow
        /// </summary>
        Follow,

        /// <summary>
        /// Like
        /// </summary>
        Like,

        /// <summary>
        /// ReplyPrivately
        /// </summary>
        ReplyPrivately,

        /// <summary>
        /// Unfollow
        /// </summary>
        Unfollow
    }
}
