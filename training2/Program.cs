﻿// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using OfficeOpenXml;


/// <summary>
/// Simply opens an existing file and reads some values and properties
/// </summary>


var filePath = FileInfo.GetCleanFileInfo("02-ReadWorkbook", "ReadWorkbook.xlsx").FullName;
Console.WriteLine("Reading column 2 of {0}", filePath);
Console.WriteLine();

FileInfo existingFile = new FileInfo(filePath);
using (ExcelPackage package = new ExcelPackage(existingFile))
{
    //Get the first worksheet in the workbook
    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

    int col = 2; //Column 2 is the item description
    for (int row = 2; row < 5; row++)
        Console.WriteLine("\tCell({0},{1}).Value={2}", row, col, worksheet.Cells[row, col].Value);

    //Output the formula from row 3 in A1 and R1C1 format
    Console.WriteLine("\tCell({0},{1}).Formula={2}", 3, 5, worksheet.Cells[3, 5].Formula);                
    Console.WriteLine("\tCell({0},{1}).FormulaR1C1={2}", 3, 5, worksheet.Cells[3, 5].FormulaR1C1);

    //Output the formula from row 5 in A1 and R1C1 format
    Console.WriteLine("\tCell({0},{1}).Formula={2}", 5, 3, worksheet.Cells[5, 3].Formula);
    Console.WriteLine("\tCell({0},{1}).FormulaR1C1={2}", 5, 3, worksheet.Cells[5, 3].FormulaR1C1);

} // the using statement automatically calls Dispose() which closes the package.

Console.WriteLine();
Console.WriteLine("Read workbook sample complete");
Console.WriteLine();


