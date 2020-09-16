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
            int linea = areaDesarrollo.GetLineFromCharIndex(areaDesarrollo.GetFirstCharIndexOfCurrentLine()+1);//se obtiene el índice [el número de columna total en el que se encuentra el cursor...
            int indice = areaDesarrollo.SelectionStart;
            int columna = indice - areaDesarrollo.GetFirstCharIndexOfCurrentLine();


            txtBx_Informativo.Text = "Linea: " + Convert.ToString(linea) + " Columna: " + Convert.ToString(columna);//parece ser repetitivo pero no lo es, porque uno se acciona cuando se presiona el teclado para hacer el cab de linea y el otro cuando se hace el cambio con el mouse
        }

        private void areaDesarrollo_MouseMoved(object sender, MouseEventArgs e)
        {
            int primerCaracter = areaDesarrollo.GetFirstCharIndexOfCurrentLine();
            int lineaActual = areaDesarrollo.GetLineFromCharIndex(primerCaracter)+1;
            int columna = areaDesarrollo.SelectionStart - primerCaracter;

            txtBx_Informativo.Text = "Linea: " + Convert.ToString(lineaActual) + " Columna: " + Convert.ToString(columna);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogoApertura = new OpenFileDialog();
            dialogoApertura.Filter = "archivos .gt|*.gt";
            dialogoApertura.RestoreDirectory = true;
            dialogoApertura.Title = "Abrir";

            //Se manda a llamar al método del manejador de archivos para leer el arch según la selección... solo que aún no lo has implementado por el hecho de que 
            //tienes que investigar si se trabaja de igual manera el guardado de objetos ó varía en algo, es decir hay que hacer algo más de serializar


        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardado = new SaveFileDialog();
            dialogoGuardado.DefaultExt = "*.rtf";
            dialogoGuardado.Filter = "archivos .gt|*.gt";
            dialogoGuardado.Title = "Guardar trabajo";

            if (dialogoGuardado.ShowDialog()== System.Windows.Forms.DialogResult.OK && dialogoGuardado.FileName.Length>0) {
                areaDesarrollo.SaveFile(dialogoGuardado.FileName, RichTextBoxStreamType.RichNoOleObjs);//puede que tengamos problemas con esto, debido a la extensión... si es así
                //es un hecho que tendrás que usar el botón de compilado... y por ello leer sin ayuda del rich su debido contenido
            }
        }

        private void compilarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String[] lineasAAnalizar = areaDesarrollo.Lines;
            limpiarLog();
            analizadorLexico.darExcepcionLexico().limpiarListadoErrores();

            for (int numeroLinea=0; numeroLinea< lineasAAnalizar.Length; numeroLinea++) {
                analizadorLexico.analizarLinea(lineasAAnalizar[numeroLinea].ToCharArray(), numeroLinea);//pero recuerda que para trabajar con los datos del rich, debido a esta suma, será necesario restarle este 1...               
            }

            if (!analizadorLexico.darControlCierre().darListaEsperaCierre().estaVacia())
            {
                Nodo<String> nododAuxiliar = analizadorLexico.darControlCierre().darListaEsperaCierre().darPrimerNodo();
                String[] contenidoDelActual = nododAuxiliar.contenido.Split(',');//si mal no estoy lo separé por comas...

                for (int excepcionActual = 0; excepcionActual < analizadorLexico.darControlCierre().darListaEsperaCierre().darTamanio(); excepcionActual++)
                {
                    if (contenidoDelActual[0].Equals('\"'))
                    {
                        analizadorLexico.darExcepcionLexico().excepcionNecesitadosCierre(Convert.ToInt32(contenidoDelActual[1]), Convert.ToInt32(contenidoDelActual[2]), analizadorLexico.darControlCierre().darMensajeErrorCadena());
                    }

                    if (contenidoDelActual[0].Equals("/*"))
                    {
                        analizadorLexico.darExcepcionLexico().excepcionNecesitadosCierre(Convert.ToInt32(contenidoDelActual[1]), Convert.ToInt32(contenidoDelActual[2]), analizadorLexico.darControlCierre().darMensajeErrorComentarioMultiLinea());
                    }

                }//fin del for que se encarga de añadir las excepciones de los necesitados de cierre                    

                herramienta.mostrarError(analizadorLexico.darExcepcionLexico().darListadoErrores());//De esta manera no se acumularán los errores de los tipos primitivos en el log... olo que hice fue nada más sacar el metodo de mostrar del metodo marcar...

            }//fin del if que permite exe el bloque para añadir los errores de los necesitados de cierre


        }//ya comila :3 UwU

        public void limpiarLog() {
            if (txtBx_mensajero.Text != null)
            {
                txtBx_mensajero.Clear();
            }
        }
    }
}
