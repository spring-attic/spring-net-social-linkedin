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
using System.Collections.Generic;

namespace Spring.Social.LinkedIn.Api
{
    /// <summary>
    /// Represents a partial patent for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Patent
    {
        /// <summary>
        /// A unique identifier for this member's patent entry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A string describing the title of this patent
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///   	A string with the patent or application number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// A URL for the patent
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// A string summary of the patent
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// A structured object with day, month, and year fields indicating when the patent was published.
        /// </summary>
        public LinkedInDate Date { get; set; }

    }
}
