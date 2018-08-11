using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameJRPG.TwoDGameEngine;

namespace MonoGameJRPG.General.Menus.Layouts
{
    public abstract class Layout : MenuElement
    {
        public abstract int Offset { get; set; }

        public abstract List<MenuElement> Elements();
    }
}
