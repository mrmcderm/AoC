<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var input = "ojvtpuvg";
	var password = new string[8];
	var length = 8;

	using (var md5 = MD5.Create())
    {
		for (Int64 i = 0; i < Int64.MaxValue; i++)
		{
			var preHashValue = input + i.ToString();		
			var hexValues = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(preHashValue))).Replace("-", string.Empty);

			if (hexValues.StartsWith("00000"))
            {
				var position = int.Parse(hexValues.Substring(5, 1), System.Globalization.NumberStyles.HexNumber);
				var character = hexValues.Substring(6, 1);
				if (position < 8 && string.IsNullOrEmpty(password[position]))
				{
					Console.WriteLine("{2} - {0} @ {1}", character, position, hexValues);
					password[position] = character;
					length--;
				}
				
				if (length == 0)
				{
					break;
				}
			}
		}
	}

	foreach (var character in password)
	{
		Console.Write(character.ToLower());
	}
}

// Define other methods and classes here
