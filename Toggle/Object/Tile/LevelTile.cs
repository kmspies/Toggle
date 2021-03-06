﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Toggle
{
    public class LevelTile : Tile
    {
        Point playerStartLocation; 
        string level;
        public LevelTile(int xLocation, int yLocation, String gGraphic, String bGraphic, string level)
            : base(xLocation, yLocation, gGraphic, bGraphic)
        {
            this.level = level;
            playerStartLocation = new Point(0,0);
        }

        public LevelTile(int xLocation, int yLocation, String gGraphic, String bGraphic, string level, Point loc)
            : base(xLocation, yLocation, gGraphic, bGraphic)
        {
            this.level = level;
            playerStartLocation = loc;
            //make em all doors?!?
            goodGraphic = Textures.textures["door"];
            badGraphic = Textures.textures["doorDark"];
        }

        public string getLevel()
        {
            return level;
        }

        public Point getPlayerStart()
        {
            return playerStartLocation;
        }

    }
}
