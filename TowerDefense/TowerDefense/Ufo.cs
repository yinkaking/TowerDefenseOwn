using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Ufo : RotatingSpriteGameObject
    {

        public Ufo(Vector2 startPosition, GameObject targetObject): base("spr_ufo")
        {
            this.Origin = this.Sprite.Center;
            this.Position = startPosition;
            this.LookAt(targetObject);
            this.targetObject = targetObject;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.LookAt(targetObject);
            Velocity = AngularDirection * 50;
        }
    }
}
