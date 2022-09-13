using System;
using System.Collections.Generic;
using System.Text;

namespace NNIOS.Commands
{
    public class Help : Command
    {
        
        public Help (String name) : base (name) { }

        public override string execute(string[] args)
        {

            return "\nWelcome to NNI OS help command. The NNI OS version is 1.0\n\nCommands:\n\nFiles\n    file create directory - creating file on path 'directory'\n    file delete directory - deleting file on path 'directory'\n    file createdir directory - creating directory on path 'directory'\n    file delete directory - deleting directory on path 'directory'\n    file write directory - write in file on path 'directory'\n    file read directory - read file on path 'directory'";
        
        }

    }
}

