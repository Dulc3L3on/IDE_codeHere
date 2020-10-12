using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Excepciones
{
    [Serializable]
    class ExcepcionLexico
    {
        ListaEnlazada<String> listaErrores = new ListaEnlazada<String>();//los nombre de los nodos tendrán el número de fila y el contenido del nodo será la palabra...
                
        Kit herramienta;
        

        public ExcepcionLexico(Kit kitHerramientas) {
            herramienta = kitHerramientas;           
        }

        public String excepcionPalabra(int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {//puesto que aún no han sido solicitados los identificadores, entones no agrego la parte donde si es un # ó _ entonces lo paso a identificador de lo contrario a lista de errores...
            
            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'd' || lineaCompleta[columnaExcepcion] == '_')
            {              
                return "posible_identificador";//en este caso se traduciría como "debe seguir concatenando la palabra aunque tenga errores"
            }//esto es lo que se adaptará al indetificador cuando ya soliciten incluirlo...

            return "primitiva_palabra";//debe parar por el hecho de que está presente otro tipo de caracter el cual puede estar definido en el alfabeto...
        }//listo xD

        public String excepcionIdentificador(int numeroFila, int columnaExcepcion, char[] lineaCompleta) {
          
            String mensajeError = "hay caracteres incorrectos en en el conjunto de la columna " + Convert.ToString(columnaExcepcion);
            anadirError(numeroFila, lineaCompleta.Length, mensajeError);           

            return "primitiva_palabra";//esto por lo mismo que identificador aún no es una clasificación formal... caundo ya sea así, seguramente esto pasará a tener otro if y a devolver algo diferente para cada situación...
        }

        public void excepcionMalformacionReservada(int numeroFila, int columnaExcepcion, String conjuntoMalFormado) { //ya sea reservada xD, identificador o método... [pero estos últimos 2 aún no se consideran
            String mensajeError="\""+conjuntoMalFormado+"\""+" NO PERTENECE a palabras reservadas";//o se oye mejor no forma parte fmmm xD
            
            anadirError(numeroFila, columnaExcepcion, mensajeError);

        }

        public String excepcionNumero(int numeroFila, int columnaExcepcion, char[] lineaCompleta)//es que no es un error como tal, sino que se empleó para hacer el cambio a decimal...
        {
            if ((columnaExcepcion+1)< lineaCompleta.Length && herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'p')//pue sí, ya que estoy viendo las excepciones por qué no matar 2 pájaros de 1 tiro... esto lo digo porque si al entrar a analizar el decimal sabiendo solamente lo del punto, puede que el siguiente al punto no sea un número, así que tronitos xD
            {
                return "posible_decimal";
            }//allá en el métoodo de decimal se revisará al sigueinte y estrictamente si no hay un número en el espacio que corresponde -> erronea            

            return "primitiva_entero";//pues se tienen otros caracteres, que posiblemente sean de comparación o que no estén en el alfabeto, donde esto últmi será un error, lo cual estará contemplado en el switch...
        }//listo xD
             

        public void excepcionNecesitadosCierre(int numeroFila, int numeroColumnaFinal,String mensajeError) {//recuerda que el número de columna final en cualquiera de estos métodos será el tamaño del arr de caracteres xD

            anadirError(numeroFila, numeroColumnaFinal, mensajeError);

            //no retorno nada porque no he guardado nada en RESULTADO aún, sino que lo hago hasta que encuentre el cierre...
        }//listo xD

        public String[] excepcionDecimal(String[] datosDecimal, int numeroFila, int columnaExcepcion, char[] lineaCompleta)
        {
            if (herramienta.determinarTipoCaracter(lineaCompleta[columnaExcepcion]) == 'p')
            {
                String mensajeError = " el tipo decimal debe tener únicamente un PUNTO";
                anadirError(numeroFila, lineaCompleta.Length, mensajeError);
                return excepcionPorPuntoExtraEnDecimal(datosDecimal, lineaCompleta, columnaExcepcion);
            }//allá en el métoodo de decimal se revisará al sigueinte y estrictamente si no hay un número en el espacio que corresponde -> erronea            

            datosDecimal[1] = "primitiva_decimal";//a mi parecer debe ser en [1] pero funciona bien... eso quiere decir que la condición de == primitiva_deciaml, entonces asigna dicho valor a la var... para colorear...
            return datosDecimal;//pues se tienen otros caracteres, que posiblemente estén sintácticamente correctos [por ser de comparación, identificadores, aritmeticos, fianlizacion y así xD] por ello será mejor analizar para determinar su validez léxica y posterior a ello la sintáctica
        }//LISTO XD


        /*
         Método llamado al hallarse un punto extra en el decimal... puesto que si es 
        otro caracter que no sea punto [y por supuesto dígito...] se pasará la batuta 
        al que le corresponda
         */
        private String[] excepcionPorPuntoExtraEnDecimal(String[] datosDecimalErrado, char[] lineaDesglosada, int posicion) {//Esta el posición donde se encontró el punto mal ubicado xD
            datosDecimalErrado[1] = "erronea";

            while (posicion<lineaDesglosada.Length && (herramienta.determinarTipoCaracter(lineaDesglosada[posicion])== 'd' || herramienta.determinarTipoCaracter(lineaDesglosada[posicion]) == 'p')) {
                datosDecimalErrado[2] +=lineaDesglosada[posicion];

                posicion++;//así de esta manera se seguirá cumpliendo el acuerdo de devolver una posición más allá...
            }

            datosDecimalErrado[0] = Convert.ToString(posicion);
            return datosDecimalErrado;
        }

        public String excepcionSimbolo(int numeroFila, int numeroColumnaFinal, String caracterErroneo) {
            String mensajeError = "La utilizacion de "+"\"" +caracterErroneo+"\"" + " no está permitida";//Aquí de una vez se muestra el error, porque si entró como "otros" y esos otros no están definido, entonces de una vez Strike y fueraaa! xD
            anadirError(numeroFila, numeroColumnaFinal, mensajeError);
            return "erronea";
        }//listo xD

        public void puntoDesubicado(int numeroFila, int numeroColumna)
        {
            String mensajeError = "Tienes un punto mal ubicado...";//Aquí de una vez se muestra el error, porque si entró como "otros" y esos otros no están definido, entonces de una vez Strike y fueraaa! xD
            anadirError(numeroFila, numeroColumna, mensajeError);            
        }


        public void anadirError(int numeroLinea, int numeroColumaFinal, String mensaje)//no habrá problema que con los primitivos muestre de una vez el error...
        {
            String mensajeError = "Error en la linea: "+ Convert.ToString(numeroLinea+1) + " >>> " + mensaje;//para que el mínimo indice de la línea sea 1...
            listaErrores.anadirAlFinal(mensajeError);

            //se manda a llamar el método para colorear la fila de corinto...
            //herramienta.marcarError(numeroLinea, numeroColumaFinal);//te hace falta mandar el número de columna donde termina la línea... deplano que lo recibirás de cada mpetodo desde díonde se llama
        }       

        public void limpiarListadoErrores() {
            listaErrores.limpiarLista();
        }

        public ListaEnlazada<String> darListadoErrores() {
            return listaErrores;
        }

        //RECUERDA: que cuando elimines los errores de la lista, deberá ser el de la línea que fue corregido, así que pienso que deberás apoyarte de los evt dericht text box,para que puedas obtener la línea que fue corregida, pero, aquí hay algo, que el hecho de modificar o borrar una fila no impica que haya arreglado el error... 
        //YA SÉ lo que debes hacer es crear un listado de errores que surgieron en el análisis actual [excluyendo los que surgieron por el hecho de que el resto del contenido puede que se encuentre en las lineas de abajo] que al final de todo el proceso será revisado para determinar si existieron o no errores, de tal manera que 
        //se sepa si debe ir a buscarse o no al listado que contiene a todos los errores que deben mostrarse en pantalla cuando no se haya encontrado ninguno Y se haya modificado la fila... talvez sería bueno dejar así como que una etiqueta donde se diga, con error hallado de tal manera que al modificarla se cree dicho listado y
        //se revise posteriormente, para saber si debe add el contenido de dicha lista ó eliminarse todos o errores que no parezcan en ese listado recién creado en el listado completo con respecto a esta línea en específico...

    }
}
