using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace NNIOS.Commands
{
    public class File : Command
    {
        
        public File (String name) : base(name)
        {

             

        }

        public override String execute(String[] args)
        {

            String response="";
            
            switch (args[0])
            {

                case "create":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
                        response = "Your file " + args[1] + " was sucessfully created!";
                    }
                    catch (Exception ex)
                    {
                        response = "Error creating file. " + ex.ToString();
                        break;
                    }

                    break;

                case "delete":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
                        response = "Your file " + args[1] + " was sucessfully deleted!";
                    }
                    catch (Exception ex)
                    {
                        response = "Error deleting file. " + ex.ToString();
                        break;
                    }

                    break;

                case "createdir":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                        response = "Your directory " + args[1] + " was sucessfully created!";
                    }
                    catch (Exception ex)
                    {
                        response = "Error creating directory. " + ex.ToString();
                        break;
                    }

                    break;

                case "deletedir":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1],true);
                        response = "Your directory " + args[1] + " was sucessfully deleted!";
                    }
                    catch (Exception ex)
                    {
                        response = "Error deleting directory. " + ex.ToString();
                        break;
                    }

                    break;

                case "write":

                    try
                    {

                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanWrite)
                        {

                            int ctr = 0;
                            StringBuilder sb = new StringBuilder();

                            foreach (String s in args)
                            {

                                if (ctr > 1)
                                {
                                    sb.Append(s + ' ');
                                }

                                ++ctr;

                            }

                            String txt = sb.ToString();
                            Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0,txt.Length-1));

                            fs.Write(data, 0, data.Length);
                            fs.Close();

                            response = "Sucesfully wrote to file";

                            break;

                        }
                        else
                        {

                            response = "Unable to write to file. Not open for writing";
                            break;

                        }

                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "read":

                    try
                    {

                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanRead)
                        {

                            Byte[] data = new byte[256];

                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);

                        }
                        else
                        {

                            response = "Unable to read to file. Not open for reading";
                            break;

                        }

                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                default:
                    response = "Unexpected argument: " + args[0];
                    break;

            }

            return response;

        }

    }
}

