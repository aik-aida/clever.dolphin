using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace CleverDolphin
{
   
    class Bubble : Sprite
    {
        Vector2 numberPos;
        SpriteFont font;
        Boolean value;
        String bubbleText;

        public Bubble(Texture2D textureCoin, SpriteFont text, String _string, Boolean val, int id, int row)
            : base(textureCoin)
        {
            font = text;
            bubbleText = _string;
            value = val;

            int datar = 0;
            int tinggi = 0;
            switch (id)
            {
                case 1: datar = 1500; break;
                case 2: datar = 1450; break;
                case 3: datar = 1400; break;
            }
            switch (row)
            {
                case 1: tinggi = 350; break;
                case 2: tinggi = 500; break;
                case 3: tinggi = 650; break;
            }

            numberPos = new Vector2(datar + 20, tinggi + 20);
            destRectangle = new Rectangle(datar, tinggi, 140, 80);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, destRectangle, Color.White);
            spriteBatch.DrawString(font, bubbleText, numberPos, Color.Black);

        }

        public override void Update(GameTime gameTime)
        {
            destRectangle.X -= 2;
            numberPos.X -= 2;
        }
    }
}
