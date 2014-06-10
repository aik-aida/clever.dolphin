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
        public Vector2 numberPos;
        public SpriteFont font;
        public Boolean value;
        public String bubbleText;

        public Bubble(Texture2D textureCoin, SpriteFont text, String _string, Boolean val, int id, int row)
            : base(textureCoin)
        {
            Active = true;
            font = text;
            bubbleText = _string;
            value = val;

            int datar = 0;
            int tinggi = 0;
            int satuan = 315;
            switch (id)
            {
                case 1: datar = 1500; break;
                case 2: datar = 1450; break;
                case 3: datar = 1400; break;
            }
            switch (row)
            {
                case 1: tinggi = satuan; break;
                case 2: tinggi = satuan + 110; break;
                case 3: tinggi = satuan + 220; break;
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
            
            destRectangle.X -= 7;
            numberPos.X -= 7;
            if (destRectangle.X < 0)
                Active = false;
        }
    }
}
