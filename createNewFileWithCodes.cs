using Hafman;

namespace Havman;

public class createNewFileWithCodes
{
	public createNewFileWithCodes(Dictionary<string, string> deCodeDict, Dictionary<string, string> codeDict,
		List<string> lines)
	{
		var newCrypt = "";
		var pathd = @"ans";
		newCrypt += deCodeDict.Count + Environment.NewLine;
		newCrypt = deCodeDict.Aggregate(newCrypt,
			(current, VARIABLE) => current + (VARIABLE.Key + " " + VARIABLE.Value + Environment.NewLine));
		var liner = lines.Aggregate("", (current, line) => current + line);
		var tokens = new Tokenizer().Tokenize(liner);
		var wordCrypt = "";
		foreach (var token in tokens)
		{
			wordCrypt += deCodeDict[token];
		}

		wordCrypt = Convert.ToString(Convert.ToInt64(wordCrypt, 2), 10);
		wordCrypt += Environment.NewLine;
		newCrypt += wordCrypt;
		File.WriteAllText(pathd, newCrypt);
	}
}