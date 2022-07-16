using NUnit.Framework;
using System.Collections.Generic;
using GartnerApplication.Services;
using Moq;
using GartnerApplication.Model;

namespace GartnerApplicationUnitTest
{
    [TestFixture]
    class ReadAllSourcesTest
    {
        public ReadAllSources ReadAllSourcesObject;
        [SetUp]
        public void SetUp()
        {
            ReadAllSourcesObject = new ReadAllSources();
        }

        [Test]
        public void DeserializeAllTypeOfFiles_ShouldNotFailIfFileListIsEmpty()
        {
            string[] fileList = { };
            Assert.DoesNotThrow(() => ReadAllSourcesObject.DeserializeAllTypeOfFiles(fileList));
        }

        [Test]
        public void DeserializeAllTypeOfFiles_ShouldNotFailIfFileDoesNotExist()
        {
            string[] fileList = { "invalidfile.json" };
            Assert.DoesNotThrow(() => ReadAllSourcesObject.DeserializeAllTypeOfFiles(fileList));
            Assert.AreEqual(ReadAllSourcesObject.DeserializeAllTypeOfFiles(fileList).Count, 0);
        }

        [Test]
        public void DeserializeAllTypeOfFiles_ShouldReturnJsonOutputIfFilesAreValid()
        {
            string[] fileList = { "softwareadvice.json" };
            var mockConvertToResultOutput = new Mock<ConvertToResultOutput>();
            //mockConvertToResultOutput.Setup(q => q.ConvertToResultWhenCategoriesAreInList(new JsonSourceContents()))
            //    .Returns(new List<SourceResult>());
            Assert.AreEqual(ReadAllSourcesObject.DeserializeAllTypeOfFiles(fileList).Count, 2);
        }
    }
}
