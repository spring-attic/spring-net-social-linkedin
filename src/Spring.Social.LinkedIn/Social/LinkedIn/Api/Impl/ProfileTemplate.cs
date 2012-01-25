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

#if NET_4_0 || SILVERLIGHT_5
using System.Threading.Tasks;
#endif

using Spring.Http;
using Spring.Rest.Client;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="IProfileOperations"/>, providing a binding to LinkedIn's profiles-oriented REST resources.
    /// </summary>
    /// <author>Bruno Baia</author>
    class ProfileTemplate : IProfileOperations
    {
        private const string ProfileUrl = "people/{id}:(id,first-name,last-name,headline,industry,site-standard-profile-request,public-profile-url,picture-url,summary)?format=json";

        private RestTemplate restTemplate;

        public ProfileTemplate(RestTemplate restTemplate)
        {
            this.restTemplate = restTemplate;
        }

        #region IProfileOperations Members

#if NET_4_0 || SILVERLIGHT_5
        public Task<LinkedInProfile> GetUserProfileAsync()
        {
            return this.restTemplate.GetForObjectAsync<LinkedInProfile>(ProfileUrl, "~");
        }

        public Task<LinkedInProfile> GetUserProfileByIdAsync(string id)
        {
            return this.restTemplate.GetForObjectAsync<LinkedInProfile>(ProfileUrl, "id=" + id);
        }

        public Task<LinkedInProfile> GetUserProfileByPublicUrlAsync(string url)
        {
            return this.restTemplate.GetForObjectAsync<LinkedInProfile>(ProfileUrl, "url=" + HttpUtils.UrlEncode(url));
        }
#else
#if !SILVERLIGHT
        public LinkedInProfile GetUserProfile()
        {
            return this.restTemplate.GetForObject<LinkedInProfile>(ProfileUrl, "~");
        }

        public LinkedInProfile GetUserProfileById(string id)
        {
            return this.restTemplate.GetForObject<LinkedInProfile>(ProfileUrl, "id=" + id);
        }

        public LinkedInProfile GetUserProfileByPublicUrl(string url)
        {
            return this.restTemplate.GetForObject<LinkedInProfile>(ProfileUrl, "url=" + HttpUtils.UrlEncode(url));
        }
#endif

        public RestOperationCanceler GetUserProfileAsync(Action<RestOperationCompletedEventArgs<LinkedInProfile>> operationCompleted)
        {
            return this.restTemplate.GetForObjectAsync<LinkedInProfile>(ProfileUrl, operationCompleted, "~");
        }

        public RestOperationCanceler GetUserProfileByIdAsync(string id, Action<RestOperationCompletedEventArgs<LinkedInProfile>> operationCompleted)
        {
            return this.restTemplate.GetForObjectAsync<LinkedInProfile>(ProfileUrl, operationCompleted, "id=" + id);
        }

#if !WINDOWS_PHONE
        public RestOperationCanceler GetUserProfileByPublicUrlAsync(string url, Action<RestOperationCompletedEventArgs<LinkedInProfile>> operationCompleted)
        {
            return this.restTemplate.GetForObjectAsync<LinkedInProfile>(ProfileUrl, operationCompleted, "url=" + HttpUtils.UrlEncode(url));
        }
#endif
#endif

        #endregion
    }
}