using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_IDE.Complementos_analizadores
{
    [Serializable]
    class ManejadorArchivo
    {
        String direccionCreado;       

        public void guardarArchivoBinario(String Path, RichTextBox areaDesarrolloASerailizar) {
            try {
                using (Stream flujo = File.Open(Path, FileMode.Create)) {//es para que pueda indicarse que aquí dentro habrán recursos... como el try con recursos de java
                    var informacionBinaria = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();//puede serializar o deserializar...
                    informacionBinaria.Serialize(flujo, areaDesarrolloASerailizar);
                }

            }
            catch (Exception e) {
                MessageBox.Show("No se ha guardado correctamente\n, intente de nuevo");
                MessageBox.Show(e.Message);
            }

        }

        public void guardarArchivoComo(String path, String texto) {
            try {
                if (File.Exists(path)) {
                    var decision = MessageBox.Show("Ya existe un archivo con ese nombre\nDesea reemplazarlo???", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (decision == DialogResult.Yes) {                        
                        File.WriteAllText(path, texto);
                        direccionCreado = path;
                    }
                }
            }
            catch (DirectoryNotFoundException exc) {
                MessageBox.Show("La dirección establecida no es correcta");
                Console.WriteLine(exc.Message);
            }
            catch (Exception exc) {
                MessageBox.Show("No se pudo guardar el archivo\nintente nuevamente");
                Console.WriteLine(exc.Message);
            }
        }

        public void guardarArchivo(String texto){
            try {
                File.WriteAllText(direccionCreado, texto);
            }
            catch (FileNotFoundException exc)
            {
                MessageBox.Show("No pudo encontrarse el archivo");
                Console.WriteLine(exc.Message);
            }//esto por si acaso borra el archivo que pertenecía al que estaba trabajando...
            catch (Exception exc)
            {
                MessageBox.Show("No se pudo guardar el archivo\nintente nuevamente");
                Console.WriteLine(exc.Message);
            }
        }

        public void guardarArbol(String grafo) {                  
            TextWriter tw = new StreamWriter("grafo.txt");
            tw.WriteLine(grafo);
            tw.Close();
        }

        public String leerArchivo(String direccionALeer) {
            String datosLeidos="";

            try {
                datosLeidos = File.ReadAllText(direccionALeer);
                direccionCreado = direccionALeer;//lo coloco después, puesto que así se asegura que no huberon errores al trabajar con el arch
            }
            catch (FileNotFoundException exc) {
                MessageBox.Show("No pudo encontrarse el archivo a leer\nintente nuevamente");
                Console.WriteLine(exc.Message);
            }
            catch (Exception exc) {
                MessageBox.Show("No se pudo leer el archivo\nintente nuevamente");
                Console.WriteLine(exc.Message);
            }

            return datosLeidos;
        }

        public void EliminarArchivo(String pathAEliminar) {

            try {
                File.Delete(pathAEliminar);
            }
            catch (FileNotFoundException exc) {
                MessageBox.Show("No pudo encontrarse el archivo a eliminar\nintente nuevamente");
                Console.WriteLine(exc.Message);
            }
        }

        public void exportarArchivoErrores(String path, String texto) {
            guardarArchivoComo(path, texto);
        }

        public void establecerDireccionDelCreado(String direccionCreadaAnteriormente) {
            direccionCreado = direccionCreadaAnteriormente;
        }//este será empleado al guardar como "----" el archivo xD

        public bool elArchivoEstaGuardado() {
            if (direccionCreado != null) {
                return true;
            }

            return false;
        }

        public bool existeArbol() {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "grafo.txt"))) { 
                return true;
            }
            return false;
        }       
    }
}
