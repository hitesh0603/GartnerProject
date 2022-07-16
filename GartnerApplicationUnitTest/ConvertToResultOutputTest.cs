using System.Collections.Generic;
using GartnerApplication.Model;
using GartnerApplication.Services;
using NUnit.Framework;

namespace GartnerApplicationUnitTest
{
    class ConvertToResultOutputTest
    {
        public ConvertToResultOutput ConvertToResultOutputObj;
        [SetUp]
        public void SetUp()
        {
            ConvertToResultOutputObj = new ConvertToResultOutput();
            //ConvertToResultOutputObject = 
        }

        [Test]
        public void ConvertToResultWhenCategoriesAreCommaSeparated_ShouldNotFailIfListIsNull()
        {
            Assert.DoesNotThrow(() => ConvertToResultOutputObj.ConvertToResultWhenCategoriesAreCommaSeparated(null));
        }

        [Test]
        public void ConvertToResultWhenCategoriesAreCommaSeparated_ShouldNotFailIfListIsEmpty()
        {
            Assert.AreEqual(
                ConvertToResultOutputObj.ConvertToResultWhenCategoriesAreCommaSeparated(new List<SourceContent>()).Count, 0);
        }

        [Test]
        public void ConvertToResultWhenCategoriesAreCommaSeparated_ShouldReturnListOfSourceResult()
        {
            var mockData = new List<SourceContent>()
            {
                new SourceContent()
                {
                    Tags = "tag-1",
                    Name = "name-1",
                    Twitter = "twitter-1"
                },
                new SourceContent()
                {
                    Tags = "tag-2",
                    Name = "name-2",
                    Twitter = "twitter-2"
                }
            };
            var result =
                ConvertToResultOutputObj.ConvertToResultWhenCategoriesAreCommaSeparated(mockData);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Twitter, "twitter-1");
            Assert.AreEqual(result[1].Twitter, "twitter-2");
        }

        [Test]
        public void ConvertToResultWhenCategoriesAreInList_ShouldNotFailIfListIsNull()
        {
            Assert.DoesNotThrow(() => ConvertToResultOutputObj.ConvertToResultWhenCategoriesAreInList(null));
        }

        [Test]
        public void ConvertToResultWhenCategoriesAreInList_ShouldNotFailIfListIsEmpty()
        {
            Assert.AreEqual(
                ConvertToResultOutputObj.ConvertToResultWhenCategoriesAreInList(new JsonSourceContents()).Count, 0);
        }

        [Test]
        public void ConvertToResultWhenCategoriesAreInList_ShouldReturnListOfSourceResult()
        {
            JsonSourceContents listOfSourceContent = new JsonSourceContents()
            {
                Products = new List<JsonSourceContent>()
                {
                    new JsonSourceContent()
                    {
                        Twitter = "twitter-1",
                        Title = "title-1",
                        Categories = new List<string>()
                    },
                    new JsonSourceContent()
                    {
                        Twitter = "twitter-2",
                        Title = "title-2",
                        Categories = new List<string>()
                    }
                }
            };
            var result =
                ConvertToResultOutputObj.ConvertToResultWhenCategoriesAreInList(listOfSourceContent);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Twitter, "twitter-1");
            Assert.AreEqual(result[1].Twitter, "twitter-2");
        }
    }
}
