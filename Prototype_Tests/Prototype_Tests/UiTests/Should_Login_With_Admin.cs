using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace Prototype_Tests.UiTests
{
    public class Should_Login_With_Admin // <-- public, nicht internal
    {
        [Fact]
        public async Task Should_Login_Successfully()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://localhost:7084/Login");

            await page.FillAsync("#nameOrMail", "admin@admin");
            await page.FillAsync("#password", "admin");
            await page.ClickAsync("text=Anmelden");

            await page.WaitForURLAsync("https://localhost:7084/");

            var currentUrl = page.Url;
            Assert.Equal("https://localhost:7084/", currentUrl);
        }
    }
}

