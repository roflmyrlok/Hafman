using Havman;

namespace Hafman;

public class decoderOfHafmanNote
{
	public string decode()
    		{
    			List<string> lines2 = new FileReader().ReadLines("ans");
    			var dictDecod = new Dictionary<string, string>();
    			var words = new List<string>();
    			for (int i = 1; i <= Convert.ToInt32(lines2[0]); i++)
    			{
    				var curr = lines2[i].Split();
    				dictDecod.Add(curr[1], curr[0]);
    			}
    
    			for (int i = Convert.ToInt32(lines2[0]) + 1; i < lines2.Count; i++)
    			{
    				var wordDeCrypt = Convert.ToString(Convert.ToInt64(lines2[i], 10), 2);
    				words.Add(wordDeCrypt);
    			}
    
    			var ListOfTokens = new List<string>();
    			foreach (var word in words)
    			{
    				var currentList = new Tokenizer().Tokenize(word);
    				foreach (var token in currentList)
    				{
    					ListOfTokens.Add(token);
    				}
    			}
    
    			var stack = new Stack<string>();
    			for (int i = ListOfTokens.Count - 1; i >= 0; i--)
    			{
    				stack.Push(ListOfTokens[i]);
    			}
    			var resultStr = "";
    			while (stack.Count > 0)
    			{
    				var newElement = stack.Pop();
    				if (dictDecod.ContainsKey(newElement))
    				{
    					resultStr += dictDecod[newElement];
    				}
    				else
    				{
    					var addIt = stack.Pop();
    					stack.Push(newElement + addIt);
    				}
    						
    			}
    			Console.WriteLine(resultStr);
    			return resultStr;
    		}
}