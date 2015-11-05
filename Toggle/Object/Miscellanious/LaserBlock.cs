﻿using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Toggle
{
    class LaserBlock : Pushable
    {
        int updatePeriod;
        bool direction;
        int[] laserEnds = new int[4]; //end points, (left x, right x, top y, bottom y)
        ArrayList laserSegments;
        ArrayList laserDetectors;
        public LaserBlock(int xLocation, int yLocation) : base(xLocation, yLocation)
        {
            direction = true;
            updateGraphic();
            updatePeriod = 0;
        }

        public LaserBlock(int xLocation, int yLocation,bool dirIn)
            : base(xLocation, yLocation)
        {
            direction = dirIn;
            updateGraphic();
            updatePeriod = 0;
        }

        public void updateGraphic()
        {
            if (direction)
            {
                goodGraphic = Textures.textures["lasBoxHori"];
                badGraphic = Textures.textures["lasBoxHori"];
            }
            else
            {
                goodGraphic = Textures.textures["lasBoxVert"];
                badGraphic = Textures.textures["lasBoxVert"];
            }
        }

        public override void onShift()
        {
            base.onShift();
            direction =! direction;
            updateGraphic();
        }

        public int[] getLaserEnds()
        {
            return laserEnds;
        }

        public void calcLaserEnds()
        {
            ArrayList toIterate = new ArrayList();
            toIterate.AddRange(Game1.miscObjects);
            toIterate.AddRange(Game1.solidTiles);
            laserEnds[0] = 0;
            laserEnds[1] = 999;
            laserEnds[2] = 0;
            laserEnds[3] = 999;
            foreach (Object m in toIterate)
            {
                if ((m != this) && (m.getX() == x))
                {
                    //calc laser end points
                    if ((m.getY() > y) && (m.getY() < laserEnds[3]))
                        laserEnds[3] = m.getY();
                    if ((m.getY() < y) && (m.getY() > laserEnds[2]))
                        laserEnds[2] = m.getY();
                }
                if ((m != this) && (m.getY() == y))
                {
                    //calc laser end points
                    if ((m.getX() > x) && (m.getX() < laserEnds[1]))
                        laserEnds[1] = m.getX();
                    if ((m.getX() < x) && (m.getX() > laserEnds[0]))
                        laserEnds[0] = m.getX();
                }
            }
        }

        public override void onUpdate()
        {
            bool zapCreature = false;
            updatePeriod++;
            ArrayList toIterate = new ArrayList();
            if (updatePeriod > 0)
            {
                foreach (Creature c in Game1.creatures)
                {
                    if (c is Player)
                    {
                        toIterate.AddRange(Game1.miscObjects);
                        toIterate.AddRange(Game1.solidTiles);
                        if ((c.getX() == x) && (!direction))
                        {
                            zapCreature = true;
                            foreach (Object m in toIterate)
                            {
                                if ((m != this) && (m.getX() == x))
                                {
                                    //creature below laser case,then above laser case
                                    if (((m.getY() < c.getY()) && (m.getY() > y)) && (c.getY() > y))
                                    {
                                        zapCreature = false;
                                    }
                                    else if (((m.getY() > c.getY()) && (m.getY() < y)) && (c.getY() < y))
                                    {
                                        zapCreature = false;
                                    }
                                }
                            }
                        }
                        if ((c.getY() == y) && (direction))
                        {
                            zapCreature = true;
                            foreach (Object m in toIterate)
                            {
                                if ((m != this) && (m.getY() == y))
                                {
                                    //creature right laser case,then left laser case
                                    if (((m.getX() < c.getX()) && (m.getX() > x)) && (c.getX() > x))
                                    {
                                        zapCreature = false;
                                    }
                                    else if (((m.getX() > c.getX()) && (m.getX() < x)) && (c.getX() < x))
                                    {
                                        zapCreature = false;
                                    }
                                }
                            }
                        }
                    }
                    if (zapCreature)
                    {
                        //should probably change this to be zap(c);, where zap is defined as a method
                        //of Laser block.  This way you don't have only one "zap" affect for a player, and
                        //can easily make different types of zaps (damage variance, world shifting, etc)
                        //c.zap();
                    }
                    
                }
                calcLaserEnds();
            }
            //endmethod

        }
    }
}
