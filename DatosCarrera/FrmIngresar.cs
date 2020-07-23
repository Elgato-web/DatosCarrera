using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatosCarrera
{
    public partial class FrmIngresar : Form
    {
        public FrmIngresar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            DatosCarrera.Modelo.DatosCarrera carrera = new DatosCarrera.Modelo.DatosCarrera();
            int x = 0;
            try
            {
                carrera.Codigo = txtCodigo.Text;
                carrera.Materia = txtMateria.Text;
                carrera.Nivel = int.Parse(txtNivel.Text);
                carrera.Creditos = int.Parse(txtCreditos.Text);
                carrera.Carrera = txtCarrera.Text;


                x = DatosCarrera.Modelo.DatosCarrerak.carrera(carrera);
                if (x > 0)
                {
                    MessageBox.Show("Datos Guardados");
                }
                else
                {
                    MessageBox.Show("Datos no Guardados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DataTable dt = Modelo.DatosCarrerak.getAll();
                this.dataGrid.DataSource = dt;
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                x = DatosCarrera.Modelo.DatosCarrerak.btnEliminar(txtEliminar.Text);
                if (x == 1)
                {
                    MessageBox.Show("Registro Borrado");

                }
                else
                {
                    MessageBox.Show("Codigo no Borrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FrmIngresar_Load(object sender, EventArgs e)
        {
            DataTable dt = Modelo.DatosCarrerak.getAll();
            this.dataGrid.DataSource = dt;

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "LinkEliminar")
            {
                int fila = e.RowIndex;
                string codigo = dataGrid[2, fila].Value.ToString();
                string confirmMessage = string.Format("¿Esta segur@ que quiere eliminar el codigo {0}?",
                    grid.Rows[fila].Cells[2].Value);
                if (MessageBox.Show(confirmMessage, " Eliminar Codigo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Codigo Eliminado Exitosamente");
                    grid.Rows.RemoveAt(fila);
                    int x = DatosCarrera.Modelo.DatosCarrerak.btnEliminar(codigo);

                }

            }
            if (grid.Columns[e.ColumnIndex].Name == "LinkModificar")
            {
                int fila = e.RowIndex;
                string codigo = dataGrid[2, fila].Value.ToString();
                string confirmMessage = string.Format("¿Esta segur@ que quiere modificar el codigo {0}?",
                    grid.Rows[fila].Cells[2].Value);
                if (MessageBox.Show(confirmMessage, " Modifcar Codigo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Modelo.DatosCarrera H = DatosCarrera.Modelo.DatosCarrerak.getcarrera(codigo);
                    FrmModificar modificar = new FrmModificar(H);
                    modificar.ShowDialog();
                    DataTable dt = Modelo.DatosCarrerak.getAll();
                    this.dataGrid.DataSource = dt;







                }
            }
        }
    }
}