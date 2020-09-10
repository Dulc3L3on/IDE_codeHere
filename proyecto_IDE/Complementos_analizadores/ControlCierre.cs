﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Excepciones;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Complementos_analizadores
{
    class ControlCierre//estaa clase será empleada para llevar el control xD de aquellos elementos que requieren de su compañero para ser cerrados y pasar a otro análisis
                      //entre los participantes se tiene a la cadena, el comentario y a los paréntesis, pero no del todo por el hecho de que aún no clasifico su agrupación interna
                      //como debe, sino que solo verifico que esté debidamente cerrado...
    {
        int ultimoCaracterAnalizado = 0;
        Resultado resultadoParentesisODivsion = new Resultado();
        ExcepcionLexico excepcionLexico;

        ListaEnlazada<String> listadoNoCerrados = new ListaEnlazada<String>();//este listado será el que contenga a los signos con su respectiva columna de inicio que aún no han encontrado a su cierre, solo serán add los elementos cuando se llegue al tamaño de la linea y áún no se haya encontrado a dicho símbolo de cierre...
        //el último que aparezca en la lista es a quien le pertenece la agrupación finalizada al hallar el signo de cierre...
        
        ListaEnlazada<String> listadoTipoAgrupaciones = new ListaEnlazada<String>();//en este listado se irán guanrdando los tipos de agrupaciones que pertenecerán al paréntesis abierto más reciente
        //[es decir el más adentrado], claro, teniendo en cuenta el hecho de que media ve aparezcan " o cualquier tipo de comentario, me importará un comino lo que venga... 
        //esto indica que tendrá que los paréntesis tendrán un método propio para asignar, puesto que el tipo lo darán según.. el contexto? mmm eso ya me suena a sintáctico o más bien trabajo semántico...
        Kit herramientas = new Kit();

        public ControlCierre(ExcepcionLexico excepcion) {
            excepcionLexico = excepcion;
        }       

        public Resultado analizarAgrupaciones(char[] lineaDesglosada,int numeroLinea, int caracterActual) {            

            if (listadoNoCerrados.estaVacia() || (listadoNoCerrados.darContenidoUltimoNodo().Equals('(') && herramientas.determinarTipoCaracter(lineaDesglosada[caracterActual]).Equals('c'))) {
                 agregarNecesitado(lineaDesglosada, caracterActual, caracterActual+1, numeroLinea);//se manda a llamar el método para hacer la debida agregación del caracter, si es que pertenece a los necesitados de cierre...
            }//fin del if donde se establecen los caracteres iniciales... es necesario hacer esto ya que así no hbrá confusión, al averiguar en el caso de las " y comentarios si se debe colocar o no este signo a la ista...

            if (!listadoNoCerrados.darUltimoNodo().contenido.StartsWith("(")) {//media vez exiten en la listaEnlazada, " ó /* es porque no se ha terminado el proceso...  si está un paréntesis, es porque se acaba de add, pues reucerda que si entra a este bloque si o sí debe hacer algo en él...
                //se mandan a llamar el método donde converge el análisis de los comentarios y cadenas...
                return analizarTipoAgrupacion(lineaDesglosada, caracterActual, numeroLinea);//aquí se devolvería el resultado como tal... sin importar si es null o no, allá en el léxico se contempla esto...
            }

            return resultadoParentesisODivsion;
        }

        private void agregarNecesitado(char[] lineaDesglosada, int caracterActual, int caracterSiguiente , int numeroLinea) {            

            String tipoDeNecesitado = herramientas.determinarTipoEncierro(lineaDesglosada[caracterActual], lineaDesglosada[caracterSiguiente]);

            switch (tipoDeNecesitado) {
                case "parentesis":
                    resultadoParentesisODivsion = new Resultado("(", "parentesis_Apertura", numeroLinea, caracterActual, caracterActual);//puede ponerse así la columna o dejar vacío este campo, ya que el siguiente paréntesis sería el fin [y por ello no tendría columna inicio...]
                    //esto realmente no debería ser así, sino que debería de estblces su final hasta que se hallara el de cierre cuando este fuera el último nodo de la lista y que el primero del cierre fuera el número de este nodo...

                    //no habrá confusión cuando se agregue el objeto resultado del 
                    //paréntesis de cierre por el hecho de que tendrá ligado el tipo, [que se encuentra en el listado de tipos 
                    //[de aquí] en el nodo que corresponde a su respectivo paréntesis de apertura... y como se tomará que el paréntesis 
                    //de cierre que se encuentre le pertenece al último de apertura, entonces cabal se obtiene la correspondencia y la excepción
                    //si es que al terminar de analizar no se encuentra dicha pareja]]

                    ultimoCaracterAnalizado = caracterActual;
                    listadoNoCerrados.anadirAlFinal("(" + "," + Convert.ToString(numeroLinea) +"," + Convert.ToString(caracterActual));//Esto será útil para las excepciones que se manejan en el cuerpo del estudio de lo que hay dentro... pero para el caso de los paréntesis, tendría que ir en otro lado o informarlo de una vez, pero esto se solucionaría si hallaras la manera en que al borrar cualquiera de os dos se borrara el otro
                    //en el método especial, después de esto estaría la add del tipo a la otra lista... de la cual los tipos primitivos irían extayendo su tipo de agrupación a partir de la obtención del contenido del último nodo...
                    listadoNoCerrados.establecerNombreNodoCreado(Convert.ToString(listadoNoCerrados.darTamanio()));//de esta manera podré hacer referencia al nodo al cual le quiero
                    //Agregar su posición final... esto sería en si método propio, en el que se estblece el respectivo signo de cierre, como en los demás y se porcede a eliminar el tipo de agrupación del listado...
                    //pero aquí habría problema por el hecho de que la lista de los resultados es solamente para la línea actual... deplano que tendrá que dejarse la lista de la fila a la que le hace falta el cierre, pero eso ya lo verás cuando andes en análisis sintáctico...
                    break;//falta establecerle su respectivo color azul y ver dónde es que se colocará el métod para los cierres, puest que habías pensado separarlos, pero debes ver si realmetne es necesario o puedes tener esa acción junto en el nloque donde se haga la asignación de su respectivo inicio...

                case "comentarioLinea"://para este y los demás el objeto resultado será generado hasta haber finalizado con el análisis
                    listadoNoCerrados.anadirAlFinal("//" + "," + Convert.ToString(numeroLinea) + "," + Convert.ToString(caracterActual));                    
                    //quite lo del nombre del nodo por el hecho de que realmente tendría que ser el tamño de la lista de RESULTADOS no esta, pues ese número lo requiero para buscar y localizar el elemento de apertura para poder así insertarle su respectivo fin...
                    break;
                
                case "comentarioMultiLinea":
                    listadoNoCerrados.anadirAlFinal("/*" + "," + Convert.ToString(numeroLinea) + "," + Convert.ToString(caracterActual));//esto será útil para cuando se haya hallado el cierre, pues de manera fácil se podrá establecer los valores de RESULTADO...               
                    break;

                case "comilla":
                    listadoNoCerrados.anadirAlFinal(Convert.ToString((int)34) + "," + Convert.ToString(numeroLinea) + "," + Convert.ToString(caracterActual));
                    break;

                default://Sería el caso de la división, porque no puede existir ningún otro tipo de excepción
                    resultadoParentesisODivsion = new Resultado("/", "division", numeroLinea, caracterActual, caracterActual);//pero aún no seá útil...
                    //se manda a llamar de una vez el método para colorear... o se retornará el tipo, para al final saber de que color... no, de una vez
                    break;
            }//hasta que sea necesario se considerará el proceso con el tipo de resultado... mmm creo que el dilema de como haberle para enviar el obj Resultado si requiero tambipen devovler elnúmero de línea se resulve en el método que llama a este, puesto que haya se manda a llamar a los métodos para aeguir con el análisis entonces allá debería ser donde se envíe al exterior el número con el que debe continuar el for y aquí se haga la única add al listado de resultado.. pero ese istado no está aquí... bueno eso lo verás después...            

        }

        private Resultado analizarTipoAgrupacion(char[] lineaDesglosada, int caracterInicial, int numeroLinea) { //obvidamente aquí no se incluye a los paréntesis puesto que ni siquiera son tomados en cuenta para poder acceder a este método, esto por el if exterior...
            String[] tipoAnalisis = listadoNoCerrados.darContenidoUltimoNodo().Split(',');//como ya se agrego el caracter especial a la lista, entonces puede procederse libremente a analizar de esta manera...

            if (tipoAnalisis[0].Equals("\"")) {
                return establecerCadena(numeroLinea, lineaDesglosada, caracterInicial);
            }

            if (tipoAnalisis[0].Equals("//")) {
                return establecerComentarioLinea(lineaDesglosada, caracterInicial);
            }
            if (tipoAnalisis[0].Equals("/*")) {
                return establecerComentarioMultiLinea(numeroLinea, lineaDesglosada, caracterInicial);
            }

            return null;//pero nunca llegará aquí puesto que en la lista no se guarda nada más que estos caracteres incluidos los parentesis, pero como al ser estos los que se encuentren al final, se evita este método, entonces NO PROBLEM! Xd
        }

        private Resultado establecerCadena(int linea, char[] lineaDesglosada, int caracterInicial) {//Asumo que este valor empieza desde 0... de todos modos puedes revisarlo fácilmente por el hecho de que es mandado por el for general...
            Resultado resultado;
            String mensajeError = "Hace falta una \" de cierrre";

            for (int caracterActual = caracterInicial; caracterActual< lineaDesglosada.Length; caracterActual++) {
                //se manda a llamar el método para colorear

                if (lineaDesglosada[caracterActual].Equals("\"")) {

                    //auí se establece en RESULTADO de una vez el espacio para el de apertura y cierre, puesto que no puede haber ninguna otra clasificación en medio de ellos... y ya se tienen todos los datos a partir de 
                    //la lista de necesaitados de cierre y se completa al obtner la columnaFin aquí... recuerda que la pareja tendrá la misma col de ini y fin, para que se hagan "referencia" a sí mismas... aunque por el hecho de que 
                    //aquí no se encuentra el listado de los resultados de la fila, entonces no tendrás que retornar en ninguno de estos métods individuales el int puro sino el arreglo que contenga dicho número y además de ello el signo de fin
                    //para que así en el método de donde se add a la lista y se manda a llamar la método donde convergen todos estos indiv se cree el obj resultado, puesto que ya tiene los datos completos, solo que habría que mandar el obj resuktado de forma directa y el número de línea se obtendría por medio de un método... que acceder´´ia a la var global...

                    String[] datosNecistadoCerrado = listadoNoCerrados.darUltimoNodo().contenido.Split(',');
                    //se elimina el nodo que corresponde a este símbolo en el listado de espera de cierre...
                    listadoNoCerrados.eliminarUltimoNodo();

                    ultimoCaracterAnalizado = caracterActual;                    

                    return resultado = new Resultado(datosNecistadoCerrado[0], "cadena", Convert.ToInt32(datosNecistadoCerrado[1]), Convert.ToInt32(datosNecistadoCerrado[2]), caracterActual);                                        
                }
            }

            //se manda a llamar el método para mostrar el error, puesto que si llegó aquí es porque no encontró la pareja de la comilla...ni siquiera en el últim espacio del arreglo...
            excepcionLexico.excepcionNecesitadoCierre(linea, mensajeError);

            ultimoCaracterAnalizado = (lineaDesglosada.Length - 1);//eso quiere decir que allá en el analizador léxico deberé sumarle 1 para ubicarme en la pos siguiente... que toca estudiar...

            return null;//por esta razón tendría que ponerse un if, para que no add cuando sea nulo...
        }

        private Resultado establecerComentarioLinea(char[] lineaDesglosada, int caracterInicial) {//realmente este no puede generar ningún tipo de excepción... ya que solo debe colorear hasta que llegue al último caracter... y por ello no importar todo lo que dentro de su dominio, esté...
            Resultado resultado;

            for (int caracterActual = caracterInicial; caracterActual < lineaDesglosada.Length; caracterActual++)
            { 
                //se manda a llamar el método para colorear
            }

            String[] datosNecistadoCerrado = listadoNoCerrados.darUltimoNodo().contenido.Split(',');
            //se elimina el nodo que corresponde a este símbolo en el listado de espera de cierre...
            listadoNoCerrados.eliminarUltimoNodo();

            ultimoCaracterAnalizado = (lineaDesglosada.Length - 1);
            return resultado = new Resultado(datosNecistadoCerrado[0], "comentarioLinea", Convert.ToInt32(datosNecistadoCerrado[1]), Convert.ToInt32(datosNecistadoCerrado[2]), caracterActual);            
        }

        private Resultado establecerComentarioMultiLinea(int linea, char[] lineaDesglosada, int caracterInicial)
        {
            String mensajeError = "No se ha cerrado el comentario multiLinea, ingresa */ para hacerlo\n";
            Resultado resultado;

            for (int caracterActual = caracterInicial; caracterActual < lineaDesglosada.Length; caracterActual++) {
                //Se manda a llamar el método para colorear

                if (lineaDesglosada[caracterActual].Equals("*/")) {
                    String[] datosNecistadoCerrado = listadoNoCerrados.darUltimoNodo().contenido.Split(',');

                    //se elimina el nodo que corresponde a este símbolo en el listado de espera de cierre...
                    listadoNoCerrados.eliminarUltimoNodo();

                    ultimoCaracterAnalizado = caracterActual;
                    return resultado = new Resultado(datosNecistadoCerrado[0], "cadena", Convert.ToInt32(datosNecistadoCerrado[1]), Convert.ToInt32(datosNecistadoCerrado[2]), caracterActual);
                }
                
            }

            //llamo el método para mostrar la excepcion debida a no hallar el símbolo de cierre en la línea donde se aperturó
            excepcionLexico.excepcionNecesitadoCierre(linea, mensajeError);

            ultimoCaracterAnalizado = (lineaDesglosada.Length - 1);
            return null;
        }

        public bool hayQueAnalizarPrimitivos()
        {
            if (listadoNoCerrados.estaVacia() || listadoNoCerrados.darContenidoUltimoNodo().Equals('(')){
                return true;
            }

            return false;
        }

        public ListaEnlazada<String> darListaEsperaCierre()
        {
            return listadoNoCerrados;
        }

        public ListaEnlazada<String> darListaTipoAgrupaciones()
        {
            return listadoTipoAgrupaciones;
        }      

        public int darUltimaLineaAnalizada() {
            return ultimoCaracterAnalizado;
        }              

    }
}
