using BL.Registro;
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
using static BL.Registro.AlumnosBL;

namespace Win.RegistroNotas
{
    public partial class FormAlumnos : Form
    {
        AlumnosBL _alumnos;
        CursosBL _cursos;
        SeccionBL _secciones;

        public FormAlumnos()
        {
            InitializeComponent();

            _alumnos = new AlumnosBL();
            listaAlumnosBindingSource.DataSource = _alumnos.ObtenerAlumnos();

            _cursos = new CursosBL();
            listaCursoBindingSource.DataSource  = _cursos.ObtenerCurso();

            _secciones = new SeccionBL();
            listaSeccionesBindingSource.DataSource = _secciones.ObtenerSecciones();
        }

        private void listaAlumnosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaAlumnosBindingSource.EndEdit();

            var alumno = (Alumno)listaAlumnosBindingSource.Current;


            if (fotoPictureBox.Image !=null)     //Guardando Imagen
            {
                alumno.Foto = Program.imageToBytearray(fotoPictureBox.Image);
            }
            else
            {
                alumno.Foto = null;
            }




            var resultado = _alumnos.GuardarAlumno(alumno);

            if(resultado.Exitoso == true)
            {
                listaAlumnosBindingSource.ResetBindings(false);
                DesahilitarHabilitarBotones(true);
                MessageBox.Show("Informacion Guardada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _alumnos.AgregarAlumno();
            listaAlumnosBindingSource.MoveLast();

            DesahilitarHabilitarBotones(false);
        }

        private void DesahilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);

                if(resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }    
            }
        }

        private void Eliminar(int id)
        {
            
            var resultado = _alumnos.EliminarAlumno(id);

            if (resultado == true)
            {
                listaAlumnosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar los datos.");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _alumnos.CancelarCambios();
            DesahilitarHabilitarBotones(true);
           
        }

        private void FormAlumnos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var alumno = (Alumno)listaAlumnosBindingSource.Current;

            if (alumno != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);


                }
            }
            else
            {
                MessageBox.Show("Añada un Alumno antes de asignarle una imagen");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void cursosIdLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
