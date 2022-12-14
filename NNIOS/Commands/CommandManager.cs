using System;
using System.Collections.Generic;
using System.Text;

namespace NNIOS.Commands
{
    public class CommandManager
    {

        private List<Command> commands;

        public CommandManager()
        {

            this.commands = new List<Command>(3);
            this.commands.Add(new Help("help"));
            this.commands.Add(new File("file"));
            this.commands.Add(new LaunchGUI("launchgui"));

        }

        public String proccesInput (String input)
        {

            String[] split = input.Split(' ');

            String label = split[0];

            List<String> args = new List<string>();

            int ctr = 0;
            foreach (String s in split)
            {

                if (ctr != 0)
                    args.Add(s);

                ++ctr;

            }

            foreach (Command cmd in this.commands)
            {

                if (cmd.name == label)
                    return cmd.execute(args.ToArray());

            }

            return "Your command \""+label+"\" does not exist!";

        }

    }
}

