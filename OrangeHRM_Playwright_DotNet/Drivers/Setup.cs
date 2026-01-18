using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.Drivers
{
    public class Setup
    {

        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;


        [SetUp]
        public async Task BrowserSetup()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = false,
                SlowMo = 3000,
                Timeout = 120000,
                Channel = "chrome"
            });
            
            context = await browser.NewContextAsync();
            await context.ClearCookiesAsync();
            await context.ClearPermissionsAsync();

            page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        }


        [TearDown]
        public async Task TearDown()
        {
            if (page != null)
            {
                await page.CloseAsync();
            }
            if (context != null)
            {
                await context.CloseAsync();
            }
            if (browser != null)
            {
                await browser.CloseAsync();
            }
            if (playwright != null)
            {
                playwright.Dispose();
            }
        }


    }
}
