using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Admin;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            AbrirFormEnPanel(new frmAdminHeroes(this)); // Abrir el formulario de administración de héroes al iniciar la aplicación
        }

        //hacer un metodo para abrir un frmHijo dentro del panelContenedor  

        public void AbrirFormEnPanel(Form formHijo)
        {
            // Verificar si ya hay un formulario hijo abierto  
            if (panelContenedor.Controls.Count > 0)
            {
                // Cerrar el formulario hijo actual  
                var control = panelContenedor.Controls[0];
                if (control is Form formActual)
                {
                    formActual.Close();
                }
                panelContenedor.Controls.Remove(control);
            }
            // Configurar el nuevo formulario hijo  
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            // Agregar el formulario hijo al panel contenedor  
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            // Mostrar el formulario hijo  
            formHijo.Show();
        }

        private void heroesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmAdminHeroes(this));
        }
    }
}
