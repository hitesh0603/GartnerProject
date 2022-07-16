using GartnerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GartnerApplication.Services
{
    public interface IReadAllSourceFiles
    {
        List<SourceResult> DeserializeAllTypeOfFiles(string[] fileNames);
    }
}
