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
        ArrayList Heroes;
        ArrayList Prowlers;
        ArrayList Tokens;

        // Random, to instatiate objects at random positions
        Random rnd = new Random();

        // Scene
        Background background;

        public void Initialize()
        {
            // Initialization of all scene components
            Heroes = new ArrayList();
            Prowlers = new ArrayList();
            Tokens = new ArrayList();
            background = new Background();

            // Background initialization
            background.Init("FondoNivel1", 6, 0, 0.16f, 1028, 578);

            // Initialization of heroes
            Spaceship Player_1 = new Spaceship();
            Player_1.setKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            Heroes.Add(Player_1);

            // Initialization of enemies
            for (int i = 0; i < 7; i++)
            {
                Prowler enemy = new Prowler();
                enemy.setPos(new Vector2(rnd.Next(950, 990), rnd.Next(0, 500)));
                Prowlers.Add(enemy);
            }
        }
        public void LoadContent(ContentManager Content)
        {
            // Load content for all scene elements
            for (int i = 0; i < Heroes.Count; i++)
                ((Spaceship)Heroes[i]).LoadContent(Content);

            for (int i = 0; i < Prowlers.Count; i++)
                ((Prowler)Prowlers[i]).LoadContent(Content);

            background.LoadContent(Content);
        }
        public SceneManagement Update(GameTime gameTime)
        {
            // Finally, update all elements
            for (int i = 0; i < Heroes.Count; i++)
                ((Spaceship)Heroes[i]).Update(gameTime);

            for (int i = 0; i < Prowlers.Count; i++)
                ((Prowler)Prowlers[i]).Update(gameTime);


            background.Update(gameTime);
            // Check for level termination conditions
            if (Prowlers.Count <= 0)
                return SceneManagement.LEVEL_2;
            else
                return SceneManagement.LEVEL_1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all elements
            background.Draw(spriteBatch);

            for (int i = 0; i < Prowlers.Count; i++)
                ((Prowler)Prowlers[i]).Draw(spriteBatch);

            for (int i = 0; i < Heroes.Count; i++)
                ((Spaceship)Heroes[i]).Draw(spriteBatch);
        }
    }
}
