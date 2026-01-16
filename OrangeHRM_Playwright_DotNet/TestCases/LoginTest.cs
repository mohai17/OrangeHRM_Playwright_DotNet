using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using OrangeHRM_Playwright_DotNet.Drivers;
using OrangeHRM_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM_Playwright_DotNet.TestCases
{
    internal class LoginTest: Setup
    {
 
        
        [Test]

        public async Task TC_001_Login_with_valid_username_and_valid_password()
        {
            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("Admin");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            DashboardPage dash = new DashboardPage(page);

            bool actualResult = await dash.IsLoginSucceed();
           
            Assert.That(actualResult, Is.True);
        }

        [Test]

        public async Task TC_002_Login_with_invalid_username_and_invalid_password()
        {

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("username");
            await login.Enter_Password("admin111");
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWaringForInvalidCredentialsVisible();

            Assert.That(actualResult, Is.True);

        }

        [Test]

        public async Task TC_003_Login_with_valid_username_and_invalid_password()
        {

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("Admin");
            await login.Enter_Password("12345");
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWaringForInvalidCredentialsVisible();

            Assert.That(actualResult, Is.True);

        }

        [Test]

        public async Task TC_004_Login_with_invalid_username_and_valid_password()
        {

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("abcde");
            await login.Enter_Password("admin123");
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWaringForInvalidCredentialsVisible();

            Assert.That(actualResult, Is.True);


        }

        [Test]
        
        public async Task TC_005_Login_with_empty_username_and_password()
        {

            LoginPage login = new LoginPage(page);

            await login.Enter_UserName("");
            await login.Enter_Password("");
            await login.ClickOnLoginButton();

            bool actualResult = await login.IsWarningForRequiredFieldVisible();

            Assert.That(actualResult, Is.True);

        }

    }
}
