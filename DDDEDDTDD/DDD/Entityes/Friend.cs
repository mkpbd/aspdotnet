using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Entityes
{
    internal class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FriendId { get; set;}

        public string GoOut(string name)
        {
            return name;
        }
    }
}
