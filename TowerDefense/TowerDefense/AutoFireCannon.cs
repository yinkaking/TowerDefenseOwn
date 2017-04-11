using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class AutoFireCannon : RotatingSpriteGameObject
    {
        int cooldownTimer;
        public bool hasFired
        {
            get
            {
                cooldownTimer++;
                if(cooldownTimer == 150)
                {
                    cooldownTimer = 0;
                    return true;
                }
                return false;
            }

        }
        public AutoFireCannon(String assetName, Vector2 position) : base(assetName)
        {
            this.Origin = new Vector2(16, 16);
            this.Position = position;
        }

        
    }
}
