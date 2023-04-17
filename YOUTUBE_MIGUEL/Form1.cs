using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOUTUBE_MIGUEL
{
    public partial class Form1 : Form
    {
        Autores a;
        Videos v;
        string archivo;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            wmp.URL = "VIDEOS/" + archivo;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            armarArbolito();
          

        }

        private void armarArbolito()
        {

            wmp.uiMode = "none";
            a = new Autores();
            v = new Videos();

            TreeNode abuelo;
            TreeNode padre;
            TreeNode hijo;

            abuelo = tv.Nodes.Add("AUTORES");

            DataTable taut = a.getAutores();
            DataTable tvid = v.getVideos();

            foreach(DataRow faut in taut.Rows)
            {
                padre = abuelo.Nodes.Add(faut["nombre"].ToString());
                foreach(DataRow fvid in tvid.Rows)
                {
                    if(faut["autor"].ToString()==fvid["autor"].ToString())
                    {
                        hijo = padre.Nodes.Add(fvid["nombre"].ToString());
                        hijo.Tag = fvid["archivo"].ToString();
                    }
                }
            }
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Level == 2)
            {
                archivo = e.Node.Tag.ToString();

            }
        }
    }
}
