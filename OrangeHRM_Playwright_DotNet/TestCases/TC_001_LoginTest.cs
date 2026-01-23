using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Utilities;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;


namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_001_Check_that_Login_functionality_is_working_correctly: Setup
    {

        private readonly string excelFilePath = Paths.DataXLSXPath("Data.xlsx");


        [Test]

        //Test Scenario
        public async Task TS_001_Login_with_valid_username_and_valid_password()
        {
            

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username")?? string.Empty;
            var password = ExcelReaderUtil.ReadData(1, "Password")?? string.Empty;

            
            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            DashboardPage dash = new DashboardPage(page);

            bool actualResult = await dash.IsLoginSucceed();

            Assert.That(actualResult, Is.True);
        }

        [Test]

        //Test Scenario
        public async Task TS_002_Login_with_invalid_username_and_invalid_password()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(2, "Username") ?? string.Empty;
            var password = ExcelReaderUtil.ReadData(2, "Password") ?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWaringForInvalidCredentialsVisible();

            Assert.That(actualResult, Is.True);
        }

        [Test]

        //Test Scenario
        public async Task TS_003_Login_with_valid_username_and_invalid_password()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(3, "Username") ?? string.Empty;
            var password = ExcelReaderUtil.ReadData(3, "Password") ?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWaringForInvalidCredentialsVisible();

            Assert.That(actualResult, Is.True);

        }

        [Test]

        //Test Scenario
        public async Task TS_004_Login_with_invalid_username_and_valid_password()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(4, "Username") ?? string.Empty;
            var password = ExcelReaderUtil.ReadData(4, "Password") ?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWaringForInvalidCredentialsVisible();

            Assert.That(actualResult, Is.True);


        }

        [Test]

        //Test Scenario
        public async Task TS_005_Login_with_empty_username_and_password()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(5, "Username") ?? string.Empty;
            var password = ExcelReaderUtil.ReadData(5, "Password") ?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWarningForRequiredFieldVisible();

            Assert.That(actualResult, Is.True);

        }

    }
}
