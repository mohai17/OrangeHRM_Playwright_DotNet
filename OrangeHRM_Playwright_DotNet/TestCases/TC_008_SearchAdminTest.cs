using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class TC_008_Check_that_search_admin_functionality_is_working_correctly:Setup
    {
        [Test]
        public async Task TS_001_user_wants_to_search_with_username()
        {
            LoginPage login = new LoginPage(page);
            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            AdminUserManagementPage admin = new AdminUserManagementPage(page);
            await admin.ClickOnAdminItem();

            SearchAdminUser search = new SearchAdminUser(page);
            await search.Enter_SearchUsername("FMLName");
            await search.ClickOnSearchButton();
            bool actualResult = await search.IsUserNameFound("FMLName");

            Assert.That(actualResult, Is.True);

        }

    }
}
