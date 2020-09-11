﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores;
using proyecto_IDE.Excepciones;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Analizadores
{
    class AnalizadorLexico
    {
        String tipoAgrupacion="erronea";

        Kit herramienta;
        ExcepcionLexico excepcionLexico;
        TablaDeSimbolos tablaSimbolos = new TablaDeSimbolos();
        ControlCierre controlCierre;
        Resultado resultadosHallados;//ahí decides si será local o no, puesto que lo que realmente nec el sintác es el listado de la fila...
        ListaEnlazada<Resultado> listaResutadosDeFilaActual = new ListaEnlazada<Resultado>();//Esta será necesaria en la fase siguiente

        public AnalizadorLexico(Kit kitHerramientas) {

            herramienta = kitHerramientas;
            excepcionLexico = new ExcepcionLexico(kitHerramientas);
            controlCierre = new ControlCierre(excepcionLexico, herramienta);            
        }

        public void analizarLinea(char[] lineaDesglosada, int numeroLinea) {
            for (int caracterActual = 0; caracterActual < lineaDesglosada.Length; caracterActual++)
            {
                if (!((int)lineaDesglosada[caracterActual] == 32))
                { //Es decir es un espacio en blanco...
                    caracterActual = analizarAgrupadores(lineaDesglosada, numeroLinea, caracterActual);
                    if (controlCierre.hayQueAnalizarPrimitivos())
                    {
                        caracterActual = analizarPrimitivos(lineaDesglosada, numeroLinea, caracterActual);
                    }
                }                

            }//fin del for que se encarga de recorrer caracter por caracter la línea que recibió del área de desarrollo
        }

        private int analizarAgrupadores(char[] lineaDesglosada, int numeroLinea, int caracterActual) {
            if (herramienta.determinarTipoCaracter(lineaDesglosada[caracterActual]).Equals('c') || !controlCierre.darListaEsperaCierre().estaVacia()) {//si pues solo al inicio será necesaria la primera condi, de ahi en adelante con solo saber que no está vacía basta para entrar a este método...
                resultadosHallados = controlCierre.analizarAgrupaciones(lineaDesglosada, numeroLinea, caracterActual);
                tipoAgrupacion = controlCierre.darTipoClasificacion();
                //se manda a llamar el método para colorear... para acceder de forma más directa a los valores... auqnue si no quieres repetir puedes hacerlo por medio de la obtención de los datos desde la lista 

                if (resultadosHallados!=null) {
                    herramienta.colorearConjuntoCaracteres(tipoAgrupacion, numeroLinea, caracterActual, controlCierre.darUltimaLineaAnalizada());//se colorea :3 UwU xD
                }

                return (controlCierre.darUltimaLineaAnalizada()+1);//ajap, esto será muuuy útil, puesto que a veces podría venir elresultado como null, lo cual no tendrás que adjuntar a la lista de la línea... pero esto es ya más orientado par cuendo se add el sintáctico...

            }//fin del if que permite entrar al análisis de los que requeren cierre, ya sea para agergar y empezar el análisis O para seguir con el análisis en el que se quedó...

            return caracterActual;
        }

        private int analizarPrimitivos(char[] lineaDesglosada, int numeroLinea, int caracterActual)
        {//Aquí ya actuó el método sea que aquí mismo se encuantre o lo esté en la clase que tiene contacto directo con la interfaz...            
           
            char tipoCaracter = herramienta.determinarTipoCaracter(lineaDesglosada[caracterActual]);//por este método es que no habrán errores de ubicarse en el caracter sigueinte al último que se estudió puesto que aquí se revisa y por o tanto está bien que en los métodos principales de análisis se estudie 1 más allá...
            //recuerda que en la columnaFin de RESULTADO siempre se almacenará la col en la que terminó el análisis, es decir en la col donde se encontró el último caracter correcto respecto al patrón actual...

            switch (tipoCaracter)
            {
                case 'p'://problemas con los identificadores no habrá... por el hecho de que DEBE empezar con un caracter y por ello caerá al método que tiene como primero una letra ya después conforme se vaya desarrollando el proceso xD se decidirá si el método que debe seguir con la revisión se debe cambiar o no...
                  resultadosHallados = analizarOcurrenciaConLetras(numeroLinea, caracterActual, lineaDesglosada);
                break;

                case 'd':
                  resultadosHallados = analizarNumero(numeroLinea, caracterActual, lineaDesglosada);
                break;

                case 'o':
                    resultadosHallados= analizarDemasCaracteres(numeroLinea, caracterActual, lineaDesglosada);
                break;
                
            }//fin del switch      

            if (!tipoAgrupacion.Equals("erronea")) {//con tal de que no busque en vano xD
                herramienta.colorearConjuntoCaracteres(tipoAgrupacion, numeroLinea, caracterActual, resultadosHallados.darColumnaFin());//YA SE COLOREAN tipos primitivos xD UwU xD
            }            

            return (resultadosHallados.darColumnaFin()+1);//Pues aquí se encuentra la pos desde la cual debe entregarse, ya que es la pos+1 desde donde terminaron su trabajo los étodos individuales anteriores...

            //aquí cuando sea necesario se mandaría a añadir el resultado hallado a la respectiva lisa de resultados de la línea en la que se está analizando
            //o bien odrías ponerlo en cada uno de los switch, da lo mismo...
        }

        private Resultado analizarOcurrenciaConLetras(int numeroLinea, int inicioAnalisis, char[] lineaAEstudiar)
        {
            String[] datosHallados = new String[3];

            datosHallados = analizarPalabra(numeroLinea, inicioAnalisis, lineaAEstudiar);

            //al final se manda a llamar al método para buscar en la tabla de símbolos
            if (!datosHallados[1].Equals("erronea") && !datosHallados[1].Equals("primitiva_caracter"))
            {
                String tipo = tablaSimbolos.buscarEnPalabrasReservadas(datosHallados[2]);                

                if (!tipo.Equals("erronea")) {

                    if (tipo.Contains("Funcional"))
                    {
                        String[] tipoNuevo = tipo.Split('_');

                        tipoAgrupacion = tipoNuevo[1];//recuerda que no es nec almacenar palabra como tal por el hecho de que eso no está definido como válido, solo es una división para auxiliar la revisión...
                    }
                    else {
                        tipoAgrupacion = tipo;//reucerda que esta var es para dar color, y mientras sea erronea, se mantendrá en color blanco...
                    }                                     
                }

                datosHallados[1] = tipo;//pues debe mandarse las cosas tal y como salieron...
            }

            Resultado resultado = new Resultado(datosHallados[2], datosHallados[1], numeroLinea, inicioAnalisis, (Convert.ToInt32(datosHallados[0])-1));//por el momento no me es útil, pero aún así devolveré este elemento para que pueda ser agregado a la lista que almacena en cada nodo un objeto resultado...            
            resultado.establecerFilaFin(numeroLinea);

            return resultado;
        }//listo

        private String[] analizarPalabra(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {//recuerda que por el hecho de recibir la línea almacenada en un arr, entonces si el número que corresponda a las col será uno menos a lo ordinario, pero debes averiguar como trabaja con las col el richTextBox... para que cuando necesites hacer manipulaciones alguna vez, no surgan problemas...
            int posicionAnalisis = posicionInicialAnalisis + 1;
            String[] detallesPalabra = { "", "primitiva_caracter", Convert.ToString(lineaAEstudiar[posicionInicialAnalisis]) };//al solo tener un caracter no se entraría a la parte para                     
            bool parar = false;

            while ((int)lineaAEstudiar[posicionAnalisis] != 32 && (parar == false) && (posicionAnalisis < lineaAEstudiar.Length))
            {//Es decir mientras no halle un espacio en blanco...      para cuando ya se agregue el identificador esta condi de !palabra deberá cambiar puesto que sin importar que sea palabra o identificador, deberá parar... ahi si deberá usarse un bool, que cb de val para que ya no siga, media vez entre al if para usar el método de Excepción...
                if (posicionAnalisis == (posicionInicialAnalisis + 1))
                {
                    detallesPalabra[1] = "primitiva_palabra";
                }
                if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionAnalisis]) != 'l')
                {
                    detallesPalabra[1] = excepcionLexico.excepcionPalabra(numeroLinea, posicionAnalisis, lineaAEstudiar);
                    if (detallesPalabra[1].Equals("primitiva_palabra"))
                    {
                        parar = true;//esto por el hecho de que se clasifica como erronea al tener caracteres válidos para un identificador
                    }
                }
                if (parar == false)
                {
                    detallesPalabra[2] += lineaAEstudiar[posicionAnalisis];
                    posicionAnalisis++;//1 pos más alla de lo que se concatenó por este método, por lo cual al enviar los datos a resultado es nec restarle 1 pues no se quedó en esta col la concat, sino en la any
                }//esto desaperecerá al tener al identificador, porque independientemente de lo que se tenga se debe parar
            }

            if (detallesPalabra[2].Length==1) {
                tipoAgrupacion = "caracter";//con caracter y con comentario de una sola línea, no hay excepciones xD
            }

            detallesPalabra[0] = Convert.ToString(posicionAnalisis);//la posición es justo 1 espacio más allá de donde se quedó a analizando, lo cual es exactamente donde el for debe estar para así asginar ese espacio al método que le corresponda...
            return detallesPalabra;

        }//por el momento puesto que no se tiene que clasificar a los identificadores, mandará de una vez a la lista de Resultados el tipo de dicha palabra como erronea
        //listo

        public void analizarIdentficador()
        {
            //sería llamado en el método de análisisPalabra cuando en la palabra se encontrara con un caracter de valor != a cualquiera de las letras
            //aquí se revisaría si es uno permitido sino a erroneas se iría... esto si es que se acepta algo más que el _

        }//Esto será empleado hasta la 2da fase, creo :v xD

        public Resultado analizarNumero(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {
            String[] hallazgos = analizarEntero(numeroLinea, posicionInicialAnalisis, lineaAEstudiar);

            Resultado resultado = new Resultado(hallazgos[2], hallazgos[1], numeroLinea, posicionInicialAnalisis, (Convert.ToInt32(hallazgos[0])-1));            

            resultado.establecerFilaFin(numeroLinea);
            return resultado;//recuerda que por medio de esto se puede avanzar a partir del indice siguiente al último que terminó de analizar el método
        }//lsito

        private String[] analizarEntero(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {
            int posicionAnalisis = posicionInicialAnalisis + 1;//Si debe ser así, pue el for analizó el que le seguía al últio caracter estudiado y por ello pude entrar a este método, entonces en este y los demás de los métodos para primitivos, deben empezar por el siguiente... creo que tb debe app a los demás métodos y creo que no lo aplicaste ni a "otros" ni a los necesitadosDeCierre
            String[] detallesEntero = { "", "primitiva_entero", Convert.ToString(lineaAEstudiar[posicionInicialAnalisis]) };//al solo tener un caracter no se entraría a la parte para                     
            bool parar = false;

            while ((int)lineaAEstudiar[posicionAnalisis] != 32 && (parar == false) && (posicionAnalisis < lineaAEstudiar.Length))
            {//Es decir mientras no halle un espacio en blanco...      para cuando ya se agregue el identificador esta condi de !palabra deberá cambiar puesto que sin importar que sea palabra o identificador, deberá parar... ahi si deberá usarse un bool, que cb de val para que ya no siga, media vez entre al if para usar el método de Excepción...

                if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionAnalisis]) != 'd')
                {
                    detallesEntero[1] = excepcionLexico.excepcionNumero(numeroLinea, posicionAnalisis, lineaAEstudiar);
                    parar = true;//Es útil para cuando se encuentren carcteres diferentes al "." puesto que lo que se había analizado entraría como un entero y como la subcadena final...

                    if (detallesEntero[1].Equals("primitiva_decimal"))
                    {                       
                        return analizarDecimal(numeroLinea, posicionAnalisis, detallesEntero[2], lineaAEstudiar);//pues lo que necesita es saber donde debe comenzar a trabajar, no dónde se quedó su antecesor...
                        //Esta es la posición donde se encuentra el PUNTO
                    }

                }
                if (parar == false)
                {
                    detallesEntero[2] += lineaAEstudiar[posicionAnalisis];
                    posicionAnalisis++;//con esto sin importar que todo el conjunto estuviera bien [es decir que al llegar al espacio o fin de la cadena todos los caracteres pertenecieran al patrón] o que hubieran excepciones, siempre me quedaré en la posición que el for debe entregar es decir 1 + allá del espacio hasta donde se concatenó
                }                
            }

            detallesEntero[0] = Convert.ToString(posicionAnalisis);//1 pos más allá de lo concatenado por este método...
            tipoAgrupacion = "entero";//esto por el hecho de que al haber excepción o deja de ser entero para pasar a decimal, o sigue siendo un entero... pero no puede ser erronea media vez sigue siendo un número entero xD :v
            return detallesEntero;

        }//listo

        private String[] analizarDecimal(int numeroLinea, int posicionInicialAnalisis, String concatenadoHastaElMomento, char[] lineaAEstudiar)
        {
            int posicionAnalisis = posicionInicialAnalisis+2;//le sumo 2 por el hecho de que la posición dada corresponde al punto y la siguiente al número por el cual se permitió entrar a este método, entonces es nece analizar el sigueinte a dicho punto que se obtiene al suarle 2
            String[] detallesDecimal = { "", "primitiva_decimal", concatenadoHastaElMomento+Convert.ToString(lineaAEstudiar[posicionInicialAnalisis])+ Convert.ToString(lineaAEstudiar[posicionInicialAnalisis+1]) };//default erronea porque si no viene un número no entraría a un bloque específico y no tendría donde nombrarle de esta manera, por ello mejor cuando se encuentra que todo esta bien, catalogo respecto a ese bienestar...
            bool parar = false;

            if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionInicialAnalisis]) == 'd')
            {                           
                while ((int)lineaAEstudiar[posicionAnalisis] != 32 && (parar == false) && (posicionAnalisis < lineaAEstudiar.Length))
                {//Es decir mientras no halle un espacio en blanco...      para cuando ya se agregue el identificador esta condi de !palabra deberá cambiar puesto que sin importar que sea palabra o identificador, deberá parar... ahi si deberá usarse un bool, que cb de val para que ya no siga, media vez entre al if para usar el método de Excepción...

                    if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionAnalisis]) != 'd')
                    {
                        parar = true;
                        detallesDecimal[1] = excepcionLexico.excepcionDecimal(numeroLinea, posicionAnalisis, lineaAEstudiar);
                    }
                    if (parar == false)                    {
                        detallesDecimal[2] += lineaAEstudiar[posicionAnalisis];
                        posicionAnalisis++;//debe estar aquí porque sino estaría entregando al for 2 passo adelante hasta donde tiene concatenados los caracteres como el tipo que le corresponde al método, en este caso decimal...
                    }//esto desaperecerá al tener al identificador, porque independientemente de lo que se tenga se debe parar
                    
                }
            }

            if (detallesDecimal[1].Equals("primitiva_decimal")) {
                tipoAgrupacion = "decimal";//aquí ya no hay pierde, puesto que o es decimal porque no había nada más correspodiente o es erronea porque cuando se halló min otro núm había algo que si no debe estar
            }

            detallesDecimal[0] = Convert.ToString(posicionAnalisis);//esta es la pos que le corresponde al for dar, es decir 1 por más alla de donde se tiene clasificado como decimal en este caso...
            return detallesDecimal;
        }//listo       

       
        private String[] analizarSimbolosSimples(int numeroLinea, int posicionInicialAnalisis, int tamanioDeFila,  char caracterAEstudiar)
        {//Se mnada un arreglo por hecho de que no siempre se podrá generar un objeto resultado, pues puede que el símbolo buscado no se encuentre en el alfabeto...        
            String[] datosSimboloSimple = {Convert.ToString(posicionInicialAnalisis), "",Convert.ToString(caracterAEstudiar) };//0 -> numeroColumnaFinal, 1-> tipo, 2-> el simbolo en sí
            Nodo<String> nodoAuxiliar = tablaSimbolos.darListadoSimbolosSimples().darPrimerNodo();

            for (int simboloActual = 1; simboloActual <= tablaSimbolos.darListadoSimbolosSimples().darTamanio(); simboloActual++)
            {
                String simboloSimple = nodoAuxiliar.contenido;

                if (Convert.ToString(caracterAEstudiar).Equals(simboloSimple))
                {                                                       
                    datosSimboloSimple[1] = nodoAuxiliar.darNombre();

                    //se manda a llamar el métoodo para colorear
                    if (datosSimboloSimple[1].Equals("asignacion_igualA") || datosSimboloSimple[1].Equals("asignacion_fin"))
                    {
                        tipoAgrupacion = "finAsigacion";
                    }
                    else {
                        tipoAgrupacion = "simbolo";
                    }

                    return datosSimboloSimple;//Retorno aquí para saber que si salgo del for es porque no hallé nada...
                }

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }//fin del for que se encarga de recorrer el listado que contiene a los símbolos simples...

            //si llega aquí es un hecho que el caracter no está en el alfabeto...
            datosSimboloSimple[1]= excepcionLexico.excepcionSimbolo(numeroLinea, tamanioDeFila, datosSimboloSimple[2]);//esta es la pos donde se encontraba el caracter analizado, s decir hasta donde se concatenó... por ello si estpa bien que en el for de análisis general de todos los tipos se sume 1 pues concuerda con los primi y con los símbolos simples [tb con los comp xD]
            return datosSimboloSimple;
        }

        private String[] analizarSimbolosCompuestos(int numeroLinea, int posicionInicialAnalisis, int tamanioFila, char caracterActual, char caracterSiguiente) {
            String conjuntoEstudio = Convert.ToString(caracterActual)+Convert.ToString(caracterSiguiente);
            String[] datosSimboloCompuesto = { Convert.ToString(posicionInicialAnalisis + 1), "", conjuntoEstudio };//0 -> numeroColumnaFinal, 1-> tipo, 2-> el simbolo en sí
           
            Nodo<String> nodoAuxiliar = tablaSimbolos.darListadoSimbolosSimples().darPrimerNodo();


            for (int simboloActual = 1; simboloActual <= tablaSimbolos.darListadoSimbolosSimples().darTamanio(); simboloActual++)
            {
                String simboloCompuesto = nodoAuxiliar.contenido;

                if (conjuntoEstudio.Equals(simboloCompuesto))
                {                 
                    datosSimboloCompuesto[1] = nodoAuxiliar.darNombre();
                    tipoAgrupacion = "simbolo";//aunque sea compuesto no importa porque es el mismísimo color xD

                    return datosSimboloCompuesto;
                }

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }//fin del for que se encarga de recorrer el listado que contiene a los símbolos simples...

            //se manda a llamar al método para informar de la excepción...
            datosSimboloCompuesto[1] = excepcionLexico.excepcionSimbolo(numeroLinea, tamanioFila, conjuntoEstudio);

            return datosSimboloCompuesto;
        }

        public Resultado analizarDemasCaracteres(int numeroLinea, int posicionInicialAnalisis, char[] lineaDeEstudio)//Metod de CONVERGENCIA para los símbolos en el alfabeto
        {
            Resultado resultado;
            String[] resultadosObtenidos;

            if (herramienta.determinarTipoCaracter(lineaDeEstudio[posicionInicialAnalisis + 1]) == 'o')
            {
                resultadosObtenidos = analizarSimbolosCompuestos(numeroLinea, posicionInicialAnalisis, lineaDeEstudio.Length, lineaDeEstudio[posicionInicialAnalisis], lineaDeEstudio[posicionInicialAnalisis + 1]);                
            }
            else
            {
                resultadosObtenidos = analizarSimbolosSimples(numeroLinea, posicionInicialAnalisis, lineaDeEstudio.Length, lineaDeEstudio[posicionInicialAnalisis]);                
            }

            resultado = new Resultado(resultadosObtenidos[2], resultadosObtenidos[1], numeroLinea, posicionInicialAnalisis, Convert.ToInt32(resultadosObtenidos[0]));

            resultado.establecerFilaFin(numeroLinea);
            return resultado;
        }//listo :3 xD

    }


}
