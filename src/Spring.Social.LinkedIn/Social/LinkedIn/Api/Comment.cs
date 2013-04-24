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

namespace Spring.Social.LinkedIn.Api {
    /// <summary>
    /// Model class representing a comment on an object such as a post or update
    /// </summary>
    /// <author>Original Java code: Robert Drysdale</author>
    /// <author>Manudea (.Net Porting)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Comment {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="id">The id.</param>
        /// <param name="person">The person.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <param name="timestamp">The timestamp.</param>
        public Comment(String comment, String id, LinkedInProfile person, int sequenceNumber, DateTime timestamp) {
            CommentText = comment;
            ID = id;
            Person = person;
            SequenceNumber = sequenceNumber;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the comment entry.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        public LinkedInProfile Person { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        public int SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }

    }
}
