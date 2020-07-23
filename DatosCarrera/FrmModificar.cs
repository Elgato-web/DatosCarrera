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
    public partial class FrmModificar : Form
    {
        public FrmModificar(Modelo.DatosCarrera car )
        {
            InitializeComponent();
            txtCarrera.Text = car.Carrera;
            txtCodigo.Text = car.Codigo;
            txtCreditos.Text = car.Creditos.ToString();
            txtMateria.Text = car.Materia;
            txtNivel.Text = car.Nivel.ToString();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                DatosCarrera.Modelo.DatosCarrera car = new Modelo.DatosCarrera();
                car.Codigo = txtCodigo.Text;
                car.Materia = txtMateria.Text;
                car.Nivel = int.Parse(txtCodigo.Text);
                car.Creditos = int.Parse(txtCodigo.Text);
                car.Carrera = txtCodigo.Text;
                x = DatosCarrera.Modelo.DatosCarrerak.update(car);
                if (x > 0)
                    MessageBox.Show("Actualizacion Copmpletada");
                else
                    MessageBox.Show("No se pudo acutalizar");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally 
            {
                this.Close();
            }
        }
    }
}
