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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            winston.LoadContent(Content);
            star = Content.Load<SpriteFont>("StardewValley");
            magicalDecimal = Content.Load<SpriteFont>("MagicalDecimal");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            winston.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.DrawString(magicalDecimal, "Esc to exit", new Vector2(2,2), Color.Black, 0, new Vector2(0), (float).8, SpriteEffects.None, 0);
            _spriteBatch.DrawString(magicalDecimal, "The Game Title", new Vector2(150, 100), Color.CadetBlue, 0, new Vector2(0), (float)1.5, SpriteEffects.None, 0);
            _spriteBatch.End();
            winston.Draw(gameTime, _spriteBatch);
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}