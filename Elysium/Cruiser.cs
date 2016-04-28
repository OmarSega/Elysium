// Title: Cruiser
// Description:
//   An enemy spaceship that is able to move freely horizontally and vertically,
//   it is armed with a laser cannon that can be fired horizontally every three
//   seconds.
// 
//   This kind of enemy is more resilient than a Prowler but has a slow rate of fire.
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using System.Collections.Generic;

namespace Elysium
{
    class Cruiser : Enemy
    {
        // Properties
        public int Life
        {
            get { return life; }
        }

        // Constructor
        public Cruiser(int time)
        {
            //
            // Initialize content for character in all its states.
            InitStand(SideDirection.STAND_LEFT, "sShip2_Enemigo.png");
            InitStand(SideDirection.STAND_RIGHT, "sShip2_Enemigo.png");
            InitStand(SideDirection.STAND_UP, "sShip2_Enemigo.png");
            InitStand(SideDirection.STAND_DOWN, "sShip2_Enemigo.png");

            InitMove(SideDirection.RUN_LEFT, "sShip2_Enemigo", 1, 0, 1, 88, 77);
            InitMove(SideDirection.RUN_LEFT, "sShip2_Enemigo", 1, 0, 1, 88, 77);
            InitMove(SideDirection.RUN_RIGHT, "sShip2_Enemigo", 1, 0, 1, 88, 77);
            InitMove(SideDirection.RUN_UP, "sShip2_Enemigo", 1, 0, 1, 88, 77);
            InitMove(SideDirection.RUN_DOWN, "sShip2_Enemigo", 1, 0, 1, 88, 77);

            // Shot content initialization
            Shots = new ArrayList();
            SoundEffects = new List<SoundEffect>();
            timeBforActvtion = time;

            // Configuration
            timer = 0;
            timeBetweenShots = 5;
            pos.X = 0;
            pos.Y = 0;
            life = 5;
            incX = 3;
            incY = 3;
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
