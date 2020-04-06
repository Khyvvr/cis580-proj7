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
    public class WinScreen
    {
        SpriteFont spriteFont;

        public void LoadContent(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("font");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(spriteFont, "YOU WIN!", new Vector2(12750, 200), Color.Gold);
            spriteBatch.End();
        }
    }
}
