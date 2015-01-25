using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level
{
    public Vector2 mCoords;
    public string mLevelPreFab;
    public string mLevelMap;

    public Level(Vector2 coords, string LevelMap)
    {
        mCoords = coords;
		mLevelMap = LevelMap;
    }
}
