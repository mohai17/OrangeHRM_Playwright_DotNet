using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    public class ProfileDropDownObjects
    {

        private IPage page;
        public ProfileDropDownObjects(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnProfileDropdown()
        {
            await page.Locator("//p[@class='oxd-userdropdown-name']").ClickAsync();
            
        }

        public async Task ClickOnLogoutLink()
        {
            await page.Locator("//a[normalize-space()='Logout']").ClickAsync();
        }

    }
}
