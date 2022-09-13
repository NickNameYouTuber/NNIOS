using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using NNIOS.Commands;
using Cosmos.System.FileSystem;
using NNIOS.Graphics;

namespace NNIOS
{
    public class Kernel : Sys.Kernel
    {

        private CommandManager CommandManager;
        private CosmosVFS VFS;
        public static GUI gui;

        protected override void BeforeRun()
        {

            Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            this.CommandManager = new CommandManager();

            Console.WriteLine("Welcome to NNI OS - the NNI Operating System");

        }

        protected override void Run()
        {

            if (Kernel.gui != null)
            {

                Kernel.gui.handleGUIInputs();
                return;

            }

            String response;
            String input = Console.ReadLine();
            response = this.CommandManager.proccesInput(input);
            Console.WriteLine(response);

        }
    }
}
