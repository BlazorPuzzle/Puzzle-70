using Microsoft.Playwright;

namespace TestProject1;

public class UserProfileTests : MyPageTests
{


	[Fact]
	public async Task CanChangePhoneNumber()
	{
		await Page.GotoAsync("/");

		try
		{
			await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
			await Page.GetByRole(AriaRole.Textbox, new() { Name = "Email" }).FillAsync(Username);
			await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(Password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			await Page.GetByRole(AriaRole.Link, new() { Name = Username }).ClickAsync();
			await Page.GetByRole(AriaRole.Link, new() { Name = "Profile" }).ClickAsync();
			await Page.GetByRole(AriaRole.Textbox, new() { Name = "Phone number" }).FillAsync("1234567890");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
			var phoneNumber = Page.GetByRole(AriaRole.Textbox, new() { Name = "Phone number" });

			Assert.NotNull(phoneNumber);
			Assert.Equal("1234567890", await phoneNumber.InputValueAsync());
		}
		finally
		{

			await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();

		}

	}

	[Fact]
	public async Task CanGetPersonalData()
	{

		try
		{

			await Page.GotoAsync("/");
			await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
			await Page.GetByRole(AriaRole.Textbox, new() { Name = "Email" }).FillAsync(Username);
			await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(Password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			await Page.GetByRole(AriaRole.Link, new() { Name = Username }).ClickAsync();
			await Page.GetByRole(AriaRole.Link, new() { Name = "Personal data" }).ClickAsync();
			var privateData = Page.GetByRole(AriaRole.Button, new() { Name = "Download" });
			Assert.NotNull(privateData);
		}
		finally
		{

			await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();

		}
	}

}
