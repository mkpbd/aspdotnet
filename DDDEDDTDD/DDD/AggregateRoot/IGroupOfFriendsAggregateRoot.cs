using DDD.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.AggregateRoot
{
    internal interface IGroupOfFriendsAggregateRoot
    {
        void AddFriend(Friend friend);
        void RemoveFriend(Friend friend);
        void GoOut(string location);
    }
}
