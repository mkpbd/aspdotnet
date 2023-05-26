using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.valueOfObject
{
    /***
     * 
     * 
     * A domain value is a value that is specific to a particular domain.
     * For example, in the domain of banking, the domain value for "account number" would be a unique identifier for a bank account.
     * In the domain of e-commerce, the domain value for "product price" would be the price of a particular product.
     * 
     * 
     * In the domain of video games, the domain value for "health points" would be a number that represents how much damage a player can take before they die.
     * 
     * In the domain of social media, the domain value for "likes" would be a number that represents how many people have liked a particular post.
     * 
     * 
     * In the domain of dating, the domain value for "attractiveness" would be a number that represents how attractive a person is, according to a particular set of criteria.
     * 
     * *******/
    public class AccountNumber
    {

        private readonly string value;

        public AccountNumber(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            AccountNumber other = (AccountNumber)obj;

            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
