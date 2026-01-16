using OrangeHRM_Playwright_DotNet.Pages;
using OrangeHRM_Playwright_DotNet.Drivers;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class TC_002_Check_that_logout_functionality_is_working_correcly:Setup
    {

        [Test]

        public async Task TS_001_user_wants_to_logout()
        {
            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            ProfileDropDownObjects profile = new ProfileDropDownObjects(page);

            await profile.ClickOnProfileDropdown();
            await profile.ClickOnLogoutLink();
         
            bool actualResult = await login.IsLoginPageTitleDisplayed();

            Assert.That(actualResult, Is.True);

        }

    }
}
