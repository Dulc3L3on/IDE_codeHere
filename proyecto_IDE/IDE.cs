using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE
{
    public partial class IDE : Form
    {
        Kit herramienta = new Kit();

        public IDE()
        {
            InitializeComponent();
        }

        private void areaDesarrollo_textChanged(object sender, EventArgs e)
        {
            int indice = areaDesarrollo.SelectionStart;//obtiene el caracter en donde se encuentra la barra de intercalado [cursor] si está seleccionado entonces devuelve el punto hasta donde llegó dicha selección...
            int linea = areaDesarrollo.GetLineFromCharIndex(indice)+1;//recuerda el indice no inicia desde 0 en cada fila sino que sigue su conteo hasta llegar al fin de todos los caracteres que pueda almacenar...

            int primerCaracter = areaDesarrollo.GetFirstCharIndexFromLine(linea-1);
            int columna = indice - primerCaracter;

            establecerNumeroLinea();
            txtBx_Informativo.Text ="Linea: "+Convert.ToString(linea)+ " Columna: "+Convert.ToString(columna);
            eliminarNumeroLineas();

        }

        private void establecerNumeroLinea() { 
            int numeroLinea = herramienta.agregarNumeroLineas(areaDesarrollo.Lines.Length+1, lst_lineario.Items.Count+1);

            if (numeroLinea!=0) {
                lst_lineario.Items.Add(Convert.ToString(numeroLinea));
            }
        }

        public void eliminarNumeroLineas() {//es que este método debería llamarse solo cuando se eliminaran filas, creo que hay una forma desaber si eliminó lineas del richTextBox...
            int numeroLineasAEliminar = herramienta.eliminarRangoLineas(areaDesarrollo.Lines.Length, lst_lineario.Items.Count);

            if (numeroLineasAEliminar!=0) {
                for (int lineasAEliminar = 0; lineasAEliminar<numeroLineasAEliminar; lineasAEliminar++) {
                    lst_lineario.Items.RemoveAt((lst_lineario.Items.Count)-1);//y así se eliminan lineas innecesarias xD
                }
            }
        }
    }
}
