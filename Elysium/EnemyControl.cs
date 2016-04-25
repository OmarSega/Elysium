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
        public void LoadContent(ContentManager Content, string enemyType, int number)
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
                        enemy.setPos(new Vector2(rnd.Next(950, 990), rnd.Next(0, 500)));
                        enemy.LoadContent(Content);
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
        public void Update(GameTime gameTime)
        {
            // Draw all enemies
            if (type == EnemyType.PROWLER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Prowler)enemies[i]).Update(gameTime);

            else if (type == EnemyType.CRUISER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Cruiser)enemies[i]).Update(gameTime);
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
        public void Collision(Rectangle recIn)
        {
            // Check collisions for each enemy
            if(type == EnemyType.PROWLER)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    ((Prowler)enemies[i]).Collision(recIn);

                    if (((Prowler)enemies[i]).collStat)
                        enemies.RemoveAt(i);
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
