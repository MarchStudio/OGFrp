using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OGFrp.Lite
{
    public class Config
    {

        public string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        public void CreateFolder()
        {
            if (Directory.Exists(Path) == false)
            {
                Directory.CreateDirectory(Path);
            }
            return;
        }

        public int loadAccessToken(TextBox tb)
        {
            try
            {
                var reader = new StreamReader(Path + "\\token.ini");
                tb.Text = reader.ReadToEnd();
                reader.Close();
            }
            catch
            {
                tb.Text = null;
                return -1;
            }
            return 0;
        }

        public int writeAccessToken(string token)
        {
            try
            {
                File.WriteAllText(Path + "\\token.ini", token);
            }
            catch
            {
                return -1;
            }
            return 0;
        }
    }
}
