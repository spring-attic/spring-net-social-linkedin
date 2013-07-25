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
using System.Text;

using NUnit.Framework;
using Spring.Rest.Client.Testing;

using Spring.IO;
using Spring.Http;
using Spring.Http.Client;

namespace Spring.Social.LinkedIn.Api.Impl {
    /// <summary>
    /// Base class for all AbstractLinkedInOperations subclasses unit tests.
    /// </summary>
    /// <author>Bruno Baia</author>
    public abstract class AbstractLinkedInOperationsTests {
        protected LinkedInTemplate linkedIn;
        protected MockRestServiceServer mockServer;
        protected HttpHeaders responseHeaders;

        [SetUp]
        public void Setup() {
            linkedIn = new LinkedInTemplate("API_KEY", "API_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            mockServer = MockRestServiceServer.CreateServer(linkedIn.RestTemplate);
            responseHeaders = new HttpHeaders();
            responseHeaders.ContentType = new MediaType("application", "json", Encoding.Default);
        }

        [TearDown]
        public void TearDown() {
            mockServer.Verify();
        }

        protected IResource JsonResource(string filename) {
            return new AssemblyResource(filename + ".json", typeof(AbstractLinkedInOperationsTests));
        }

        protected static RequestMatcher UriStartsWith(string url) {
            return delegate(IClientHttpRequest request) {
                AssertionUtils.IsTrue(
                    request.Uri.ToString().StartsWith(url, StringComparison.OrdinalIgnoreCase),
                    String.Format("URI '{0}' didn't start with expected value [expected:<{1}>]", request.Uri, url));
            };
        }

        protected void AssertProfile(LinkedInProfile connection, String id, String headline, String firstName,
        String lastName, String industry, String standardUrl) {
            Assert.AreEqual(id, connection.ID);
            Assert.AreEqual(headline, connection.Headline);
            Assert.AreEqual(firstName, connection.FirstName);
            Assert.AreEqual(lastName, connection.LastName);
            if (!string.IsNullOrEmpty(industry))
                Assert.AreEqual(industry, connection.Industry);
            if (!string.IsNullOrEmpty(standardUrl))
                Assert.AreEqual(standardUrl, connection.StandardProfileUrl);
        }

        protected void AssertProfile(LinkedInProfile profile,
            string id, string headline, string firstName, string lastName, string industry, string pictureUrl,
            string summary, string publicProfileUrl, string standardProfileUrl, string authToken) {
            Assert.AreEqual(id, profile.ID);
            Assert.AreEqual(headline, profile.Headline);
            Assert.AreEqual(firstName, profile.FirstName);
            Assert.AreEqual(lastName, profile.LastName);
            Assert.AreEqual(industry, profile.Industry);
            Assert.AreEqual(pictureUrl, profile.PictureUrl);
            Assert.AreEqual(summary, profile.Summary);
            Assert.AreEqual(publicProfileUrl, profile.PublicProfileUrl);
            Assert.AreEqual(standardProfileUrl, profile.StandardProfileUrl);
            Assert.AreEqual(authToken, profile.AuthToken);
        }

#if NET_4_0 || SILVERLIGHT_5
        protected void AssertLinkedInApiException(AggregateException ae, string expectedMessage, LinkedInApiError error) {
            ae.Handle(ex => {
                if (ex is LinkedInApiException) {
                    Assert.AreEqual(expectedMessage, ex.Message);
                    Assert.AreEqual(error, ((LinkedInApiException)ex).Error);
                    return true;
                }
                return false;
            });
        }
#else
        protected void AssertLinkedInApiException(Exception ex, string expectedMessage, LinkedInApiError error)
        {
            if (ex is LinkedInApiException)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
                Assert.AreEqual(error, ((LinkedInApiException)ex).Error);
            }
            else
            {
                Assert.Fail("LinkedInApiException expected");
            }
        }
#endif
    }
}
