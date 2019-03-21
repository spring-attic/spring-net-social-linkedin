#region License

/*
 * Copyright 2002-2012 the original author or authors.
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
    // https://developer.linkedin.com/documents/profile-fields#skills"/>

    /// <summary>
    /// Represents a skill details for a Profile on LinkedIn.
    /// </summary>
    /// <author>James Fleming</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Skill
    {
        /// <summary>
        /// Gets or sets the unique identifier for the skill entry.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the internationalized name of the canonical language.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's skill level.
        /// <para/>
        /// Possible values for level are: beginner, intermediate, advanced and expert.
        /// </summary>
        public Proficiency Proficiency { get; set; }

        /// <summary>
        /// Gets or sets the years of experience for this skill. 
        /// </summary>
        public Years Years { get; set; }
    }
}
