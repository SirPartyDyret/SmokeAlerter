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
	public partial class CreateGroupOptionsPage : ContentPage
	{
        

		public CreateGroupOptionsPage ()
        {
			InitializeComponent ();
		}

        private async void AddMembers_Clicked(object sender, EventArgs e)
        {
            var multiPage = new SelectMultipleBasePage<Member>(MainPage.memberList) { Title = "Add Group Members" };

            await Navigation.PushAsync(multiPage);
        }

        private async void CreateGroup_Clicked(object sender, EventArgs e)
        {
            if (Data.selectedMembersToAdd.Count == 0)
            {
                await DisplayAlert("No members", "Please add atleast one member.", "OK");
            }
            else if (Data.groupsList.Any(group => group.groupName == createGroupNameEntry.Text))
            {
                await DisplayAlert("Group name duplicate", "A group with that name already exists!", "OK");
            }
            else if (createGroupNameEntry.Text == "")
            {
                await DisplayAlert("No group name", "Please name your group.", "OK");
            }
            else
            {
                Group newGroup = new Group(createGroupNameEntry.Text, Data.selectedMembersToAdd, Data.selectedMembersToAdd.Count);
                newGroup.Add();

                //  Navigate to previous page on the stack
                await Navigation.PopAsync();

                Data.selectedMembersToAdd.Clear();
            }
        }
    }
}