using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeAlerter
{
    public class Group
    {
        //add an ID
        public string groupName { get; set; }
        public List<Member> members { get; set; }
        public int quantity { get; set; }

        public Group(string GroupName, List<Member> Members, int Quantity)
        {
            groupName = GroupName;
            members = Members;
            quantity = Quantity;
        }

        public void Add()
        {
            Data.groupsList.Add(this);
        }

        public void Remove()
        {
            Data.groupsList.Remove(this);
        }
    }
}
