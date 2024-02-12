using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malafi.Tests.Utilities
{
    public class ExcelManipulation
    {
        public static XLWorkbook GetDownloadedFile(string filePrefix)
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");

            DirectoryInfo downloadDir = new DirectoryInfo(pathDownload);
            FileInfo[] files = downloadDir.GetFiles("*.xlsx");
            var file = files.OrderByDescending(f => f.LastWriteTime).Where(p => p.Name.Contains(filePrefix)).FirstOrDefault();
            var fileName = file.FullName;
            var workbook = new XLWorkbook(fileName);

            return workbook;
        }
    }
}
