using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameJRPG.General.Combat
{
    public interface ICombatEntity
    {
        bool IsPlayerControlled { get; }
        int Speed { get; }
    }
}
