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
    /// <summary>
    /// Represents an certification details for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Certification
    {
        /// <summary>
        /// Gets or sets the unique identifier for the certification entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A string indicating the name of this certification
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  	A structured object containing the name of the certification's issuing body
        /// </summary>
        public string AuthorityName { get; set; }

        /// <summary>
        /// A string describing the license number for this certification
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Gets or sets the year indicating when the certification began.
        /// </summary>
        public LinkedInDate StartDate { get; set; }

        /// <summary>
        /// Gets or sets the year indicating when the certification ended, 
        /// or <see langword="null"/> when the certification is current.
        /// </summary>
        public LinkedInDate EndDate { get; set; }

    }
}
