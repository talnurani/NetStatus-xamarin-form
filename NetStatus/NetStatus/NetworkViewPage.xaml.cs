using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity.Abstractions;

namespace NetStatus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ConnectionDetails.Text == null)
                return;
            ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString();
            CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (CrossConnectivity.Current != null)
            {
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
            }
        }
        private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current!=null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
        }
    }
}
