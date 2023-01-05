using System;
using System.Diagnostics;
namespace MaP;

class MaP{
    static void Main(string[] args) {
        Console.Write("Run with sudo/as admin if already haven't! \n");
        int argno = args.Count();
        if (argno < 2) {
            Console.Write("NEEDS ATLEAST 2 ARGUMENTS. \n");
        }
//        var p = new Process();
//      p.StartInfo.RedirectStandardOutput = true;
//      p.StartInfo.CreateNoWindow = true;
//      p.StartInfo.UseShellExecute = false;
//      p.StartInfo.FileName = "sudo";
//      p.Start();
//      string output = p.StandardOutput.ReadToEnd();
//      p.WaitForExit();
try{
        if (args[0] == "i" || args[0] == "install"){
            Console.Write("Don't close, installing(trying) via apt. Progress may not be shown. \n");
            var apt_app_proc = new Process();
            apt_app_proc.StartInfo.RedirectStandardOutput = true;
            apt_app_proc.StartInfo.CreateNoWindow = true;
            apt_app_proc.StartInfo.UseShellExecute = false;
            apt_app_proc.StartInfo.FileName = "apt-get";
            apt_app_proc.StartInfo.Arguments = "install -y " + args[1];
            apt_app_proc.Start();
            apt_app_proc.WaitForExit();
            string apt_install_output = apt_app_proc.StandardOutput.ReadToEnd();
            Console.Write(apt_install_output + "\n");
            if (apt_install_output.Contains("packages will be installed") == false){
                Console.Write("Using Flatpak instead of apt. Don't Close, Progress may not be shown. \n");
                var fp_app_proc = new Process();
                fp_app_proc.StartInfo.RedirectStandardOutput = true;
                fp_app_proc.StartInfo.CreateNoWindow = true;
                fp_app_proc.StartInfo.UseShellExecute = false;
                fp_app_proc.StartInfo.FileName = "flatpak";
                fp_app_proc.StartInfo.Arguments = "install -y " + args[1];
                fp_app_proc.Start();
                string fp_install_output = fp_app_proc.StandardOutput.ReadToEnd();
                fp_app_proc.WaitForExit();
                Console.Write(fp_install_output);
                Console.Write("Used Flatpak instead of apt! \n");
                if (fp_install_output.Contains("Installing") == false){
                    Console.Write("No Flatpak Either, Installing Snap");
                    var snap_app_proc = new Process();
                    snap_app_proc.StartInfo.RedirectStandardOutput = true;
                    snap_app_proc.StartInfo.CreateNoWindow = true;
                    snap_app_proc.StartInfo.UseShellExecute = false;
                    snap_app_proc.StartInfo.FileName = "snap";
                    snap_app_proc.StartInfo.Arguments = "install " + args[1];
                    snap_app_proc.Start();
                    string snap_install_output = snap_app_proc.StandardOutput.ReadToEnd();
                    fp_app_proc.WaitForExit();
                    Console.Write(snap_install_output + "\n Used Snap! \n ");


                }
                
            }
        }
        if (args[0] == "remove" || args[0] == "r"){
            var rmapt = new Process();
            rmapt.StartInfo.RedirectStandardOutput = true;
            rmapt.StartInfo.CreateNoWindow = true;
            rmapt.StartInfo.UseShellExecute = false;
            rmapt.StartInfo.FileName = "apt-get";
            rmapt.StartInfo.Arguments = "remove -y " + args[1];
            rmapt.Start();
            string rmaptout = rmapt.StandardOutput.ReadToEnd();
            rmapt.WaitForExit();
            Console.Write(rmaptout + "\n");
            var rmfp = new Process();
            rmfp.StartInfo.RedirectStandardOutput = true;
            rmfp.StartInfo.CreateNoWindow = true;
            rmfp.StartInfo.UseShellExecute = false;
            rmfp.StartInfo.FileName = "flatpak";
            rmfp.StartInfo.Arguments = "remove -y " + args[1];
            rmfp.Start();
            string rmfpout = rmfp.StandardOutput.ReadToEnd();
            rmapt.WaitForExit();
            Console.Write(rmfpout + "\n");
            var rmsnap = new Process();
            rmsnap.StartInfo.RedirectStandardOutput = true;
            rmsnap.StartInfo.CreateNoWindow = true;
            rmsnap.StartInfo.UseShellExecute = false;
            rmsnap.StartInfo.FileName = "snap";
            rmsnap.StartInfo.Arguments = "remove " + args[1];
            rmsnap.Start();
            string rmsnapout = rmapt.StandardOutput.ReadToEnd();
            rmapt.WaitForExit();
            Console.Write(rmsnapout + "\n");
            Console.Write("Removed in Apt, Flatpak and Snap. \n");
        }
}
catch{Console.Write("ERROR: Minimum of 2 arguments needed, i/install and Appname \n");}
    }
}