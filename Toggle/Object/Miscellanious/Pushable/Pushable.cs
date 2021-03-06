﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Toggle
{
    class Pushable : Miscellanious
    {
        protected bool isPushable;
        public Pushable(int xLocation, int yLocation)
            : base(xLocation, yLocation)
        {
            isPushable = true;
            isSolid = true;
        }

        /*
        public void push(int direction, int amount)
        {
            switch (direction)
            {
                case 0:
                    hitBox.X -= amount;
                    break;
                case 1:
                    hitBox.Y -= amount;
                    break;
                case 2:
                    hitBox.X += amount;
                    break;
                case 3:
                    hitBox.Y += amount;
                    break;
            }
        }
         * */

      
        public bool push(int direction, int amount)
        {
            if(!isPushable)
            {
                return false;
            }
            Rectangle nextHitBox = hitBox;
            switch (direction)
            {
                case 0:
                    nextHitBox.X -= amount;
                    break;
                case 1:
                    nextHitBox.Y -= amount;
                    break;
                case 2:
                    nextHitBox.X += amount;
                    break;
                case 3:
                    nextHitBox.Y += amount;
                    break;
            }

            foreach (Creature c in Game1.creatures)
            {
                Rectangle hitBoxOther = c.getHitBox();
                if (nextHitBox.Intersects(hitBoxOther))
                {
                    return false;
                }
            }
            
            foreach (Tile t in Game1.solidTiles)
            {
                if(t is Wall)
                {
                    Rectangle hitBoxOther = t.getHitBox();
                    if (nextHitBox.Intersects(hitBoxOther))
                    {
                        return false;
                    }
                }

            }

            foreach (Miscellanious m in Game1.miscObjects)
            {
                Rectangle hitBoxOther = m.getHitBox();
                if (!m.Equals(this))
                {
                    if (m.getSolid() == true)
                    {
                        if (nextHitBox.Intersects(hitBoxOther))
                        {
                            return false;
                        }
                    }
                    //depress heavy buttons
                    if ((m is Button) && (nextHitBox.Intersects(hitBoxOther)))
                    {
                        if (((Button)m).isHeavyButton() == true)
                        {
                            m.onTrigger();
                        }
                    }
                }
            }

            hitBox = nextHitBox;
            x = hitBox.X;
            y = hitBox.Y;
            return true;
        }



        public override bool getSolid()
        {
            return isSolid;
        }
        
    }
}
