using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParallaxStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        List<Rock> rocks = new List<Rock>();

        lossScreen loss = new lossScreen();
        WinScreen win = new WinScreen();

        bool lost = false;
        bool won = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            loss.LoadContent(Content);
            win.LoadContent(Content);

            var spritesheet = Content.Load<Texture2D>("helicopter");
            player = new Player(spritesheet);

            var rock = Content.Load<Texture2D>("rock");
            rocks.Add(new Rock(rock, new Vector2(350, 200)));
            rocks.Add(new Rock(rock, new Vector2(450, 300)));
            rocks.Add(new Rock(rock, new Vector2(500, 0)));

            rocks.Add(new Rock(rock, new Vector2(1000, 0)));
            rocks.Add(new Rock(rock, new Vector2(1200, 200)));

            rocks.Add(new Rock(rock, new Vector2(1400, 300)));
            rocks.Add(new Rock(rock, new Vector2(1500, 200)));
            rocks.Add(new Rock(rock, new Vector2(1600, 0)));

            rocks.Add(new Rock(rock, new Vector2(1400, 300)));
            rocks.Add(new Rock(rock, new Vector2(1500, 200)));
            rocks.Add(new Rock(rock, new Vector2(1600, 0)));

            rocks.Add(new Rock(rock, new Vector2(1800, 150)));
            rocks.Add(new Rock(rock, new Vector2(1900, 50)));
            rocks.Add(new Rock(rock, new Vector2(2000, 225)));

            rocks.Add(new Rock(rock, new Vector2(2500, 100)));
            rocks.Add(new Rock(rock, new Vector2(2700, 225)));
            rocks.Add(new Rock(rock, new Vector2(2800, 275)));

            rocks.Add(new Rock(rock, new Vector2(3100, 0)));
            rocks.Add(new Rock(rock, new Vector2(3150, 225)));
            rocks.Add(new Rock(rock, new Vector2(3300, 300)));

            rocks.Add(new Rock(rock, new Vector2(3800, 275)));
            rocks.Add(new Rock(rock, new Vector2(4200, 150)));
            rocks.Add(new Rock(rock, new Vector2(4400, 50)));

            rocks.Add(new Rock(rock, new Vector2(4750, 100)));
            rocks.Add(new Rock(rock, new Vector2(4900, 50)));
            rocks.Add(new Rock(rock, new Vector2(5000, 200)));
            rocks.Add(new Rock(rock, new Vector2(5100, 150)));

            rocks.Add(new Rock(rock, new Vector2(5350, 200)));
            rocks.Add(new Rock(rock, new Vector2(5450, 75)));
            rocks.Add(new Rock(rock, new Vector2(5550, 150)));
            rocks.Add(new Rock(rock, new Vector2(5650, 225)));

            rocks.Add(new Rock(rock, new Vector2(9500, 150)));
            rocks.Add(new Rock(rock, new Vector2(9600, 100)));
            rocks.Add(new Rock(rock, new Vector2(9800, 0)));

            rocks.Add(new Rock(rock, new Vector2(10400, 250)));
            rocks.Add(new Rock(rock, new Vector2(10500, 150)));
            rocks.Add(new Rock(rock, new Vector2(10600, 100)));
            rocks.Add(new Rock(rock, new Vector2(10750, 125)));

            rocks.Add(new Rock(rock, new Vector2(11000, 0)));
            rocks.Add(new Rock(rock, new Vector2(11100, 75)));
            rocks.Add(new Rock(rock, new Vector2(11200, 75)));
            rocks.Add(new Rock(rock, new Vector2(11300, 75)));

            rocks.Add(new Rock(rock, new Vector2(11500, 250)));
            rocks.Add(new Rock(rock, new Vector2(11600, 100)));
            rocks.Add(new Rock(rock, new Vector2(11700, 100)));
            rocks.Add(new Rock(rock, new Vector2(11800, 100)));
            rocks.Add(new Rock(rock, new Vector2(11900, 100)));

            rocks.Add(new Rock(rock, new Vector2(12200, 90)));
            rocks.Add(new Rock(rock, new Vector2(12200, 225)));

            rocks.Add(new Rock(rock, new Vector2(12450, 0)));
            rocks.Add(new Rock(rock, new Vector2(12300, 225)));
            rocks.Add(new Rock(rock, new Vector2(12400, 225)));
            rocks.Add(new Rock(rock, new Vector2(12500, 225)));

            var rockLayer = new ParallaxLayer(this);
            foreach (Rock r in rocks)
            {
                rockLayer.Sprites.Add(r);
            }
            rockLayer.DrawOrder = 2;
            Components.Add(rockLayer);



            var backgroundTexture = Content.Load<Texture2D>("background");
            var backgroundSprite = new StaticSprite(backgroundTexture);
            var backgroundLayer = new ParallaxLayer(this);
            backgroundLayer.Sprites.Add(backgroundSprite);
            backgroundLayer.DrawOrder = 0;
            Components.Add(backgroundLayer);

            var playerLayer = new ParallaxLayer(this);
            playerLayer.Sprites.Add(player);
            playerLayer.DrawOrder = 2;
            Components.Add(playerLayer);

            var midgroundTextures = new Texture2D[]
            {
                Content.Load<Texture2D>("midground1"),
                Content.Load<Texture2D>("midground2")
            };

            var midgroundSprites = new StaticSprite[]
            {
                new StaticSprite(midgroundTextures[0]),
                new StaticSprite(midgroundTextures[1], new Vector2(3500, 0))
            };

            var midgroundLayer = new ParallaxLayer(this);
            midgroundLayer.Sprites.AddRange(midgroundSprites);
            midgroundLayer.DrawOrder = 1;

            var midgroundScrollController = midgroundLayer.ScrollController as AutoScrollController;
            midgroundScrollController.Speed = 40f;
            Components.Add(midgroundLayer);


            var foregroundTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("foreground1"),
                Content.Load<Texture2D>("foreground2"),
                Content.Load<Texture2D>("foreground3"),
                Content.Load<Texture2D>("foreground4")
            };

            var foregroundSprites = new List<StaticSprite>();
            for(int i = 0; i < foregroundTextures.Count; i++)
            {
                var position = new Vector2(i * 3500, 0);
                var sprite = new StaticSprite(foregroundTextures[i], position);
                foregroundSprites.Add(sprite);
            }

            var foregroundLayer = new ParallaxLayer(this);
            foreach(var sprite in foregroundSprites)
            {
                foregroundLayer.Sprites.Add(sprite);
            }

            foregroundLayer.DrawOrder = 4;

            var foregroundScrollController = foregroundLayer.ScrollController as AutoScrollController;
            foregroundScrollController.Speed = 80f;
            Components.Add(foregroundLayer);

            var playerScrollController = playerLayer.ScrollController as AutoScrollController;
            playerScrollController.Speed = 80f; 



            // SCROLLING WITH PLAYER (PART 8 IN LAB TUTORIAL)
            backgroundLayer.ScrollController = new PlayerTrackingScrollController(player, 0.1f);
            midgroundLayer.ScrollController = new PlayerTrackingScrollController(player, 0.4f);
            playerLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
            rockLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
            foregroundLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            foreach (Rock r in rocks)
            {
                if (player.boundary.CollidesWith(r.boundary))
                {
                    lost = true;
                }
            }

            foreach (Rock r in rocks)
            {
                if (player.Position.X > r.boundary.X)
                {
                    won = true;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            if (lost == true)
            {
                loss.Draw(spriteBatch);
            }
            
            if (won == true)
            {
                win.Draw(spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
