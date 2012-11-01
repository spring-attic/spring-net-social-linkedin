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
    /// Unit tests for the ProfileTemplate class.
    /// </summary>
    /// <author>Bruno Baia</author>
    [TestFixture]
    public class ProfileTemplateTests : AbstractLinkedInOperationsTests 
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
        public void GetUserProfileById()
        {
            mockServer.ExpectNewRequest()
                .AndExpect(UriStartsWith("https://api.linkedin.com/v1/people/id=xO3SEJSVZN:("))
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("Profile"), responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileByIdAsync("xO3SEJSVZN").Result;
#else
            LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileById("xO3SEJSVZN");
#endif
            AssertProfile(profile, "xO3SEJSVZN", "Architecte en informatique spécialisé sur les technologies Microsoft .NET",
                "Bruno", "Baia", "Information Technology and Services", "http://media.linkedin.com/pictureUrl",
                "Consultant .NET indépendant", "http://www.linkedin.com/in/bbaia", "http://www.linkedin.com/profile", null);
        }

        [Test]
        public void GetUserProfileByPublicUrl()
        {
            mockServer.ExpectNewRequest()
                .AndExpect(UriStartsWith("https://api.linkedin.com/v1/people/url=http://www.linkedin.com/in/bbaia:("))
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("Profile"), responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileByPublicUrlAsync("http://www.linkedin.com/in/bbaia").Result;
#else
            LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileByPublicUrl("http://www.linkedin.com/in/bbaia");
#endif
            AssertProfile(profile, "xO3SEJSVZN", "Architecte en informatique spécialisé sur les technologies Microsoft .NET",
                "Bruno", "Baia", "Information Technology and Services", "http://media.linkedin.com/pictureUrl",
                "Consultant .NET indépendant", "http://www.linkedin.com/in/bbaia", "http://www.linkedin.com/profile", null);
        }

        [Test] 
	    public void GetUserFullProfile() 
        {
		    mockServer.ExpectNewRequest()
                .AndExpect(UriStartsWith("https://api.linkedin.com/v1/people/~:("))
                .AndExpectMethod(HttpMethod.GET)
                .AndRespondWith(JsonResource("FullProfile"), responseHeaders);

#if NET_4_0 || SILVERLIGHT_5
            LinkedInFullProfile profile = linkedIn.ProfileOperations.GetUserFullProfileAsync().Result;
#else
            LinkedInFullProfile profile = linkedIn.ProfileOperations.GetUserFullProfile();
#endif

            AssertProfile(profile, "UB2kruYmAL", "Software Architect", "Robert", "Drysdale", "Telecommunications",
                "http://media.linkedin.com/pictureUrl", "J2EE Application Architect with over 10 years industry experience.",
                "http://www.linkedin.com/in/robdrysdale", "http://www.linkedin.com/profile?viewProfile=&key=15567709&authToken=O91G&authType=name&trk=api*a151944*s160233*", "name:O91G");
		
		    Assert.AreEqual("Canoeing Ireland", profile.Associations);
		    Assert.AreEqual("None", profile.Honors);
            Assert.AreEqual(206, profile.Specialties.Length);
            Assert.AreEqual(2, profile.RecommendersCount);
            Assert.AreEqual("Telecommunications", profile.Industry);
            Assert.AreEqual("Kayaking", profile.Interests);
            Assert.AreEqual("ie", profile.CountryCode);
            Assert.AreEqual("Ireland", profile.Location);
            Assert.AreEqual(189, profile.ConnectionsCount);
            Assert.AreEqual(false, profile.IsConnectionsCountCapped);
            Assert.AreEqual("Dublin, Ireland", profile.MainAddress);
            Assert.AreEqual(0, profile.Distance);
            Assert.AreEqual("", profile.ProposalComments);
            Assert.AreEqual(1900, profile.BirthDate.Year);
            Assert.AreEqual(1, profile.BirthDate.Month);
            Assert.AreEqual(1, profile.BirthDate.Day);
		    Assert.AreEqual(1, profile.ImAccounts.Count);
            Assert.AreEqual("skype", profile.ImAccounts[0].Type);
		    Assert.AreEqual("robbiedrysdale", profile.ImAccounts[0].Name);
            Assert.AreEqual(1, profile.PhoneNumbers.Count);
            Assert.AreEqual("mobile", profile.PhoneNumbers[0].Type);
            Assert.AreEqual("+353 87 9580000", profile.PhoneNumbers[0].Number);
		    Assert.AreEqual(1, profile.UrlResources.Count);
            Assert.AreEqual("Company Website", profile.UrlResources[0].Name);
		    Assert.AreEqual("http://www.robatron.com", profile.UrlResources[0].Url);
            Assert.AreEqual(3, profile.Skills.Count);
            Assert.AreEqual("Java", profile.Skills[0].Name);
            Assert.AreEqual(1, profile.TwitterAccounts.Count);
            Assert.AreEqual("23438000", profile.TwitterAccounts[0].ID);
            Assert.AreEqual("robdrysdale", profile.TwitterAccounts[0].Name);
		    Assert.AreEqual(8, profile.Positions.Count);
		    Assert.AreEqual("133861560", profile.Positions[0].ID);
		    Assert.AreEqual(true, profile.Positions[0].IsCurrent);
		    Assert.AreEqual(2010, profile.Positions[0].StartDate.Year);
		    Assert.AreEqual(6, profile.Positions[0].StartDate.Month);
		    Assert.IsNull(profile.Positions[0].StartDate.Day);
		    Assert.AreEqual("CBW at robatron, a Media Streaming startup.  Ongoing Technology research into potential new products.", profile.Positions[0].Summary);
		    Assert.AreEqual("CBW", profile.Positions[0].Title);
		    Assert.AreEqual("Computer Software", profile.Positions[0].Company.Industry);
		    Assert.AreEqual("robatron", profile.Positions[0].Company.Name);
            Assert.AreEqual(3, profile.Educations.Count);
            Assert.AreEqual(11962179, profile.Educations[0].ID);
            Assert.AreEqual("MSc Innovation & Technology Management", profile.Educations[0].Degree);
            Assert.AreEqual("University College Dublin", profile.Educations[0].SchoolName);
            Assert.AreEqual("Product Management, Project Management, New Business Development, Portfolio Managment, Supply Chain", profile.Educations[0].StudyField);
            Assert.AreEqual("Activities", profile.Educations[0].Activities);
            Assert.AreEqual("Notes", profile.Educations[0].Notes);
            Assert.AreEqual(2009, profile.Educations[0].EndDate.Year);
            Assert.AreEqual(2007, profile.Educations[0].StartDate.Year);
		    Assert.AreEqual(2, profile.Recommendations.Count);
		    Assert.AreEqual(236, profile.Recommendations[0].Text.Length);
		    Assert.AreEqual(RecommendationType.Colleague, profile.Recommendations[0].Type);
		    Assert.AreEqual("Damien", profile.Recommendations[0].Recommender.FirstName);
	    }

        [Test]
	    public void Search() 
        {
		    mockServer.ExpectNewRequest()
                .AndExpectUri("https://api.linkedin.com/v1/people-search:(people:(id,first-name,last-name,headline,industry,public-profile-url,picture-url,summary,site-standard-profile-request,api-standard-profile-request))?format=json&keywords=SpringSource")
				.AndExpectMethod(HttpMethod.GET)
		        .AndRespondWith(JsonResource("Search"), responseHeaders);

		    SearchParameters parameters = new SearchParameters();
		    parameters.Keywords = "SpringSource";

#if NET_4_0 || SILVERLIGHT_5
            LinkedInProfiles result = linkedIn.ProfileOperations.SearchAsync(parameters).Result;
#else
            LinkedInProfiles result = linkedIn.ProfileOperations.Search(parameters);
#endif

            AssertProfile(result.Profiles[0],
                   "lNJuCn-ejG", "Principal Software Engineer at SpringSource", "Mark", "Pollack", "Computer Software",
                   null, "", "http://www.linkedin.com/pub/mark-pollack/7/17a/b77", 
                   "http://www.linkedin.com/profile?viewProfile=&key=21314827&authToken=Vl4x&authType=OUT_OF_NETWORK&trk=api*a159628*s167852*", "OUT_OF_NETWORK:Vl4x");

            Assert.AreEqual(0, result.Start);
            Assert.AreEqual(10, result.Count);
            Assert.AreEqual(110, result.Total);
            Assert.AreEqual(10, result.Profiles.Count);
	    }
    }
}
