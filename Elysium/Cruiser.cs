using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class Cruiser : AutoCharacter
    {
        // Attributes
        int life;

        // Properties
        public int Life
        {
            get { return life; }
        }

        // Constructor
        public Cruiser()
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

            // Configuration
            life = 5;
            incX = 4;
            incY = 4;
        }
        public override void Update(GameTime gameTime)
        {
            // If the prowler takes a hit, reduce life by one
            if (collStat)
            {
                life--;
                collStat = false;
            }
            base.Update(gameTime);
        }
    }
}
