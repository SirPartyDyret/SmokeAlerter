using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeAlerter
{
    public class Data
    {
        public static List<Group> groupsList = new List<Group>();
        public static List<Member> selectedMembersToAdd = new List<Member>();
        public static List<Member> selectedMembersToRemove = new List<Member>();
        public static Group selectedGroup;
    }


}
