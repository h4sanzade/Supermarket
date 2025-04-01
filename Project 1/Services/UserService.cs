using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Project_1.Models;

namespace Project_1.Services
{
    public class UserService
    {
        private List<User> users;
        private string usersFilePath = "users.json";

        public UserService()
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(usersFilePath))
            {
                string json = File.ReadAllText(usersFilePath);
                users = JsonSerializer.Deserialize<List<User>>(json);
            }
            else
            {
                users = new List<User>();
            }
        }

        private void SaveUsers()
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(usersFilePath, json);
        }

        public void Register(User user)
        {
            users.Add(user);
            SaveUsers();
        }

        public User Login(string username, string password)
        {
            return users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public void UpdateProfile(User user, string newUsername, string newPassword, string newEmail)
        {
            var existingUser = users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.UserName = newUsername;
                existingUser.Password = newPassword;
                existingUser.Email = newEmail;
                SaveUsers();
            }
        }
    }
}
