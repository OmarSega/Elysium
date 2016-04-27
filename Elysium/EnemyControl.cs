using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
                        Cruiser enemy = new Cruiser();
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
                        Prowler enemy = new Prowler();
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
        // TO DO: WE COULD USE A GENERIC COLLISION CHECK HERE!!!
        public void Collision(ArrayList Heroes)
        {
            // Check collisions for each enemy
            if(type == EnemyType.PROWLER)
            {
                foreach(Prowler prowler in enemies)
                {
                    foreach (Spaceship spaceship in Heroes)
                    {
                        for (int k = 0; k < spaceship.getShots().Count; k++)
                        {
                            try
                            {
                                prowler.Collision(((AutoSprite)spaceship.getShots()[k]).Pos);
                                if (prowler.collStat)
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
            if (type == EnemyType.CRUISER)
            {
                foreach (Cruiser cruiser in enemies)
                {
                    foreach (Spaceship spaceship in Heroes)
                    {
                        for (int k = 0; k < spaceship.getShots().Count; k++)
                        {
                            try
                            {
                                 cruiser.Collision(((AutoSprite)spaceship.getShots()[k]).Pos);
                                if (cruiser.collStat)
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
        }
        public ArrayList getEnemies()
        {
            return enemies;
        }
        public void RemoveAt(int index)
        {
            enemies.RemoveAt(index);
        }
    }
}
