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
using System.Globalization;
using System.Collections.Generic;

using Spring.Json;

namespace Spring.Social.LinkedIn.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for LinkedIn full user's profile.
    /// </summary>
    /// <author>Bruno Baia</author>
    class LinkedInFullProfileDeserializer : LinkedInProfileDeserializer
    {
        public override object Deserialize(JsonValue json, JsonMapper mapper)
        {
            LinkedInFullProfile profile = (LinkedInFullProfile)base.Deserialize(json, mapper);

            profile.Associations = json.GetValueOrDefault<string>("associations", String.Empty);
            profile.BirthDate = DeserializeLinkedInDate(json.GetValue("dateOfBirth"));
            profile.ConnectionsCount = json.GetValue<int>("numConnections");
            profile.Distance = json.GetValue<int>("distance");
            profile.Educations = DeserializeEducations(json.GetValue("educations"));
            profile.Honors = json.GetValueOrDefault<string>("honors", String.Empty);
            profile.ImAccounts = DeserializeImAccounts(json.GetValue("imAccounts"));
            profile.Interests = json.GetValueOrDefault<string>("interests", String.Empty);
            profile.IsConnectionsCountCapped = json.GetValue<bool>("numConnectionsCapped");
            JsonValue locationJson = json.GetValue("location");
            profile.CountryCode = locationJson.GetValue("country").GetValue<string>("code");
            profile.Location = locationJson.GetValueOrDefault<string>("name", String.Empty);
            profile.MainAddress = json.GetValueOrDefault<string>("mainAddress", String.Empty);
            profile.PhoneNumbers = DeserializePhoneNumbers(json.GetValue("phoneNumbers"));
            profile.Positions = DeserializePositions(json.GetValue("positions"));
            profile.ProposalComments = json.GetValueOrDefault<string>("proposalComments", String.Empty);
            profile.Recommendations = DeserializeRecommendations(json.GetValue("recommendationsReceived"), mapper);
            profile.RecommendersCount = json.GetValueOrDefault<int?>("numRecommenders");
            profile.Skills = DeserializeSkills(json.GetValue("skills"));
            profile.Specialties = json.GetValueOrDefault<string>("specialties", String.Empty);
            profile.TwitterAccounts = DeserializeTwitterAccounts(json.GetValue("twitterAccounts"));
            profile.UrlResources = DeserializeUrlResources(json.GetValue("memberUrlResources"));

            return profile;
        }

        protected override LinkedInProfile CreateLinkedInProfile()
        {
            return new LinkedInFullProfile();
        }

        private static LinkedInDate DeserializeLinkedInDate(JsonValue json)
        {
            if (json != null)
            {
                return new LinkedInDate()
                {
                    Year = json.GetValueOrDefault<int?>("year"),
                    Month = json.GetValueOrDefault<int?>("month"),
                    Day = json.GetValueOrDefault<int?>("day")
                };
            }
            return null;
        }

        private static IList<string> DeserializeSkills(JsonValue json)
        {
            IList<string> skills = new List<string>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        skills.Add(itemJson.GetValue("skill").GetValue<string>("name"));
                    }
                }
            }
            return skills;
        }

        private static IList<ImAccount> DeserializeImAccounts(JsonValue json)
        {
            IList<ImAccount> imAccounts = new List<ImAccount>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        imAccounts.Add(new ImAccount()
                        {
                            Type = itemJson.GetValue<string>("imAccountType"),
                            Name = itemJson.GetValue<string>("imAccountName")
                        });
                    }
                }
            }
            return imAccounts;
        }

        private static IList<PhoneNumber> DeserializePhoneNumbers(JsonValue json)
        {
            IList<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        phoneNumbers.Add(new PhoneNumber()
                        {
                            Type = itemJson.GetValue<string>("phoneType"),
                            Number = itemJson.GetValue<string>("phoneNumber")
                        });
                    }
                }
            }
            return phoneNumbers;
        }

        private static IList<LinkedInUrl> DeserializeUrlResources(JsonValue json)
        {
            IList<LinkedInUrl> urlResources = new List<LinkedInUrl>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        if (itemJson.ContainsName("url"))
                        {
                            urlResources.Add(new LinkedInUrl()
                            {
                                Name = itemJson.GetValue<string>("name"),
                                Url = itemJson.GetValue<string>("url")
                            });
                        }
                    }
                }
            }
            return urlResources;
        }

        private static IList<TwitterAccount> DeserializeTwitterAccounts(JsonValue json)
        {
            IList<TwitterAccount> twitterAccounts = new List<TwitterAccount>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        twitterAccounts.Add(new TwitterAccount()
                        {
                            ID = itemJson.GetValue<string>("providerAccountId"),
                            Name = itemJson.GetValue<string>("providerAccountName")
                        });
                    }
                }
            }
            return twitterAccounts;
        }

        private static IList<Education> DeserializeEducations(JsonValue json)
        {
            IList<Education> educations = new List<Education>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        educations.Add(new Education()
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            SchoolName = itemJson.GetValueOrDefault<string>("schoolName", String.Empty),
                            StudyField = itemJson.GetValueOrDefault<string>("fieldOfStudy", String.Empty),
                            StartDate = DeserializeLinkedInDate(itemJson.GetValue("startDate")),
                            EndDate = DeserializeLinkedInDate(itemJson.GetValue("endDate")),
                            Degree = itemJson.GetValueOrDefault<string>("degree", String.Empty),
                            Activities = itemJson.GetValueOrDefault<string>("activities", String.Empty),
                            Notes = itemJson.GetValueOrDefault<string>("notes", String.Empty)
                        });
                    }
                }
            }
            return educations;
        }

        private static IList<Recommendation> DeserializeRecommendations(JsonValue json, JsonMapper mapper)
        {
            IList<Recommendation> recommendations = new List<Recommendation>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        recommendations.Add(new Recommendation()
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            Text = itemJson.GetValueOrDefault<string>("recommendationText", String.Empty),
                            Type = DeserializeRecommendationType(itemJson.GetValue("recommendationType")),
                            Recommender = mapper.Deserialize<LinkedInProfile>(itemJson.GetValue("recommender"))
                        });
                    }
                }
            }
            return recommendations;
        }

        private static RecommendationType DeserializeRecommendationType(JsonValue json)
        {
            if (json != null)
            {
                string code = json.GetValue<string>("code");
                switch (code.ToLowerInvariant())
                {
                    case "business-partner": return RecommendationType.BusinessPartner;
                    case "colleague": return RecommendationType.Colleague;
                    case "education": return RecommendationType.Education;
                    case "service-provider": return RecommendationType.ServiceProvider;
                }
            }
            return RecommendationType.Unknown;
        }

        private static IList<Position> DeserializePositions(JsonValue json)
        {
            IList<Position> positions = new List<Position>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        positions.Add(new Position()
                        {
                            ID = itemJson.GetValue<string>("id"),
                            Company = DeserializeCompany(itemJson.GetValue("company")),
                            Title = itemJson.GetValueOrDefault<string>("title", String.Empty),
                            Summary = itemJson.GetValueOrDefault<string>("summary", String.Empty),
                            IsCurrent = itemJson.GetValue<bool>("isCurrent"),
                            StartDate = DeserializeLinkedInDate(itemJson.GetValue("startDate")),
                            EndDate = DeserializeLinkedInDate(itemJson.GetValue("endDate"))
                        });
                    }
                }
            }
            return positions;
        }

        private static Company DeserializeCompany(JsonValue json)
        {
            if (json != null)
            {
                return new Company()
                {
                    ID = json.GetValueOrDefault<int>("id"),
                    Name = json.GetValueOrDefault<string>("name", String.Empty),
                    Industry = json.GetValueOrDefault<string>("industry", String.Empty),
                    Size = json.GetValueOrDefault<string>("size", String.Empty),
                    Type = json.GetValueOrDefault<string>("type", String.Empty),
                    Ticker = json.GetValueOrDefault<string>("ticker", String.Empty)
                };
            }
            return null;
        }
    }
}