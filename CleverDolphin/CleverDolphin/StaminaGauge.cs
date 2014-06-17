using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverDolphin
{
    class StaminaGauge : Sprite
    {
        int staminaValue;
        int staminaParam;
        int width;
        int height;
        public StaminaGauge(Texture2D staminaText, Vector2 position, int width, int height)
            : base(staminaText)
        {
            Active = true;
            this.width = width;
            this.height = height;
            staminaParam = 0;
            staminaValue = width;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            sourcRectangle = new Rectangle(0,0,width, height);
 
        }

        public override void Update(GameTime gameTime)
        {
            staminaParam += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (staminaParam > 2000)
            {
                destRectangle.Width-=10;
                sourcRectangle.Width-=10;
                staminaValue -= 10;
                if (staminaValue == 0)
                {
                    Game1.status = false;
                }
                staminaParam = 0;
            }
            //sourcRectangle = new Rectangle(0,0, width, height);
            //base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, destRectangle, sourcRectangle, Color.White);
            //base.Draw(spriteBatch);
        }
    }
}
