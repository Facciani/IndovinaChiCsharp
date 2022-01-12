using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    public partial class Risultato : Form
    {
        public Risultato(int i)
        {
            InitializeComponent();
            if (i == 1)
            {
                Image g = Image.FromFile(@"..\..\Images\haivinto.png");
                pic_result.Image = g;
            }
            else
            {
                Image g = Image.FromFile(@"..\..\Images\haiperso.png");
                pic_result.Image = g;
            }
        }
    }
}
