using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    internal class SupportPage
    {
        private readonly IPage page;

        public SupportPage(IPage page)
        {
            this.page = page;
        }
        public async Task<bool> IsSupportPageDisplayed()
        {
            return await page.Locator("//p[@class='oxd-text oxd-text--p orangehrm-sub-title']").IsVisibleAsync();
        }
    }
}
