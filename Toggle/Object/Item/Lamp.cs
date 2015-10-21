﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toggle
{
    class Lamp : Item
    {
        public Lamp(int xLocation, int yLocation): base(xLocation, yLocation)
        {
            goodGraphic = Textures.textures["lampoff"];
            badGraphic = Textures.textures["lampoff"];
            width = 32;
            height = 32;
            imageBoundingRectangle = new Rectangle(0, 0, width, height);
            hitBox = new Rectangle(xLocation, yLocation, width, height);
        }

        public override void makeInventoryItem()
        {
            inventoryItem = new GreenBlockI();
        }
    }
}