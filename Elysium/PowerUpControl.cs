// Title: PowerUpControl
// Description:
//   Manages the creation of PowerUps and their .

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Elysium
{
    class PowerUpControl
    {
        // Attributes
        ArrayList PowerUps;     // Holds all powerups.
        Random rnd;             // To instatiate objects at random positions.
        float timer;            // To keep track of time.
        float timeBtwnPowerUps; // Time before a new shot is created.
        List<SoundEffect> SoundEffects;

        // Properties
        public int Count
        {
            // Return count of powerups.
            get { return PowerUps.Count; }
        }

        // Constructor
        public PowerUpControl()
        {
            PowerUps = new ArrayList();
            rnd = new Random();
            SoundEffects = new List<SoundEffect>();
            timeBtwnPowerUps = 50;
        }

        // Methods
        public void LoadContent(ContentManager Content)
        {
            SoundEffects.Add(Content.Load<SoundEffect>("ping.wav"));
            SoundEffects.Add(Content.Load<SoundEffect>("lifeUp.wav"));
        }
        public void Update(GameTime gameTime, ContentManager Content)
        {
            // Keep track track of elapsed game time
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Create new shots every timeBtwnPowerUps
            if (timer > timeBtwnPowerUps)
                createPowerUp(Content, rnd.Next(1, 3));

            // Remove powerUps that are off the screen
            for (int i = 0; i < PowerUps.Count; i++)
            {
                ((AutoSprite)PowerUps[i]).Update(gameTime);
                if (((AutoSprite)PowerUps[i]).Pos.X < 0)
                       PowerUps.RemoveAt(i);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw ships
            for (int i = 0; i < PowerUps.Count; i++)
                ((AutoSprite)PowerUps[i]).Draw(spriteBatch);
        }

        // Methods for object creation and removal
        void createPowerUp(ContentManager Content, int n)
        {
            // Create n powerups
            for (int i = 0; i < n; i++)
            {
                PowerUp pwrUp = new PowerUp(rnd.Next(2, 6));
                pwrUp.LoadContent(Content);
                pwrUp.setSize(30, 30);
                pwrUp.setPos(1029, rnd.Next(0, 548));
                PowerUps.Add(pwrUp);
                notify();
            }
            // Reset timer
            timer = 0;
        }
        void RemoveAt(int i)
        {
            // Removes PowerUp at position 1
            PowerUps.RemoveAt(i);
        }

        // Methods for collision checking
        public void checkCollision(ArrayList heroes)
        {
            // Check collision between a spaceship and a powerup, if that happens
            // add the powerup's life increment to the ship
            foreach (Spaceship ship in heroes)
            {
                for(int i = 0; i < Count; i++)
                {
                    ship.Collision(((PowerUp)PowerUps[i]).Pos);

                    if (ship.collStat)
                    {
                        ship.collStat = false;
                        ship.Life += ((PowerUp)PowerUps[i]).LifeIncrement;
                        levelUpSound();
                        PowerUps.RemoveAt(i);
                    }
                }
            }
        } 
        void notify()
        {
            // Notify players a sound was created
            var instance = SoundEffects[0].CreateInstance();
            instance.Volume = 0.3f;
            instance.Play();
        }
        void levelUpSound()
        {
            // Sound effect played when a player collides with a powerup
            var instance = SoundEffects[1].CreateInstance();
            instance.Volume = 0.5f;
            instance.Play();
        }
    }
}

