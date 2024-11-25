using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine_Proy.UI
{
    public interface IButton
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(float deltaTime);
    }
}
