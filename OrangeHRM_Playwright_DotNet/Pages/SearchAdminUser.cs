using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    internal class SearchAdminUser
    {
        private readonly IPage page;

        public SearchAdminUser(IPage page)
        {
            this.page = page;
        }

        public async Task Enter_SearchUsername(string username)
        {
            await page.Locator("//label[normalize-space()='Username']//parent::div/following-sibling::div//input").FillAsync(username);
        }

        public async Task ClickOnSearchButton()
        {
            await page.Locator("//button[@type='submit']").ClickAsync();
        }

        public async Task ClickOnResetButton()
        {
            await page.Locator("//button[normalize-space()='Reset']").ClickAsync();
        }

    }
}
