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
    public class AdminCreatesNewEventTest
    {
        [Fact]
        public async Task Admin_Can_Create_New_Event_With_Testort()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://localhost:7084/Login");

            await page.FillAsync("#nameOrMail", "admin@admin");
            await page.FillAsync("#password", "admin");
            await page.ClickAsync("text=Anmelden");

            await page.WaitForURLAsync("https://localhost:7084/");

            await page.ClickAsync("text=Neues Event Erstellen");

            await page.WaitForURLAsync(url => url.Contains("/EventAdministration"));

            Console.WriteLine(await page.ContentAsync()); // NEU: zum Debuggen der HTML-Seite

            // ALTERNATIVE Methode: Suche alle Inputs, nimm das letzte vor Eventprozesse
            var locationInput = page.Locator("p:has-text('Ort der Veranstaltung')").Locator("..").Locator("input");
            await locationInput.FillAsync("Testort");


            // Robust speichern
            await page.ClickAsync("button:has-text('Änderungen speichern')");
        }
        [Fact]
        public async Task Admin_Can_Create_And_Register_For_Event()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false, SlowMo = 250 }); // slowmo für sichtbare Aktionen
            var page = await browser.NewPageAsync();

            // Login
            await page.GotoAsync("https://localhost:7084/Login");
            await page.FillAsync("#nameOrMail", "admin@admin");
            await page.FillAsync("#password", "admin");
            await page.ClickAsync("text=Anmelden");
            await page.WaitForURLAsync("https://localhost:7084/");

            // Neues Event erstellen
            await page.ClickAsync("text=Neues Event Erstellen");
            await page.WaitForURLAsync(url => url.Contains("/EventAdministration"));

            // Event-Name ins erste Textarea eingeben
            var textAreas = page.Locator("textarea");
            await textAreas.Nth(0).FillAsync("NewEvent");

            // Ort der Veranstaltung ausfüllen
            await page.Locator("//p[contains(text(), 'Ort der Veranstaltung')]/following-sibling::input").FillAsync("Testort");

            // Änderungen speichern
            await page.ClickAsync("button:has-text('Änderungen speichern')");
            await page.WaitForTimeoutAsync(1000);

            // Jetzt NICHT Seite neu laden – sondern oben auf "Home" klicken
            await page.ClickAsync("text=Home");
            await page.WaitForURLAsync(url => url == "https://localhost:7084/");

            // Auf das neue Event klicken
            await page.ClickAsync("text=NewEvent");
            await page.WaitForURLAsync(url => url.Contains("/Event/"));

            // Auf "Anmelden" klicken
            await page.ClickAsync("text=Anmelden");

            // Sicherstellen, dass "Abmelden" Button sichtbar ist
            await page.WaitForSelectorAsync("text=Abmelden");

            // Browser offen lassen zum Debuggen
            Console.WriteLine("Test fertig, Browser bleibt offen. Drücke Enter zum Schließen...");
            Console.ReadLine();
        }



    }
}

