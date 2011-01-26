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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Gears.Cloud;

namespace GearsDebug
{
    public class GearsDebug : Microsoft.Xna.Framework.Game
    {
        //Screen Resolution defaults
        private const int ScreenWidth = 1280;
        private const int ScreenHeight = 720;

        private GraphicsDeviceManager graphics;
        private GraphicsDevice device;
        private SpriteBatch spriteBatch;

        public GearsDebug()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            //VERSION
            VersionManager.Version = "0.1.0";

            //Register our ContentManager
            ContentButler.setGame(this);

            //Setup screen display/graphics device
            ViewportHandler.SetScreen(ScreenWidth, ScreenHeight);
            graphics.PreferredBackBufferWidth = ViewportHandler.GetWidth();
            graphics.PreferredBackBufferHeight = ViewportHandler.GetHeight();
            graphics.IsFullScreen = false;
<<<<<<< HEAD
            graphics.ApplyChanges();
            
            //TODO: GetVersionInformation();
=======
            graphics.ApplyChanges();      
>>>>>>> cec7cc02e86c5d16618a97923c90265584afbb9f
            

            #if DEBUG
                Window.Title = "Gears [Debug] v." + VersionManager.Version;

                // MAYBE TODO: Make this enum based for easier switching?
                //  DEBUG :: The uncommented line will change the default state that runs first.
                //  Only one of the following Master.Push() lines should be uncommented at a time.
                //Master.Push(new Splash());    //Uncomment this line to start game normally.
                Master.Push(new debugger());    //Uncomment this line to start the game with debug menu.
                //  END of Master.Push() lines
                
            #else //release
                Window.Title = "Gears v." + versionManager.Version;
                Master.Push(new Splash()); //Start game normally
            #endif

            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(device);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            Master.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Master.GetClearColor());

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, ViewportHandler.GetScaleMatrix());

            Master.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }


    };

}