<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var input = "uqwqemis";
	var startingValue = 0;

	using (var md5 = MD5.Create())
    {
		for(var j = 0; j < 8; j++)
		{
			for (var i = startingValue; i < int.MaxValue; i++)
			{
				var hash = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(input + i.ToString()))).Replace("-", string.Empty).ToLowerInvariant();
				
				if(hash.StartsWith("00000"))
				{
					Console.Write(hash[5]);
					startingValue = i+1;
					break;
				}
			}
		}
	}
}