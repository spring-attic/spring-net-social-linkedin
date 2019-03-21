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
using System.Globalization;
using System.Collections.Generic;

using Spring.Json;

namespace Spring.Social.LinkedIn.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for LinkedIn full user's profile.
    /// </summary>
    /// <author>Bruno Baia</author>
    /// <author>James Fleming</author>
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
            profile.Email = json.GetValueOrDefault<string>("emailAddress");
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
            profile.Specialties = json.GetValueOrDefault<string>("specialties", String.Empty);
            profile.TwitterAccounts = DeserializeTwitterAccounts(json.GetValue("twitterAccounts"));
            profile.UrlResources = DeserializeUrlResources(json.GetValue("memberUrlResources"));
            profile.Certifications = DeserializeCertifications(json.GetValue("certifications"));
            profile.Skills = DeserializeSkills(json.GetValue("skills"));
            profile.Publications = DeserializePublications(json.GetValue("publications"));         
            profile.Courses = DeserializeCourses(json.GetValue("courses"));
            profile.Languages = DeserializeLanguages(json.GetValue("languages"));

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
                            ID = itemJson.GetValueOrDefault<string>("id"),
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

        private static IList<Skill> DeserializeSkills(JsonValue json)
        {
            IList<Skill> skills = new List<Skill>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        skills.Add(new Skill
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            Name = itemJson.ContainsName("skill") ? itemJson.GetValue("skill").GetValueOrDefault<string>("name", String.Empty) : String.Empty,
                            Proficiency = DeserializeProficiency(itemJson.GetValue("proficiency")),
                            Years = DeserializeYears(itemJson.GetValue("years"))
                        });
                    }
                }
            }
            return skills;
        }

        private static Proficiency DeserializeProficiency(JsonValue json)
        {
            if (json != null)
            {
                return new Proficiency()
                {
                    Level = json.GetValueOrDefault<string>("level", String.Empty),
                    Name = json.GetValueOrDefault<string>("name", String.Empty)
                };
            }
            return null;
        }

        private static Years DeserializeYears(JsonValue json)
        {
            if (json != null)
            {
                return new Years()
                {
                    ID = json.GetValueOrDefault<int>("id"),
                    Name = json.GetValueOrDefault<string>("name", String.Empty)
                };
            }
            return null;
        }

        private static IList<Certification> DeserializeCertifications(JsonValue json)
        {
            IList<Certification> certifications = new List<Certification>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        certifications.Add(new Certification()
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            Name = itemJson.GetValueOrDefault<string>("name", String.Empty),
                            AuthorityName = itemJson.ContainsName("authority") ? itemJson.GetValue("authority").GetValueOrDefault<string>("name", String.Empty) : String.Empty,
                            Number = itemJson.GetValueOrDefault<string>("number", String.Empty),
                            StartDate = DeserializeLinkedInDate(itemJson.GetValue("startDate")),
                            EndDate = DeserializeLinkedInDate(itemJson.GetValue("endDate"))
                        });
                    }
                }
            }
            return certifications;
        }

        private static IList<Course> DeserializeCourses(JsonValue json)
        {
            IList<Course> courses = new List<Course>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        courses.Add(new Course()
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            Name = itemJson.GetValueOrDefault<string>("name", String.Empty),
                            Number = itemJson.GetValueOrDefault<string>("number", String.Empty)
                        });
                    }
                }
            }
            return courses;
        }

        private static IList<Language> DeserializeLanguages(JsonValue json)
        {
            IList<Language> languages = new List<Language>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        languages.Add(new Language
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            Name = itemJson.ContainsName("language") ? itemJson.GetValue("language").GetValueOrDefault<string>("name", String.Empty) : String.Empty,
                            Proficiency = DeserializeProficiency(itemJson.GetValue("proficiency"))
                        });
                    }
                }
            }
            return languages;
        }

        private static IList<Publication> DeserializePublications(JsonValue json)
        {
            IList<Publication> publications = new List<Publication>();
            if (json != null)
            {
                JsonValue valuesJson = json.GetValue("values");
                if (valuesJson != null)
                {
                    foreach (JsonValue itemJson in valuesJson.GetValues())
                    {
                        publications.Add(new Publication()
                        {
                            ID = itemJson.GetValueOrDefault<int>("id"),
                            Title = itemJson.GetValueOrDefault<string>("title", String.Empty),
                            PublisherName = itemJson.ContainsName("publisher") ? itemJson.GetValue("publisher").GetValueOrDefault<string>("name", String.Empty) : String.Empty,
                            Summary = itemJson.GetValueOrDefault<string>("summary", String.Empty),
                            Url = itemJson.GetValueOrDefault<string>("url"),
                            Date = DeserializeLinkedInDate(itemJson.GetValue("date"))
                        });
                    }
                }
            }
            return publications;
        }
    }
}