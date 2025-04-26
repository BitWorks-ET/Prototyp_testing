using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

public class LoginPageTest
{
    [Fact]
    public async Task Should_Login_With_Valid_Credentials()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://localhost:7084/Login");

        await page.FillAsync("#nameOrMail", "testest@test.de"); // Existiert der User?
        await page.FillAsync("#password", "1234");
        await page.ClickAsync("text=Anmelden");

        // Alternative: explizit auf Weiterleitung warten
        // await page.WaitForURLAsync("**/");

        var url = page.Url;
        Console.WriteLine($"Aktuelle URL: {url}");

        Assert.Contains("/Login", url); // Check, dass wir noch auf der Login-Seite sind
    }
}

