using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_IDE.Complementos_analizadores.Sintactico
{
    class graph
    {
        StringBuilder textoArbol = new StringBuilder();
        ManejadorArchivo manejadorArchivoArbol = new ManejadorArchivo();

        public graph() { 
            textoArbol.Append("digraph G {" + Environment.NewLine);
        }

        public void agregarHijo(String nodoPadre, String nodoHijo) {
            textoArbol.AppendFormat("{0}->{1}{2}", "\""+nodoPadre+ "\"", "\""+ nodoHijo+ "\"", Environment.NewLine);
        }

        public void terminarArbol() {
            textoArbol.Append("}");
            manejadorArchivoArbol.guardarArbol(textoArbol.ToString());
        }

        public void generarArbol() {
            try
            {
                String directorioActual = Directory.GetCurrentDirectory();
                String nombreArchivoArbol = "grafo.txt";
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(directorioActual, nombreArchivoArbol), Path.Combine(directorioActual, nombreArchivoArbol.Replace(".txt", ".jpg")));
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proceso = new System.Diagnostics.Process();
                proceso.StartInfo = procStartInfo;
                proceso.Start();
                proceso.WaitForExit();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Surgio un problema al generar el árbol");
                Console.WriteLine(exception.Message);
            }
        }

    }
}
