using UnityEngine;
using System.Collections.Generic; //Generic added because Tutorial
using System.Text.RegularExpressions;

public class ImportText : MonoBehaviour {
	public TextAsset textFile;     // drop your file here in inspector
		
		//function to read the Level file
		public string[][] readFile(){
			string text = textFile.text;
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
