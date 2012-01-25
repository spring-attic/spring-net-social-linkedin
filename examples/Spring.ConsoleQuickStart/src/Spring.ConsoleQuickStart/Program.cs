using System;
using System.Diagnostics;

using Spring.Json;
using Spring.Social.OAuth1;
using Spring.Social.LinkedIn.Api;
using Spring.Social.LinkedIn.Connect;

namespace Spring.ConsoleQuickStart
{
    class Program
    {
        // Register your own LinkedIn app at https://www.linkedin.com/secure/developer.
        // Set your API key & secret here
        private const string LinkedInApiKey = TODO;
        private const string LinkedInApiSecret = TODO;

        static void Main(string[] args)
        {
            try
            {
                LinkedInServiceProvider linkedInServiceProvider = new LinkedInServiceProvider(LinkedInApiKey, LinkedInApiSecret);

#if NET_4_0
                /* OAuth 'dance' */

                // Authentication using Out-of-band/PIN Code Authentication
                Console.Write("Getting request token...");
                OAuthToken oauthToken = linkedInServiceProvider.OAuthOperations.FetchRequestTokenAsync("oob", null).Result;
                Console.WriteLine("Done");

                string authenticateUrl = linkedInServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);
                Console.WriteLine("Redirect user for authentication: " + authenticateUrl);
                Process.Start(authenticateUrl);
                Console.WriteLine("Enter PIN Code from LinkedIn authorization page:");
                string pinCode = Console.ReadLine();

                Console.Write("Getting access token...");
                AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, pinCode);
                OAuthToken oauthAccessToken = linkedInServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
                Console.WriteLine("Done");

                /* API */

                ILinkedIn linkedIn = linkedInServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

                LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfileAsync().Result;
                Console.WriteLine("Authenticated user is " + profile.FirstName + " " + profile.LastName);

                // Use step by step debugging             
/*
                LinkedInProfile profileById = linkedIn.ProfileOperations.GetUserProfileByIdAsync("xO3SEJSVZN").Result;
                LinkedInProfile profileByPublicUrl = linkedIn.ProfileOperations.GetUserProfileByPublicUrlAsync("http://www.linkedin.com/in/bbaia").Result;
*/ 
                // Consume LinkedIn endpoints that are not covered by the API binding
/*
                string stringResult = linkedIn.RestOperations.GetForObjectAsync<string>("company-search?keywords=SpringSource&format=json").Result;
                JsonValue jsonResult = linkedIn.RestOperations.GetForObjectAsync<JsonValue>("job-search?job-title=LinkedIn&country-code=FR&format=json").Result;
*/
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                    {
                        // TODO: Update after error handler implementation
                        if (ex is Spring.Rest.Client.HttpResponseException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(((Spring.Rest.Client.HttpResponseException)ex).GetResponseBodyAsString());
                            return true;
                        }
                        return false;
                    });
            }
#else
                /* OAuth 'dance' */

                // Authentication using Out-of-band/PIN Code Authentication
                Console.Write("Getting request token...");
                OAuthToken oauthToken = linkedInServiceProvider.OAuthOperations.FetchRequestToken("oob", null);
                Console.WriteLine("Done");

                string authenticateUrl = linkedInServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);
                Console.WriteLine("Redirect user for authentication: " + authenticateUrl);
                Process.Start(authenticateUrl);
                Console.WriteLine("Enter PIN Code from LinkedIn authorization page:");
                string pinCode = Console.ReadLine();

                Console.Write("Getting access token...");
                AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, pinCode);
                OAuthToken oauthAccessToken = linkedInServiceProvider.OAuthOperations.ExchangeForAccessToken(requestToken, null);
                Console.WriteLine("Done");

                /* API */

                ILinkedIn linkedIn = linkedInServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

                LinkedInProfile profile = linkedIn.ProfileOperations.GetUserProfile();
                Console.WriteLine("Authenticated user is " + profile.FirstName + " " + profile.LastName);

                // Use step by step debugging             
/*
                LinkedInProfile profileById = linkedIn.ProfileOperations.GetUserProfileById("xO3SEJSVZN");
                LinkedInProfile profileByPublicUrl = linkedIn.ProfileOperations.GetUserProfileByPublicUrl("http://www.linkedin.com/in/bbaia");
*/
                // Consume LinkedIn endpoints that are not covered by the API binding
/*
                string stringResult = linkedIn.RestOperations.GetForObject<string>("company-search?keywords=SpringSource&format=json");
                JsonValue jsonResult = linkedIn.RestOperations.GetForObject<JsonValue>("job-search?job-title=LinkedIn&country-code=FR&format=json");
*/
            }
            // TODO: Update after error handler implementation
            catch (Spring.Rest.Client.HttpResponseException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(((Spring.Rest.Client.HttpResponseException)ex).GetResponseBodyAsString());
            }
#endif
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("--- hit <return> to quit ---");
                Console.ReadLine();
            }
        }
    }
}

