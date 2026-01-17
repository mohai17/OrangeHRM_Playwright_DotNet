using Microsoft.Playwright;

namespace OrangeHRM_Playwright_DotNet.Pages
{


    internal class ChangePasswordPage
    {
        private IPage page;

        public ChangePasswordPage(IPage page)
        {
            this.page = page;
        }

        public async Task Enter_CurrentPassword(string oldPassword)
        {
            await page.Locator("//label[normalize-space()='Current Password']//parent::div//following-sibling::div//input").FillAsync(oldPassword);

        }

        public async Task Enter_NewPassword(string newPassword)
        {
            await page.Locator("//label[normalize-space()='Password']//parent::div//following-sibling::div//input").FillAsync(newPassword);

        }

        public async Task Enter_ConfirmPassword(string confirmPassword)
        {
            await page.Locator("//label[normalize-space()='Confirm Password']//parent::div//following-sibling::div//input").FillAsync(confirmPassword);
        }

        public async Task ClickOnSaveButton()
        {
            await page.Locator("//button[@type='submit']").ClickAsync();
        }

        public async Task ClickOnCancel()
        {
            await page.Locator("//button[normalize-space()='Cancel']").ClickAsync();
        }

        public async Task<bool> IsToastMessageVisible()
        {
            
            var element = await page.WaitForSelectorAsync("//div[@id='oxd-toaster_1']//p[normalize-space()='Successfully Saved']", new PageWaitForSelectorOptions { State = WaitForSelectorState.Visible });
            
            return element != null && await element.IsVisibleAsync();
        }

    }
}
