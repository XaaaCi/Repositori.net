using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FP_ONLINEREP.App_Code;

namespace FP_ONLINEREP.App_Code
{
    public class LoginAndRegisterController
    {
        public static bool tryLogin(string uName, string password)
        {
            User result = UserService.getUserByNameOrEmail(uName, uName);
            if (result.Password == password)
            {
                return true;
            }
            return false;
            
        }
    }
}