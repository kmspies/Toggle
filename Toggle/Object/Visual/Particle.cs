﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace Toggle
{
    class Particle : Object
    {
        int lifeTime;
        int lifeTick;
        Vector2 directionVector;
        Color cMod;
        float scale;
        float rotation;
        bool scaleGrow; //does particle get smaller (false) or bigger (true)
        public Particle(int xLocation, int yLocation,string graphicString)
            : base(xLocation, yLocation)
        {
            goodGraphic = Textures.textures[graphicString];
            badGraphic = Textures.textures[graphicString];
            cMod = Color.White;
            scale = (float)(Game1.random.NextDouble() * 2);
            scaleGrow = false;
            rotation = (float)(Game1.random.NextDouble() * Math.PI * 2);
            lifeTime = 20 + Game1.random.Next(20);
            lifeTick = lifeTime;
            directionVector = new Vector2((float)((Game1.random.NextDouble() * 10) - 5f), ((float)(Game1.random.NextDouble() * 10) - 5f));
            imageBoundingRectangle = new Rectangle(0,0,32,32);
            int randx = Game1.random.Next(2);
            int randy = Game1.random.Next(2);
            if (graphicString == "particleShadow")
            {
                imageBoundingRectangle = new Rectangle(randx * 16, randy * 16, 16, 16);
            }
        }

        //set velocity cons
        public Particle(int xLocation, int yLocation, string graphicString, float velocity)
            : base(xLocation, yLocation)
        {
            goodGraphic = Textures.textures[graphicString];
            badGraphic = Textures.textures[graphicString];
            cMod = Color.White;
            scale = (float)(Game1.random.NextDouble() * 2);
            scaleGrow = false;
            rotation = (float)(Game1.random.NextDouble() * Math.PI * 2);
            lifeTime = 20 + Game1.random.Next(20);
            lifeTick = lifeTime;
            directionVector = new Vector2((float)((Game1.random.NextDouble() * velocity) - (velocity/2)), ((float)(Game1.random.NextDouble() * velocity) - (velocity/2)));
            imageBoundingRectangle = new Rectangle(0, 0, 32, 32);
            int randx = Game1.random.Next(2);
            int randy = Game1.random.Next(2);
            if (graphicString == "particleShadow")
            {
                imageBoundingRectangle = new Rectangle(randx * 16, randy * 16, 16, 16);
            }
        }

        //set velocity, scale, lifetimebase
        public Particle(int xLocation, int yLocation, string graphicString, float velocity,float scaleIn, int lifeTimeBase,bool scaleGrowin)
            : base(xLocation, yLocation)
        {
            goodGraphic = Textures.textures[graphicString];
            badGraphic = Textures.textures[graphicString];
            cMod = Color.White;
            scale = (float)(Game1.random.NextDouble() * (scaleIn - 0.5f)) + 0.5f;
            scaleGrow = scaleGrowin;
            rotation = (float)(Game1.random.NextDouble() * Math.PI * 2);
            lifeTime = lifeTimeBase + Game1.random.Next(20);
            lifeTick = lifeTime;
            directionVector = new Vector2((float)((Game1.random.NextDouble() * velocity) - (velocity / 2)), ((float)(Game1.random.NextDouble() * velocity) - (velocity / 2)));
            imageBoundingRectangle = new Rectangle(0, 0, 32, 32);
            int randx = Game1.random.Next(2);
            int randy = Game1.random.Next(2);
            if (graphicString == "particleShadow")
            {
                imageBoundingRectangle = new Rectangle(randx * 16, randy * 16, 16, 16);
            }
        }

        public void update()
        {
            setPosition(getPosition() + directionVector);
            spriteAlpha -= ((float)1/lifeTime);
            if (scaleGrow)
                scale += ((float)1 / lifeTime);
            else
                scale -= ((float)1 / lifeTime);
            lifeTick--;
        }
        
        public int getLifetime()
        {
            //if tick is 0 should destroy
            return lifeTick;
        }

        public Color getColor()
        {
            return cMod;
        }

        public float getScale()
        {
            return scale;
        }

        public float getRotation()
        {
            return rotation;
        }

        public virtual Texture2D getGraphic()
        {
            if (state)
                return goodGraphic;
            else
                return badGraphic;
        }

    }
}
