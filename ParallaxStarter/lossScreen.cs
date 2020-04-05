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
    public class lossScreen
    {
        SpriteFont spriteFont;
        Texture2D texture;

        public void LoadContent(ContentManager content)
        {
            //spriteFont = content.Load<SpriteFont>("font");
            texture = content.Load<Texture2D>("pixel");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(texture, new Rectangle(500, 600, 300, 400), Color.Red);
            spriteBatch.End();
        }
    }
}
