using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using GartnerApplication.Model;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GartnerApplication.Services
{
    public class ReadAllSources
    {
        public readonly ConvertToResultOutput ConvertResult;
        
        public ReadAllSources()
        {
            ConvertResult = new ConvertToResultOutput();
        }
        public List<SourceResult> DeserializeAllTypeOfFiles(string[] fileNames)
        {
            List<SourceResult> result = new List<SourceResult>();
            try
            {
                foreach (var filename in fileNames)
                {
                    if (File.Exists($"{SaasProductConstant.SourcePath}{filename}"))
                    {
                        using (StreamReader file = File.OpenText($"{SaasProductConstant.SourcePath}{filename}"))
                        {
                            if (filename.EndsWith(".yaml"))
                            {
                                result.AddRange(DeserializeYamlFiles(file));
                            }
                            else if (filename.EndsWith(".json"))
                            {
                                result.AddRange(DeserializeJsonFiles(file));
                            }
                            else if (filename.EndsWith(".csv"))
                            {
                                result.AddRange(DeserializeCsvFiles(file));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GetExceptionDetail(ex);
            }
            return result;
        }

        private List<SourceResult> DeserializeYamlFiles(StreamReader file)
        {
            var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
            var listOfSourceContent = deserializer.Deserialize<List<SourceContent>>(file);
            return ConvertResult.ConvertToResultWhenCategoriesAreCommaSeparated(listOfSourceContent);
        }

        private List<SourceResult> DeserializeJsonFiles(StreamReader file)
        {
            JsonSerializer serializer = new JsonSerializer();
            var listOfSourceContent = (JsonSourceContents)serializer.Deserialize(file,
                typeof(JsonSourceContents));
            return ConvertResult.ConvertToResultWhenCategoriesAreInList(listOfSourceContent);
        }

        private List<SourceResult> DeserializeCsvFiles(StreamReader file1)
        {
            using (var csvReader = new CsvReader(file1, CultureInfo.CurrentCulture))
            {
                var listOfSourceContent = csvReader.GetRecords<SourceContent>().ToList();
                return ConvertResult.ConvertToResultWhenCategoriesAreCommaSeparated(listOfSourceContent);
            }
        }
        private void GetExceptionDetail(Exception ex)
        {
            var frames = new StackTrace(ex, true)?.GetFrames();
            if (frames?.Length > 0)
            {
                var frame = frames.Last();
                var lineNumber = frame.GetFileLineNumber();
                var fileName = frame.GetFileName();
                var exceptionDetailMessage = $"The exception is coming in file: {fileName} at line {lineNumber} and message is {ex.InnerException?.Message ?? ex.Message}";
                Console.WriteLine(exceptionDetailMessage);
                if (Directory.Exists($"{SaasProductConstant.ResultPath}"))
                    File.WriteAllText($"{SaasProductConstant.ResultPath}/errorlog.txt", exceptionDetailMessage);
                else
                {
                    Directory.CreateDirectory($"{SaasProductConstant.ResultPath}");
                    File.WriteAllText($"{SaasProductConstant.ResultPath}/errorlog.txt", exceptionDetailMessage);
                }
            }
        }
    }
}
