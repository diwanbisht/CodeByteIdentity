using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeByte.Core
{
    public class ReadExcelData
    {

        public static Dictionary<String, String> ReadExcelRowByRow(int rowNumber)
        {
            string fname = SystemUtils.GetExcelDataFilePath() + @"\TestData.xlsx";
           
           // string fname = @"D:\Coding\CodeByte\CodeByte\TestData\TestData.xlsx";
            // Read excel file.
            IWorkbook workbook = WorkbookFactory.Create(new FileStream(Path.GetFullPath(fname),
                                FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
             );
            Dictionary<String, String> ReadExcelDataValue = new Dictionary<string, string>();
            ISheet worSheet = workbook.GetSheetAt(0);
            int RowCount = worSheet.LastRowNum;
            int ColumnsCount = worSheet.GetRow(0).PhysicalNumberOfCells;

            string ColumnValue = string.Empty;
            string RowValue = string.Empty;

            DataFormatter formatter = new DataFormatter();//Formatter will work fine for cell value.
            for (int ColumnIndex = 0; ColumnIndex < ColumnsCount; ColumnIndex++) //Loop the records upto filled row  
            {
                if (worSheet.GetRow(ColumnsCount) == null)  //null is when the row only contains empty cells   
                {
                    ColumnValue = worSheet.GetRow(0).GetCell(ColumnIndex).StringCellValue; //Here for sample , I just save the value in "value" field, Here you can write your custom logics...  
                    RowValue = formatter.FormatCellValue(worSheet.GetRow(rowNumber).GetCell(ColumnIndex));

                }

                ReadExcelDataValue.Add(ColumnValue, RowValue);
            }

            return ReadExcelDataValue;
        }
    }
}