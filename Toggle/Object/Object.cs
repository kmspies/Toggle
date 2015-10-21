﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace Toggle
{
    class Object
    {
        protected int x, y;
        protected int width, height;
        protected bool state;           //true good, false bad
        protected bool collidable;       //can things collide with this
        protected Texture2D goodGraphic;
        protected Texture2D badGraphic;
        protected Rectangle hitBox;
        protected Rectangle imageBoundingRectangle;
        protected bool isSolid = false;

        public Object(int xLocation, int yLocation)
        {
            x = xLocation;
            y = yLocation;
            state = Game1.worldState;
            collidable = false;

            imageBoundingRectangle = new Rectangle(0, 0, 32, 32);

            width = 32;
            height = 32;
            hitBox = new Rectangle(xLocation, yLocation, width, height);
        }

        public Object()
        {
            state = Game1.worldState;
            collidable = false;

            imageBoundingRectangle = new Rectangle(0, 0, 32, 32);

            width = 32;
            height = 32;
            //hitBox = new Rectangle(xLocation, yLocation, width, height);

        }

        public virtual void switchState(){
            state = !state;
        }

        public Texture2D getGraphic()
        {
            if (state)
                return goodGraphic;
            else
                return badGraphic;
        }

        public virtual void setState(bool st)
        {
            state = st;
        }

        public void setX(int xLocation)
        {
            x = xLocation;
        }

        public void setY(int yLocation)
        {
            y = yLocation;
        }

        public void setPosition(Vector2 v)
        {
            x = (int)(v.X + 0.5);
            y = (int)(v.Y + 0.5);
            hitBox = new Rectangle(x, y, width, height);
        }

        //return true is this is overlapping m
        public bool checkOverlap(Object m)
        {
            bool isOverlap = false;
            if (((x > (m.getX()) - 32) && (x < (m.getX() + 32))) &&
               ((y > (m.getY()) - 32) && (y < (m.getY() + 32))))
            {
                isOverlap = true;
            }
            return isOverlap;
        }

        public bool getCollision() {return collidable;}
        public bool getState() { return state; }
        public int getX(){return x;}
        public int getY(){return y;}
        public Rectangle getHitBox() { return hitBox; }
        public Rectangle getImageBoundingRectangle() { return imageBoundingRectangle; }
        public Vector2 getPositionVector() { return new Vector2(x, y); }
        public Vector2 getPosition(){return new Vector2(x, y); }
        public virtual bool getSolid() { return isSolid; }
        public Vector2 getCenter() { return new Vector2(x + width/2.0f, y + height/2.0f); }

    }
}
