using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ParallaxStarter
{
    public class Rock : ISprite
    {
        Texture2D texture;
        public BoundingRectangle boundary;

        Rectangle sourceRect = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 101,
            Height = 140
        };

        Vector2 Position { get; set; }


        public Rock(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;

            boundary = new BoundingRectangle(position.X, position.Y, 100, 140);
        }


        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, Position, sourceRect, Color.White);
        }

    }
}
