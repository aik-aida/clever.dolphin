﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverDolphin
{
    class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color warna = new Color(255, 255, 255, 255);

        public Vector2 size;

        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;

            size = new Vector2(graphics.Viewport.Width / 8, graphics.Viewport.Height / 8);

        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse, SoundEffect effect)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y );

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (warna.A == 255) down = false;
                if (warna.A == 0) down = true;
                if (down) warna.A += 3;
                else warna.A -= 3;

                if (mouse.LeftButton == ButtonState.Pressed)
                { 
                    isClicked = true;
                    effect.Play();

                }
            }
            else if (warna.A < 255)
            {
                warna.A += 3;
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, warna);
        }

        }

    
}
