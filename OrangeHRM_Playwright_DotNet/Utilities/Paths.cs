using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // Add this using directive

namespace OrangeHRM_Playwright_DotNet.Utilities
{
    public static class Paths
    {

        public static string DataXLSXPath(string XLName)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string localfilePath = Path.Combine(projectRoot, "TestData", $"{XLName}");

            return localfilePath;
        }

    }
}
