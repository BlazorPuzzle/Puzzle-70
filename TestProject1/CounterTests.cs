using Microsoft.Playwright;

namespace TestProject1;

public class CounterTests : MyPageTests
{

	[Fact]
	public async Task CanNavigateToCounter()
	{

		// Go to the home page
		await Page.GotoAsync("/");


		// Go to the counter page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

		//await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

		// Find the counter element
		var counter = Page.GetByRole(AriaRole.Status);
		Assert.NotNull(counter);
		Assert.Equal("Current count: 0", await counter.TextContentAsync());


	}

	[Fact]
	public async Task CanIncrementCounter()
	{
		// Go to the home page
		await Page.GotoAsync("/");

		// Go to the counter page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
		//await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

		// Find the counter element
		var counter = Page.GetByRole(AriaRole.Status);
		Assert.NotNull(counter);
		Assert.Equal("Current count: 0", await counter.TextContentAsync());

		// Find the increment button
		var incrementButton = Page.GetByRole(AriaRole.Button, new() { Name = "Click me" });
		Assert.NotNull(incrementButton);

		// Click the increment button
		await incrementButton.ClickAsync();

		// Assert the counter has been incremented
		Assert.Equal("Current count: 1", await counter.TextContentAsync());

	}

	[Fact]
	public async Task CanIncrementCounterManyTimes()
	{
		// Go to the home page
		await Page.GotoAsync("/");

		// Go to the counter page
		await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
		//await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

		// Find the counter element
		var counter = Page.GetByRole(AriaRole.Status);
		Assert.NotNull(counter);
		Assert.Equal("Current count: 0", await counter.TextContentAsync());

		// Find the increment button
		var incrementButton = Page.GetByRole(AriaRole.Button, new() { Name = "Click me" });
		Assert.NotNull(incrementButton);

		// Click the increment button a random number of times
		var random = new Random();
		var times = random.Next(1, 100);
		for (var i = 0; i < times; i++)
		{
			await incrementButton.ClickAsync();
		}

		// Assert the counter has been incremented
		Assert.Equal($"Current count: {times}", await counter.TextContentAsync());

	}


}
