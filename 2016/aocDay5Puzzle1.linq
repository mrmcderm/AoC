<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var input = "abc";

	using (var md5 = MD5.Create())
    {
		for (var i = 0; i < 10; i++)
		{
			var preHashValue = input + i.ToString();

			
			var hexValues = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(preHashValue))).Replace("-", string.Empty);

			Console.WriteLine("{0}: {1}", preHashValue, hexValues);

		}
	}
}

// Define other methods and classes here
