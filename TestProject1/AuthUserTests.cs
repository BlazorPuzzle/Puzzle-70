using Microsoft.Playwright;

namespace TestProject1;

public class AuthUserTests : MyPageTests
{

	[Fact]
	public async Task CanLogin()
	{

		await Page.GotoAsync("/");
		await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
		await Page.GetByRole(AriaRole.Textbox, new() { Name = "Email" }).FillAsync(Username);
		await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(Password);
		await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

		await Page.GetByRole(AriaRole.Link, new() { Name = "Auth Required" }).ClickAsync();
		var authRequired = Page.GetByRole(AriaRole.Heading, new() { Name = "You are authenticated" });

		Assert.NotNull(authRequired);

		await Page.GetByRole(AriaRole.Link, new() { Name = Username }).ClickAsync();
		await Page.GetByRole(AriaRole.Link, new() { Name = "Email" }).ClickAsync();
		await Page.GetByRole(AriaRole.Link, new() { Name = "Password" }).ClickAsync();
		await Page.GetByRole(AriaRole.Link, new() { Name = "Two-factor authentication" }).ClickAsync();
		await Page.GetByRole(AriaRole.Link, new() { Name = "Personal data" }).ClickAsync();
		await Page.GetByRole(AriaRole.Link, new() { Name = "Home" }).ClickAsync();

	}

	[Fact]
	public async Task CanLogout()
	{
		await Page.GotoAsync("/");
		await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
		await Page.GetByRole(AriaRole.Textbox, new() { Name = "Email" }).FillAsync(Username);
		await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(Password);
		await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
		await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
		var login = Page.GetByRole(AriaRole.Link, new() { Name = "Login" });
		Assert.NotNull(login);
	}

}
