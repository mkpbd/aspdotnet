using DDD.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.AggregateRoot
{
    internal class GroupOfFriends : IGroupOfFriendsAggregateRoot
    {
        public string Name { get; set; }
        public List<Friend> Friends { get; set; }
        public void AddFriend(Friend friend)
        {
            Friends.Add(friend);
        }

        public void GoOut(string location)
        {
            foreach (var friend in Friends)
            {
                friend.GoOut(location);
            }
        }

        public void RemoveFriend(Friend friend)
        {
            Friends.Remove(friend);
        }
    }
}
