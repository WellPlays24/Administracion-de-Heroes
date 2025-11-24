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
using Presentacion.Edit;

namespace Presentacion.Admin
{
    public partial class frmAdminHeroes : Form
    {
        private frmPrincipal _parentForm;
        public frmAdminHeroes(frmPrincipal parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;  // Guardamos la referencia
        }

        HeroeLN heroeLN = new HeroeLN();

        public void Listar(string val)
        {
            dataGridView1.DataSource = heroeLN.ShowFiltro(val);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminHeroes_Load(object sender, EventArgs e)
        {
            Listar(toolStripTextBox1.Text);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Listar(toolStripTextBox1.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }


       

        private void Nuevo()
        {
            // Crear una nueva instancia del formulario de edición de héroe
            frmEditHeroe frm = new frmEditHeroe(_parentForm);
            frm.ObtenerSiguienteID();  // Ejecutar la lógica de obtener el siguiente ID

            // Llamar al método para abrir el formulario dentro del panel
            _parentForm.AbrirFormEnPanel(frm);  // Usamos el método que ya tienes para abrir el formulario dentro del panel

            // Cuando el formulario se cierre (en el panel), podemos realizar la lógica para guardar el héroe
            // Esto puede hacerse desde dentro de frmEditHeroe, pero en general, debes escuchar algún evento de cierre.
            frm.FormClosed += (sender, e) =>
            {
                if (frm.DialogResult == DialogResult.OK) // Verificar si se guardó correctamente
                {
                    Heroe op = frm.crearObjeto();  // Obtener el objeto del héroe creado
                    heroeLN.Create(op);  // Crear el héroe en la base de datos
                    Listar("");  // Refrescar la lista de héroes
                    MessageBox.Show("Héroe creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
        }


        private void Actualizar()
        {
            try
            {
                //validar que este seleccionado un heroe
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un héroe para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Obtener el héroe seleccionado
                Heroe heroeSeleccionado = (Heroe)dataGridView1.SelectedRows[0].DataBoundItem;
                // Crear una nueva instancia del formulario de edición de héroe
                frmEditHeroe frm = new frmEditHeroe(_parentForm);
                frm.ObtenerSiguienteID();  // Ejecutar la lógica de obtener el siguiente ID
                frm.cargarDatos(heroeSeleccionado);
                // Llamar al método para abrir el formulario dentro del panel
                _parentForm.AbrirFormEnPanel(frm);  // Usamos el método que ya tienes para abrir el formulario dentro del panel

                // Cuando el formulario se cierre (en el panel), podemos realizar la lógica para guardar el héroe
                // Esto puede hacerse desde dentro de frmEditHeroe, pero en general, debes escuchar algún evento de cierre.
                frm.FormClosed += (sender, e) =>
                {
                    if (frm.DialogResult == DialogResult.OK) // Verificar si se guardó correctamente
                    {
                        Heroe op = frm.crearObjeto();  // Obtener el objeto del héroe creado
                        heroeLN.Update(op);  // Crear el héroe en la base de datos
                        Listar("");  // Refrescar la lista de héroes
                        MessageBox.Show("Héroe actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public void Eliminar()
        {
            try
            {
                //validar que este seleccionado un heroe
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un héroe para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Obtener el héroe seleccionado
                Heroe heroeSeleccionado = (Heroe)dataGridView1.SelectedRows[0].DataBoundItem;
                // Confirmar la eliminación
                DialogResult result = MessageBox.Show($"¿Está seguro de eliminar al héroe {heroeSeleccionado.Alias}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    heroeLN.Delete(heroeSeleccionado);
                    Listar("");
                    MessageBox.Show("Héroe eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
