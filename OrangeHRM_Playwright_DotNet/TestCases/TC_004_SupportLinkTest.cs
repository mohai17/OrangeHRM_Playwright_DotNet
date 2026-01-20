using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;


namespace OrangeHRM_Playwright_DotNet.TestCases
{
    //Test Case
    internal class TC_004_Check_that_Support_Link_working_correctly:Setup
    {
        [Test]

        //Test Scenario
        public async Task TS_001_user_wants_to_go_to_support_page()
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
