using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace game0
{
    public class MonkeySprite
    {
        private Texture2D texture;

        private double directionTimer;

        private double animationTimer;

        private short animationFrame = 1;

        public Vector2 Position;

        /// <summary>
        /// loads bat sprite
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("monkeyballanimation");
        }


        
        /// <summary>
        /// draws the animated sprite
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // update animation frame
            if (animationTimer > 0.8)
            {
                animationFrame++;
                if (animationFrame > 8) animationFrame = 1;
                animationTimer -= 0.8;
            }
            var source = new Rectangle(animationFrame * 30, 900, 900, 900);
            spriteBatch.Draw(texture, Position, source, Color.White);
        }

    }
}
