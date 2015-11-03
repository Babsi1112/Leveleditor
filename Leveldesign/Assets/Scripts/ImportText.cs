using UnityEngine;
using System.Collections.Generic; //Generic added because Tutorial
using System.Text.RegularExpressions;

public class ImportText : MonoBehaviour {
	public TextAsset textFile;     // drop your file here in inspector
	//private static int level = 1;


		
		//function to read the Level file
		public string[][] readFile(int level){
			TextAsset bindata= Resources.Load("level"+level.ToString()) as TextAsset;
			string text = bindata.text;
			string[] lines = Regex.Split(text, "\n");
			int rows = lines.Length;
			
			string[][] levelBase = new string[rows][];
			for (int i = 0; i < lines.Length; i++)  {
				string[] stringsOfLine = Regex.Split(lines[i], " ");
				levelBase[i] = stringsOfLine;
			}
			return levelBase;
		}
	
	
}
