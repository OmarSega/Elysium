using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class Prowler : AutoCharacter
    {
        // Attributes
        int life;

        public Prowler()
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

            // Configuration
            pos.X = 0;
            pos.Y = 0;
            life = 5;
            incX = 7;
            incY = 7;
        }
    }
}
