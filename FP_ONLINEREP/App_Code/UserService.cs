using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP_ONLINEREP.App_Code
{
    public class UserService
    {
        public static IEnumerable<User> getAllUser()
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<User> result = from u in context.Users
                                           select u;
                return result.ToList();
            }
        }

        public static IEnumerable<User> getUserByName(string name)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<User> result = from u in context.Users
                                           where u.Name==name
                                           select u;
                return result.ToList();
            }
        }

        public static IEnumerable<User> getUserByEmail(string email)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<User> result = from u in context.Users
                                           where u.Email == email
                                           select u;
                return result.ToList();
            }
        }

        public static User getUserByNameOrEmail(string name, string email)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<User> result = from u in context.Users
                                           where u.Email == email || u.Name == name
                                           select u;
                return result.FirstOrDefault();
            }
        }

        public static IEnumerable<User> getUserByID(int id)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<User> result = from u in context.Users
                                           where u.UserId == id
                                           select u;
                return result.ToList();
            }
        }

        public static int getMaxId()
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                int result = (from u in context.Users
                             select u.UserId).Max();
                return result;
            }
        }

        public static void addNewUser(string uName, string email, string password)
        {
            int id = getMaxId() + 1;
            User newUser = new User();
            newUser.UserId = id;
            newUser.Name = uName;
            newUser.Password = password;
            newUser.Authority = 2;
            newUser.Email = email;
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public static void deleteUserById(int id)
        {
            User userToDelete = getUserByID(id).FirstOrDefault();

            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
        }

        public static void changePassword(string newpassword, int id)
        {
            
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                User userToChangePassword = (from u in context.Users
                                             where u.UserId == id
                                             select u).FirstOrDefault();

                userToChangePassword.Password = newpassword;
                context.SaveChanges();
            }
        }
    }
}