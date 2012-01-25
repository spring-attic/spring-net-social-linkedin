using System;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Collections.Generic;

using Spring.Social.OAuth1;
using Spring.Social.LinkedIn.Api;

namespace Spring.WindowsPhoneQuickStart.ViewModel
{
    public class LinkedInViewModel : INotifyPropertyChanged
    {
        private const string OAuthTokenKey = "OAuthToken";
        public const string CallbackUrl = "http://localhost/LinkedIn/Callback";

        private OAuthToken requestOAuthToken;
        private Uri authenticateUri;
        private LinkedInProfile profile;

        public IOAuth1ServiceProvider<ILinkedIn> LinkedInServiceProvider { get; set; }

        public bool IsAuthenticated
        {
            get
            {
                return this.OAuthToken != null;
            }
        }

        public OAuthToken OAuthToken
        {
            get
            {
                return this.LoadSetting<OAuthToken>(OAuthTokenKey, null);
            }
            set
            {
                this.SaveSetting(OAuthTokenKey, value);
                NotifyPropertyChanged("IsAuthenticated");
            }
        }

        public Uri AuthenticateUri
        {
            get
            {
                return this.authenticateUri;
            }
            set
            {
                this.authenticateUri = value;
                NotifyPropertyChanged("AuthenticateUri");
            }
        }

        public LinkedInProfile Profile
        {
            get
            {
                return this.profile;
            }
            set
            {
                this.profile = value;
                NotifyPropertyChanged("Profile");
            }
        }

        public void Authenticate()
        {
            this.LinkedInServiceProvider.OAuthOperations.FetchRequestTokenAsync(CallbackUrl, null,
                r =>
                {
                    this.requestOAuthToken = r.Response;
                    this.AuthenticateUri = new Uri(this.LinkedInServiceProvider.OAuthOperations.BuildAuthenticateUrl(r.Response.Value, null));
                });
        }

        public void AuthenticateCallback(string verifier)
        {
            AuthorizedRequestToken authorizedRequestToken = new AuthorizedRequestToken(this.requestOAuthToken, verifier);
            this.LinkedInServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null,
                r =>
                {
                    this.OAuthToken = r.Response;
                    this.Home();
                });
        }

        public void Home()
        {
            ILinkedIn linkedInClient = this.LinkedInServiceProvider.GetApi(this.OAuthToken.Value, this.OAuthToken.Secret);
            linkedInClient.ProfileOperations.GetUserProfileAsync(
                r =>
                {
                    this.Profile = r.Response;
                });
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        private void SaveSetting(string key, object value)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(key))
            {
                settings[key] = value;
            }
            else
            {
                settings.Add(key, value);
            }
        }

        private T LoadSetting<T>(string key, T defaultValue)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(key))
            {
                settings.Add(key, defaultValue);
            }
            return (T)settings[key];
        }
    }
}
