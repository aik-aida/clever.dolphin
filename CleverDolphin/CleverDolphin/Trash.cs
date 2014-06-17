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
    class Trash : Sprite
    {
        public Trash(Texture2D texture, Vector2 position, int width, int height)
            : base(texture)
        {
            speed = 10;
            Active = true;
            myTexture = texture;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public override void Update(GameTime gameTime)
        {
            destRectangle.X -= speed;
            if (destRectangle.X < 0)
                Active = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, destRectangle, Color.White);
        }
    }
}
