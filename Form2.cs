using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Dashboard
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            save.FlatStyle = FlatStyle.Flat;
            save.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            save.FlatAppearance.BorderSize = 1;

            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Server\\server.properties");
            List<string> aux = new List<string>();
            aux = lines.ToList();
            aux.RemoveAt(0);
            aux.RemoveAt(0);
            int counter = 36;
            foreach(Control c in Controls)
            {
                if(c is TextBox)
                {
                    c.Text = aux[counter].ToString().Split('=')[1];
                    counter--;
                }
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Server\\server.properties");
            List<string> aux = new List<string>();
            List<string> caixas = new List<string>();
            aux = lines.ToList();
            aux.RemoveAt(0);
            aux.RemoveAt(0);
            aux.Reverse();

            foreach (Control c in Controls)
                if (c is TextBox)
                    caixas.Add(c.Text);

            for (int i = 0; i < aux.Count; i++)
                aux[i] = aux[i].ToString().Split('=')[0] + "=" + caixas[i];

            aux.Reverse();
            aux.Insert(0, lines[1]);
            aux.Insert(0, lines[0]);

            File.WriteAllText(Directory.GetCurrentDirectory() + "\\Server\\server.properties", String.Empty);
            foreach(string line in aux)
                using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\Server\\server.properties"))
                    sw.WriteLine(line);
            this.Close();
        }
    }
}
