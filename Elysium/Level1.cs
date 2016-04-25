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
            Enemies.LoadContent(Content, "Prowler", 7);
            Heroes.LoadContent(Content);
            background.LoadContent(Content);
            background.setPos(0, -20);
        }
        public SceneManagement Update(GameTime gameTime, ContentManager Content)
        {
            // Check collisions with all elements
            //foreach(Prowler prowler in Enemies.getEnemies())
            //{
            //    foreach(Spaceship spaceship in Heroes.getHeroes())
            //    {
            //        foreach (AutoSprite shot in spaceship.getShots())
            //        {
            //            prowler.Collision(shot.Pos);
            //        }
            //    }
            //}
            for(int i = 0; i < Enemies.Count; i++)
            {
                foreach (Spaceship spaceship in Heroes.getHeroes())
                {
                    foreach (AutoSprite shot in spaceship.getShots())
                    {
                        ((Prowler)Enemies.getEnemies()[i]).Collision(shot.Pos);
                        if (((Prowler)Enemies.getEnemies()[i]).collStat)
                            Enemies.RemoveAt(i);
                    }
                }
            }

            // Finally, update all elements
            Heroes.Update(gameTime, Content);
            Enemies.Update(gameTime);
            background.Update(gameTime);

            // Check for level termination conditions
            if (Enemies.Count <= 0)
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
