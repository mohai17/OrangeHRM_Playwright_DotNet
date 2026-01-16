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
            await page.Locator("//i[@class='oxd-icon bi-caret-down-fill oxd-userdropdown-icon']").ClickAsync();
   
        }

        public async Task ClickOnLogoutLink()
        {
            await page.Locator("//a[normalize-space()='Logout']").ClickAsync();

        }

        public async Task ClickOnAboutLink()
        {
            await page.Locator("//a[normalize-space()='About']").ClickAsync();

        }

        public async Task ClickOnSupportLink()
        {
            await page.Locator("//a[normalize-space()='Support']").ClickAsync();

        }

        public async Task ClickOnChangePasswordLink()
        {
            await page.Locator("//a[normalize-space()='Change Password']").ClickAsync();

        }
    }
}
