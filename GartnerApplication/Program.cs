using System;
using GartnerApplication.Services;

namespace GartnerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the list of File name");
            var fileName = Console.ReadLine()?.Split(',');
            ReadAllSources readFiles = new ReadAllSources();
            InsertIntoFile insertContent = new InsertIntoFile();
            var getAllFileContent = readFiles.DeserializeAllTypeOfFiles(fileName);
            insertContent.CreateTheJsonFile(getAllFileContent);
        }
    }
}
