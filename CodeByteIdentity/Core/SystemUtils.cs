using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeByte.Core
{
    class SystemUtils
    {

        public static string GetProjectPath()
        {
            string path = Directory.GetCurrentDirectory().Split("\\bin")[0];
            return path + "\\";
        }

        public static string GetExtendReportPath()
        {
            string path = Directory.GetCurrentDirectory().Split("\\Results")[0];
            return path + "\\";
        }

        public static string GetExcelDataFilePath()
        {
            string ExcelFilePath = Directory.GetCurrentDirectory().Split("\\bin")[0];
            return ExcelFilePath + "\\TestData";
        }
    }
}