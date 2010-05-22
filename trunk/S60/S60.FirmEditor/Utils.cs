using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace S60.FirmEditor
{
    class Utils
    {

        public bool LoadPlugins()
        {
            bool isSuccessful = false;

            /* load plugins, and IF all loaded properly,
             * change the isSuccessful value to true
             */

            return isSuccessful;
        }

        public List<ListViewItem> getLoadedPlugins()
        {
            List<ListViewItem> pluginList = new List<ListViewItem>();

            /* add all plugins to the list
             * 
             ******************************
             *
             * each list item is a filename with path from 
             * root Application.StartupPath + "\\plugins\\"
             */


            return pluginList;
        }

        public static void Check()
        {
            if (!Directory.Exists(Application.StartupPath + "\\plugins"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\plugins");
            }
        }
    }
}
