using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParallaxStarter
{
    public class Rock : ISprite
    {
        Texture2D spritesheet;
        public BoundingRectangle boundary;

        Rectangle sourceRect = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 101,
            Height = 140
        };

        Vector2 Position { get; set; }


        public Rock(Texture2D spritesheet, Vector2 position)
        {
            this.spritesheet = spritesheet;
            this.Position = position;

            boundary = new BoundingRectangle(position.X, position.Y, sourceRect.Width, sourceRect.Height);
        }


        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // not quite sure if this is right
            spriteBatch.Draw(spritesheet, Position, sourceRect, Color.White);
        }

    }
}
