// Title: Enemy
// Description:
//   Abstracts the interaction between an enemy and it's environement,
//   it handles enemy generation, collision checking, removal of enemies
//   and creation of explosions.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

namespace Elysium
{
    enum EnemyType
    {
        PROWLER, CRUISER, BOSS
    };
    class EnemyControl
    {
        // Attributes
        ArrayList enemies;          // Holds all the enemies.
        Random rnd = new Random();  // To instatiate objects at random positions
        EnemyType type;             // Type of enemies held in arraylist.

        // Properties
        public int Count
        {
            get { return enemies.Count; }
        }

        // Constructor
        public EnemyControl()
        {
            enemies = new ArrayList();
        }

        // Methods
        public void loadEnemies(ContentManager Content, string enemyType, int number)
        {
            // Create new enemies according to the type and number specified.
            try
            {
                if (enemyType == "Cruiser")
                {
                    type = EnemyType.CRUISER;
                    for (int i = 0; i < number; i++)
                    {
                        Cruiser enemy = new Cruiser(rnd.Next(0, 15));
                        enemy.LoadContent(Content);
                        enemy.setPos(new Vector2(rnd.Next(950, 990), rnd.Next(0, 500)));
                        enemies.Add(enemy);
                    }
                }
                else if (enemyType == "Prowler")
                {
                    type = EnemyType.PROWLER;
                    for (int i = 0; i < number; i++)
                    {
                        Prowler enemy = new Prowler(rnd.Next(0, 15));
                        enemy.setPos(new Vector2(rnd.Next(950, 990), rnd.Next(0, 500)));
                        enemy.LoadContent(Content);
                        enemies.Add(enemy);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error al crear enemigos.");
            }
        }
        public void Update(GameTime gameTime, ContentManager Content)
        {
            // Draw all enemies
            if (type == EnemyType.PROWLER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Prowler)enemies[i]).Update(gameTime, Content);

            else if (type == EnemyType.CRUISER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Cruiser)enemies[i]).Update(gameTime, Content);

            // Remove enemies if necessary
            if (type == EnemyType.PROWLER)
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (((Prowler)enemies[i]).Life <= 0)
                        enemies.RemoveAt(i);
                }

            else if (type == EnemyType.CRUISER)
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (((Cruiser)enemies[i]).Life <= 0)
                        enemies.RemoveAt(i);
                }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all enemies
            if (type == EnemyType.PROWLER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Prowler)enemies[i]).Draw(spriteBatch);

            else if (type == EnemyType.CRUISER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Cruiser)enemies[i]).Draw(spriteBatch);
        }

        // Collision handling and detection methods
        public void checkCollision<T>(ArrayList Heroes) where T : AnimatedCharacter
        {
            // Check collision for each enemy currently held on the Enemies 
            // arraylist, if there is Collision with a Shot then it's necessary to
            // remove it so that it doesn't decrement the enemy's life continously.
            foreach (T enemyShip in enemies)
            {
                foreach (Spaceship spaceship in Heroes)
                {
                    for (int k = 0; k < spaceship.getShots().Count; k++)
                    {
                        try
                        {
                            enemyShip.Collision(((AutoSprite)spaceship.getShots()[k]).Pos);
                            if (enemyShip.collStat)
                                spaceship.removeShotAt(k);
                        }
                        catch
                        {
                            Console.WriteLine("Error al eliminar");
                        }
                    }
                }
            }
        }
        public ArrayList getEnemies()
        {
            // Return arraylist of enemies.
            return enemies;
        }
        public void RemoveAt(int index)
        {
            // Remove enemy at position i.
            enemies.RemoveAt(index);
        }
    }
}
