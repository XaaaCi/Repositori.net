using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FP_ONLINEREP.MockDB;

namespace FP_ONLINEREP.MockDB
{
    public class MockFile
    {
        public static List<File> Files = new List<File>();

        public MockFile()
        {
            List<File> Files = new List<File>();
        }

        public void createMockFile()
        {
            //isi data variable mock file;
            File file1 = new File();
            file1.Name = "ssd.doc";
            file1.ContentType = " ";
            file1.Size = 100;
            file1.UserId = 1;
            file1.FileId = 1;

            File file2 = new File();
            file2.Name = "adm.doc";
            file2.ContentType = " ";
            file2.Size = 100;
            file2.UserId = 2;
            file2.FileId = 2;

            File file3 = new File();
            file3.Name = "net.doc";
            file3.ContentType = " ";
            file3.Size = 100;
            file3.UserId = 1;
            file3.FileId = 3;

            Files.Add(file1);
            Files.Add(file2);
            Files.Add(file3);
        }

        public File makeNewFile(string name, string contentType, int size, int uID)
        {
            File newFile = new File();
            newFile.Name = name;
            newFile.ContentType = contentType;
            newFile.Size = size;
            newFile.UserId = uID;
            newFile.FileId = getMaxId() + 1;

            return newFile;
        }
        public List<File> getAllFile()
        {
                IEnumerable<File> result = from f in Files
                                           select f;
                return result.ToList();
        }

        public List<File> getFileByID(int id)
        {
                IEnumerable<File> result = from f in Files
                                           where f.FileId == id
                                           select f;
                return result.ToList();
        }

        public List<File> getFileByOwner(int userID)
        {
                IEnumerable<File> result = from f in Files
                                           where f.UserId == userID
                                           select f;
                return result.ToList();

        }

        public List<File> searchFile(string keyword)
        {
                IEnumerable<File> result = from f in Files
                                           where f.Name.Contains(keyword)
                                           select f;
                return result.ToList();
        }

        public void deleteFile(int id)
        {
                File fileToDelete = (from f in Files
                                     where f.FileId == id
                                     select f).FirstOrDefault();

                Files.Remove(fileToDelete);
        }

        public int getMaxId()
        {
                int id = (from f in Files
                          select f.FileId).Max();
                return id;
        }


        public void addNewFile(File fileToAdd)
        {
                Files.Add(fileToAdd);
        }

        public List<File> getFileByKeyword(string keyword)
        {
            IEnumerable<File> result = from f in Files
                                where f.Name.Contains(keyword)
                                select f;
            return result.ToList();
        }
    }
}