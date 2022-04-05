using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadWpfApp
{
    class TabItemControl
    {
        private string fileName;
        private string filePath;
        private string fileContent;

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }       
        
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
            }
        }        
        
        public string FileContent
        {
            get
            {
                return fileContent;
            }
            set
            {
                fileContent = value;
            }
        }


    }
}
