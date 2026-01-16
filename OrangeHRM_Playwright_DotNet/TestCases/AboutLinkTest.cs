using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class AboutLinkTest:Setup
    {
        [Test]

        public async Task TC_007_About_Link_is_working_correctly()
        {

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            ProfileDropDownObjects profile = new ProfileDropDownObjects(page);

            await profile.ClickOnProfileDropdown();
            await profile.ClickOnAboutLink();

            AboutPage about = new AboutPage(page);

            bool actualResult = await about.IsAboutPageDisplayed();

            Assert.That(actualResult, Is.True);
        }

    }
}
