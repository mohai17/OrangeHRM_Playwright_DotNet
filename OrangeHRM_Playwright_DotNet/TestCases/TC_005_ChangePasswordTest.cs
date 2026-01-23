using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_005_Check_that_Change_Password_functionality_is_working_correctly:Setup
    {
        private readonly string excelFilePath = Paths.DataXLSXPath("Data.xlsx");

        [Test]

        //Test Scenario

        public async Task TS_001_user_wants_to_change_password_with_correct_old_password()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username")?? string.Empty;
            var password = ExcelReaderUtil.ReadData(1, "Password")?? string.Empty;
      
            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            ProfileDropDownObjects profile = new ProfileDropDownObjects(page);

            await profile.ClickOnProfileDropdown();
            await profile.ClickOnChangePasswordLink();

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "ChangePassword");
            var NewPassword = ExcelReaderUtil.ReadData(1, "NewPassword")?? string.Empty;
            var ConfirmPassword = ExcelReaderUtil.ReadData(1, "ConfirmPassword")?? string.Empty;

            ChangePasswordPage change = new ChangePasswordPage(page);

            await change.Enter_CurrentPassword(password);
            await change.Enter_NewPassword(NewPassword);
            await change.Enter_ConfirmPassword(ConfirmPassword);
            await change.ClickOnSaveButton();

            bool actualResult = await change.IsToastMessageVisible();

            Assert.That(actualResult,Is.True);

        }

    }
}
