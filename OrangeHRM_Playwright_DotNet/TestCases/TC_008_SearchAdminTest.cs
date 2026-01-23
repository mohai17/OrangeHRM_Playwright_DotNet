using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_008_Check_that_search_admin_functionality_is_working_correctly:Setup
    {
        private readonly string excelFilePath = Paths.DataXLSXPath("Data.xlsx");

        [Test]

        //Test Scenario
        public async Task TS_001_user_wants_to_search_with_username()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username")?? string.Empty;
            var password = ExcelReaderUtil.ReadData(1, "Password")?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            AdminUserManagementPage admin = new AdminUserManagementPage(page);
            await admin.ClickOnAdminItem();


            ExcelReaderUtil.PopulateInCollection(excelFilePath, "SearchData");

            var admin_username = ExcelReaderUtil.ReadData(1, "UserName")?? string.Empty;

            SearchAdminUser search = new SearchAdminUser(page);
            await search.Enter_SearchUsername(admin_username);
            await search.ClickOnSearchButton();

            bool actualResult = await search.IsUserNameFound(admin_username);

            Assert.That(actualResult, Is.True);

        }

    }
}
