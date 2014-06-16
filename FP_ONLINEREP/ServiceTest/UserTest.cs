using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP_ONLINEREP.MockDB;
using FP_ONLINEREP;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSelectAllItem()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            List<User> result = tester.getAllUserTest();
            int expected = 3;
            int a = result.Count;
            Assert.AreEqual(expected, a,"Seharusnya 3");
        }

        [TestMethod]
        public void TestSelectByName()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            List<User> result = tester.getUserByName("ali");
            String expected = "ali";
            User testing = result.FirstOrDefault();
            Assert.AreEqual(expected,testing.Name, "Seharusnya ali");
        }

        [TestMethod]
        public void TestSelectByEmail()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            List<User> result = tester.getUserByEmail("asd");
            
            Assert.IsFalse(result.Any(), "harusnya false");
            //Assert.IsNotNull(result, "Seharusnya not null");
        }

        [TestMethod]
        public void TestSelectByNameorEmail()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            User result = tester.getUserByNameOrEmail("ali","ali@gmail.com");
            Assert.IsNotNull(result, "Seharusnya not null");
        }

        [TestMethod]
        public void TestSelectByID()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            List<User> result = tester.getUserByID(5);
            Assert.IsNotNull(result, "Seharusnya not null");
        }

        [TestMethod]
        public void TestSelectMaxID()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            int result = tester.getMaxId();
            int expected = 3;
            Assert.AreEqual(result,expected, "Seharusnya 3");
        }

        [TestMethod]
        public void TestAddNewUser()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            tester.addNewUser("adi","adi@gmail.com","12345");
            int expected = 4;
            List<User> result = tester.getAllUserTest();
            int a = result.Count;
            Assert.AreEqual(expected, a, "Seharusnya 4");
        }

        [TestMethod]
        public void TestDeleteUserbyId()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            tester.deleteUserById(3);
            int expected = 2;
            List<User> result = tester.getAllUserTest();
            int a = result.Count;
            Assert.AreEqual(expected, a, "Seharusnya 2");
        }

        [TestMethod]
        public void TestChangePassword()
        {
            MockUser tester = new MockUser();
            tester.createMockUser();
            tester.changePassword("123456789",3);
            string expected = "123456789";
            List<User> result = tester.getUserByID(3);
            string a = result.FirstOrDefault().Password;
            Assert.AreEqual(expected, a, "Seharusnya sama");
        }

    }
}
