using passwordTests;

namespace Tests
{
	public class MainTest
	{
		[Theory]
		[InlineData("mod")]
		[InlineData("pAsswOrd9")]
		[InlineData("sEvEn777")]
		[InlineData("twElvEl3ttr")]
		[InlineData("0xEE_____")]
		[InlineData("Y0Y0TIME")]
		public void AllowsPassword(string password)
		{
			List<string> passwords = ["Test", "admin"];

			Assert.True(Passwords.AddPassword(password, passwords));
			Assert.Equal(3, passwords.Count);
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
		[InlineData("twElvEl3tter")]
		public void BansPassword(string password)
		{
			List<string> passwords = ["Test", "admin"];

			Assert.False(Passwords.AddPassword(password, passwords));
			Assert.Equal(2, passwords.Count);
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(2, true)]
		[InlineData(3, true)]
		[InlineData(4, false)]
		[InlineData(6, false)]
		[InlineData(8, false)]
		[InlineData(9, false)]
		[InlineData(10, false)]
		[InlineData(977, true)]
		[InlineData(978, false)]
		public void IsPrime(int number, bool shouldBePrime)
		{
			bool isPrime = Passwords.IsNumberPrime(number);
			Assert.Equal(shouldBePrime, isPrime);
		}
	}
}