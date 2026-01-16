using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;


namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class SupportLinkTest:Setup
    {
        [Test]
        
        public async Task TC_008_Support_Link_is_working_correctly()
        {
            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            ProfileDropDownObjects profile = new ProfileDropDownObjects(page);

            await profile.ClickOnProfileDropdown();
            await profile.ClickOnSupportLink();

            SupportPage support = new SupportPage(page);

            bool actualResult = await support.IsSupportPageDisplayed();

            Assert.That(actualResult, Is.True);
        } 

    }
}
