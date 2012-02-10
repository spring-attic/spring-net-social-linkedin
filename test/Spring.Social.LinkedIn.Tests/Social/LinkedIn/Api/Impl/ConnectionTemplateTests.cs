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

using System.Net;
using System.Collections.Generic;

using NUnit.Framework;
using Spring.Rest.Client.Testing;

using Spring.Http;
using Spring.IO;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Unit tests for the ConnectionTemplate class.
    /// </summary>
    /// <author>Bruno Baia</author>
    [TestFixture]
    public class ConnectionTemplateTests : AbstractLinkedInOperationsTests 
    {    
	    [Test]
	    public void GetUserProfile()
        {
		    mockServer.ExpectNewRequest()
                .AndExpect(UriStartsWith("https://api.linkedin.com/v1/people/~:("))
				.AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("Profile"), responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
		    LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileAsync().Result;
#else
            LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfile();
#endif
            AssertProfile(profile, "xO3SEJSVZN", "Architecte en informatique spécialisé sur les technologies Microsoft .NET",
                "Bruno", "Baia", "Information Technology and Services", "http://media.linkedin.com/pictureUrl",
                "Consultant .NET indépendant", "http://www.linkedin.com/in/bbaia", "http://www.linkedin.com/profile", null);
	    }

	    [Test]
	    public void GetConnections() 
        {
		    mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people/~/connections:(id,first-name,last-name,headline,industry,site-standard-profile-request,public-profile-url,picture-url,summary)?format=json")
                .AndExpectMethod(HttpMethod.GET)
				.AndRespondWith(JsonResource("Connections"), responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            IList<LinkedInProfile> connections = linkedIn.ConnectionOperations.GetConnectionsAsync().Result;
#else
            IList<LinkedInProfile> connections = linkedIn.ConnectionOperations.GetConnections();
#endif

            Assert.AreEqual(4, connections.Count);
		    AssertProfile(connections[0], "kR0lnX1ll8", "SpringSource Cofounder", "Keith", "Donald", "Computer Software",
                    null, "", null, "http://www.linkedin.com/profile?viewProfile=&key=2526541&authToken=61Sm&authType=name&trk=api*a121026*s129482*", "name:61Sm");
            AssertProfile(connections[1], "VRcwcqPCtP", "GM, SpringSource and SVP, Middleware at VMware", "Rod", "Johnson", "Computer Software",
                    null, "", null, "http://www.linkedin.com/profile?viewProfile=&key=210059&authToken=3hU1&authType=name&trk=api*a121026*s129482*", "name:3hU1");
            AssertProfile(connections[2], "Ia7uR1OmDB", "Spring and AOP expert; author AspectJ in Action", "Ramnivas", "Laddad", "Computer Software",
				    "http://media.linkedin.com/mpr/mprx/0__gnH4Z-585hJSJSu_M6B4RrHCikUf0pu30CB4Rhqg6KwrUI2fUQXnUNVuSXku4j8CYN9cyYH-JuX", "", null,
                    "http://www.linkedin.com/profile?viewProfile=&key=208994&authToken=P5K9&authType=name&trk=api*a121026*s129482*", "name:P5K9");
            AssertProfile(connections[3], "gKEMq4CMdl", "Head of Groovy Development at SpringSource", "Guillaume", "Laforge", "Information Technology and Services", 
				    "http://media.linkedin.com/mpr/mprx/0_CV5yQ4-Er7cqa-ZZhJziQU1WpS3v2qZZhRliQU1Miez51K74apvKHRbB-iTE71MN_JbCWpT7SdWe", "", null,
                    "http://www.linkedin.com/profile?viewProfile=&key=822306&authToken=YmIW&authType=name&trk=api*a121026*s129482*", "name:YmIW");
	    }

        [Test]
	    public void GetStatistics() 
        {
		    mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people/~/network/network-stats?format=json")
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("Statistics"), responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            NetworkStatistics stats = linkedIn.ConnectionOperations.GetNetworkStatisticsAsync().Result;
#else
            NetworkStatistics stats = linkedIn.ConnectionOperations.GetNetworkStatistics();
#endif

            Assert.AreEqual(189, stats.FirstDegreeCount);
            Assert.AreEqual(50803, stats.SecondDegreeCount);
	    }
    }
}
