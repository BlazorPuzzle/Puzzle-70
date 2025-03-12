using Microsoft.Playwright;

namespace TestProject1;

public class WeatherTests : MyPageTests
{

	[Fact]
	public async Task CanNavigateToWeather()
	{
		// Go to the home page
		await Page.GotoAsync("/");

		// Go to the weather page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Weather" }).ClickAsync();

		// Find the weather element
		var weather = Page.GetByRole(AriaRole.Cell, new() { Name = "Date" });
		Assert.NotNull(weather);

	}

	[Fact]
	public async Task ContainsTomorrowsWeather()
	{
		// Go to the home page
		await Page.GotoAsync("/");

		// Go to the weather page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Weather" }).ClickAsync();

		// Find the weather element
		var weather = Page.GetByRole(AriaRole.Cell, new() { Name = "Date" });
		Assert.NotNull(weather);

		var firstDate = Page.GetByRole(AriaRole.Cell, new() { Name = DateTime.Now.AddDays(1).ToShortDateString() });
		Assert.NotNull(firstDate);

	}

	[Fact]
	public async Task CanNavigateToManyPages()
	{
		// Go to the home page
		await Page.GotoAsync("/");
		// Go to the weather page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Weather" }).ClickAsync();
		// Find the weather element
		var weather = Page.GetByRole(AriaRole.Cell, new() { Name = "Date" });
		Assert.NotNull(weather);
		// Go to the counter page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
		// Find the counter element
		var counter = Page.GetByRole(AriaRole.Status);
		Assert.NotNull(counter);
		Assert.Equal("Current count: 0", await counter.TextContentAsync());
		// Go to the home page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Home" }).ClickAsync();

	}


}
