// Title: Enemy
// Description:
//   Provides the base functionality for an enemy, that is: shooting, playing
//   audio when firing and decrementing life when fired.
//   
//   It is assumed all sprites have the same dimensions and position, most 
//   attributes and functionality are determined by the leftmost BasicSprite.
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    class Enemy : AutoCharacter
    {
        // Attributes
        protected int life;                 // Enemy's health
        protected float timer;              // Ancillary variable to control shot instantiation
        protected float timeBetweenShots;   // Time between shots
        protected ArrayList Shots;          // Shots fired by the 
        protected float timeBforActvtion;   // Time before the enemy starts shooting
        protected bool active;              // If an enemy can start shooting or not.
        protected List<SoundEffect> SoundEffects;

        public Enemy()
        {
            // Shot content initialization
            Shots = new ArrayList();
            SoundEffects = new List<SoundEffect>();
        }

        // Methods
        public void Update(GameTime gameTime, ContentManager Content)
        {
            // Create new shots
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > timeBetweenShots && active)
            {
                createShot(Content);
                timer = 0f;
            }
            // We'll also use the timer (timeSinceLastShot) to activate our enemy
            // so that the enemies cannot fire all at the same time.
            if (timer > timeBforActvtion)
            {
                active = true;
            }

            // If the prowler takes a hit, reduce life by one
            if (collStat)
            {
                life--;
            }

            collStat = false;
            // Update shots and remove if they are off the screen
            for (int i = 0; i < Shots.Count; i++)
            {
                ((AutoSprite)Shots[i]).Update(gameTime);
                if (((AutoSprite)Shots[i]).Pos.X < 0)
                    Shots.RemoveAt(i);
            }

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw ships
            base.Draw(spriteBatch);

            // Draw shots
            for (int i = 0; i < Shots.Count; i++)
                ((AutoSprite)Shots[i]).Draw(spriteBatch);
        }

        // Shot control and collision
        protected virtual void createShot(ContentManager Content)
        {
            // Configure and add new shot to Shots arraylist
            AutoSprite shot = new AutoSprite("Shot_Enemigo.png");
            shot.LoadContent(Content);
            shot.setSize(9, 5);
            shot.setIncrement(-9, 0);
            shot.setPos((int)pos.X, (int)pos.Y + standLeft.Pos.Height / 2);
            Shots.Add(shot);
        }
        public ArrayList getShots()
        {
            return Shots;
        }
        public void removeShotAt(int i)
        {
            Shots.RemoveAt(i);
        }
    }
}
