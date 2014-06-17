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
        
        public int StaminaValue { get; set; }
        public int Width { get; set; }
        
        int staminaParam;
        int height;
        public StaminaGauge(Texture2D staminaText, Vector2 position, int width, int height)
            : base(staminaText)
        {
            Active = true;
            this.Width = width;
            this.height = height;
            staminaParam = 0;
            StaminaValue = width;
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
                StaminaValue -= 10;
                if (StaminaValue == 0)
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
