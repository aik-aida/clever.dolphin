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
using System.IO;

namespace CleverDolphin
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Dolphin dolphin;

        Sprite ocean;
        Sprite sky;
        List<Sprite> listCumi;
        List<Sprite> listKaleng;

        _3choise _3pilihan;
        SpriteFont score;
        SpriteFont number;

        Vector2 playerPosition;
        Vector2 fontScore;
        Vector2 fontHighScore;
        Vector2 fontNumber;

        TimeSpan newTimeBubble;
        TimeSpan newTimeCumi;
        TimeSpan newTimeKaleng;
        TimeSpan prevTimeBubble;
        TimeSpan prevTimeCumi;
        TimeSpan prevTimeKaleng;
        TimeSpan timeAddCumi;
        TimeSpan timeAddKaleng;
        TimeSpan timeAddBubble;
        Random rand;

        int tempScore;
        int initialNumber;
        int windowHeight;
        int windowWidth;
        int stopSpawn;

        string text;
        int text2;

        float delay;
        float timeSpan;


        public Game1()
        {

            windowHeight = 720;
            windowWidth = 1280;
            playerPosition = new Vector2(35, 330);
            tempScore = 0;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;

            // graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            rand = new Random();
            initialNumber = rand.Next(1, 10);
            timeSpan = 0;
            delay = 1;
            stopSpawn = 0;
            listCumi = new List<Sprite>();
            listKaleng = new List<Sprite>();
            prevTimeBubble = TimeSpan.Zero;
            prevTimeCumi = TimeSpan.Zero;
            prevTimeKaleng = TimeSpan.Zero;
            timeAddCumi = TimeSpan.Zero;
            timeAddBubble = TimeSpan.Zero;
            timeAddKaleng = TimeSpan.Zero;
            newTimeBubble = TimeSpan.FromSeconds(4.0);
            newTimeKaleng= TimeSpan.FromSeconds(0.8);
            newTimeCumi = TimeSpan.FromSeconds(0.5);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dolphin = new Dolphin(Content.Load<Texture2D>("si lumba lumba"), playerPosition, 140, 240, windowHeight);
            sky = new Sky(Content.Load<Texture2D>("awan copy"), Content.Load<Texture2D>("awan copy2"), Content.Load<Texture2D>("awan copy3"), Content.Load<Texture2D>("awan copy4"), windowWidth, 380);
            ocean = new Ocean(Content.Load<Texture2D>("seapolos1"), Content.Load<Texture2D>("seapolos2"), windowWidth, windowHeight);
            _3pilihan = new _3choise(Content.Load<Texture2D>("si bubble"), Content.Load<SpriteFont>("medium"), initialNumber);

            score = Content.Load<SpriteFont>("coinText");
            fontScore = new Vector2(1100, 0);
            fontHighScore = new Vector2(500, 0);

            number = Content.Load<SpriteFont>("small");
            fontNumber = dolphin.numberPos;

            AddThing();

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            dolphin.UpdateMovement(gameTime);
            fontNumber = dolphin.numberPos;

            sky.Update(gameTime);
            ocean.Update(gameTime);
            UpdateThing(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            sky.Draw(spriteBatch);
            ocean.Draw(spriteBatch);
            dolphin.Draw(spriteBatch);

            //menampilkan list Bubble
            foreach (Sprite sp in _3pilihan.listBubble)
                sp.Draw(spriteBatch);

            foreach (Sprite rp in listCumi)
                rp.Draw(spriteBatch);

            foreach (Sprite smp in listKaleng)
                smp.Draw(spriteBatch);

            //menampilkan font score Bubble
            spriteBatch.DrawString(score, tempScore.ToString(), fontScore, Color.Black);
            spriteBatch.DrawString(score, text2.ToString(), fontHighScore, Color.Black);
            spriteBatch.DrawString(number, initialNumber.ToString(), fontNumber, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void CollisionThing()
        {
            Sprite bubbleRemove = null;

            foreach (Sprite sp in _3pilihan.listBubble)
            {
                if (dolphin.destRectangle.Intersects(sp.destRectangle))
                {
                    bubbleRemove = sp;
                    if (((Bubble)sp).value)
                    {
                        tempScore += 100;
                        text2 += 1;
                        _3pilihan.listBubble.Clear();
                        break;
                    }
                    else
                    {
                        tempScore -= 50;
                        _3pilihan.listBubble.Clear();
                        break;
                    }

                }
            }

            foreach (Sprite rp in listCumi)
            {
                if (dolphin.destRectangle.Intersects(rp.destRectangle))
                {
                    rp.Active = false;
                    tempScore += 50;
                    break;
                }
            }

            foreach (Sprite smp in listKaleng) {
                if(dolphin.destRectangle.Intersects(smp.destRectangle)) {
                    smp.Active = false;
                    tempScore -= 50;
                    break;
                }
            }

            if (bubbleRemove != null)
                _3pilihan.listBubble.Remove(bubbleRemove);


        }

        private void AddThing()
        {
            int y, kaleng, nCumi, nKaleng;
            Random r = new Random();

            nCumi = r.Next(1, 6);
            nKaleng = r.Next(1, 3);
            int satuan = 315;

            y = r.Next(1, 4);
            kaleng = r.Next(1, 4); ;

            switch (y)
            {
                case 1: y = satuan; break;
                case 2: y = satuan + 110; break;
                case 3: y = satuan + 220;  break;
            }
            switch (kaleng)
            {
                case 1: kaleng = satuan+10; break;
                case 2: kaleng = satuan + 1200; break;
                case 3: kaleng = satuan + 240; break;
            }
            
            listCumi.Add(new Cumi(Content.Load<Texture2D>("si cumi cumi"), new Vector2(windowWidth, y), 58, 123));
            listKaleng.Add(new Trash(Content.Load<Texture2D>("sampah"), new Vector2(windowWidth, kaleng), 30, 52));

        }


        private void UpdateThing(GameTime gameTime)
        {
            timeSpan += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeAddCumi = gameTime.TotalGameTime - prevTimeCumi;
            timeAddBubble = gameTime.TotalGameTime - prevTimeBubble;
            timeAddKaleng = gameTime.TotalGameTime - prevTimeKaleng;

            if (timeAddBubble > newTimeBubble && stopSpawn == 0)
            {
                prevTimeBubble = gameTime.TotalGameTime;
                _3pilihan.listBubble.Clear();
                _3pilihan.UpdateList();
                stopSpawn = 1;
                //AddThing();
            }

            if (timeAddCumi > newTimeCumi && stopSpawn == 0 || timeAddKaleng > newTimeKaleng && stopSpawn == 0)
            {
                if(timeAddCumi > newTimeCumi && stopSpawn == 0)
                    prevTimeCumi = gameTime.TotalGameTime;
                if (timeAddKaleng > newTimeKaleng && stopSpawn == 0)
                    prevTimeKaleng = gameTime.TotalGameTime;
                AddThing();
                stopSpawn = 1;
                //timeSpan = 0;
            }


            if (timeSpan > delay)
            {
                stopSpawn = 0;
                timeSpan = 0;
            }
            foreach (Sprite sp in _3pilihan.listBubble)
                sp.Update(gameTime);


            for (int i = 0; i < listCumi.Count; i++)
            {
                if (!listCumi[i].Active)
                    listCumi.RemoveAt(i);
                else
                    listCumi[i].Update(gameTime);
            }

            for (int i = 0; i < listKaleng.Count; i++)
            {
                if (!listKaleng[i].Active)
                    listKaleng.RemoveAt(i);
                else
                    listKaleng[i].Update(gameTime);
            }

            CollisionThing();
        }

        private void AccessHighScore()
        {
            text = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "\\highscore.txt"));
            text2 = Convert.ToInt32(text);

        }
    }
}

