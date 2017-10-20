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
    public partial class EditGroupOptionsPage : ContentPage
    {
        public EditGroupOptionsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            editGroupNameEntry.Text = Data.selectedGroup.groupName;
            groupMembersLabel.Text = String.Join(",", Data.selectedMembersToAdd.Select(m => m.UserName));
            DisplayAlert("y", Data.selectedGroup.groupName, "g");
        }

        private async void DeleteGroup_Clicked(object sender, EventArgs e)
        {
            if (Data.groupsList.Contains(Data.selectedGroup))
            {
                Data.selectedGroup.Remove();
                GroupsPage.groupSelected = false;
                await Navigation.PopAsync();
            }
        }

        private async void SaveChanges_Clicked(object sender, EventArgs e)
        {
            if (editGroupNameEntry.Text != "")
            {
                Data.selectedGroup.groupName = editGroupNameEntry.Text;
                await Navigation.PopAsync();
            }
            else if (editGroupNameEntry.Text == "")
            {
                await DisplayAlert("No group name", "Please enter a group name.", "OK");
            }
        }

        private async void AddMembers_Clicked(object sender, EventArgs e)
        {
            var multiPage = new SelectMultipleBasePage<Member>(MainPage.memberList) { Title = "Add Group Members" };

            await Navigation.PushAsync(multiPage);
        }

        private async void RemoveMembers_Clicked(object sender, EventArgs e)
        {
            var multiPage = new SelectMultipleBasePage<Member>(Data.selectedGroup.members) { Title = "Remove Group Members" };

            await Navigation.PushAsync(multiPage);
        }
    }
}