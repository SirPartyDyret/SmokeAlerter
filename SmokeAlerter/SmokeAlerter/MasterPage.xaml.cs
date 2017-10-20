using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmokeAlerter
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
		public MasterPage ()
		{
			InitializeComponent ();
		}

        public void OnSmoke() { }

        public async void OnGroupMngmt()
        {
            var GroupsPage = new SmokeAlerter.GroupsPage();

            await Navigation.PushAsync(GroupsPage);
        }
	}
}