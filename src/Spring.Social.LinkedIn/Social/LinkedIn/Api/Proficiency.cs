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
    /// Represents an proficiency details for a Profile on LinkedIn.
    /// </summary>
    /// <author>Bruno Baia</author>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Proficiency
    {
        /// <summary>
        /// A structured object indicating the user's fluency. Returns one of the following five values: 
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// This field is for humans to read. It may be localized in the future..
        /// </summary>
        public string Name { get; set; }
    }
}