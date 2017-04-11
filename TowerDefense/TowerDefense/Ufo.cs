using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Ufo : RotatingSpriteGameObject
    {

        public Ufo(String assetName, Vector2 startPosition, GameObject targetObject): base(assetName)
        {
            this.Origin = this.Sprite.Center;
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
