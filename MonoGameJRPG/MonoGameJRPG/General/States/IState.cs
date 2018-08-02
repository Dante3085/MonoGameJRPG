using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.States
{
    public interface IState
    {
        void Update(GameTime gameTime);
        void Render();
        void OnEnter();
        void OnExit();
    }
}
