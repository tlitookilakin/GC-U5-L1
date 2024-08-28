using passwordTests;

namespace Tests
{
	public class MainTest
	{
		[Theory]
		[InlineData("mod")]
		[InlineData("pAsswOrd9")]
		[InlineData("sEvEn777")]
		[InlineData("twElvElettr")]
		[InlineData("0xFF_____")]
		[InlineData("Y0Y0TIME")]
		public void AllowsPassword(string password)
		{
			List<string> passwords = ["Test", "admin"];

			Assert.True(Passwords.AddPassword(password, passwords));
			Assert.Contains(password, passwords);
		}

		[Theory]
		[InlineData("Test")]
		[InlineData("")]
		[InlineData(null)]
		[InlineData("derp")]
		[InlineData("nevergonnagiveyouup,nevergonnaletyoudown")]
		[InlineData("Cool Password")]
		[InlineData("password6")]
		[InlineData("password")]
		[InlineData("admin")]
		[InlineData("PAsswOrd")]
		[InlineData("sEvEn77")]
		[InlineData("twElvEletter")]
		public void BansPassword(string password)
		{
			List<string> passwords = ["Test", "admin"];

			Assert.False(Passwords.AddPassword(password, passwords));
			Assert.DoesNotContain(password, passwords);
		}
	}
}