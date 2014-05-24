using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverDolphin
{
    class Sky : Sprite
    {
        Rectangle rect1;
        Rectangle rect2;
        Texture2D sktTxtr2;
        int width;
        int height;
        public Sky(Texture2D skyTxtr, Texture2D addPict, int width, int height) : base(skyTxtr)
        {
            this.width = width;
            this.height = height;
            this.sktTxtr2 = addPict;
            rect1 = new Rectangle(0, 0, this.width, this.height);
            rect2 = new Rectangle(this.width, 0, this.width, this.height);
            
        
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, rect1, Color.White);
            spriteBatch.Draw(sktTxtr2, rect2, Color.White);
           // base.Draw(spriteBatch);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (rect1.X + width <= 0)
                rect1.X = rect2.X + width;
            if (rect2.X + width <= 0)
                rect2.X = rect1.X + width;

            rect1.X -= 2;
            rect2.X -= 2;
            //myRectangle.X -= 2;
            //base.Update(gameTime);
        }
    }
}
