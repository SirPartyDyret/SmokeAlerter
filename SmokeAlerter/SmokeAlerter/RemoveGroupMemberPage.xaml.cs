using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmokeAlerter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveGroupMemberPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public RemoveGroupMemberPage()
        {
            InitializeComponent();

            //  groupMembersListView.ItemsSource = Data.selectedGroup.members;  Don't think this works
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as Member;
                Data.selectedMembersToRemove.Add(selection);
            }
        }

        private void RemoveMember_Clicked(object sender, EventArgs e)
        {

        }

        //  Gets called when TextChanged in the memberSearchBar
        public void OnSearch()
        {
            var keyword = memberSearchBar.Text;
            groupMembersListView.ItemsSource = MainPage.memberList.Where(member => member.UserName.Contains(keyword));
        }
    }
}