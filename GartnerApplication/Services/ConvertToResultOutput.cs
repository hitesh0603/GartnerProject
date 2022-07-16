using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GartnerApplication.Model;

namespace GartnerApplication.Services
{
    public class ConvertToResultOutput
    {
        public List<SourceResult> ConvertToResultWhenCategoriesAreCommaSeparated(List<SourceContent> listOfSourceContent)
        {
            List<SourceResult> result = new List<SourceResult>();
            if (listOfSourceContent?.Count > 0)
            {
                foreach (var sourceItem in listOfSourceContent)
                {
                    SourceResult singleItem = new SourceResult()
                    {
                        Name = sourceItem.Tags,
                        Twitter = sourceItem.Twitter,
                        Categories = sourceItem.Tags?.Split(',').ToList()
                    };
                    result.Add(singleItem);
                }
            }
            return result;
        }

        public List<SourceResult> ConvertToResultWhenCategoriesAreInList(JsonSourceContents listOfSourceContent)
        {
            List<SourceResult> result = new List<SourceResult>();
            if (listOfSourceContent?.Products?.Count > 0)
            {
                foreach (var sourceItem in listOfSourceContent.Products)
                {
                    SourceResult singleItem = new SourceResult()
                    {
                        Name = sourceItem.Title,
                        Twitter = sourceItem.Twitter,
                        Categories = sourceItem.Categories
                    };
                    result.Add(singleItem);
                }
            }
            return result;
        }
    }
}
