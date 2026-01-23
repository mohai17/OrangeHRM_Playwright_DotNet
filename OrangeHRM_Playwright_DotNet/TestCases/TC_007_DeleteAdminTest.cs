using Microsoft.Playwright;
using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_007_Check_that_admin_user_deletion_functionality_is_working_correctly:Setup
    {

        private readonly string excelFilePath = Paths.DataXLSXPath("Data.xlsx");

        [Test]

        //Test Scenario

        public async Task TS_001_user_wants_to_delete_specific_admin_user()
        {

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username")?? string.Empty;
            var password = ExcelReaderUtil.ReadData(1, "Password")?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();


            ExcelReaderUtil.PopulateInCollection(excelFilePath, "AddAdminData");

            var empName = ExcelReaderUtil.ReadData(2, "EmployeeName")?? string.Empty;
            var admin_username = ExcelReaderUtil.ReadData(2, "UserName")?? string.Empty;
            var admin_password = ExcelReaderUtil.ReadData(2, "Password")?? string.Empty;
            var cpassword = ExcelReaderUtil.ReadData(2, "ConfirmPassword")?? string.Empty;


            AdminUserManagementPage admin = new AdminUserManagementPage(page);
            await admin.ClickOnAdminItem();
            await admin.ClickOnAddAdminUserButton();
            await admin.ClickOnUserRoleDropDown();
            await admin.SelectUserRoleFromDropDown();
            await admin.Enter_EmployeeName(empName);
            await admin.SelectEmployeedName(empName);
            await admin.ClickOnStatusDropDown();
            await admin.SelectStatus();
            await admin.Enter_Username(admin_username);
            await admin.Enter_Password(admin_password);
            await admin.Enter_ConfirmPassword(cpassword);
            await admin.ClickOnSaveButton();
            await page.WaitForRequestFinishedAsync();

            SearchAdminUser search = new SearchAdminUser(page);
            await search.Enter_SearchUsername(admin_username);
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
