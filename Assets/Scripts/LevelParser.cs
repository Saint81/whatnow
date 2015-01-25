using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public enum TileType{EMPTY,BLOCK,ITEM};
public class LevelParser : MonoBehaviour {
	public TileType[,] levelMap;
	public bool blah;
	// Use this for initialization
	void Start () {
        ParseLevel("test.txt");
        //toString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public TileType[,] ParseLevel(string level)
	{
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader file = new StreamReader(Application.dataPath + "/Resources/Levels/" + level, Encoding.Default);
		try
		{
			using(file)
			{
				string line;

					line = file.ReadLine();
					if (line != null)
					{
						string[] tile =  line.Split(' ');
						if(tile.Length > 0)
						{
                            //get header info
                           int height = int.Parse(tile[0]);
                           int width = int.Parse(tile[1]);
                           levelMap = new TileType[height, width];
						}
					}
                    //start reading in the rest of the file into the thing;
                    for (int i = 0; i < levelMap.GetLength(0)/* height */; i++)
                    {
                        line = file.ReadLine();
                        string[] tile = line.Split(' ');
                        for(int j = 0; j < levelMap.GetLength(1) /*width*/; j++)
                        {
                            levelMap[i, j] = (TileType)int.Parse(tile[j]);
						
                        }
                    }
			}
				file.Close();
		}catch(System.Exception e)
		{

		}
		
		return levelMap;
	}

	/*void ParseTile(string[] entries) {
		if (entries[0] == "SIZE")
		{
			int x = int.Parse(entries[1]);
			int y = int.Parse(entries[2]);
			levelMap = new GameObject[x,y];

		}
		else {
			try
			{
				int xCoord = int.Parse(entries[0]);
				int yCoord = int.Parse(entries[1]);
				TileType Ttype = (TileType)(int.Parse(entries[2]));
				Texture2D texture = Resources.Load<Texture2D>(entries[3]);
				GameObject newTile = (GameObject)Instantiate("Tile",new Vector3(xCoord * 50, yCoord * 50, 0),Quaternion.identity);
				newTile.GetComponent<Tile>().mType = Ttype;
				newTile.GetComponent<Tile>().mText = texture;
				levelMap[xCoord,yCoord] = newTile;

			}
			catch (System.Exception e)
			{
				//Debug.Log("{0}\n" + e.Message);
			}
		}
	}
	*/
	void toString()
	{
		int x = levelMap.GetLength(0);
		int y = levelMap.GetLength(1);

		for(int i = 0; i < x; i++)
		{
			for(int j = 0; j < y; j++)
			{
				//if(levelMap[i,j] != null)
				//Debug.Log(levelMap[i,j].mX + " " + levelMap[i,j].mY + " " + levelMap[i,j].mText.ToString());
               // Debug.Log(levelMap[i, j].ToString());
			}
		}
	}

}
