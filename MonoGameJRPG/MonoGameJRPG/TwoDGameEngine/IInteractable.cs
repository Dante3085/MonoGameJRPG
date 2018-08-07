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
        // TODO: Man kann nicht nur mit Charactern interagieren. Auch mit der Umwelt.
        T Interact(Character partner);
    }
}
