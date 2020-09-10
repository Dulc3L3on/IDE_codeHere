using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Herramientas
{
    class Kit
    {
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
         Este método será empleado específicamente cuando se sepa que si debe analizarse la
         agrupación y que debe hacerse el agregado a la lista de espera del signo de cierre
         que le corresponde
         */
        public String determinarTipoEncierro(char caracterActual, char caracterSiguiente) { //me refiero a si es agrupacion, cadena o comentrio xD... es que encierran xD
            if ((int)caracterActual == 47 && (int)caracterSiguiente == 47) {
                return "comentarioLinea";
            }

            if ((int)caracterActual == 47 && (int)caracterSiguiente == 42) {
                return "comentarioMultiLinea";
            }

            if ((int)caracterActual == 34) {
                return "comilla";//por la manera de trabajar esta comilla siempre será la de apertura...
            }
            if ((int) caracterActual == 40) {
                return "parentesis";
            }

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
    }
}
