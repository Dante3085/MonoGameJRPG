using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Characters
{
    public interface IAction
    {
        bool IsReady();
        int TimeRemaining();
        void Update(GameTime gameTime);
    }
}
