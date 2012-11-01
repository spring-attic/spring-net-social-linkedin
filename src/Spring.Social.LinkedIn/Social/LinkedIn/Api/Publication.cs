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

namespace Spring.Social.LinkedIn.Api
{
    // TODO: publication's authors

    /// <summary>
    /// Represents a publication details for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Publication
    {
        /// <summary>
        /// Gets or sets the unique identifier for the publication entry.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title of this publication.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the publisher of this publication.
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// Gets or sets a URL for the publication.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the summary of the publication
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the date indicating when the publication was published.
        /// </summary>
        public LinkedInDate Date { get; set; }
    }
}
