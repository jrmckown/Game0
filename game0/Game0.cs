using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game0
{
    public class Game0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont magicalDecimal;
        private SpriteFont star;
        private YetiSprite winston;
        private PlaySprite playButton;
        private OptionsSprite optionsButton;
        private CoinSprite[] coin;
        private Texture2D ball;
        //private MonkeySprite monkey;

        public Game0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            winston = new YetiSprite();
            coin = new CoinSprite[]
            {
                new CoinSprite(new Vector2(280, 300)),
                new CoinSprite(new Vector2(300, 300)),
                new CoinSprite(new Vector2(320, 300)),
                new CoinSprite(new Vector2(340, 300)),
                new CoinSprite(new Vector2(360, 300)),
                new CoinSprite(new Vector2(380, 300)),
                new CoinSprite(new Vector2(400, 300)),
                new CoinSprite(new Vector2(420, 300)),
                new CoinSprite(new Vector2(440, 300)),
            };
            playButton = new PlaySprite( new Vector2(300, 250));
            optionsButton = new OptionsSprite(new Vector2(300, 340));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            winston.LoadContent(Content);
            playButton.LoadContent(Content);
            optionsButton.LoadContent(Content);
            foreach (var coin in coin) coin.LoadContent(Content);
            ball = Content.Load<Texture2D>("ball");
            star = Content.Load<SpriteFont>("StardewValley");
            magicalDecimal = Content.Load<SpriteFont>("MagicalDecimal");
            //monkey = new MonkeySprite() { Position = new Vector2(800, 800) };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            winston.Update(gameTime);
            playButton.Update(gameTime);
            optionsButton.Update(gameTime);

            //detect process collisions
            if (playButton.Bounds.CollidesWith(winston.Bounds))
            {
                playButton.color = Color.DarkGray;
            }
            else playButton.color = Color.White;

            if (optionsButton.Bounds.CollidesWith(winston.Bounds))
            {
                optionsButton.color = Color.DarkGray;
            }
            else optionsButton.color = Color.White;
            //monkey.LoadContent(Content);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.DrawString(magicalDecimal, "Esc to exit", new Vector2(2,2), Color.Black, 0, new Vector2(0), (float).8, SpriteEffects.None, 0);
            _spriteBatch.DrawString(magicalDecimal, "Battle Bucket", new Vector2(150, 100), Color.CadetBlue, 0, new Vector2(0), (float)1.5, SpriteEffects.None, 0);

            //draws coin
            foreach (var coin in coin) coin.Draw(gameTime, _spriteBatch);
            //checking a collision box
            //_spriteBatch.Draw(ball, new Vector2(winston.Bounds.X, winston.Bounds.Y), Color.Red);
            //monkey.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            playButton.Draw(gameTime, _spriteBatch);
            optionsButton.Draw(gameTime, _spriteBatch);
            winston.Draw(gameTime, _spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}