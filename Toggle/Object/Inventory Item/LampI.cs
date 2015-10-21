﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toggle
{
    class LampI : InventoryItem
    {

        bool batteries = false;
        public LampI()
            : base()
        {
            goodGraphic = Textures.textures["lampoff"];
            badGraphic = Textures.textures["lampoff"];
            width = 32;
            height = 32;
            itemTipGood = "Batteries not included";
            itemTipBad = "Batteries not included";
        }


        public override bool combineItems(InventoryItem i)
        {
            if(i is BatteryGooI && i.getState())
            {
                batteries = true;
                itemTipGood = "I am bright as the sun";
                itemTipBad = "I am bright as the sun";
                goodGraphic = Textures.textures["lampon"];
                badGraphic = Textures.textures["lampon"];
                return true;
            }
            return false;
        }

        public bool hasBatteries()
        {
            return batteries;
        }
    }
 
}