using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Xml.Linq;

namespace SmokeAlerter
{
    public partial class MainPage : ContentPage
    {
        public static List<Member> memberList;

        public MainPage()
        {
            memberList = new List<Member>();

            memberList.Add(new Member("Morten", "123"));
            memberList.Add(new Member("Andreas", "123"));
            memberList.Add(new Member("Christian", "123"));
            memberList.Add(new Member("Minik", "123"));

            InitializeComponent();
        }

        public void OnCreate(object o, EventArgs e)
        {
            memberList.Add(new Member(
                            Username.Text,
                            Password.Text
                                    )
                            );

            DisplayAlert("Account creation", "Successfully created the account.", "Cancel");
        }

        public async void OnLogin(object o, EventArgs e)
        {
            var MasterPage = new NavigationPage(new SmokeAlerter.MasterPage());

            if (memberList.Any(str => str.UserName == Username.Text) & memberList.Any(str2 => str2.Password == Password.Text))
            {
                await Navigation.PushModalAsync(MasterPage);
            }
        }

        public void remMeSwitch_IsClicked(object o, EventArgs e)
        {
            if (Username.Text != String.Empty & Password.Text != String.Empty)
            {
                Helpers.Settings.UserName = Username.Text.Trim();
                Helpers.Settings.PassWord = Password.Text.Trim();
            }
        }
    }
}
