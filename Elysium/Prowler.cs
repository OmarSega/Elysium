// Title: Prowler
// Description:
//   An enemy spaceship that is able to move freely horizontally and vertically,
//   it is armed with a laser cannon that can be fired horizontally everyseconds.
// 
//   This kind of enemy is more resilient than a Prowler but has a slow rate of fire.
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.Collections;

namespace Elysium
{
    class Prowler : Enemy
    {
        // Properties
        public int Life
        {
            get { return life; }
        }

        // Constructor
        public Prowler(int time)
        {
            // Initialize content for character in all its states.
            InitStand(SideDirection.STAND_LEFT, "sShip1_Enemigo.png");
            InitStand(SideDirection.STAND_RIGHT, "sShip1_Enemigo.png");
            InitStand(SideDirection.STAND_UP, "sShip1_Enemigo.png");
            InitStand(SideDirection.STAND_DOWN, "sShip1_Enemigo.png");

            InitMove(SideDirection.RUN_LEFT, "sShip1_Enemigo.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_LEFT, "sShip1_Enemigo.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_RIGHT, "sShip1_Enemigo.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_UP, "sShip1_Enemigo.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_DOWN, "sShip1_Enemigo.png", 1, 0, 1, 80, 77);

            // Shot content initialization
            Shots = new ArrayList();
            SoundEffects = new List<SoundEffect>();
            timeBforActvtion = time;

            // Configuration
            timer = 0;
            timeBetweenShots = 2;
            pos.X = 0;
            pos.Y = 0;
            life = 2;
            incX = 4;
            incY = 4;
        }

        // Methods
        public override void LoadContent(ContentManager Content)
        {
            // Load textures and sound effects
            SoundEffects.Add(Content.Load<SoundEffect>("laser-shot-silenced.wav"));
            base.LoadContent(Content);
        }
        protected override void createShot(ContentManager Content)
        {
            base.createShot(Content);
            var instance = SoundEffects[0].CreateInstance();
            instance.Volume = 0.4f;
            instance.Play();
        }
    }
}
