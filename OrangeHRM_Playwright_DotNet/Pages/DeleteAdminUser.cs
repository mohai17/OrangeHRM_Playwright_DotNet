using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Pages
{
    internal class DeleteAdminUser
    {

        private readonly IPage page;


        public DeleteAdminUser(IPage page)
        {
            this.page = page;
        }
        
        public async Task ClickOnDeleteButton()
        {
            await page.Locator("//div[@role='table']//button[1]//i[@class='oxd-icon bi-trash']").ClickAsync();
        }

        public async Task ClickOnConfirmationButton()
        {
            await page.Locator("//button[normalize-space()='Yes, Delete']").ClickAsync();
        }

        public async Task ClickOnCancelButton()
        {
            await page.Locator("//button[normalize-space()='No, Cancel']").ClickAsync();
        }

        public async Task<bool> IsSuccessfullyDeleted()
        {

            return await page.Locator("//span[normalize-space()='No Records Found']").IsVisibleAsync();
            
        }

    }
}
