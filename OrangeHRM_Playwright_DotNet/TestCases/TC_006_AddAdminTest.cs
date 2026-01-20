using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_006_Check_that_add_admin_functionality_is_working_correctly:Setup
    {
        private readonly string excelFilePath = Paths.DataXLSXPath();

        [Test]

        //Test Scenario

        public async Task TS_001_user_wants_to_add_new_admin_user()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username");
            var password = ExcelReaderUtil.ReadData(1, "Password");

            Console.WriteLine($"U: {username}");
            Console.WriteLine($"P: {password}");

            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username cannot be null.");
            if (password == null)
                throw new ArgumentNullException(nameof(password), "Password cannot be null.");

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();



            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "AddAdminData");

            var empName = ExcelReaderUtil.ReadData(1, "EmployeeName");
            if (empName == null)
                throw new ArgumentNullException(nameof(empName), "EmployeeName cannot be null.");

            
            var admin_username = ExcelReaderUtil.ReadData(1, "UserName");
            if (admin_username == null)
                throw new ArgumentNullException(nameof(admin_username), "Admin username cannot be null.");

            var admin_password = ExcelReaderUtil.ReadData(1, "Password");
            if (admin_password == null)
                throw new ArgumentNullException(nameof(admin_password), "Admin password cannot be null.");

            var cpassword = ExcelReaderUtil.ReadData(1, "ConfirmPassword");
            if (cpassword == null)
                throw new ArgumentNullException(nameof(cpassword), "Confirm password cannot be null.");

            Console.WriteLine($"U: {empName}"); 
            Console.WriteLine($"U: {admin_username}");
            Console.WriteLine($"U: {admin_password}");
            Console.WriteLine($"P: {cpassword}");

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

            bool actualResult = await admin.IsSuccessfullyAddedMsgDisplayed();

            Assert.That(actualResult, Is.True);

        }

        [Test]

        //Test Scenario
        public async Task TS_002_user_wants_to_calcel_add_admin_process()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ExcelReaderUtil.PopulateInCollection(excelFilePath, "LoginData");

            var username = ExcelReaderUtil.ReadData(1, "Username");
            var password = ExcelReaderUtil.ReadData(1, "Password");

            Console.WriteLine($"U: {username}");
            Console.WriteLine($"P: {password}");

            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username cannot be null.");
            if (password == null)
                throw new ArgumentNullException(nameof(password), "Password cannot be null.");

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName(username);
            await login.Enter_Password(password);
            await login.ClickOnLoginButton();

            AdminUserManagementPage admin = new AdminUserManagementPage(page);
            await admin.ClickOnAdminItem();
            await admin.ClickOnAddAdminUserButton();
            await admin.ClickOnCancelButton();
            bool actualResult = await admin.IsSuccessfullyCanceledAddAdmin();

            Assert.That(actualResult, Is.True);

        }

    }
}
