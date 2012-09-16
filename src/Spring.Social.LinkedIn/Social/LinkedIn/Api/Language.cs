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

namespace Spring.Social.LinkedIn.Api
{
    using System;

    /// <summary>
    /// Represents an language details for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Language
    {
        /// <summary>
        /// Gets or sets the unique identifier for the language entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A structured object specifying the language name
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
        ///  structured object indicating the user's fluency. Returns one of the following five values: elementary, limited-working, professional-working, full-professional, native-or-bilingual
        /// </summary>
        public Proficiency Proficiency { get; set; }
    }
}
