using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using game0.Collisions;

namespace game0
{
    /// <summary>
    /// A class representing a slime ghost
    /// </summary>
    public class OptionsSprite
    {
       
        private Texture2D texture;

        private Vector2 position = new Vector2(300, 340);

        private BoundingRectangle bounds;
        /// <summary>
        /// bounds of the button
        /// </summary>
        public BoundingRectangle Bounds => bounds;

        public Color color { get; set; } = Color.White;

        public OptionsSprite(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingRectangle(position, 160, 60);
        }

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Options  col_Button");
        }

        /// <summary>
        /// Updates the sprite's position based on user input
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public void Update(GameTime gameTime)
        {
            

        }

        /// <summary>
        /// Draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(texture, position, null, color, 0, new Vector2(64, 64), (float).3, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
