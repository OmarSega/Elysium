
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class Spaceship : UserCharacter
    {
        // Attributes
        int life;
        ArrayList Shots;

        // Constructor
        public Spaceship()
        {
            // Initialize content for character in all its states.
            InitStand(SideDirection.STAND_LEFT, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_RIGHT, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_UP, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_DOWN, "sShip_Heroe.png");

            InitMove(SideDirection.RUN_LEFT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_LEFT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_RIGHT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_UP, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_DOWN, "sShip_Heroe.png", 1, 0, 1, 80, 77);

            // Configuration
            life = 3;
            incX = 4;
            incY = 4;
            Shots = new ArrayList();
        }
        public override void Update(GameTime gameTime)
        {
            // Generate enable shots every
            // Remove shots

            base.Update(gameTime);
        }
    }
}
