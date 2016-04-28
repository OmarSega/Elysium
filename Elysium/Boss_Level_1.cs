using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class Boss_Level_1 : Enemy
    {
        public Boss_Level_1()
        {
            InitMove(SideDirection.RUN_DOWN, "Rob_Squid", "Rob_f", 39, 0.025f);
            InitMove(SideDirection.RUN_UP, "Rob_Squid", "Rob_f", 39, 0.025f);

            // Shot content initialization
            Shots = new ArrayList();
            SoundEffects = new List<SoundEffect>();
            timeBforActvtion = 0;

            // Configuration
            timer = 0;
            timeBetweenShots = 5;
            pos.X = 0;
            pos.Y = 0;
            life = 20;
            incX = 0;
            incY = 1;
        }
    }
}
