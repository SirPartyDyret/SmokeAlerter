using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmokeAlerter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGroupMemberPage : ContentPage
    {

        public AddGroupMemberPage()
        {
            InitializeComponent();

            groupMembersListView.ItemsSource = MainPage.memberList;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as Member;
                Data.selectedMembersToAdd.Add(selection);
            }
        }

        //  Gets called when TextChanged in the memberSearchBar
        public void OnSearch()
        {
            var keyword = memberSearchBar.Text;
            groupMembersListView.ItemsSource = MainPage.memberList.Where(member => member.UserName.Contains(keyword));
        }

        //  Move this function to GroupOptionsPage
        public async void OnAddGroupMember()
        {
            if (Data.selectedMembersToAdd.Count != 0)
            {
                //  Navigate to previous page in the stack
                await Navigation.PopAsync();
                groupMembersListView.BackgroundColor = Color.White; // currently doesnt work
            }
        }
    }
}