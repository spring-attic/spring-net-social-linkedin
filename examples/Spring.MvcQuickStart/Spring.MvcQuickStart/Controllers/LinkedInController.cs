using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
        private const string LinkedInApiKey = TODO ;
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
            var parameters = new NameValueCollection();
           // parameters.Add("scope", "r_basicprofile r_fullprofile"); //r_emailaddress");
            //TODO: Verify your port number.
            OAuthToken requestToken = linkedInProvider.OAuthOperations.FetchRequestTokenAsync("http://localhost/LinkedIn/Callback", parameters).Result;
            Session["RequestToken"] = requestToken;

            return Redirect(linkedInProvider.OAuthOperations.BuildAuthenticateUrl(requestToken.Value, null));
        }

        // GET: /LinkedIn/Callback
        public ActionResult Callback(string oauth_verifier)
        {
            var requestToken = Session["RequestToken"] as OAuthToken;
            var authorizedRequestToken = new AuthorizedRequestToken(requestToken, oauth_verifier);
            OAuthToken token = linkedInProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null).Result;

            Session["AccessToken"] = token;

            ILinkedIn linkedInClient = linkedInProvider.GetApi(token.Value, token.Secret);
            LinkedInProfile profile = linkedInClient.ProfileOperations.GetUserProfileAsync().Result;
            var fullProfile = linkedInClient.ProfileOperations.GetUserFullProfileAsync().Result;
            return View(profile);
        }

        // GET: /LinkedIn/SignIn
        public ActionResult SignInFullProfile()
        {
            var parameters = new NameValueCollection {{"scope", "r_basicprofile r_fullprofile"}};
            //TODO: Verify your port number.
            OAuthToken requestToken = linkedInProvider.OAuthOperations.FetchRequestTokenAsync("http://localhost/LinkedIn/CallbackFullProfile", parameters).Result;
            Session["RequestToken"] = requestToken;

            return Redirect(linkedInProvider.OAuthOperations.BuildAuthenticateUrl(requestToken.Value, null));
        }

        // GET: /LinkedIn/Callback
        public ActionResult CallbackFullProfile(string oauth_verifier)
        {
            var requestToken = Session["RequestToken"] as OAuthToken;
            var authorizedRequestToken = new AuthorizedRequestToken(requestToken, oauth_verifier);
            OAuthToken token = linkedInProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null).Result;

            Session["AccessToken"] = token;

            ILinkedIn linkedInClient = linkedInProvider.GetApi(token.Value, token.Secret);
            var fullProfile = linkedInClient.ProfileOperations.GetUserFullProfileAsync().Result;
            return View("FullProfile", fullProfile);
        }
    }
}
