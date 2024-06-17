using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DemoEx.Models
{
    public static class DataBase
    {
        private static string connectionString = "Data Source=DESKTOP-SQB4B00\\DELUR;Initial Catalog=SessionEx;User ID=sa;Password=123";

        public static List<User> GetUsers()
        {
            var users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID, RoleID, Email, Pssword, FirstName, LastName, OfficeID, BirthDate, Image, Active FROM Users";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        RoleID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                        Email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Pssword = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        FirstName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        LastName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        OfficeID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        BirthDate = reader.IsDBNull(7) ? new DateTime(1950, 1, 1) : reader.GetDateTime(7),
                        Image = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Active = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    });
                }
            }

            return users;
        }

        public static List<Role> GetRoles()
        {
            var roles = new List<Role>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID, Title FROM Roles";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(new Role
                    {
                        ID = reader.GetInt32(0),
                        Title = reader.GetString(1)
                    });
                }
            }

            return roles;
        }

        public static List<Office> GetOffices()
        {
            var offices = new List<Office>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select ID, Tittle from Office";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    offices.Add(new Office
                    {
                        ID = reader.GetInt32(0),
                        Tittle = reader.GetString(1)
                    });
                }
            }
            return offices;
        }

        public static void RegUser(User user)
        {
            // Хэшируем пароль
            string hashedPassword = HashPassword(user.Pssword);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Email, Pssword, FirstName, LastName) VALUES (@Email, @Pssword, @FirstName, @LastName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Pssword", hashedPassword); // Сохраняем хэш пароля
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.ExecuteNonQuery();
            }
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Преобразуем пароль в массив байтов
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                // Хэшируем пароль
                byte[] hash = sha256.ComputeHash(bytes);
                // Преобразуем хэш в строку шестнадцатеричного формата
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hash)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }


        public static void AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Users (RoleID, Email, Pssword, FirstName, LastName, OfficeID, BirthDate, Image, Active) VALUES (@RoleID, @Email, @Pssword, @FirstName, @LastName, @OfficeID, @BirthDate, @Image, @Active)", connection);

                command.Parameters.AddWithValue("@RoleID", user.RoleID);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Pssword", user.Pssword);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@OfficeID", user.OfficeID);
                command.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                command.Parameters.AddWithValue("@Image", user.Image);
                command.Parameters.AddWithValue("@Active", user.Active);

                command.ExecuteNonQuery();
            }
        }
        public static void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Users SET RoleID = @RoleID, Email = @Email, Pssword = @Pssword, FirstName = @FirstName, LastName = @LastName, OfficeID = @OfficeID, BirthDate = @BirthDate, Image = @Image, Active = @Active WHERE ID = @ID",
                    connection);

                command.Parameters.AddWithValue("@RoleID", user.RoleID);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Pssword", user.Pssword);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@OfficeID", user.OfficeID);
                command.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                command.Parameters.AddWithValue("@Image", user.Image);
                command.Parameters.AddWithValue("@Active", user.Active);
                command.Parameters.AddWithValue("@ID", user.ID);

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Users WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", userId);
                command.ExecuteNonQuery();
            }
        }


        public static bool ValidateUser(string email, string password)
        {
            // Хэшируем введенный пользователем пароль

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Pssword = @Pssword";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Pssword", password); // Сравниваем с хэшем пароля из базы данных
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

    }
}
