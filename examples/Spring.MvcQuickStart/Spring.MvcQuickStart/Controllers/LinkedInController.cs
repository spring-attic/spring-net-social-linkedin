using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Spring.Social.OAuth1;
using Spring.Social.LinkedIn.Api;
using Spring.Social.LinkedIn.Connect;

namespace Spring.MvcQuickStart.Controllers
{
    public class LinkedInController : Controller
    {
        // Register your own LinkedIn app at https://www.linkedin.com/secure/developer.
        // Configure the OAuth Redirect URL with 'http://localhost/LinkedIn/Callback'
        // Set your API key & secret here
        private const string LinkedInApiKey = TODO;
        private const string LinkedInApiSecret = TODO;

        IOAuth1ServiceProvider<ILinkedIn> linkedInProvider =
            new LinkedInServiceProvider(LinkedInApiKey, LinkedInApiSecret);

        // GET: /LinkedIn/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: /LinkedIn/SignIn
        public ActionResult SignIn()
        {
            OAuthToken requestToken = linkedInProvider.OAuthOperations.FetchRequestTokenAsync("http://localhost/LinkedIn/Callback", null).Result;
            Session["RequestToken"] = requestToken;

            return Redirect(linkedInProvider.OAuthOperations.BuildAuthenticateUrl(requestToken.Value, null));
        }

        // GET: /LinkedIn/Callback
        public ActionResult Callback(string oauth_verifier)
        {
            OAuthToken requestToken = Session["RequestToken"] as OAuthToken;
            AuthorizedRequestToken authorizedRequestToken = new AuthorizedRequestToken(requestToken, oauth_verifier);
            OAuthToken token = linkedInProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null).Result;

            Session["AccessToken"] = token;

            ILinkedIn linkedInClient = linkedInProvider.GetApi(token.Value, token.Secret);
            LinkedInProfile profile = linkedInClient.ProfileOperations.GetUserProfileAsync().Result;
            return View(profile);
        }
    }
}
