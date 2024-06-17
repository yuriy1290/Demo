using DemoEx.Models;
using DemoEx;
using Xunit;

namespace TestsDemonstrateEx
{
    public class UnitTest1
    {
        [Fact]
        public void GetUsers_ShouldReturnUsers()
        {
            var users = DataBase.GetUsers();

            Assert.NotEmpty(users);
        }

        [Fact]
        public void GetRoles_ShouldReturnURoles()
        {
            var roles = DataBase.GetRoles();

            Assert.NotEmpty(roles);
        }

        [Fact]
        public void GetOffice_ShouldReturnOffice()
        {
            var offices = DataBase.GetOffices();

            Assert.NotEmpty(offices);
        }

       
        [Fact]
        public void AddUser_ShouldInsertUser()
        {
            // Arrange
            var user = new User
            {
                RoleID = 1,
                Email = "addsssuser@example.com",
                Pssword = "password",
                FirstName = "Add",
                LastName = "User",
                OfficeID = 1,
                BirthDate = DateTime.Now,
                Image = "",
                Active = "Active"
            };

            // Act
            DataBase.AddUser(user);

            // Assert
            var users = DataBase.GetUsers();
            Assert.Contains(users, u => u.Email == user.Email);
        }




    }
}