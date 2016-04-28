// Title: Level 1
// Description:
//   This level consists of four stages on which the heroes will have to de-
//   feat hordes of enemies from the Evil Empire, to get to the next level
//   they will have to defeat a Boss.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    class Level1
    {
        // Interactive elements
        EnemyControl Enemies;
        HeroControl Heroes;

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
            Enemies.loadEnemies(Content, "Prowler", 7);
            Heroes.LoadContent(Content);
            background.LoadContent(Content);
            background.setPos(0, -20);
            sequencer = Stage.STAGE_1;
        }
        public SceneManagement Update(GameTime gameTime, ContentManager Content)
        {
            if (sequencer == Stage.STAGE_1)
            {
                Enemies.checkCollision<Prowler>(Heroes.getHeroes());
                Heroes.checkCollision<Prowler>(Enemies.getEnemies());

                // Proceed to stage 2
                if (Enemies.Count <= 0)
                {
                    Enemies.loadEnemies(Content, "Cruiser", 1);
                    sequencer = Stage.STAGE_2;
                }
            }

            else if (sequencer == Stage.STAGE_2)
            {
                Enemies.checkCollision<Cruiser>(Heroes.getHeroes());
            }

            // Finally, update all elements
            Heroes.Update(gameTime, Content);
            Enemies.Update(gameTime, Content);
            background.Update(gameTime);

            // Check for level termination conditions
            if (sequencer == Stage.BOSS && Enemies.Count == 0)
                return SceneManagement.LEVEL_2;
            else if (Heroes.Count == 0)
                return SceneManagement.MENU;
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
