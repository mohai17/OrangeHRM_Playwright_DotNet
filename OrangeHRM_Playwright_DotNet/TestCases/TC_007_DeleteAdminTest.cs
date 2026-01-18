using Microsoft.Playwright;
using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class TC_007_Check_that_admin_user_deletion_functionality_is_working_correctly:Setup
    {

        [Test]

        public async Task TS_001_user_wants_to_delete_specific_admin_user()
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
            await admin.IsSuccessfullyAddedMsgDisplayed();
            await page.WaitForRequestFinishedAsync();


            SearchAdminUser search = new SearchAdminUser(page);
            await search.Enter_SearchUsername("amelia");
            await search.ClickOnSearchButton();
         

            DeleteAdminUser deleteAdmin = new DeleteAdminUser(page);
            await deleteAdmin.ClickOnDeleteButton();
            await deleteAdmin.ClickOnConfirmationButton();
            await page.WaitForRequestFinishedAsync();

            bool actualResult = await deleteAdmin.IsSuccessfullyDeleted();
            

            Assert.That(actualResult, Is.True);
     
        }

    }
}
