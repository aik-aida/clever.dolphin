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

        enum GameState
        {
            MainMenu,
            Playing,
            GameOver
        }
        GameState CurrentGameState = GameState.MainMenu;


        Button btnPlay;
        Button btnPlayAgain;
        Button btnExit;
        Button btnExit2;

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
        Vector2 fontHighScore2;
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

        Texture2D staminaPict;
        Texture2D highScorePict;
        Texture2D ScorePict;
        StaminaGauge staminaGauge;
        Random rand;

        SoundEffect effect, effect_1, effect_2, effect_3, effect_4;
        Song song, song_1;

        int tempScore;
        int initialNumber;
        int windowHeight;
        int windowWidth;
        int stopSpawn;

        static string text;
        string rating;
        string displayRating;
        string tempRating;
        int correctAns;
        static int text3;
        int highscores;
        int tempHighScore;

        float delay;
        float timeSpan;
        float delayColor;
        float timeSpanColor;
        float totalElapsedTime;

        int tempSquidSpeed;
        int tempCanSpeed;
        int tempBubbleSpeed;
        public static bool status = true;
        public static string path;
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

           //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {


            rand = new Random();
            initialNumber = rand.Next(1, 10);
            rating = "Newbie";
            displayRating = "Newbie";
            tempRating = string.Copy(rating);
            timeSpan = 0;
            delay = 1;
            delayColor = 50;
            stopSpawn = 0;
            tempSquidSpeed = 7;
            tempCanSpeed = 10;
            tempBubbleSpeed = 7;
            listCumi = new List<Sprite>();
            listKaleng = new List<Sprite>();
            prevTimeBubble = TimeSpan.Zero;
            prevTimeCumi = TimeSpan.Zero;
            prevTimeKaleng = TimeSpan.Zero;
            timeAddCumi = TimeSpan.Zero;
            timeAddBubble = TimeSpan.Zero;
            timeAddKaleng = TimeSpan.Zero;
            newTimeBubble = TimeSpan.FromSeconds(4.0);
            newTimeKaleng = TimeSpan.FromSeconds(0.8);
            newTimeCumi = TimeSpan.FromSeconds(0.5);

            base.Initialize();
        }

        public void LoadGame()
        {
            ResetGame();
            rand = new Random();
            initialNumber = rand.Next(1, 10);
            rating = "Newbie";
            tempRating = string.Copy(rating);
            timeSpan = 0;
            delay = 1;
            delayColor = 50;
            stopSpawn = 0;
            tempSquidSpeed = 7;
            tempCanSpeed = 10;
            tempBubbleSpeed = 7;
            listCumi = new List<Sprite>();
            listKaleng = new List<Sprite>();
            prevTimeBubble = TimeSpan.Zero;
            prevTimeCumi = TimeSpan.Zero;
            prevTimeKaleng = TimeSpan.Zero;
            timeAddCumi = TimeSpan.Zero;
            timeAddBubble = TimeSpan.Zero;
            timeAddKaleng = TimeSpan.Zero;
            newTimeBubble = TimeSpan.FromSeconds(4.0);
            newTimeKaleng = TimeSpan.FromSeconds(0.8);
            newTimeCumi = TimeSpan.FromSeconds(0.5);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //graphics.PreferredBackBufferWidth = windowWidth;
            //graphics.PreferredBackBufferHeight = windowHeight;

            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new Button(Content.Load<Texture2D>("Play"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(200, 400));

            btnPlayAgain = new Button(Content.Load<Texture2D>("playAgain2"), graphics.GraphicsDevice);
            btnPlayAgain.setPosition(new Vector2(200, 400));

            btnExit = new Button(Content.Load<Texture2D>("exit2"), graphics.GraphicsDevice);
            btnExit.setPosition(new Vector2(400, 400));

            btnExit2 = new Button(Content.Load<Texture2D>("exit2"), graphics.GraphicsDevice);
            btnExit2.setPosition(new Vector2(400, 400));

            dolphin = new Dolphin(Content.Load<Texture2D>("si lumba lumba"), playerPosition, 140, 240, windowHeight);
            sky = new Sky(Content.Load<Texture2D>("awan copy"), Content.Load<Texture2D>("awan copy2"), Content.Load<Texture2D>("awan copy3"), Content.Load<Texture2D>("awan copy4"), windowWidth, 380);
            ocean = new Ocean(Content.Load<Texture2D>("seapolos1"), Content.Load<Texture2D>("seapolos2"), windowWidth, windowHeight);
            _3pilihan = new _3choise(Content.Load<Texture2D>("si bubble"), Content.Load<SpriteFont>("medium"), initialNumber);
            staminaPict = Content.Load<Texture2D>("dasaran stamina");
            highScorePict = Content.Load<Texture2D>("highscore");
            ScorePict = Content.Load<Texture2D>("score");
            staminaGauge = new StaminaGauge(Content.Load<Texture2D>("stamina"), new Vector2(55, 5), 180, 40);
            score = Content.Load<SpriteFont>("coinText");
            fontScore = new Vector2(1100, 0);
            fontHighScore = new Vector2(250, 0);
            fontHighScore2 = new Vector2(810, 0);
            // staminaBar = new Vector2(50,0);


            effect = Content.Load<SoundEffect>("button-3");
            effect_1 = Content.Load<SoundEffect>("BUBBLE");
            effect_2 = Content.Load<SoundEffect>("dolphin");
            effect_3 = Content.Load<SoundEffect>("Reaction, Children Sound Effects");
            effect_4 = Content.Load<SoundEffect>("Disappointed Cartoon Booing Group Sound Effects");
            song = Content.Load<Song>("CAREFREE AND HAPPY UPBEAT UKULELE INSTRUMENTAL BACKGROUND MUSIC - Mp3 Download (2.70 MB)");
            song_1 = Content.Load<Song>("Hans_zimmer_-_Beach_song_[HD_");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

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

            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    else if (btnExit2.isClicked == true)
                    {
                        //effect_4.Play();
                        Exit();
                    }
                    btnPlay.Update(mouse, effect);
                    btnExit2.Update(mouse, effect);
                    break;

                case GameState.Playing:
                    
                    dolphin.UpdateMovement(gameTime, effect_1);
                    fontNumber = dolphin.numberPos;

                    sky.Update(gameTime);
                    ocean.Update(gameTime);
                    UpdateThing(gameTime);
                    staminaGauge.Update(gameTime);
                    GameEfect(gameTime);


                    if (status == false)
                    {
                        if (tempHighScore > highscores)
                        {
                            var input = text3.ToString();
                            System.IO.File.WriteAllText(path, input);
                        }
                        CurrentGameState = GameState.GameOver;
                    }

                    break;

                case GameState.GameOver:
                    if (btnPlayAgain.isClicked == true)
                    {
                        effect_3.Play();
                        LoadGame();
                        //Initialize();
                        CurrentGameState = GameState.Playing;
                        
                        status = true;
                    }
                    else if (btnExit.isClicked == true)
                    {
                        effect_4.Play();
                        Exit();
                    }
                    
                    btnPlayAgain.Update(mouse, effect);
                    btnExit.Update(mouse, effect);
                    break;

                default:
                    break;
            }


        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("halamanDepan"), new Rectangle(0, 0, windowWidth, windowHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnExit2.Draw(spriteBatch);
                    break;

                case GameState.Playing:
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
                    spriteBatch.DrawString(score, displayRating, fontHighScore, Color.Black);
                    spriteBatch.DrawString(score, text3.ToString(), fontHighScore2, Color.Black);
                    // spriteBatch.DrawString(score, staminaValue.ToString(), staminaBar, Color.Yellow);
                    spriteBatch.DrawString(number, initialNumber.ToString(), fontNumber, Color.White);
                    spriteBatch.Draw(staminaPict, new Rectangle(50, 2, 190, 47), Color.White);
                    spriteBatch.Draw(highScorePict, new Rectangle(740, 0, 250, 52), Color.White);
                    spriteBatch.Draw(ScorePict, new Rectangle(1000, 0, 250, 52), Color.White);
                    staminaGauge.Draw(spriteBatch);

                    break;

                case GameState.GameOver:
                    //GraphicsDevice.Reset();
                    
                    
                    spriteBatch.Draw(Content.Load<Texture2D>("halamanDepan"), new Rectangle(0, 0, windowWidth, windowHeight), Color.White);
                    btnPlayAgain.Draw(spriteBatch);
                    btnExit.Draw(spriteBatch);
                    break;

                default:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void GameEfect(GameTime gameTime)
        {
            rating = UpdateRating(correctAns);
            UpdateSpeed(gameTime);

            if (dolphin.colorBody != Color.White)
            {
                timeSpanColor += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timeSpanColor > delayColor)
                {
                    dolphin.colorBody = Color.White;
                    timeSpanColor = 0;
                }
            }


        }

        private void UpdateSpeed(GameTime gameTime)
        {
            totalElapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            foreach (var squid in listCumi)
                squid.speed = tempSquidSpeed;

            foreach (var bubble in _3pilihan.listBubble)
                bubble.speed = tempBubbleSpeed;

            foreach (var can in listKaleng)
                can.speed = tempCanSpeed;

            if (totalElapsedTime > 20000 && ocean.speed < 13)
            {
                ocean.speed++;
                sky.speed++;
                tempBubbleSpeed++;
                tempSquidSpeed++;
                tempCanSpeed++;
                totalElapsedTime = 0;
            }
        }

        public String UpdateRating(int nCorrect)
        {
            String rateNow = "";
            if (nCorrect >= 3 && nCorrect < 6)
            {
                rateNow = "Moderate";
                rating = "Moderate";
                displayRating = "Moderate";
                
            }

            if (nCorrect >= 6 && nCorrect < 10)
            {
                rateNow = "Smart";
                rating = "Smart";
                displayRating = "Smart";
            }

            if (nCorrect >= 10 && nCorrect < 15)
            {
                rateNow = "Clever";
                rating = "Clever";
                displayRating = "Clever";
            }

            if (nCorrect >= 18 && nCorrect < 23)
            {
                rateNow = "Genius";
                rating = "Genius";
                displayRating = "Genius";
            }

            if (nCorrect >= 23 && nCorrect <= 30)
            {
                rateNow = "Professor";
                rating = "Professor";
                displayRating = "Professor";
            }

            return rateNow;
        }

        private void CollisionThing(SoundEffect effect_2)
        {
            Sprite bubbleRemove = null;

            foreach (Sprite sp in _3pilihan.listBubble)
            {
                if (dolphin.destRectangle.Intersects(sp.destRectangle))
                {
                    bubbleRemove = sp;
                    if (((Bubble)sp).value)
                    {
                        dolphin.colorBody = Color.Yellow;
                        tempScore += 100;
                        correctAns += 1;
                        _3pilihan.listBubble.Clear();
                        effect_2.Play();
                        break;
                    }
                    else
                    {
                        dolphin.colorBody = Color.Red;
                        if (correctAns > 0)
                            correctAns -= 1;

                        staminaGauge.StaminaValue -= 10;
                        staminaGauge.sourcRectangle.Width -= 10;
                        staminaGauge.destRectangle.Width -= 10;
                        //tempScore -= 50;
                        _3pilihan.listBubble.Clear();
                        break;
                    }

                }
            }

            foreach (Sprite rp in listCumi)
            {
                if (dolphin.destRectangle.Intersects(rp.destRectangle))
                {
                    if (staminaGauge.StaminaValue < staminaGauge.Width)
                    {
                        staminaGauge.StaminaValue += 7;
                        staminaGauge.sourcRectangle.Width += 7;
                        staminaGauge.destRectangle.Width += 7;
                    }
                    rp.Active = false;
                    tempScore += 50;
                    effect_2.Play();
                    break;
                }
            }

            foreach (Sprite smp in listKaleng)
            {
                if (dolphin.destRectangle.Intersects(smp.destRectangle))
                {
                    staminaGauge.StaminaValue -= 7;
                    staminaGauge.sourcRectangle.Width -= 7;
                    staminaGauge.destRectangle.Width -= 7;
                    smp.Active = false;
                    tempScore -= 50;
                    break;
                }
            }

            if (bubbleRemove != null)
                _3pilihan.listBubble.Remove(bubbleRemove);

            //access highscore
            path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\\highscore.txt");
            text = System.IO.File.ReadAllText(path);
            int.TryParse(text, out text3);
            tempHighScore = text3;
            highscores = text3;

            if (tempScore == 0 || highscores > tempScore)
            {
                text3 = tempHighScore;
            }
            else if (highscores == tempScore || highscores < tempScore)
            {
                tempHighScore = tempScore;
                text3 = tempHighScore;
            }

            /*if (status == false)// || tempHighScore > highscores)
            {
                var input = text3.ToString();
                System.IO.File.WriteAllText(path, input);
                CurrentGameState = GameState.GameOver;
            }*/


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
                case 3: y = satuan + 220; break;
            }
            switch (kaleng)
            {
                case 1: kaleng = satuan + 10; break;
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

            if (timeAddCumi > newTimeCumi && stopSpawn == 0 || timeAddKaleng > newTimeKaleng && listKaleng.Count <= 1 && stopSpawn == 0)
            {
                if (timeAddCumi > newTimeCumi && stopSpawn == 0)
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

            CollisionThing(effect_2);
        }

        private void AccessHighScore()
        {
            text = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "\\highscore.txt"));
            correctAns = Convert.ToInt32(text);

        }

        private void ResetGame()
        {
            //rating = "Newbie";
            correctAns = 0;
            tempScore = 0;
            tempSquidSpeed = 7;
            tempCanSpeed = 10;
            tempBubbleSpeed = 7;
            staminaGauge.StaminaValue -= staminaGauge.Width;
            staminaGauge.sourcRectangle.Width -= staminaGauge.Width;
            staminaGauge.destRectangle.Width -= staminaGauge.Width;
        }
    }
}

