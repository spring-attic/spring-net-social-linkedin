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
using System.Reflection;
using NUnit.Framework;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// This is a test class for ProfileUrl and is intended to contain all ProfileUrl Unit Tests
    /// </summary>
    [TestFixture]
    public class ProfileUrlTest
    {
        private static object RunStatic(Type classType, string method, object[] parameters)
        {
            var methodInfo = classType.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Static);
            return methodInfo.Invoke(null, parameters);
        }

        /// <summary>
        /// A test for AllowedField with out of boundary index and single permission.
        /// </summary>
        [Test]
        public void AllowedField0Test()
        {
            int index = -1;
            Permissions permissions = Permissions.r_basicprofile;
            bool expected = false;
            bool actual = (bool)RunStatic(typeof(ProfileUrl), "AllowedField", new object[] { index, permissions });
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for AllowedField with out of boundary index and single permission.
        /// </summary>
        [Test]
        public void AllowedField1Test()
        {
            int index = 100;
            Permissions permissions = Permissions.r_basicprofile;
            bool expected = false;
            bool actual = (bool)RunStatic(typeof(ProfileUrl), "AllowedField", new object[] { index, permissions });
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for AllowedField with composed permissions.
        /// </summary>
        [Test]
        public void AllowedField2Test()
        {
            int index = 30;
            Permissions permissions = Permissions.r_basicprofile | Permissions.r_fullprofile;
            bool expected = true;
            bool actual = (bool)RunStatic(typeof(ProfileUrl), "AllowedField", new object[] { index, permissions });
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for AllowedField with no permissions.
        /// </summary>
        [Test]
        public void AllowedField3Test()
        {
            int index = 30;
            Permissions permissions = Permissions.none;
            bool expected = false;
            bool actual = (bool)RunStatic(typeof(ProfileUrl), "AllowedField", new object[] { index, permissions });
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Get method accepting all parameters (prefix, postfix, field indexes, and permissions)
        /// </summary>
        [Test]
        public void GetMaximum0Test()
        {
            string prefix = "people/{id}:";
            string postfix = string.Empty;
            var fieldIndexes = new List<int> { 1, 2, 13, 14, 26, 9, 10, 38 };
            string expected = "people/{id}:(first-name,last-name,last-modified-timestamp,location,industry,three-current-positions)";
            string actual = ProfileUrl.Get(prefix, postfix, fieldIndexes, Permissions.all);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Get method accepting all parameters (prefix, postfix, field indexes, and permissions) with no permissions
        /// </summary>
        [Test]
        public void GetMaximum1Test()
        {
            string prefix = "people/{id}:";
            string postfix = "format=json";
            var fieldIndexes = new List<int> { 1, 2, 13, 14, 26, 9, 10, 38 };
            string expected = string.Empty;
            string actual = ProfileUrl.Get(prefix, postfix, fieldIndexes, Permissions.none);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Get method accepting all parameters (prefix, postfix, field indexes, and permissions) with limited permission (only basic profile)
        /// </summary>
        [Test]
        public void GetMaximum2Test()
        {
            string prefix = "people/{id}:";
            string postfix = "format=json";
            var fieldIndexes = new List<int> { 1, 2, 13, 14, 26, 9, 10, 38 };
            string expected = "people/{id}:(first-name,last-name,location,industry)?format=json";
            string actual = ProfileUrl.Get(prefix, postfix, fieldIndexes, Permissions.r_basicprofile);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Get method accepting only the field indexes as parameter
        /// </summary>
        [Test]
        public void GetMinimumTest()
        {
            var fieldIndexes = new List<int> { 1, 2, 13, 14, 26, 9, 10 };
            string expected = "people/{id}:(first-name,last-name,last-modified-timestamp,location,industry)?format=json";
            string actual = ProfileUrl.Get(fieldIndexes);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Basic property
        /// </summary>
        [Test]
        public void BasicTest()
        {
            string expected = "people/{id}:(id,first-name,last-name,headline,industry,public-profile-url,picture-url,summary,site-standard-profile-request,api-standard-profile-request)?format=json";
            string actual = ProfileUrl.Basic;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Full property
        /// </summary>
        [Test]
        public void FullTest()
        {
            string expected = "people/{id}:(id,first-name,last-name,maiden-name,formatted-name,phonetic-first-name,phonetic-last-name,formatted-phonetic-name,headline,location,industry,distance,relation-to-viewer,current-share,num-connections,num-connections-capped,summary,specialties,positions,picture-url,site-standard-profile-request,api-standard-profile-request,public-profile-url,email-address,last-modified-timestamp,proposal-comments,associations,interests,publications,patents,languages,skills,certifications,educations,courses,volunteer,three-current-positions,three-past-positions,num-recommenders,recommendations-received,mfeed-rss-url,following,job-bookmarks,suggestions,date-of-birth,member-url-resources,related-profile-views,phone-numbers,bound-account-types,im-accounts,main-address,twitter-accounts,primary-twitter-account,connections,group-memberships,network)?format=json";
            string actual = ProfileUrl.Full;
            Assert.AreEqual(expected, actual);
        }
    }
}
