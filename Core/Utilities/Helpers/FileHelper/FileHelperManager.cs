﻿using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            //File Control
            if (File.Exists(filePath))
            {  //File Delete
                File.Delete(filePath);
            }

        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {   //Old file delete
                File.Delete(filePath);
            }
            //New file upload
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {   // 
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                //File extensions .JPG .PNG ...
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelperManager.CreateGuid();
                string filePath = guid + extension;
                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;

        }
    }
}
