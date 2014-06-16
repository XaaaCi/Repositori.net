using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP_ONLINEREP.MockDB;
using FP_ONLINEREP;
using System.Linq;

namespace ServiceTest
{
    [TestClass]
    public class FileTest
    {        
        [TestMethod]
        public void TestMakeNewFile()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            File result = tester.makeNewFile("datmin","content",12,1);
            string expected = "datmin";
            Assert.AreEqual(expected, result.Name, "Seharusnya sama");
        }

        [TestMethod]
        public void TestGetAllFile()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            List<File> result = tester.getAllFile();
            int expected = 3;
            Assert.AreEqual(expected, result.Count, "Seharusnya 3");
        }

        [TestMethod]
        public void TestGetfileById()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            List<File> result = tester.getFileByID(2);
            string expected = "adm.doc";
            Assert.AreEqual(expected, result.FirstOrDefault().Name, "Seharusnya sama");
        }

        [TestMethod]
        public void TestGetfileByOwner()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            List<File> result = tester.getFileByOwner(1);
            string expected = "ssd.doc";
            Assert.AreEqual(expected, result.FirstOrDefault().Name, "Seharusnya sama");
        }

        [TestMethod]
        public void TestSearchFile()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            List<File> result = tester.searchFile("sd");
            string expected = "ssd.doc";
            Assert.AreEqual(expected, result.FirstOrDefault().Name, "Seharusnya sama");
        }

        [TestMethod]
        public void TestDeleteFile()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            tester.deleteFile(1);
            List<File> result = tester.getAllFile();
            int expected = 2;
            Assert.AreEqual(expected, result.Count, "Seharusnya 2");
        }

        [TestMethod]
        public void TestMaxId()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            tester.deleteFile(3);
            int a = tester.getMaxId();
            int expected = 2;
            Assert.AreEqual(expected, a, "Seharusnya 2");
        }

        [TestMethod]
        public void TestAddNewFile()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            File file4 = new File();
            file4.Name = "kk.doc";
            file4.ContentType = " ";
            file4.Size = 100;
            file4.UserId = 1;
            file4.FileId = 4;
            tester.addNewFile(file4);
            List<File> result = tester.getAllFile();
            int expected = 4;
            Assert.AreEqual(expected, result.Count, "Seharusnya 4");
        }

        [TestMethod]
        public void TestGetFileByKeyword()
        {
            MockFile tester = new MockFile();
            tester.createMockFile();
            string keyword = "s";
            List<File> result = tester.getFileByKeyword(keyword);

            Assert.AreEqual(1, result.Count, "katanya sih 1");
        }
    }
}
