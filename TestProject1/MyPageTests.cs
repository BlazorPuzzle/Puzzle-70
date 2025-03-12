using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace TestProject1;

public abstract class MyPageTests : PageTest
{

	public const string Username = "admin@localhost";
	public const string Password = "Admin1234!";

	public override BrowserNewContextOptions ContextOptions()
	{
		return new BrowserNewContextOptions()
		{
			ColorScheme = ColorScheme.Light,
			Locale = "en-US",
			ViewportSize = new()
			{
				// set the viewport to 1024x768
				Width = 1024,
				Height = 768,
			},
			BaseURL = "http://localhost:5183"
		};
	}

	public override async Task InitializeAsync()
	{

		await base.InitializeAsync();
		Context.SetDefaultNavigationTimeout((float)TimeSpan.FromSeconds(5).TotalMilliseconds);
		Context.SetDefaultTimeout((float)TimeSpan.FromSeconds(5).TotalMilliseconds);

	}


}
