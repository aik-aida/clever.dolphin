using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CleverDolphin
{
    class Animation
    {
        int currFrame;
        int totalFrame;
        int frameWidth;
        int frameHeight;
        float delay;
        float elapsed;

        public void Initialize(int totalFrame, float delay,int frameWidth, int frameHeight)
        {
            currFrame = 0;
            elapsed = 0;
            this.totalFrame = totalFrame;
            this.delay = delay;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
        }

        public Rectangle Animate(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (currFrame >= totalFrame)
                {
                    currFrame = 0;
                }
                else
                {
                    currFrame++;
                }
                elapsed = 0;
            }
            return new Rectangle(0, currFrame * frameHeight, frameWidth, frameHeight);
        }

        
    }
}
