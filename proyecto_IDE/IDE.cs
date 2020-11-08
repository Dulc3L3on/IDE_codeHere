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
using proyecto_IDE.Complementos_analizadores;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE
{ 
    public partial class IDE : Form
    {
        Kit herramienta;
        AnalizadorLexico analizadorLexico;
        AnalizadorSintactico analizadorSintactico;
        ManejadorArchivo manejadorArchivo = new ManejadorArchivo();        

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
            int primerCaracter = areaDesarrollo.GetFirstCharIndexOfCurrentLine();
            int lineaActual = areaDesarrollo.GetLineFromCharIndex(primerCaracter) + 1;
            int columna = areaDesarrollo.SelectionStart - primerCaracter;

            txtBx_Informativo.Text = "Linea: " + Convert.ToString(lineaActual) + " Columna: " + Convert.ToString(columna);//parece ser repetitivo pero no lo es, porque uno se acciona cuando se presiona el teclado para hacer el cab de linea y el otro cuando se hace el cambio con el mouse
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
            if (dialogoApertura.ShowDialog() == System.Windows.Forms.DialogResult.OK) {//si aqupi se verificara su existencia sería muchisisísimo mejor...
                areaDesarrollo.Clear();
                areaDesarrollo.Text = manejadorArchivo.leerArchivo(dialogoApertura.FileName);
                correrAnalisis();//y todo vuelve a la normalidad xD
            }
            habiliarGuargarCambios();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardado = new SaveFileDialog();            
            dialogoGuardado.DefaultExt = "*.gt";            
            dialogoGuardado.Filter = "archivos .gt|*.gt";
            dialogoGuardado.Title = "Guardar trabajo";

            

            if (dialogoGuardado.ShowDialog()== System.Windows.Forms.DialogResult.OK && dialogoGuardado.FileName.Length>0) {//Esto es para que no se guarde sin nombre...
                //se manda a llamar el método para guardar...
                //MessageBox.Show(dialogoGuardado.FileName);
                manejadorArchivo.guardarArchivoComo(dialogoGuardado.FileName, areaDesarrollo.Text);
            }

            habiliarGuargarCambios();
        }

        private void compilarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            correrAnalisis();

        }//ya comila :3 UwU

        private void correrAnalisis() {
            String[] lineasAAnalizar = areaDesarrollo.Lines;
            dejarTodoComoAlPrincipio();

            for (int numeroLinea = 0; numeroLinea < lineasAAnalizar.Length; numeroLinea++)
            {
                analizadorLexico.analizarLinea(lineasAAnalizar[numeroLinea].ToCharArray(), numeroLinea);//pero recuerda que para trabajar con los datos del rich, debido a esta suma, será necesario restarle este 1...                               
                if (numeroLinea == (lineasAAnalizar.Length-1)) {
                    analizadorLexico.finalizarResultados(numeroLinea);
                    analizadorSintactico = new AnalizadorSintactico(analizadorLexico.darListaTokensClasificados(), herramienta);
                    analizadorSintactico.analizarCodigo();
                }
            }            

            if (!analizadorLexico.darControlCierre().darListaEsperaCierre().estaVacia())
            {
                Nodo<String> nododAuxiliar = analizadorLexico.darControlCierre().darListaEsperaCierre().darPrimerNodo();
                String[] contenidoDelActual = nododAuxiliar.contenido.Split(',');//si mal no estoy lo separé por comas...

                for (int excepcionActual = 0; excepcionActual < analizadorLexico.darControlCierre().darListaEsperaCierre().darTamanio(); excepcionActual++)
                {
                    if (contenidoDelActual[0].Length == 1 && (int)Convert.ToChar(contenidoDelActual[0]) == 34)
                    {
                        analizadorLexico.darExcepcionLexico().excepcionNecesitadosCierre(Convert.ToInt32(contenidoDelActual[1]), 0, analizadorLexico.darControlCierre().darMensajeErrorCadena());//hago esto porque cuando un comentario no se cierra, no se colorea todo ello :v, solo se ondica el hecho con el msjin xD
                    }

                    if (contenidoDelActual[0].Equals("/*"))
                    {
                        analizadorLexico.darExcepcionLexico().excepcionNecesitadosCierre(Convert.ToInt32(contenidoDelActual[1]), 0, analizadorLexico.darControlCierre().darMensajeErrorComentarioMultiLinea());//lo mismo app para este xD, pues el número de columna solo es útil para marcar el error...
                    }//Recuerda que el comentario 1 linea xD no tiene errores... y tampoco caracter... a menos que sea uno inválido...

                }//fin del for que se encarga de añadir las excepciones de los necesitados de cierre                                

            }//fin del if que permite exe el bloque para añadir los errores de los necesitados de cierre

            if (!analizadorLexico.darExcepcionLexico().darListadoErrores().estaVacia())
            {//así se podrán mostrar los errores de los primitivos y/o necesitados de cierre de una sola vez...
                herramienta.mostrarError(analizadorLexico.darExcepcionLexico().darListadoErrores());//De esta manera no se acumularán los errores de los tipos primitivos en el log... olo que hice fue nada más sacar el metodo de mostrar del metodo marcar...
            }

            //analizadorLexico.darHerramienta().reiniciarColorLetra();
        }

        private void dejarTodoComoAlPrincipio() {
            limpiarLog();
            analizadorLexico.darExcepcionLexico().limpiarListadoErrores();
            analizadorLexico.darControlCierre().reiniciarListadoNoCerrados();
            analizadorLexico.darListaTokensClasificados().limpiarLista();
            //analizadorLexico.darHerramienta().quitarSubrayado();
        }

        public void limpiarLog() {
            if (txtBx_mensajero.Text != null)
            {
                txtBx_mensajero.Clear();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogoApertura = new OpenFileDialog();
            dialogoApertura.Filter = "archivos .gt|*.gt";
            dialogoApertura.RestoreDirectory = true;
            dialogoApertura.Title = "Abrir";

            if (dialogoApertura.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                manejadorArchivo.EliminarArchivo(dialogoApertura.FileName);
            }            
        }

        private void guardarCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manejadorArchivo.elArchivoEstaGuardado()) {
                manejadorArchivo.guardarArchivo(areaDesarrollo.Text);
            }
        }

        private void exportarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardado = new SaveFileDialog();
            dialogoGuardado.DefaultExt = "*.gtE";
            dialogoGuardado.Filter = "archivos .gtE|*.gtE";
            dialogoGuardado.Title = "Exportar errores";

            if (dialogoGuardado.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialogoGuardado.FileName.Length > 0)
            {//Esto es para que no se guarde sin nombre...
                //se manda a llamar el método para guardar...                
                manejadorArchivo.exportarArchivoErrores(dialogoGuardado.FileName, txtBx_mensajero.Text);
            }

        }

        public void habiliarGuargarCambios() {
            if (guardarCambiosToolStripMenuItem.Enabled == false)
            {
                guardarCambiosToolStripMenuItem.Enabled = true;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            areaDesarrollo.Clear();
            limpiarLog();
        }//Así como Word xD

        private void verArbolDeDerivacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manejadorArchivo.existeArbol()) {
                System.Diagnostics.Process.Start("grafo.txt");
                analizadorSintactico.darAutomata().darArbol().darGrafo().generarArbol();
                System.Diagnostics.Process.Start("grafo.jpg");//errorsin xD                
            }
        }
    }
}
