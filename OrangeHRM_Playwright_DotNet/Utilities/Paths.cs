using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // Add this using directive

namespace OrangeHRM_Playwright_DotNet.Utilities
{
    public static class Paths
    {

        public static string DataXLSXPath()
        {
               return System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TestData", "Data.xlsx");
        }

    }
}
