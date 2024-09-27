using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_SOLID.Open_Closed_Principle
{
    #region Overview
    /*
     * The Open/Closed Principle suggests that a class should be open for extension but closed for modification.This means you can add new features without altering existing code.

    Key Idea: Once a class is written, it should be closed for modifications but open for extensions.

    Real-Time Example: Your smartphone — you don’t open it up to add features; you just download apps to extend its capabilities.
    */
    #endregion

    #region Example-1

    // Without OCP
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class AreaCalculator
    {
        public double CalculateArea(Rectangle rectangle)
        {
            return rectangle.Width * rectangle.Height;
        }
    }

    //With OCP

    public interface IShape
    {
        double CalculateArea();
    }

    public class _Rectangle : IShape
    {     
        public double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    public class _Circle : IShape
    {
     
        public double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Example-2
    //Wihthout OCP
    public class FileExporter
    {
        public void ExportToCsv(string filePath, DataTable data)
        {
            // Code to export data to a CSV file.
        }
    }
    //With OCP
    public abstract class _FileExporter
    {
        public abstract void Export(string filePath, DataTable data);
    }
    public class CsvFileExporter : _FileExporter
    {
        public override void Export(string filePath, DataTable data)
        {
            // Code logic to export data to a CSV file.
        }
    }
    public class ExcelFileExporter : _FileExporter
    {
        public override void Export(string filePath, DataTable data)
        {
            // Code logic to export data to an Excel file.
        }
    }
    public class JsonFileExporter : _FileExporter
    {
        public override void Export(string filePath, DataTable data)
        {
            // Code logic to export data to a JSON file.
        }
    }


    #endregion

}
