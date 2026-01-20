using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_005_Check_that_Change_Password_functionality_is_working_correctly:Setup
    {

        [Test]

        //Test Scenario

        public async Task TS_001_user_wants_to_change_password_with_correct_old_password()
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
