using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ImportText : MonoBehaviour {
	public TextAsset textFile;   
		
		//function to read the Level file
		public string[][] readFile(int level){
			TextAsset bindata= Resources.Load("level"+level.ToString()) as TextAsset;

			//TextAsset bindata= Resources.Load("Testlevel") as TextAsset;
			string textRead = bindata.text;
			string[] lines = Regex.Split(textRead, "\n");
			int rows = lines.Length;
			
			string[][] levelBase = new string[rows][];
			for (int i = 0; i < lines.Length; i++)  {
				string[] stringsOfLine = Regex.Split(lines[i], " ");
				levelBase[i] = stringsOfLine;
			}
			return levelBase;
		}
	
	
}
