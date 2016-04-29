// Title: Enemy
// Description:
//   Abstracts the interaction between an enemy and it's environement,
//   it handles enemy generation, collision checking, removal of enemies
//   and creation of explosions.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Elysium
{
    enum EnemyType
    {
        PROWLER, CRUISER, BOSS_1, BOSS_2
    };
    class EnemyControl
    {
        // Attributes
        ArrayList enemies;      // Holds all the enemies.
        ArrayList explosions;   // Holds explosion animations
        Random rnd;             // To instatiate objects at random positions
        EnemyType type;         // Type of enemies held in arraylist.
        List<SoundEffect> SoundEffects;

        // Properties
        public int Count
        {
            get { return enemies.Count; }
        }

        // Constructor
        public EnemyControl()
        {
            rnd = new Random(DateTime.Now.Second * DateTime.Now.Millisecond * DateTime.Now.Minute);
            enemies = new ArrayList();
            explosions = new ArrayList();
            SoundEffects = new List<SoundEffect>();
        }

        // Methods
        public void LoadContent(ContentManager Content)
        {
            // Load sound effects
            SoundEffects.Add(Content.Load<SoundEffect>("explosion.wav"));
            SoundEffects.Add(Content.Load<SoundEffect>("BossNotification.wav"));
        }
        public void createEnemies(ContentManager Content, string enemyType, int number)
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
                        enemy.setPos(new Vector2(rnd.Next(500, 990), rnd.Next(0, 500)));
                        enemies.Add(enemy);
                    }
                }
                else if (enemyType == "Prowler")
                {
                    type = EnemyType.PROWLER;
                    for (int i = 0; i < number; i++)
                    {
                        Prowler enemy = new Prowler(rnd.Next(0, 15));
                        enemy.setPos(new Vector2(rnd.Next(500, 990), rnd.Next(0, 500)));
                        enemy.LoadContent(Content);
                        enemies.Add(enemy);
                    }
                }
                else if (enemyType == "Boss_1")
                {
                    type = EnemyType.BOSS_1;
                    Boss_Level_1 enemy = new Boss_Level_1();
                    enemy.setPos(new Vector2(rnd.Next(500, 600), rnd.Next(0, 500)));
                    enemy.LoadContent(Content);
                    enemies.Add(enemy);
                }
            }
            catch
            {
                Console.WriteLine("Error al crear enemigos.");
            }
        }
        public void Update(GameTime gameTime, ContentManager Content)
        {
            // Update all enemies
            if (type == EnemyType.PROWLER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Prowler)enemies[i]).Update(gameTime, Content);

            else if (type == EnemyType.CRUISER)
                for (int i = 0; i < enemies.Count; i++)
                    ((Cruiser)enemies[i]).Update(gameTime, Content);

            else if (type == EnemyType.BOSS_1)
                for (int i = 0; i < enemies.Count; i++)
                    ((Boss_Level_1)enemies[i]).Update(gameTime, Content);

            // Update explosions
            foreach (Explosion exp in explosions)
                exp.Update(gameTime);

            // Remove enemies if necessary
            if (type == EnemyType.PROWLER)
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (((Prowler)enemies[i]).Life <= 0)
                    {
                        createExplosion(Content, ((Prowler)enemies[i]).Pos);
                        enemies.RemoveAt(i);
                    }
                }

            else if (type == EnemyType.CRUISER)
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (((Cruiser)enemies[i]).Life <= 0)
                    {
                        createExplosion(Content, ((Cruiser)enemies[i]).Pos);
                        enemies.RemoveAt(i);
                    }
                }

            // Remove explosions if they are marked as removable
            for (int i = 0; i < explosions.Count; i++)
            {
                if (!((Explosion)explosions[i]).Active)
                    explosions.RemoveAt(i);
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

            // Draw explosions
            for (int i = 0; i < explosions.Count; i++)
                ((Explosion)explosions[i]).Draw(spriteBatch);
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

        // Animation and sound methods
        void createExplosion(ContentManager Content, Rectangle Pos)
        {
            // Creates an explosion animation where a shot impacted an
            // enemy ship. It is assumed the explosion will not move and
            // will disappear after the animation is complete.
            Explosion exp = new Explosion();
            exp.LoadContent(Content);
            exp.setPos(Pos.X + Pos.Width / 2, Pos.Y - Pos.Height / 2);
            explosions.Add(exp);
            explosionSound();
        }
        void explosionSound()
        {
            // Explosion sound effect
            var instance = SoundEffects[0].CreateInstance();
            instance.Volume = 0.4f;
            instance.Play();
        }
        void notifyBoss()
        {
            // Sound that informs the user a boss has appeared.
            var instance = SoundEffects[1].CreateInstance();
            instance.Volume = 0.4f;
            instance.Play();
        }
    }
}
