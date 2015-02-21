using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WSFinderBasic
{
    class Search
    {
        static public void AstroConfigs()
        {
            //Swith this to XmlReader
            string config1 = Environment.ExpandEnvironmentVariables("%AppData%\\Notepad++\\config.xml");
            XmlTextReader configFile1 = new XmlTextReader(config1);
            while (configFile1.Read())
            {
                switch (configFile1.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + configFile1.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(configFile1.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + configFile1.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
        }
        /*static public void AstroConfigs()
        {
            string config1 = Environment.ExpandEnvironmentVariables("%AppData%\\Notepad++\\config.xml");
            XmlDocument configFile1 = new XmlDocument();
            configFile1.Load(config1);
        }*/
   
        static public void Astro(string wName)
        {
            string path = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%\\AstroGrep\\AstroGrep.exe");
            //string astroArgs = String.Format("/stext=\"(COMPLETION CODE)|(BOB VILA)\" /stypes=\"*_IMAGE.log, *_BDA.log, *_OBM.log\" /r /e /l /cl=\"2\" /s", wName);
            string astroArgs = String.Format("/spath=\"\\\\{0}\\C$\\\" /stypes=\"*_IMAGE.log, *_BDA.log, *_OBM.log\" /e /r /l /cl=\"2\" /s", wName);
            //string astroArgs = String.Format("/stext=\"(COMPLETION CODE)|(BOB VILA)\" /spath=\"\\\\{0}\\C$\\\"",wName);
            Process.Start(path, astroArgs);
        }
        // /spath = \"\\\\{1}\\C$"
        // , wName
    }
}
