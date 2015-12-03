using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class User : BasedEntity
    {
        protected virtual string Email { get; set; }
        protected virtual string Password { get; set; }
        protected virtual string FirstName { get; set; }
        protected virtual string LastName { get; set; }
        protected virtual string MiddleName { get; set; }
        protected virtual DateTime RegistrationDate { get; set; }
        protected virtual Role Role { get; set; }

        //Added for json serialization
        public string EMAIL { get { return Email; } set { Email = value; } }
        public string PASSWORD { get { return Password; } set { Password = value; } }
        public string FIRSTNAME { get { return FirstName; } set { FirstName = value; } }
        public string LASTNAME { get { return LastName; } set { LastName = value; } }
        public string MIDDLENAME { get { return MiddleName; } set { MiddleName = value; } }
        public DateTime REGISTRATIONDATE { get { return RegistrationDate; } set { RegistrationDate = value; } }
        public Role ROLE { get { return Role; } set { Role = value; } }

        public User() { }

        public User(Guid Id, string Email, string Password, string FirstName, string LastName, string MiddleName, DateTime RegistrationDate, Role Role)
        {
            this.Id = Id;
            this.Email = Email;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.RegistrationDate = RegistrationDate;
            this.Role = Role;
        }

    }
}