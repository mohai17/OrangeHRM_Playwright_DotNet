using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class TC_006_Check_that_add_admin_functionality_is_working_correctly:Setup
    {

        [Test]

        public async Task TS_001_user_wants_to_add_new_admin_user()
        {
            LoginPage login = new LoginPage(page);
            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            AdminUserManagementPage admin = new AdminUserManagementPage(page);
            await admin.ClickOnAdminItem();
            await admin.ClickOnAddAdminUserButton();
            await admin.ClickOnUserRoleDropDown();
            await admin.SelectUserRoleFromDropDown();
            await admin.Enter_EmployeeName("Amelia Brown");
            await admin.SelectEmployeedName("Amelia Brown");
            await admin.ClickOnStatusDropDown();
            await admin.SelectStatus();
            await admin.Enter_Username("amelia");
            await admin.Enter_Password("amelia123");
            await admin.Enter_ConfirmPassword("amelia123");
            await admin.ClickOnSaveButton();

            bool actualResult = await admin.IsSuccessfullyAddedMsgDisplayed();

            Assert.That(actualResult, Is.True);

        }

        [Test]
        public async Task TS_002_user_wants_to_calcel_add_admin_process()
        {

        }

    }
}
