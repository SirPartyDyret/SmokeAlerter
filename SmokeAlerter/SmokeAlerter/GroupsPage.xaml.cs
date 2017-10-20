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
    public partial class GroupsPage : ContentPage
    {
        public static bool groupSelected = false;

        public GroupsPage()
        {
            InitializeComponent();
            groupListView.ItemsSource = Data.groupsList; 

        }

        private void EnableGroupButtons()
        {
            if (groupSelected)
            {
                editGroupButton.IsEnabled = true;
                deleteGroupButton.IsEnabled = true;
            }
        }

        private void DisableGroupButtons()
        {
            if (!groupSelected)
            {
                editGroupButton.IsEnabled = false;
                deleteGroupButton.IsEnabled = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            groupSelected = false;
            Data.selectedGroup = null;
            groupListView.ItemsSource = null;
            groupListView.ItemsSource = Data.groupsList;
            DisableGroupButtons();
        }

        public async void AddGroup_Clicked(object sender, EventArgs e)
        {
            var createGroupOptionsPage = new SmokeAlerter.CreateGroupOptionsPage();
            await Navigation.PushAsync(createGroupOptionsPage);
        }

        public async void EditGroup_Clicked(object sender, EventArgs e)
        {
            if (Data.groupsList.Contains(Data.selectedGroup))
            {
                var editGroupOptionsPage = new SmokeAlerter.EditGroupOptionsPage();
                await Navigation.PushAsync(editGroupOptionsPage);
            }
        }

        private void DeleteGroup_Clicked(object sender, EventArgs e)
        {
            if (Data.groupsList.Contains(Data.selectedGroup))
            {
                groupSelected = false;
                Data.groupsList.Remove(Data.selectedGroup);
                groupListView.ItemsSource = null;
                groupListView.ItemsSource = Data.groupsList;

                DisableGroupButtons();
            }
        }

        private void OnGroupSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Data.selectedGroup = e.SelectedItem as Group;
                groupSelected = true;

                EnableGroupButtons();
            }
        }

        //  TODO: Make an OnGroupDeselected, that changes the color of the selected object back to white.
    }
}