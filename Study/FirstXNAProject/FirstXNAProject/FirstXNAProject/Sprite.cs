using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstXNAProject
{
    public class Sprite
    {
        protected Texture2D myTexture2D;
        protected Rectangle myRectangle;

        public Sprite(Texture2D myTexture2D)
        {
            this.myTexture2D = myTexture2D;
        }

        public Sprite(Texture2D myTexture2D, Rectangle myRectangle)
        {
            this.myTexture2D = myTexture2D;
            this.myRectangle = myRectangle;

        }

        public virtual void Update(GameTime gameTime)
        {
           // myRectangle.X += 2;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture2D, myRectangle, Color.White);
        }
    }
}
