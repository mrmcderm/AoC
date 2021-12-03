<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	//var input = "uqwqemis";
	var input = "abc";
	var startingValue = 0;
	var password = new string[8] {"_", "_", "_", "_", "_", "_", "_", "_"};

	Console.WriteLine(string.Join("", password));
	using (var md5 = MD5.Create())
    {
		for(var j = 0; j < 8; j++)
		{
			for (var i = startingValue; i < int.MaxValue; i++)
			{
				var hash = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(input + i.ToString()))).Replace("-", string.Empty).ToLowerInvariant();
				
				if(hash.StartsWith("00000"))
				{
					int position = -1;
					if(int.TryParse(hash[5].ToString(), out position) && position > -1 && position < 8)
					{
						password[position] = hash[6].ToString();
						startingValue = i+1;
						Console.WriteLine(string.Join("", password));
						break;
					}
				}
			}
		}
	}
}