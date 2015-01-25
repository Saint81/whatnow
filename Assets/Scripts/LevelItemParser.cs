using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class LevelItemParser {
	
	public List<LevelParser.SActiveItem>    lActiveItems;

	public void ParseLevel(string level)
	{
		// Create a new StreamReader, tell it which file to read and what encoding the file
		// was saved as
		StreamReader file = new StreamReader(Application.dataPath + "/Resources/Levels/" + level, Encoding.Default);
		
		using(file)
		{
			string line;
			int height = 0, width = 0;
			line = file.ReadLine();
			if (line != null)
			{
				string[] tile =  line.Split(' ');
				if(tile.Length > 0)
				{
					//get header info
					height = int.Parse(tile[0]);
					width = int.Parse(tile[1]);
				}
			}

			//start reading in the rest of the file into the thing;
			for (int i = 0; i < height ; i++)
			{
				line = file.ReadLine();
			}

			// read active items, one per each line
			lActiveItems = new List<LevelParser.SActiveItem>();
			while(true)
			{
				line = file.ReadLine ();
				if(line == null)
					break;
				string[] lItem = line.Split(' ');
				if( lItem.Length == 3 )
				{
					LevelParser.SActiveItem newItem = new LevelParser.SActiveItem();
					newItem.name = lItem[0];
					newItem.x = System.Convert.ToInt16(lItem[1]);
					newItem.y = System.Convert.ToInt16(lItem[2]);
					newItem.noSabotage = (newItem.name == "Sign");
					newItem.isFirst = true;
					foreach(LevelParser.SActiveItem item in lActiveItems)
					{
						if(item.name != newItem.name)
							continue;
						
						newItem.isFirst = false;
						break;
					}
					lActiveItems.Add (newItem);
				}
			}
		}
		file.Close();
	}
}
