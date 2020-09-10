using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Complementos_analizadores
{
    class ControlCierre//estaa clase será empleada para llevar el control xD de aquellos elementos que requieren de su compañero para ser cerrados y pasar a otro análisis
                      //entre los participantes se tiene a la cadena, el comentario y a los paréntesis, pero no del todo por el hecho de que aún no clasifico su agrupación interna
                      //como debe, sino que solo verifico que esté debidamente cerrado...
    {
     
        ListaEnlazada<String> listadoNoCerrados = new ListaEnlazada<String>();//este listado será el que contenga a los signos con su respectiva columna de inicio que aún no han encontrado a su cierre, solo serán add los elementos cuando se llegue al tamaño de la linea y áún no se haya encontrado a dicho símbolo de cierre...
        //el último que aparezca en la lista es a quien le pertenece la agrupación finalizada al hallar el signo de cierre...
        
        ListaEnlazada<String> listadoTipoAgrupaciones = new ListaEnlazada<String>();//en este listado se irán guanrdando los tipos de agrupaciones que pertenecerán al paréntesis abierto más reciente
        //[es decir el más adentrado], claro, teniendo en cuenta el hecho de que media ve aparezcan " o cualquier tipo de comentario, me importará un comino lo que venga... 
        //esto indica que tendrá que los paréntesis tendrán un método propio para asignar, puesto que el tipo lo darán según.. el contexto? mmm eso ya me suena a sintáctico o más bien trabajo semántico...
        Kit herramientas = new Kit();
        

        bool continuaClasificando = false;//Esto será empleado para saber si la siguiente línea que se recibe del rich, debe seguirse analizando como uno de estos o no...

        public void clasificarCadena(char caracter) { //para este caso, la siguiente comilla luego de haber establecedio con apertura = true será tomada como la de cierre
            


        }

        public void clasificarAgrupacion() {//debido a la anidación, el primer parentesis de cierre que se halle será tomado como el cierre del último de apertura registrado y así hasta llegar al más externo... si es qu elo hay xD
        
        }

        public void calsificarComentarioMultiLinea() {//no puede ser anidado, por ello al encontrar la debida combinacion de cierre se terminará de clasificar con este tipo todo lo que encuentre...
        
        }

        public void clasificarComentarioLinea() {//uego de encontrar la doble barra todo lo que exista hasta el final de la línea será clasificado como coment de una línea...
        
        }

        public ListaEnlazada<String> darListaEsperaCierre()
        {
            return listadoNoCerrados;
        }

        public ListaEnlazada<String> darListaTipoAgrupaciones()
        {
            return listadoTipoAgrupaciones;
        }

        public bool hayQueAnalizarPrimitivos() {
            if (listadoNoCerrados.estaVacia() || listadoNoCerrados.darContenidoUltimoNodo().Equals('(')) {
                return true;
            }

            return false;
        }

        public int analizarAgrupaciones(char[] lineaDesglosada,int numeroLinea, int caracterActual) {
            //Resultado resultado;

            if (listadoNoCerrados.estaVacia() || (listadoNoCerrados.darContenidoUltimoNodo().Equals('(') && herramientas.determinarTipoCaracter(lineaDesglosada[caracterActual]).Equals('c'))) {
                 agregarNecesitado(lineaDesglosada, caracterActual, caracterActual+1, numeroLinea);
            }//fin del if donde se establecen los caracteres iniciales... es necesario hacer esto ya que así no hbrá confusión, al averiguar en el caso de las " y comentarios si se debe colocar o no este signo a la ista...

            if (!listadoNoCerrados.darUltimoNodo().contenido.StartsWith("(")) {//media vez exiten en la listaEnlazada, " ó /* es porque no se ha terminado el proceso...  si está un paréntesis, es porque se acaba de add, pues reucerda que si entra a este bloque si o sí debe hacer algo en él...
                //se mandan a llamar el método donde converge el análisis de los comentarios y cadenas...
                return analizarTipoAgrupacion(lineaDesglosada, numeroLinea, caracterActual);
            }

            return caracterActual++;
        }

        private void agregarNecesitado(char[] lineaDesglosada, int caracterActual, int caracterSiguiente , int numeroLinea) {
            Resultado resultado;

            String tipoDeNecesitado = herramientas.determinarTipoEncierro(lineaDesglosada[caracterActual], lineaDesglosada[caracterSiguiente]);

            switch (tipoDeNecesitado) {
                case "parentesis":                
                    //resultado = new Resultado("(", "parentesis_Apertura", numeroLinea, caracterActual, caracterActual);//puede ponerse así la columna o dejar vacío este campo, ya que el siguiente paréntesis sería el fin [y por ello no tendría columna inicio...]
                                                                                                          //esto realmente no debería ser así, sino que debería de estblces su final hasta que se hallara el de cierre cuando este fuera el último nodo de la lista y que el primero del cierre fuera el número de este nodo...

                    //no habrá confusión cuando se agregue el objeto resultado del 
                    //paréntesis de cierre por el hecho de que tendrá ligado el tipo, [que se encuentra en el listado de tipos 
                    //[de aquí] en el nodo que corresponde a su respectivo paréntesis de apertura... y como se tomará que el paréntesis 
                    //de cierre que se encuentre le pertenece al último de apertura, entonces cabal se obtiene la correspondencia y la excepción
                    //si es que al terminar de analizar no se encuentra dicha pareja]]

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
                    listadoNoCerrados.anadirAlFinal("/*" + "," + Convert.ToString(numeroLinea) + "," + Convert.ToString(caracterActual));                    
                    break;

                case "comilla":
                    listadoNoCerrados.anadirAlFinal(Convert.ToString((int)34) + "," + Convert.ToString(numeroLinea) + "," + Convert.ToString(caracterActual));
                    break;

                default://Sería el caso de la división, porque no puede existir ningún otro tipo de excepción
                    resultado = new Resultado("/", "parentesis_Apertura", numeroLinea, caracterActual, caracterActual);//pero aún no seá útil...
                    //se manda a llamar de una vez el método para colorear... o se retornará el tipo, para al final saber de que color... no, de una vez
                    break;
            }//hasta que sea necesario se considerará el proceso con el tipo de resultado... mmm creo que el dilema de como haberle para enviar el obj Resultado si requiero tambipen devovler elnúmero de línea se resulve en el método que llama a este, puesto que haya se manda a llamar a los métodos para aeguir con el análisis entonces allá debería ser donde se envíe al exterior el número con el que debe continuar el for y aquí se haga la única add al listado de resultado.. pero ese istado no está aquí... bueno eso lo verás después...            

        }

        private int analizarTipoAgrupacion(char[] lineaDesglosada, int caracterInicial, int numeroLinea) { //obvidamente aquí no se incluye a los paréntesis puesto que ni siquiera son tomados en cuenta para poder acceder a este método, esto por el if exterior...
            String[] tipoAnalisis = listadoNoCerrados.darContenidoUltimoNodo().Split(",");//como ya se agrego el caracter especial a la lista, entonces puede procederse libremente a analizar de esta manera...

            if (tipoAnalisis[0].Equals("\"")) {
                return establecerComentarioLinea(lineaDesglosada, caracterInicial);
            }

            if (tipoAnalisis[0].Equals("//") {
                return establecerComentarioLinea(lineaDesglosada, caracterInicial);
            }
            if (tipoAnalisis[0].Equals("/*") {
                return establecerComentarioMultiLinea(lineaDesglosada, caracterInicial);
            }

            return 0;//pero nunca llegará aquí puesto que en la lista no se guarda nada más que estos caracteres incluidos los parentesis, pero como al ser estos los que se encuentren al final, se evita este método, entonces NO PROBLEM! Xd
        }

        private int establecerCadena(char[] lineaDesglosada, int caracterInicial) {//Asumo que este valor empieza desde 0... de todos modos puedes revisarlo fácilmente por el hecho de que es mandado por el for general...
            for (int caracterActual = caracterInicial; caracterActual< lineaDesglosada.Length; caracterActual++) {
                //se manda a llamar el método para colorear

                if (lineaDesglosada[caracterActual].Equals("\"")) {
                    return caracterActual;
                }

            }

            //se manda a llamar el método para mostrar el error, puesto que si llegó aquí es porque no encontró la pareja de la comilla...
            return (lineaDesglosada.Length - 1);
        }

        private int establecerComentarioLinea(char[] lineaDesglosada, int caracterInicial) {//realmente este no puede generar ningún tipo de excepción... ya que solo debe colorear hasta que llegue al último caracter... y por ello no importar todo lo que dentro de su dominio, esté...
            for (int caracterActual = caracterInicial; caracterActual < lineaDesglosada.Length; caracterActual++)
            { 
                //se manda a llamar el método para colorear
            }

            return (lineaDesglosada.Length-1);
        }

        private int establecerComentarioMultiLinea(char[] lineaDesglosada, int caracterInicial)
        {
            for (int caracterActual = caracterInicial; caracterActual < lineaDesglosada.Length; caracterActual++) {
                //Se manda a llamar el método para colorear

                if (lineaDesglosada[caracterActual].Equals("*/")) {
                    return caracterActual;
                }
                
            }

            //llamo el método para mostrar la excepcion debida a no hallar el símbolo de cierre en la línea donde se aperturó
            return (lineaDesglosada.Length - 1);
        }
              

    }
}
