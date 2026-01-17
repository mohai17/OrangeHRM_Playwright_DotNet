using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    internal class AdminUserManagementPage
    {
        private readonly IPage page;
        public AdminUserManagementPage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnAdminItem()
        {
            await page.Locator("//span[normalize-space()='Admin']").ClickAsync();
        }

        public async Task ClickOnAddAdminUserButton()
        {
            await page.Locator("//button[normalize-space()='Add']").ClickAsync();
        }

        public async Task ClickOnUserRoleDropDown()
        {
            await page.Locator("//label[normalize-space()='User Role']/parent::div/following-sibling::div/div[normalize-space()='-- Select --']").ClickAsync();
        }

        public async Task SelectUserRoleFromDropDown()
        {
            await page.Locator("//div[@role='option']//span[normalize-space()='Admin']").ClickAsync();
        }

        public async Task Enter_EmployeeName(string ename)
        {
            await page.Locator("//input[@placeholder='Type for hints...']").FillAsync(ename);
        }

        public async Task SelectEmployeedName(string ename)
        {
            string xpath = $"//div[@role='option']//span[normalize-space()='{ename}']";
            await page.Locator(xpath).ClickAsync();
        
        }

        public async Task ClickOnStatusDropDown()
        {
            await page.Locator("//div[3]//div[1]//div[2]//div[1]//div[1]//div[1]").ClickAsync();
        }
        public async Task SelectStatus()
        {
            await page.Locator("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[3]/div/div[2]/div/div[2]/div[2]/span").ClickAsync();
        }

        public async Task Enter_Username(string username)
        {
            await page.Locator("//label[normalize-space()='Username']/parent::div/following-sibling::div/input").FillAsync(username);
        }

        public async Task Enter_Password(string password)
        {
            await page.Locator("//label[normalize-space()='Password']/parent::div/following-sibling::div/input").FillAsync(password);
        }

        public async Task Enter_ConfirmPassword(string cpassword)
        {
            await page.Locator("//label[normalize-space()='Confirm Password']/parent::div/following-sibling::div/input").FillAsync(cpassword);
        }

        public async Task ClickOnSaveButton()
        {
            await page.Locator("//button[@type='submit' and normalize-space()='Save']").ClickAsync();
        }

        public async Task ClickOnCancelButton()
        {
            await page.Locator("//button[normalize-space()='Cancel']").ClickAsync();
        }

        public async Task<bool> IsSuccessfullyAddedMsgDisplayed()
        {
            var element = await page.WaitForSelectorAsync("//div[@id='oxd-toaster_1']//p[normalize-space()='Successfully Saved']", new()
            {
                State = WaitForSelectorState.Visible
            });


            return element!=null && await element.IsVisibleAsync();
        }

        public async Task<bool> IsSuccessfullyCanceledAddAdmin()
        {
            var userManagementVisible = await page.Locator("//h6[normalize-space()='User Management']").IsVisibleAsync();
            var addButtonVisible = await page.Locator("//button[normalize-space()='Add']").IsVisibleAsync();
            
            return userManagementVisible && addButtonVisible;
        }

    }
}
