using System.Text.RegularExpressions;

namespace passwordTests
{
	public partial class Passwords
	{
		public const string ForbiddenChars = " 6";
		public const string CapitalVowels = "AEIOUY";

		public List<string> passwords { get; set; } = new();

		public static bool AddPassword(string password, List<string> passwords)
		{
			if (password is null)
				return false;

			if (passwords.Contains(password))
				return false;

			if (password is "mod" or "admin")
			{
				passwords.Add(password);
				return true;
			}

			if (password.Length is <= 7 or >= 12)
				return false;

			if (!ContainsOnlyPrimes(password))
				return false;

			bool hasNumber = false;
			int capitalVowels = 0;

			for (int i = 0; i < password.Length; i++)
			{
				char letter = password[i];

				if (ForbiddenChars.Contains(letter))
					return false;

				if (CapitalVowels.Contains(letter))
					capitalVowels++;

				if (letter is >= '0' and <= '9')
					hasNumber = true;

				if (hasNumber && capitalVowels >= 2)
				{
					passwords.Add(password);
					return true;
				}
			}

			return false;
		}

		public static bool ContainsOnlyPrimes(string password)
		{
			IList<Match> matches = NumberSearch().Matches(password);
			foreach (var match in matches)
				if (!IsNumberPrime(int.Parse(match.Value)))
					return false;
			return true;
		}

		public static bool IsNumberPrime(int num)
		{
			int sqrt = (int)Math.Sqrt(num);

			for (int i = 2; i <= sqrt; i++)
				if (num % i == 0)
					return false;
			return true;
		}

		[GeneratedRegex("[0-9]+")]
		private static partial Regex NumberSearch();
	}
}
