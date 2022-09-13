using System;
using System.Collections.Generic;
using System.Text;
using NNIOS.Graphics;

namespace NNIOS.Commands
{
    public class LaunchGUI : Command
    {
        
        public LaunchGUI (String name) : base (name)
        {

        }

        public override String execute(String[] args)
        {
            System.Console.WriteLine("-1");
            if (Kernel.gui != null)
            {
                return "You are already in GUI";
            }
            System.Console.WriteLine("-2");
            Kernel.gui = new GUI();
            
            return "Launched GUI";

        }

    }
}

