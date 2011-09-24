namespace Terrawar.Client.XnaExperience.Screen
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class GameplayScreen : BaseGameScreen
    {
        private Texture2D tex;

        public override void LoadContent(IServiceProvider gameServiceProvider)
        {
            var content = new ContentManager(gameServiceProvider, "Content");
            tex = content.Load<Texture2D>("graphics/dirt/1");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // TODO query world status
            spriteBatch.Begin();
            for (int y = 0; y < spriteBatch.GraphicsDevice.DisplayMode.Height; y += 20)
            {
                for (int x = 0; x < spriteBatch.GraphicsDevice.DisplayMode.Width; x += 20)
                {
                    spriteBatch.Draw(tex, new Vector2(x, y), Color.White);
                }
            }

            spriteBatch.End(); 
        }
    }
}
