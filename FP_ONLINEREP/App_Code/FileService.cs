using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP_ONLINEREP.App_Code
{
    public class FileService
    {
        
        public static File makeNewFile(string name, string contentType, int size, byte[] fileData, int uID)
        {
            File newFile = new File();
            newFile.Name = name;
            newFile.ContentType = contentType;
            newFile.Size = size;
            newFile.Data = fileData;
            newFile.UserId = uID;
            newFile.FileId = FileService.getMaxId()+1;

            return newFile;
        }

        public static IEnumerable<File> getAllFile()
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<File> result = from f in context.Files
                                           select f;
                return result.ToList();
            }
        }

        public static IEnumerable<File> getFileByID(int id)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<File> result = from f in context.Files
                                           where f.FileId == id
                                           select f;
                return result.ToList();
            }
        }
        
        public static IEnumerable<File> getFileByOwner(int userID)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<File> result = from f in context.Files
                                           where f.UserId == userID
                                           select f;
                return result.ToList();
            }
        }

        public static IEnumerable<File> searchFile(string keyword)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                IEnumerable<File> result = from f in context.Files
                                           where f.Name.Contains(keyword)
                                           select f;
                return result.ToList();
            }
        }

        public static void deleteFile(int id)
        {
                
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                File fileToDelete = (from f in context.Files
                                    where f.FileId == id
                                    select f).FirstOrDefault();
                
                context.Files.Remove(fileToDelete);
                context.SaveChanges();
            }
        }

        public static int getMaxId()
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                int id = (from f in context.Files
                          select f.FileId).Max();
                return id;
            }
        }


        public static void addNewFile(File fileToAdd)
        {
            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                context.Files.Add(fileToAdd);
                context.SaveChanges();
            }
        }
    }
}