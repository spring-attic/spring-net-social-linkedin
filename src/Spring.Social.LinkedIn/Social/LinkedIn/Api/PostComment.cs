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

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Represents a LinkedIn comment on an object such as a post or update.
    /// </summary>    
    /// <author>Robert Drysdale</author>
    /// <author>Manudea (.NET)</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class PostComment
    {
        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime CreationTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        public LinkedInProfile Creator { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }
    }
}
