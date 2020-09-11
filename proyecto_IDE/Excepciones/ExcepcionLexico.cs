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
                
        Kit herramienta;

        public ExcepcionLexico(Kit kitHerramientas) {
            herramienta = kitHerramientas;
        }

        public String excepcionPalabra(int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {//puesto que aún no han sido solicitados los identificadores, entones no agrego la parte donde si es un # ó _ entonces lo paso a identificador de lo contrario a lista de errores...
            String mensajeError = "La palabra tiene errores a partir del caracter: ";

            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'n' || lineaCompleta[columnaExcepcion] == '_')
            {
                mensajeError += Convert.ToString(columnaExcepcion);
                anadirError(numeroFila, lineaCompleta.Length, mensajeError);


                return "erronea";//en este caso se traduciría como "debe seguir concatenando la palabra aunque tenga errores"
            }//esto es lo que se adaptará al indetificador cuando ya soliciten incluirlo...

            return "primitiva_palabra";//debe parar por el hecho de que está presente otro tipo de caracter el cual puede estar definido en el alfabeto...
        }//listo xD

        public String excepcionNumero(int numeroFila, int columnaExcepcion, char[] lineaCompleta)//es que no es un error como tal, sino que se empleó para hacer el cambio a decimal...
        {
            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'p' && herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion+1]) == 'n')//pue sí, ya que estoy viendo las excepciones por qué no matar 2 pájaros de 1 tiro... esto lo digo porque si al entrar a analizar el decimal sabiendo solamente lo del punto, puede que el siguiente al punto no sea un número, así que tronitos xD
            {
                return "primitiva_decimal";
            }//allá en el métoodo de decimal se revisará al sigueinte y estrictamente si no hay un número en el espacio que corresponde -> erronea            

            return "primitiva_entero";//pues se tienen otros caracteres, que posiblemente sean de comparación o que no estén en el alfabeto, donde esto últmi será un error, lo cual estará contemplado en el switch...
        }//listo xD

        public void excepcionNecesitadoCierre(int numeroFila, int numeroColumnaFinal,String mensajeError) {//recuerda que el número de columna final en cualquiera de estos métodos será el tamaño del arr de caracteres xD
            anadirError(numeroFila, numeroColumnaFinal, mensajeError);

            //no retorno nada porque no he guardado nada en RESULTADO aún, sino que lo hago hasta que encuentre el cierre...
        }//listo xD

        public String excepcionDecimal(int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {
            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'p')
            {

                String mensajeError = "El decimal debe tener únicamente un . ";
                anadirError(numeroFila, lineaCompleta.Length, mensajeError);
                return "erronea";
            }//allá en el métoodo de decimal se revisará al sigueinte y estrictamente si no hay un número en el espacio que corresponde -> erronea            

            return "primitiva_decimal";//pues se tienen otros caracteres, que posiblemente estén sintácticamente correctos [por ser de comparación, identificadores, aritmeticos, fianlizacion y así xD] por ello será mejor analizar para determinar su validez léxica y posterior a ello la sintáctica
        }//LISTO XD

        public String excepcionSimbolo(int numeroFila, int numeroColumnaFinal, String caracterErroneo) {

            String mensajeError = "La utilizacion de "+ caracterErroneo + " no está permitida";//Aquí de una vez se muestra el error, porque si entró como "otros" y esos otros no están definido, entonces de una vez Strike y fueraaa! xD
            anadirError(numeroFila, numeroColumnaFinal, mensajeError);
            return "erronea";
        }//listo xD


        private void anadirError(int numeroLinea, int numeroColumaFinal, String mensaje)
        {
            String mensajeError = Convert.ToString(numeroLinea) + "   " + mensaje;
            listaErrores.anadirAlFinal(mensajeError);


            //se manda a llamar el método para colorear la fila de corinto...
            herramienta.marcarError(numeroLinea, numeroColumaFinal, listaErrores);//te hace falta mandar el número de columna donde termina la línea... deplano que lo recibirás de cada mpetodo desde díonde se llama
        }

        //RECUERDA: que cuando elimines los errores de la lista, deberá ser el de la línea que fue corregido, así que pienso que deberás apoyarte de los evt dericht text box,para que puedas obtener la línea que fue corregida, pero, aquí hay algo, que el hecho de modificar o borrar una fila no impica que haya arreglado el error... 
        //YA SÉ lo que debes hacer es crear un listado de errores que surgieron en el análisis actual [excluyendo los que surgieron por el hecho de que el resto del contenido puede que se encuentre en las lineas de abajo] que al final de todo el proceso será revisado para determinar si existieron o no errores, de tal manera que 
        //se sepa si debe ir a buscarse o no al listado que contiene a todos los errores que deben mostrarse en pantalla cuando no se haya encontrado ninguno Y se haya modificado la fila... talvez sería bueno dejar así como que una etiqueta donde se diga, con error hallado de tal manera que al modificarla se cree dicho listado y
        //se revise posteriormente, para saber si debe add el contenido de dicha lista ó eliminarse todos o errores que no parezcan en ese listado recién creado en el listado completo con respecto a esta línea en específico...

    }
}
