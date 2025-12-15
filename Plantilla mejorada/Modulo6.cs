using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrador
{
    public partial class Modulo6 : UserControl
    {
        public Modulo6()
        {
            InitializeComponent();
        }

        private void buttAdjuntar_Click(object sender, EventArgs e)
        {
            // Crear el cuadro de diálogo para abrir archivos
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurar el filtro para tipos de archivo de imagen
                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.dicom;*.dcm|" +
                                       "Archivos DICOM|*.dicom;*.dcm|" +
                                       "Todos los archivos|*.*";

                openFileDialog.FilterIndex = 1; // Filtro predeterminado
                openFileDialog.Title = "Seleccionar archivo de imagen";
                openFileDialog.Multiselect = false; // Solo un archivo a la vez

                // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtener la ruta completa del archivo seleccionado
                        string rutaArchivo = openFileDialog.FileName;

                        // Mostrar la ruta en el TextBox
                        RutaArcText.Text = rutaArchivo;

                        // Opcional: Verificar si el archivo existe
                        if (!System.IO.File.Exists(rutaArchivo))
                        {
                            MessageBox.Show("El archivo seleccionado no existe.",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                            RutaArcText.Text = string.Empty;
                            return;
                        }

                        // Opcional: Mostrar el tamaño del archivo
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(rutaArchivo);
                        long tamañoKB = fileInfo.Length / 1024;

                        MessageBox.Show($"Archivo adjuntado exitosamente.\nTamaño: {tamañoKB} KB",
                                      "Éxito",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al adjuntar el archivo: {ex.Message}",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                        RutaArcText.Text = string.Empty;
                    }
                }
            }
        }



    }
}
