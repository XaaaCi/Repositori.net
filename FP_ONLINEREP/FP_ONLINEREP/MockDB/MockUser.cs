using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FP_ONLINEREP.MockDB;

namespace FP_ONLINEREP.MockDB
{
    public class MockUser
    {
        public static List<User> Users = new List<User>();

        public MockUser()
        {
            List<User> Users = new List<User>();
        }

        public void createMockUser()
        {
            //isi data variable mock user;
            User user1 = new User();
            user1.UserId =(1);
            user1.Name = ("budi");
            user1.Email = ("budi@gmail.com");
            user1.Password = ("12345");
            user1.Authority = (2);

            User user2 = new User();
            user2.UserId = (2);
            user2.Name = ("ali");
            user2.Email = ("ali@gmail.com");
            user2.Password = ("12345");
            user2.Authority = (2);

            User user3 = new User();
            user3.UserId = (3);
            user3.Name = ("bambang");
            user3.Email = ("bambang@gmail.com");
            user3.Password = ("12345");
            user3.Authority = (2);

            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
        }

        public List<User> getAllUserTest()
        {
            IEnumerable<User> result = from u in Users
                                       select u;
            return result.ToList();
        }

        public List<User> getUserByName(string name)
        { 
                IEnumerable<User> result = from u in Users
                                           where u.Name == name
                                           select u;
                return result.ToList();            
        }

        public List<User> getUserByEmail(string email)
        {
               IEnumerable<User> result = from u in Users
                                           where u.Email == email
                                           select u;
                return result.ToList();
        }

        public User getUserByNameOrEmail(string name, string email)
        {
                IEnumerable<User> result = from u in Users
                                           where u.Email == email || u.Name == name
                                           select u;
                return result.FirstOrDefault();
        }

        public List<User> getUserByID(int id)
        {
                IEnumerable<User> result = from u in Users
                                           where u.UserId == id
                                           select u;
                return result.ToList();
        }

        public int getMaxId()
        {
                int result = (from u in Users
                              select u.UserId).Max();
                return result;
        }

        public void addNewUser(string uName, string email, string password)
        {
            int id = getMaxId() + 1;
            User newUser = new User();
            newUser.UserId = id;
            newUser.Name = uName;
            newUser.Password = password;
            newUser.Authority = 2;
            newUser.Email = email;
            Users.Add(newUser);
        }

        public void deleteUserById(int id)
        {
            User userToDelete = getUserByID(id).FirstOrDefault();
            Users.Remove(userToDelete);
        }

        public void changePassword(string newpassword, int id)
        {
            User userToChangePassword = (from u in Users
                                         where u.UserId == id
                                         select u).FirstOrDefault();

            userToChangePassword.Password = newpassword;

        }
    }
}