namespace Terrawar.Client.XnaExperience.ScreenManager
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Terrawar.Client.XnaExperience.Screen;

    public class TerrawarScreenManager : DrawableGameComponent
    {
        private readonly List<BaseGameScreen> screens;
        private SpriteBatch spriteBatch;
        private bool isInitialized;

        public TerrawarScreenManager(Game game)
            : base(game)
        {
            this.screens = new List<BaseGameScreen>();
        }

        public void AddScreen(BaseGameScreen screen)
        {
            if (this.isInitialized)
            {
                screen.LoadContent(Game.Services);
            }

            this.screens.Add(screen);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(var screen in this.screens)
            {
                screen.Draw(gameTime, this.spriteBatch);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            this.isInitialized = true;
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var screen in this.screens)
            {
                screen.LoadContent(Game.Services);
            }
        }
    }
}
