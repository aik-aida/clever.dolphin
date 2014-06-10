using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CleverDolphin
{
    class Squid : Sprite
    {
        public bool Active;
        public Vector2 Position;
        Animation squidAnimation;
        int maxWidth;

        public Squid(Texture2D dolphinTextr, Vector2 position, int width, int height,int maxWidth)
            : base(dolphinTextr)
        {
            Active = true;
            this.maxWidth = maxWidth;
            Position = position;
            squidAnimation = new Animation();
            destRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height/4);
            sourcRectangle = new Rectangle(0, 0, width, height / 4);
        }

        public override void Update(GameTime gameTime)
        {
            destRectangle.X -= 5;

            if (destRectangle.X < 0)
                Active = false;
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, destRectangle, sourcRectangle, Color.White);
            //base.Draw(spriteBatch);
        }
    }
}
