using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Security.BusinessLogic;

namespace Lecture.Web.Models
{
    public class CodeGenerator
    {
        public static string GetLaunchCode(string country)
        {
            Authentication auth = new Authentication(country);
            return auth.Hash;
        }
    }
}
