using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WSFinderBasic
{
    class Search
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Removes read-only attributes and opens AstroGrep configurations for modification.
        /// </summary>
        static public void OpenAstroConfigs()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AstroGrep");
                log.Info(string.Format("Configuration path has been set to {0}", path));
                string generalConfigPath = Path.Combine(path, "AstroGrep.general.config");
                log.Debug(string.Format("General configuration path has been set to {0}", generalConfigPath));
                try
                {
                    FileInfo generalConfigInfo = new FileInfo(generalConfigPath);
                    generalConfigInfo.IsReadOnly = false;
                    try { Process.Start(generalConfigPath); }
                    catch (Exception launchConfigException) { log.Error(string.Format("An error has occured when attempting to open {0}.", generalConfigPath), launchConfigException); }
                }
                catch (Exception fileInfoException) { log.Error(string.Format("An error has occured when attempting to modify the attributes of {0}.", generalConfigPath), fileInfoException); }
                string searchConfigPath = Path.Combine(path, "AstroGrep.search.config");
                log.Debug(string.Format("Search configuration path has been set to {0}.", searchConfigPath));
                try
                {
                    FileInfo searchConfigInfo = new FileInfo(searchConfigPath);
                    searchConfigInfo.IsReadOnly = false;
                    try { Process.Start(searchConfigPath); }
                    catch (Exception launchConfigException) { log.Error(string.Format("An error has occured when attempting to open {0}.", searchConfigPath), launchConfigException); }
                }
                catch (Exception fileInfoException) { log.Error(string.Format("An error has occured when attempting to modify the attributes of {0}.", searchConfigPath), fileInfoException); }
            }
            catch (Exception readInException) { log.Error("An error has occured when attempting to locate the working path for AstroGrep.", readInException); }
        }
        /// <summary>
        /// Set read-only attributes on AstroGrep configurations.
        /// </summary>
        static public void CloseAstroConfigs()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AstroGrep");
                log.Info(string.Format("Configuration path has been set to {0}.", path));
                string generalConfigPath = Path.Combine(path, "AstroGrep.general.config");
                log.Debug(string.Format("General configuration path has been set to {0}.", generalConfigPath));
                try
                {
                    FileInfo generalConfigInfo = new FileInfo(generalConfigPath);
                    generalConfigInfo.IsReadOnly = true;
                    log.Info("General configuration file has been set to read only.");
                }
                catch (Exception fileInfoException) { log.Error(string.Format("An error has occured when attempting to modify the attributes of {0}.", generalConfigPath), fileInfoException); }
                string searchConfigPath = Path.Combine(path, "AstroGrep.search.config");
                log.Debug(string.Format("Search configuration path has been set to {0}", searchConfigPath));
                try
                {
                    FileInfo searchConfigInfo = new FileInfo(searchConfigPath);
                    searchConfigInfo.IsReadOnly = true;
                    log.Info("Search configuration file has been set to read only.");
                }
                catch (Exception fileInfoException) { log.Error(string.Format("An error has occured when attempting to modify the attributes of {0}.", searchConfigPath), fileInfoException); }
            }
            catch (Exception readInException) { log.Error("An error has occured when attempting to locate the working path for AstroGrep.", readInException); }
        }
        /// <summary>
        /// Unready code. Don't use.
        /// </summary>
        static public void AstroConfigs()
        {
            //Swith this to XmlReader
            //This not ready code. Don't use.
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

        static public void Astro(string wName)
        {
            string path = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%\\AstroGrep\\AstroGrep.exe");
            //string astroArgs = String.Format("/stext=\"(COMPLETION CODE)|(BOB VILA)\" /stypes=\"*_IMAGE.log, *_BDA.log, *_OBM.log\" /r /e /l /cl=\"2\" /s", wName);
            //string astroArgs = String.Format("/stext=\"(COMPLETION CODE)|(BOB VILA)\" /spath=\"\\\\{0}\\C$\\\"",wName);
            string astroArgs = String.Format("/spath=\"\\\\{0}\\C$\\Airgroup\\Log\" /stypes=\"*_IMAGE.log, *_BDA.log, *_OBM.log\" /e /r /l /cl=\"2\" /s", wName);
            log.Debug(string.Format("Astrogrep has been launched for {0}", wName));
            Process.Start(path, astroArgs);
        }
    }
}
