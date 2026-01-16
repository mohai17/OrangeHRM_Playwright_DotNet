using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    public class LoginPage
    {

        private IPage page;
        public LoginPage(IPage page)
        {
            this.page = page;
        }

        public async Task Enter_UserName(string username)
        {

            await page.Locator("//input[@placeholder='Username']").FillAsync(username);

        }

        public async Task Enter_Password(string password)
        {
            await page.Locator("//input[@placeholder='Password']").FillAsync(password);
        }

        public async Task ClickOnLoginButton()
        {
            await page.Locator("//button[@type='submit']").ClickAsync();
        }

        public async Task<bool> IsWarningForRequiredFieldVisible()
        {
            return await page.Locator("//div[@class='orangehrm-login-slot-wrapper']//div[1]//div[1]//span[1]").IsVisibleAsync();

        }

        public async Task<bool> IsWaringForInvalidCredentialsVisible()
        {
           return await page.Locator("//p[@class='oxd-text oxd-text--p oxd-alert-content-text']").IsVisibleAsync();

        }

        public async Task<bool> IsLoginPageTitleDisplayed()
        {

            return await page.Locator("//h5[@class='oxd-text oxd-text--h5 orangehrm-login-title']").IsVisibleAsync();
        }


    }
}
