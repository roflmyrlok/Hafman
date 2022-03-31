namespace Hafman;

public class Tokenizer
{
	public List<string> Tokenize(string expression)
	{
		{
			var answearShit = new List<string>();

			for (var index = 0; index != expression.Length; index++)
			{
				var element = expression[index].ToString();
				answearShit.Add(element);
				
			}

			return answearShit;
		}
	}
}