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
        Rectangle rect3;
        Rectangle rect4;
        Texture2D sktTxtr2, sktTxtr3, sktTxtr4;
        int width;
        int height;
        public Sky(Texture2D skyTxtr, Texture2D addPict, Texture2D addPict2, Texture2D addPict3, int width, int height) : base(skyTxtr)
        {
            speed = 2;
            this.width = width;
            this.height = height;
            this.sktTxtr2 = addPict;
            this.sktTxtr3 = addPict2;
            this.sktTxtr4 = addPict3;
            rect1 = new Rectangle(0, 50, this.width, this.height);
            rect2 = new Rectangle(this.width, 50, this.width, this.height);
            rect3 = new Rectangle(this.width*2, 50, this.width, this.height);
            rect4 = new Rectangle(this.width * 3, 50, this.width, this.height);




        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, rect1, Color.White);
            spriteBatch.Draw(sktTxtr2, rect2, Color.White);
            spriteBatch.Draw(sktTxtr3, rect3, Color.White);
            spriteBatch.Draw(sktTxtr4, rect4, Color.White);
           // base.Draw(spriteBatch);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (rect1.X + width <= 0)
                rect1.X = rect4.X + width;
            if (rect2.X + width <= 0)
                rect2.X = rect1.X + width;
            if (rect3.X + width <= 0)
                rect3.X = rect2.X + width;
            if (rect4.X + width <= 0)
                rect4.X = rect3.X + width;

            rect1.X -= speed;
            rect2.X -= speed;
            rect3.X -= speed;
            rect4.X -= speed;
            //myRectangle.X -= 2;
            //base.Update(gameTime);
        }
    }
}
