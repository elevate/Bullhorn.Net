using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Helper
{
    public class RestFileManager
    {
        private string formFileName = "file";

        public RestFileManager()
        {
        }

        public Dictionary<string, object> addFileToMultiValueMap(MultipartFormDataContent multipartFile)
        {

            //string newFolderPath = Path.GetTempPath() "/" + DateTime.Now.Millisecond.ToString();

            //File newFolder = new File(newFolderPath);

            //FileUtils.forceMkdir(newFolder);

            //String originalFileName = multipartFile.getOriginalFilename();
            //String filePath = newFolderPath + "/" + originalFileName;
            //File file = new File(filePath);

            //FileCopyUtils.copy(multipartFile.getBytes(), file);

            //return addFileToMultiValueMap(file);
            throw new NotImplementedException();

        }

    }
}
