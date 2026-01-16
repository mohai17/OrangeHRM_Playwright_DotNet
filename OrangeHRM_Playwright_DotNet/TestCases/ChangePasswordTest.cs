using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class ChangePasswordTest:Setup
    {

        [Test]

        public async Task TC_008_Change_Password_Functionality_is_working_correctly()
        {

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            ProfileDropDownObjects profile = new ProfileDropDownObjects(page);

            await profile.ClickOnProfileDropdown();
            await profile.ClickOnChangePasswordLink();

            ChangePasswordPage change = new ChangePasswordPage(page);

            await change.Enter_CurrentPassword("admin123");
            await change.Enter_NewPassword("admin@123456");
            await change.Enter_ConfirmPassword("admin@123456");
            await change.ClickOnSaveButton();

            bool actualResult = await change.IsToastMessageVisible();

            Assert.That(actualResult,Is.True);

        }

    }
}
