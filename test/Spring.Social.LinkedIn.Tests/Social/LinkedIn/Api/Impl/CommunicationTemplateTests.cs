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

using NUnit.Framework;
using Spring.Rest.Client.Testing;

using Spring.Http;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Unit tests for the CommunicationTemplate class.
    /// </summary>
    /// <author>Bruno Baia</author>
    [TestFixture]
    public class CommunicationTemplateTests : AbstractLinkedInOperationsTests 
    {
	    [Test]
	    public void SendMessage() 
        {
            mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people/~/mailbox")
		        .AndExpectMethod(HttpMethod.POST)
                .AndExpectBody("{\"subject\":\"Test message\",\"body\":\"This is a test\",\"recipients\":{\"values\":[{\"person\":{\"_path\":\"/people/~\"}}]}}")
		        .AndRespondWith("", responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
		    linkedIn.CommunicationOperations.SendMessageAsync("Test message", "This is a test", "~").Wait();
#else
            linkedIn.CommunicationOperations.SendMessage("Test message", "This is a test", "~");
#endif
        }

	    [Test]
	    public void SendInvitationToLinkedInUser() 
        {
            mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people/~/mailbox")
                .AndExpectMethod(HttpMethod.POST)
                .AndExpectBody("{\"subject\":\"I'd like to add you to my professional network on LinkedIn\",\"body\":\"I'd like to add you to my professional network on LinkedIn\",\"recipients\":{\"values\":[{\"person\":{\"_path\":\"/people/UB2kruYvvv\"}}]},\"item-content\":{\"invitation-request\":{\"connect-type\":\"friend\",\"authorization\":{\"name\":\"NAME_SEARCH\",\"value\":\"aaaa\"}}}}")
                .AndRespondWith("", responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            linkedIn.CommunicationOperations.ConnectToAsync("I'd like to add you to my professional network on LinkedIn",
				    "I'd like to add you to my professional network on LinkedIn", "UB2kruYvvv", "NAME_SEARCH:aaaa").Wait();
#else
            linkedIn.CommunicationOperations.ConnectTo("I'd like to add you to my professional network on LinkedIn",
				    "I'd like to add you to my professional network on LinkedIn", "UB2kruYvvv", "NAME_SEARCH:aaaa");
#endif
        }

        [Test]
        public void SendInvitationToNonLinkedInUser() 
        {
            mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people/~/mailbox")
                .AndExpectMethod(HttpMethod.POST)
                .AndExpectBody("{\"subject\":\"I'd like to add you to my professional network on LinkedIn\",\"body\":\"I'd like to add you to my professional network on LinkedIn\",\"recipients\":{\"values\":[{\"person\":{\"_path\":\"/people/email=rob@test.com\",\"first-name\":\"Robert\",\"last-name\":\"Smith\"}}]},\"item-content\":{\"invitation-request\":{\"connect-type\":\"friend\"}}}")
                .AndRespondWith("", responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            linkedIn.CommunicationOperations.ConnectToAsync("I'd like to add you to my professional network on LinkedIn",
                    "I'd like to add you to my professional network on LinkedIn", "rob@test.com", "Robert", "Smith").Wait();
#else
            linkedIn.CommunicationOperations.ConnectTo("I'd like to add you to my professional network on LinkedIn",
				    "I'd like to add you to my professional network on LinkedIn", "rob@test.com", "Robert", "Smith");
#endif
	    }
    }
}
