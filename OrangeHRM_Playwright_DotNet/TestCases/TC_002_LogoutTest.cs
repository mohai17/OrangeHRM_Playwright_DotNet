using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Utilities;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_002_Check_that_logout_functionality_is_working_correcly:Setup
    {
        private readonly string excelFilePath = Paths.DataXLSXPath("Data.xlsx");

        [Test]

        //Test Scenario
        public async Task TS_001_user_wants_to_logout()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username") ?? string.Empty;
            var password = ExcelReaderUtil.ReadData(1, "Password") ?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();


            ProfileDropDownObjects profile = new ProfileDropDownObjects(page);

            await profile.ClickOnProfileDropdown();
            await profile.ClickOnLogoutLink();
          

            bool actualResult = await login.IsLoginPageTitleDisplayed();

            Assert.That(actualResult, Is.True);

        }

    }
}
