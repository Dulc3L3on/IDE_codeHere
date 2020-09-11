using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_IDE.Analizadores;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE
{
    public partial class IDE : Form
    {
        Kit herramienta;
        AnalizadorLexico analizadorLexico;
        private int[] lineaCambiada = new int[2];//cuando el 2 tenga un valor !=0 se mandará a llamar la métood para analizar...

        public IDE()
        {
            InitializeComponent();
            herramienta = new Kit(areaDesarrollo, txtBx_mensajero);
            analizadorLexico = new AnalizadorLexico(herramienta);
        }

        private void areaDesarrollo_textChanged(object sender, EventArgs e)
        {          
            establecerNumeroLinea();            
            eliminarNumeroLineas();

            lineaCambiada[0] = areaDesarrollo.GetLineFromCharIndex(areaDesarrollo.GetFirstCharIndexOfCurrentLine());//esto es para saber de quien pedir el texto a analizar...
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

        private void areaDesarrollo_KeyUp(object sender, KeyEventArgs e)
        {
            int linea = areaDesarrollo.GetLineFromCharIndex(areaDesarrollo.GetFirstCharIndexOfCurrentLine());//se obtiene el índice [el número de columna total en el que se encuentra el cursor...
            int indice = areaDesarrollo.SelectionStart;
            int columna = indice - areaDesarrollo.GetFirstCharIndexOfCurrentLine();


            txtBx_Informativo.Text = "Linea: " + Convert.ToString(linea) + " Columna: " + Convert.ToString(columna);//parece ser repetitivo pero no lo es, porque uno se acciona cuando se presiona el teclado para hacer el cab de linea y el otro cuando se hace el cambio con el mouse
        }

        private void areaDesarrollo_MouseMoved(object sender, MouseEventArgs e)
        {
            int primerCaracter = areaDesarrollo.GetFirstCharIndexOfCurrentLine();
            int lineaActual = areaDesarrollo.GetLineFromCharIndex(primerCaracter);
            int columna = areaDesarrollo.SelectionStart - primerCaracter;

            txtBx_Informativo.Text = "Linea: " + Convert.ToString(lineaActual) + " Columna: " + Convert.ToString(columna);
        }
    }
}
