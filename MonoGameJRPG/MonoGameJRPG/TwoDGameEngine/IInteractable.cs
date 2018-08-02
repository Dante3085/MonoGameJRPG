using MonoGameJRPG.General.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.TwoDGameEngine
{
    public interface IInteractable<T>
    {
        T Interact(Character partner);
    }
}
