using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Inventario;
using Logica.Inventario;
using Presentacion.Admin;

namespace Presentacion.Edit
{
    public partial class frmEditHeroe : Form
    {
        private frmPrincipal _parentForm;
        public frmEditHeroe(frmPrincipal parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        public void ObtenerSiguienteID()
        {
            HeroeLN opln = new HeroeLN();
            List<Heroe> lista = opln.Show();
            if (lista.Count > 0)
            {
                int maxID = lista.Max(h => h.HeroID);
                textBox1.Text = (maxID + 1).ToString();
            }
            else
            {
                textBox1.Text = "1"; // Si no hay heroes, iniciar con ID 1
            }
        }

        public void cargarDatos(Heroe op)
        {
            label1.Text = "Editar Heroe";
            textBox1.Text = op.HeroID+"";
            textBox2.Text = op.RealName;
            textBox3.Text = op.Alias;
            textBox4.Text = op.Abilities;
            textBox5.Text = op.History;
            textBox6.Text = op.Seasons;
            textBox7.Text = op.ActorName;
        }

        public Heroe crearObjeto()
        {
            Heroe heroe = new Heroe
            {
                HeroID = Convert.ToInt32(textBox1.Text),
                RealName = textBox2.Text,
                Alias = textBox3.Text,
                Abilities = textBox4.Text,
                History = textBox5.Text,
                Seasons = textBox6.Text,
                ActorName = textBox7.Text
            };
            return heroe;
        }

        public bool Validar()
        {
            if(textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null
                 && textBox6 != null && textBox7 != null)
            {
                 return true;
            }
            else
            {
                return false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                this.DialogResult = DialogResult.OK;
                _parentForm.AbrirFormEnPanel(new frmAdminHeroes(_parentForm));
                this.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _parentForm.AbrirFormEnPanel(new frmAdminHeroes(_parentForm));
            this.DialogResult = DialogResult.Cancel;
            this.Close();


        }
    }
}
