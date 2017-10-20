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
    public partial class Splash : ContentPage
    {
        string userName = Helpers.Settings.UserName;
        string passWord = Helpers.Settings.PassWord;

        public Splash()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var mainpage = new NavigationPage(new SmokeAlerter.MainPage());

            if (userName == String.Empty || passWord == String.Empty)
            {
                await Navigation.PushModalAsync(mainpage);
            }

            else
            {
                var masterpage = new NavigationPage(new SmokeAlerter.MasterPage());

                if (MainPage.memberList.Any(item => item.UserName == userName) && MainPage.memberList.Any(item2 => item2.Password == passWord))
                {
                    await Navigation.PushModalAsync(masterpage);
                }

                else
                {
                    Helpers.Settings.UserName = null;
                    Helpers.Settings.PassWord = null;

                    await Navigation.PushModalAsync(mainpage);
                }
            }
        }
    }
}