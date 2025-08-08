using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemDomain
{
    [Serializable]
    public class User
    {
        // Properties
        private string firstName;
        private string lastName;
        private string emailAddress;

        // Constructors
        public User()
        {
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.emailAddress = string.Empty;
        }

        public User(string firstName, string lastName, string emailAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
        }

        // Getters and Setters
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        // Override equals method
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User other = (User)obj;
            return firstName.Equals(other.firstName) &&
                   lastName.Equals(other.lastName) &&
                   emailAddress.Equals(other.emailAddress);
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return (firstName + lastName + emailAddress).GetHashCode();
        }
    }
}