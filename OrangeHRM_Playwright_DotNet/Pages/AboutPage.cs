using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    internal class AboutPage
    {
        private IPage page;
        public AboutPage(IPage page)
        {
            this.page = page;
        }
        public async Task<bool> IsAboutPageDisplayed()
        {
            return await page.Locator("//h6[normalize-space()='About']").IsVisibleAsync();
        }

    }
}
