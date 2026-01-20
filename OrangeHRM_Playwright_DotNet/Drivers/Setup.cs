using Microsoft.Playwright;


namespace OrangeHRM_Playwright_DotNet.Drivers
{
    public class Setup
    {
        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;

        [OneTimeSetUp]
        public async Task OneTimeBrowserSetup()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = false,
                SlowMo = 3000,
                Channel = "msedge"
            });
        }

        [SetUp]
        public async Task TestSetup()
        {
            context = await browser.NewContextAsync();
            await context.ClearCookiesAsync();
            await context.ClearPermissionsAsync();

            page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login",
                new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded, Timeout = 120000 });
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
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (browser != null)
            {
                browser.CloseAsync().GetAwaiter().GetResult();
            }
            if (playwright != null)
            {
                playwright.Dispose();
            }
        }
    }
}