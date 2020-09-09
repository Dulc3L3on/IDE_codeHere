using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Excepciones
{
    class ExcepcionLexico
    {
        ListaEnlazada<String> listaErrores = new ListaEnlazada<String>();//los nombre de los nodos tendrán el número de fila y el contenido del nodo será la palabra...

        Kit herramienta = new Kit();

        public String excepcionPalabra(int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {//puesto que aún no han sido solicitados los identificadores, entones no agrego la parte donde si es un # ó _ entonces lo paso a identificador de lo contrario a lista de errores...
            String mensajeError = "La palabra tiene errores a partir del caracter: ";

            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'n' || lineaCompleta[columnaExcepcion] == '_')
            {
                mensajeError += Convert.ToString(columnaExcepcion);
                anadirError(numeroFila, mensajeError);

                return "erronea";//en este caso se traduciría como "debe seguir concatenando la palabra aunque tenga errores"
            }//esto es lo que se adaptará al indetificador cuando ya soliciten incluirlo...

            return "primitiva_palabra";//debe parar por el hecho de que está presente otro tipo de caracter el cual puede estar definido en el alfabeto...
        }

        public String excepcionNumero(int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {
            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'p')
            {
                return "primitiva_decimal";
            }//allá en el métoodo de decimal se revisará al sigueinte y estrictamente si no hay un número en el espacio que corresponde -> erronea            

            return "primitiva_entero";//pues se tienen otros caracteres, que posiblemente sean de comparación o que no estén en el alfabeto, donde esto últmi será un error, lo cual estará contemplado en el switch...

        }

        public String excepcionDecimal(int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {
            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'p')
            {
                String mensajeError = "El decimal debe tener únicamente un . ";
                anadirError(numeroFila, mensajeError);
                return "erronea";
            }//allá en el métoodo de decimal se revisará al sigueinte y estrictamente si no hay un número en el espacio que corresponde -> erronea            

            return "primitiva_decimal";//pues se tienen otros caracteres, que posiblemente estén sintácticamente correctos [por ser de comparación, identificadores, aritmeticos, fianlizacion y así xD] por ello será mejor analizar para determinar su validez léxica y posterior a ello la sintáctica
        }


        private void anadirError(int numeroLinea, String mensaje)
        {
            String mensajeError = Convert.ToString(numeroLinea) + "   " + "mensaje";
            listaErrores.anadirAlFinal(mensajeError);
        }

        //RECUERDA: que cuando elimines los errores de la lista, deberá ser el de la línea que fue corregido, así que pienso que deberás apoyarte de los evt dericht text box,para que puedas obtener la línea que fue corregida, pero, aquí hay algo, que el hecho de modificar o borrar una fila no impica que haya arreglado el error... 
        //YA SÉ lo que debes hacer es crear un listado de errores que surgieron en el análisis actual [excluyendo los que surgieron por el hecho de que el resto del contenido puede que se encuentre en las lineas de abajo] que al final de todo el proceso será revisado para determinar si existieron o no errores, de tal manera que 
        //se sepa si debe ir a buscarse o no al listado que contiene a todos los errores que deben mostrarse en pantalla cuando no se haya encontrado ninguno Y se haya modificado la fila... talvez sería bueno dejar así como que una etiqueta donde se diga, con error hallado de tal manera que al modificarla se cree dicho listado y
        //se revise posteriormente, para saber si debe add el contenido de dicha lista ó eliminarse todos o errores que no parezcan en ese listado recién creado en el listado completo con respecto a esta línea en específico...

    }
}
