using GartnerApplication.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GartnerApplication.Services
{
    public class InsertIntoFile
    {
        /// <summary>
        /// We can insert into DB instead of inserting in file.
        /// </summary>
        /// <param name="listOfSourceResult"></param>
        public void CreateTheJsonFile(List<SourceResult> listOfSourceResult)
        {
            if (listOfSourceResult?.Count > 0)
            {
                var jsonData = JsonConvert.SerializeObject(listOfSourceResult, Formatting.Indented);
                Console.WriteLine(jsonData);
                if (Directory.Exists($"{SaasProductConstant.ResultPath}"))
                    File.WriteAllText($"{SaasProductConstant.ResultPath}/sourceTable.json", jsonData);
                else
                {
                    Directory.CreateDirectory($"{SaasProductConstant.ResultPath}");
                    File.WriteAllText($"{SaasProductConstant.ResultPath}/sourceTable.json", jsonData);
                }
            }
            Console.WriteLine("Press Enter key to close this command line window");
            Console.ReadLine();
        }
    }
}
