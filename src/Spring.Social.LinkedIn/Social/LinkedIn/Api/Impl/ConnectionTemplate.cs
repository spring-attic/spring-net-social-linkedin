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

#if NET_4_0 || SILVERLIGHT_5
using System.Threading.Tasks;
#endif

using Spring.Http;
using Spring.Rest.Client;

namespace Spring.Social.LinkedIn.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="IConnectionOperations"/>, providing a binding to LinkedIn's connections-oriented REST resources.
    /// </summary>
    /// <author>Robert Drysdale</author>
    /// <author>Bruno Baia  (.NET)</author>
    class ConnectionTemplate : IConnectionOperations
    {
        private RestTemplate restTemplate;

        public ConnectionTemplate(RestTemplate restTemplate)
        {
            this.restTemplate = restTemplate;
        }

        #region IConnectionOperations Members

#if NET_4_0 || SILVERLIGHT_5
        public Task<IList<LinkedInProfile>> GetConnectionsAsync()
        {
            return this.restTemplate.GetForObjectAsync<IList<LinkedInProfile>>("people/~/connections:(id,first-name,last-name,headline,industry,site-standard-profile-request,public-profile-url,picture-url,summary)?format=json");
        }

        public Task<NetworkStatistics> GetNetworkStatisticsAsync()
        {
            return this.restTemplate.GetForObjectAsync<NetworkStatistics>("people/~/network/network-stats?format=json");
        }
#else
#if !SILVERLIGHT
        public IList<LinkedInProfile> GetConnections()
        {
            return this.restTemplate.GetForObject<IList<LinkedInProfile>>("people/~/connections:(id,first-name,last-name,headline,industry,site-standard-profile-request,public-profile-url,picture-url,summary)?format=json");
        }

        public NetworkStatistics GetNetworkStatistics()
        {
            return this.restTemplate.GetForObject<NetworkStatistics>("people/~/network/network-stats?format=json");
        }
#endif

        public RestOperationCanceler GetConnectionsAsync(Action<RestOperationCompletedEventArgs<IList<LinkedInProfile>>> operationCompleted)
        {
            return this.restTemplate.GetForObjectAsync<IList<LinkedInProfile>>("people/~/connections:(id,first-name,last-name,headline,industry,site-standard-profile-request,public-profile-url,picture-url,summary)?format=json", operationCompleted);
        }

        public RestOperationCanceler GetNetworkStatisticsAsync(Action<RestOperationCompletedEventArgs<NetworkStatistics>> operationCompleted)
        {
            return this.restTemplate.GetForObjectAsync<NetworkStatistics>("people/~/network/network-stats?format=json", operationCompleted);
        }
#endif

        #endregion
    }
}