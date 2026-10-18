using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    namespace GameFramework
    {
        public class CameraFollowModule : Component
        {
            public override void Update(GameTime gameTime)
            {
                Camera.Position = Owner.Transform.Position;
            }
        }
    }
}
