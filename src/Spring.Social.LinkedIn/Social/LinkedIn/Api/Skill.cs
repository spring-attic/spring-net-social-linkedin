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
    /// Represents an education details for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
    /// <see cref="https://developer.linkedin.com/documents/profile-fields#skills"/>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Skill
    {
        /// <summary>
        /// Gets or sets the unique identifier for the skill entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A structured object that indicates the internationalized name of the canonical language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A flattened projection of a structured object indicating the user's skill level. Returns one of the four following values.
        /// This field is for computer programs and map to beginner, intermediate, advanced, expert
        /// </summary>
        public string ProficiencyLevel { get; set; }

        /// <summary>
        /// A flattened projection of a structured object indicating the user's skill level. Returns one of the four following values.
        /// This field is for humans to read. It may be localized in the future. and map to beginner, intermediate, advanced, expert
        /// </summary>
        public string ProficiencyName { get; set; }

        /// <summary>
        /// A structured object indicating the user's skill level. Returns one of the four following values.
        /// This field is for humans to read. It may be localized in the future. and map to beginner, intermediate, advanced, expert
        /// </summary>
        public Proficiency Proficiency { get; set; }

        /// <summary>
        /// A flattened projection of a structured object describing the years of experience for this skill. The ID form is an enumerated ID where the ID equals the number of years.
        /// </summary>
        public string YearsId { get; set; }

        /// <summary>
        /// A flattened projection of a structured object describing the years of experience for this skill. The name form is a string representation of the number of years.
        /// </summary>
        public string YearsName { get; set; }

        /// <summary>
        /// A structured object describing the years of experience for this skill. The name form is a string representation of the number of years.
        /// </summary>
        public Years Years { get; set; }
       
    }
}
