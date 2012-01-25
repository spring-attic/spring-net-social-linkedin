using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

using Spring.WindowsPhoneQuickStart.ViewModel;

namespace Spring.WindowsPhoneQuickStart.Views
{
    public partial class LinkedIn : PhoneApplicationPage
    {
        public LinkedIn()
        {
            InitializeComponent();

            this.DataContext = this.ViewModel;
            this.ViewModel.PropertyChanged += new PropertyChangedEventHandler(ViewModel_PropertyChanged);
        }

        public LinkedInViewModel ViewModel
        {
            get { return App.Current.LinkedInViewModel; }
        }

        // Overrided methods

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.ViewModel.IsAuthenticated)
            {
                this.ViewModel.Home();
            }
            else
            {
                this.ViewModel.Authenticate();
            }
        }

        // Event methods

        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // WebBrowser.Source property not bindable
            if (e.PropertyName == "AuthenticateUri")
            {
                this.WebBrowser.Navigate(this.ViewModel.AuthenticateUri);
            }
        }

        private void WebBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            if (this.ViewModel != null)
            {
                string url = e.Uri.ToString();
                if (url.StartsWith(LinkedInViewModel.CallbackUrl, StringComparison.OrdinalIgnoreCase))
                {
                    string verifier = url.Substring(url.LastIndexOf("oauth_verifier=") + 15);
                    this.ViewModel.AuthenticateCallback(verifier);
                }
            }
        }
    }
}