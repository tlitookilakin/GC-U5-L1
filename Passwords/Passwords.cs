namespace passwordTests
{
	public class Passwords
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
	}
}
