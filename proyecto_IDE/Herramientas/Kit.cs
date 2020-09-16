using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_IDE.Herramientas
{
    class Kit
    {
        RichTextBox areaDesarrollo;
        TextBox txtBx_mensajero;
        ListaEnlazada<int> numeroLineaCambiada = new ListaEnlazada<int>();//será útil para saber cuando se debe llamar al analizador...

        public Kit(RichTextBox areaEnriquecida, TextBox txt_mensajero) {
            areaDesarrollo = areaEnriquecida;
            txtBx_mensajero = txt_mensajero;
        }

        public char determinarTipoCaracter(char caracterInicial)
        {
            if (((int)caracterInicial >= 65 && (int)caracterInicial <= 90) || (int)caracterInicial >= 97 && (int)caracterInicial <= 122)
            {
                return 'l';//De letra
            }

            if ((int)caracterInicial >= 48 && (int)caracterInicial <= 57)
            {
                return 'd';//de digito
            }

            if ((int)caracterInicial == 46)
            {
                return 'p';//de punto
            }

            if ((int)caracterInicial == 34 || (int) caracterInicial == 40 || (int)caracterInicial == 47)//cuando la c se hay devueto por el hecho de ser 47, tendrá que analizarse inmediatamente su siguiente en el método qie determina las agrupaciones, para saber si se sigue analizando ahí o no...
            {
                return 'c';//De necesita cierre -> "", (,  / [en este caso no pero por el hecho de colorear todo lo que dentro de él esté] /**/
            }

            return 'o';//De otros, que hasta el momento no se sabe si correponden o no al alfabeto...
        }
/*
        public bool esSimboloCierre() {
            if ((int)caracterInicial == 41 ((int)lineaDesglosada[caracterActual] == 47 && (int)lineaDesglosada[caracterActual + 1] == 47) || (int)lineaDesglosada[caracterActual] == 47 && (int)lineaDesglosada[caracterActual + 1] == 42) {
                return true;
            }
        }
        */

        /*
         Este método será empleado específicamente cuando se sepa que si debe analizarse la
         agrupación y que debe hacerse el agregado a la lista de espera del signo de cierre
         que le corresponde
         */
        public String determinarTipoEncierro(char[] lineaDesglosada, int caracterActual) { //me refiero a si es agrupacion, cadena o comentrio xD... es que encierran xD

            if ((caracterActual+1)<lineaDesglosada.Length) {
                if ((int)lineaDesglosada[caracterActual] == 47 && (int)lineaDesglosada[caracterActual + 1] == 47)
                {
                    return "comentarioLinea";
                }

                if ((int)lineaDesglosada[caracterActual] == 47 && (int)lineaDesglosada[caracterActual + 1] == 42)
                {
                    return "comentarioMultiLinea";
                }
            }           

            if ((int)lineaDesglosada[caracterActual] == 34) {
                return "cadena";//por la manera de trabajar esta comilla siempre será la de apertura...
            }
            if ((int)lineaDesglosada[caracterActual] == 40) {
                return "parentesisApertura";
            }//no puede agregarse el paréntesis de cierre porque sino se estaría poneindo en desacuerdo el hecho de permitir entrar a este método SSi tiene estos caracteres de apertura ó aún no ha cerrado el ciclo           

            //Por el contexto en el que se emplea este método, cuando devulva null, será un hecho de que se trata del signo para dividir...
            return "division";//Es decir que no es ninguno y por ello deberé de clasiicar la barra como de división de una vez en el control de cierre, porque para qué estar revisando toda la enumeración si ya sé que es...
        }

        public String cerrarComentario(char caracaterAnterior, char caracterPosterior)
        {//será el primero en ser llamado por el hecho de contener menos condiciones que revisar... auqneu talvez sea el menos empleado de todos...
            if ((int)caracaterAnterior == 47 && (int)caracaterAnterior == 42)
            {
                char barraComentario = (char)47;
                String comentarioMultiLinCierre = "*" + barraComentario;
                return comentarioMultiLinCierre;
            }

            return null;
        }
        public char cerrarAperturado(char signoApertura)
        {//será llamado por el keyTyped para que revise y cuando sea alguno de estos tipos que devuelva el caracter correspondiente...
            if (((int)signoApertura) == 34)
            {
                return (char)34;
            }
            if ((int)signoApertura == 40)
            {
                return (char)41;
            }//cuando sea incluido también irían aquí los [] y las {}

            return (char)32;//devuelve un espacio en blanco...

        }

        public int agregarNumeroLineas(int lineaPosicion, int lineaMostrada) {//la posición es dada por el rich y la linea mostrada por la lista...
            if (lineaPosicion> lineaMostrada) {
                return lineaMostrada++;
            }

            return 0;
        }

        public int eliminarRangoLineas(int lineasLlenas, int lineaMostrada) {
            if (lineasLlenas< lineaMostrada) {//quiere decir que hay líneas de más...
                return (lineaMostrada-lineasLlenas);//se manda el total de elementos a eliminar, por lo cual en el método directo para eliminar deberá borrarse un elemento desde el final de la lista hasta llevar a 0 esta cantidad
            }

            return 0;//DE TODOS MODOS SI FUERAN IGUALES EL RESULTADO SERÍA 0...
        }

        public void marcarError(int numeroLinea, int numeroColumnaFinal, ListaEnlazada<String> listaErrores)
        {
            areaDesarrollo.Select(areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + numeroColumnaFinal));//así obtnego la columna general, no relativa :v xD
            areaDesarrollo.SelectionColor = System.Drawing.Color.PeachPuff;
            areaDesarrollo.Select(0, 0);            
        }

        public void mostrarError(ListaEnlazada<String> listaDeErrores) {//recuerda que aún no has contemplado eliminar el error cuando la línea se modifique... creo que tendrías que hacer un reemplazo o modificación... bueno eso habías dicho antes...
            Nodo<String> nodoAuxiliar = listaDeErrores.darPrimerNodo();

            for (int errorActual=0; errorActual< listaDeErrores.darTamanio(); errorActual++) {
                txtBx_mensajero.Text += nodoAuxiliar.contenido;

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }            
        }

        public void colorearConjuntoCaracteres(String tipoAgrupacion,int numeroLinea,  int columnaInicio, int columnaFin) {//recuerda que en realidad este número de cols es la posición del caracter en el arreglo de caracteres obtenido, es decir es su ubucacion relativa, puesto que es en base a la línea actual...
            switch (tipoAgrupacion)
            {
                case "entero":
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea)+columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea)+columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.DarkViolet;
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "cadena"://hace falta que agregues esto...
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.DimGray;//sino mystiRose xD
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "Funcional"://si app lo que explico 2 lineas abajo, entonces este caso desaparecerá xD
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.DarkOliveGreen;//mientras tanto... en lo que averiguo si tengo que app el mismo color que sus elemntos a la reservada, si e así lo que deberá hacer es terminar el método de abajo para colorearla según ello Ó hacer que la var que se revisa para esto, guarde el nombre de su tipo correspondiente así aunque sea la palabra reservada o su contenido en sí tengan el mismo color... esto me gusta más xD, auqneu eso implicaría add un if donde si es reservada_Tipado el tipo :v del conjunto estudiado entonce que se coloque el 2do nombre para que así concuerde... xD muajajajaj xD
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "decimal":
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.DarkCyan;
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "booleano":
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.Orange;
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "caracter":
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.Chocolate;
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "finAsignacion":
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.DeepPink;//sino mystiRose xD
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                case "comentario":
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.Tomato;//sino mystiRose xD
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;                

                case "simbolo"://hace falta que agregues esto...
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.Blue;
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                default:
                    areaDesarrollo.Select((areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaInicio), (areaDesarrollo.GetFirstCharIndexFromLine(numeroLinea) + columnaFin)+1);
                    areaDesarrollo.SelectionColor = System.Drawing.Color.White;//sino mystiRose xD
                    areaDesarrollo.SelectionStart = areaDesarrollo.Text.Length;

                    break;

                    //De lo contraio, blanco xD
            }//fin del switch

        }

        public void llevarControlCambios(int numeroLineaAfectada) {
            numeroLineaCambiada.anadirAlFinal(numeroLineaAfectada);
        }//deprecated xD
    }
}
