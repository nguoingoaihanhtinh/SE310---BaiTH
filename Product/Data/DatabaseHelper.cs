using MySql.Data.MySqlClient;
using Product.Models;
using System;
using System.Collections.Generic;

namespace Product.Data
{

    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Food> GetAllFoods()
        {
            var foods = new List<Food>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Foods", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foods.Add(new Food
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Description = reader.GetString("Description"),
                            Price = reader.GetDecimal("Price"),
                            ImageUrl = reader.GetString("ImageUrl")
                        });
                    }
                }
            }

            return foods;
        }
        public List<User> getAllUser()
        {
            var users = new List<User>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Users", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            Password = reader.GetString("Password"),
                            Email = reader.GetString("Email")
                        });
                    }
                }
            }

            return users;
        }

        public void AddFood(Food food)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Foods (Name, Description, Price, ImageUrl) VALUES (@Name, @Description, @Price, @ImageUrl)", connection);
                command.Parameters.AddWithValue("@Name", food.Name);
                command.Parameters.AddWithValue("@Description", food.Description);
                command.Parameters.AddWithValue("@Price", food.Price);
                command.Parameters.AddWithValue("@ImageUrl", food.ImageUrl);
                command.ExecuteNonQuery();
            }
        }
        public Food GetFoodById(int id)
        {
            Food food = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Foods WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        food = new Food
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Description = reader.GetString("Description"),
                            Price = reader.GetDecimal("Price"),
                            ImageUrl = reader.GetString("ImageUrl")
                        };
                    }
                }
            }

            return food;
        }
        public User GetUserById(int id)
        {
            User user = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            Password = reader.GetString("Password"), // Assuming you need this, but consider security
                            Email = reader.GetString("Email")
                        };
                    }
                }
            }

            return user;
        }
        public void UpdateFood(Food food)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Foods SET Name = @Name, Description = @Description, Price = @Price, ImageUrl = @ImageUrl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", food.Id);
                command.Parameters.AddWithValue("@Name", food.Name);
                command.Parameters.AddWithValue("@Description", food.Description);
                command.Parameters.AddWithValue("@Price", food.Price);
                command.Parameters.AddWithValue("@ImageUrl", food.ImageUrl);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFood(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Foods WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
        public void AddUser(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.ExecuteNonQuery();
            }
        }


        public void UpdateUser(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Users SET Username = @Username, Email = @Email WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.ExecuteNonQuery(); // Execute the update command
            }
        }

        public void DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

}