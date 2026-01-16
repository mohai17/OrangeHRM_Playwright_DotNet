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
            browser = await playwright.Chromium.LaunchAsync(new()
            {
                Channel = "chrome",
                Headless = false,
                SlowMo = 2000,
           
                Args = new[] {"--start-maximized" }

            });

            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }


        [TearDown]

        public async Task TearDown()
        {
            if(page != null )
            {
                await page.CloseAsync();
            }

            if(browser !=null)
            {
                await browser.CloseAsync();
            }
        }


    }
}
