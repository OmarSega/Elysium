using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace Elysium
{
    class Level1
    {
        // Interactive elements
        EnemyControl Enemies;
        HeroControl Heroes;
        SpriteFont font;

        // Scene
        Background background;

        // Game control
        Stage sequencer;

        public void Initialize()
        {
            // Initialization of all scene components
            Enemies = new EnemyControl();
            Heroes = new HeroControl();
            background = new Background();

            // Background initialization
            background.Init("FondoNivel2");
        }
        public void LoadContent(ContentManager Content)
        {
            // Load content for all scene elements
            Enemies.loadEnemies(Content, "Prowler", 1);
            Heroes.LoadContent(Content);
            background.LoadContent(Content);
            background.setPos(0, -20);
            sequencer = Stage.STAGE_1;
        }
        public SceneManagement Update(GameTime gameTime, ContentManager Content)
        {
            // Delete check for enemies-shot collision
            if(sequencer == Stage.STAGE_1)
            {
                Enemies.Collision(Heroes.getHeroes());

                // Proceed to the next stage
                if(Enemies.Count <= 0)
                {
                    Enemies.loadEnemies(Content, "Cruiser", 1);
                    sequencer = Stage.STAGE_2;
                }
            }

            else if (sequencer == Stage.STAGE_2)
            {
                Enemies.Collision(Heroes.getHeroes());
            }

            // Finally, update all elements
            Heroes.Update(gameTime, Content);
            Enemies.Update(gameTime, Content);
            background.Update(gameTime);

            // Check for level termination conditions
            if (Enemies.Count <= -1)
                return SceneManagement.LEVEL_2;
            else
                return SceneManagement.LEVEL_1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all elements
            background.Draw(spriteBatch);
            Enemies.Draw(spriteBatch);
            Heroes.Draw(spriteBatch);
        }
    }
}
