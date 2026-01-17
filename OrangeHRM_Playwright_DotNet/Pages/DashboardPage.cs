using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    public class DashboardPage
    {

        private readonly IPage page;
        public DashboardPage(IPage page)
        {
            this.page = page;
        }

        public async Task<bool> IsLoginSucceed()
        {
            return await page.Locator("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-module']").IsVisibleAsync();
      
        }

    }
}
