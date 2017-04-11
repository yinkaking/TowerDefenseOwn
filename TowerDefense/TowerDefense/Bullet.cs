using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Bullet: SpriteGameObject
    {
        public Bullet(Vector2 position, Vector2 velocity) : base("spr_bullet")
        {
            this.Origin = this.Sprite.Center;
            this.Velocity = velocity;
            this.Position = position;
        }
    }
}
