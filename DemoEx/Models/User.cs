using System;

namespace DemoEx.Models
{
    public class User
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Pssword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OfficeID { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string Active { get; set; }
    }
}
