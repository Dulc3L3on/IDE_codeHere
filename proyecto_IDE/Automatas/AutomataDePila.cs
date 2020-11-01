using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Complementos_analizadores.Sintactico.Elementos;
using proyecto_IDE.Complementos_analizadores.Sintactico.Estados;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;
using proyecto_IDE.Excepciones;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Automatas
{
    class AutomataDePila
    {
        //Aquí la llamada a la pila xD
        Pila<Elemento> pila;
        Elemento noTerminalInicial = new Elemento();
        Elemento marcaDeFin = new Elemento();
        ListaEnlazada<String> listaNoTerminalesGeneralesEnEstudio = new ListaEnlazada<String>();//Esta será útil para almacenar solo aquellos NT generales, de tal forma que cuando exista un error, se ignore toda la estructura que estaba implicada con este y pueda proseguirse con lo que falta... se alamacenará el nombre y la pos en el arreglo que estará fija mientras no se haya "consumido" todos los elementos "desplegados"
        int indiceTerminalActual;//Estos eran para hacer el trato de los 2 tipos de excepciones [extra y faltante]
        int indiceNTActual;
        ExcepcionSintactico excepcionSintactico;

        NoTerminal[] noTerminales = {new M(), new B(false), new B_(), new C(), new D(), new Y(), new A(), new I(), new X(), new T(), new U(), new X_(), new T_(), new S(), new L(), new E(), new E_(), new O(), new O_(), new N(), new Q(), new Z(), new K(), new H(), new G(), new V(), new F(), new F_(), new W(), new R()};//no será funcional, puesto que no se considerará la exe...si se considerara, tendría que hallarse la forma de que cada vez que se llegase a B, se agregara un bloque al NT por el cual se ll´gó ahí... pero creo que para eso habría que hacerlo desde el NT enviador... xd
        //NoTerminal[] noTerminales = new NoTerminal[29];
        //NoTerminal[0] = new M();

        String[] terminales = {"Reservada_principal", "inicio_Bloque", "tipo", "var", "valor", "signo_mas",
            "signo_menos", "signo_multiplicacion", "signo_division", "asignacion_igualA", "parentesis_Apertura", "parentesis_Cierre",
            "negacion", "asignacion_fin", "coma", "comparacion","Estructural_HACER", "Estructural_DESDE",//sino habrá AMBIGUEDAD por la palabra lógico de simbolo lógico xD
            "Estructural_MIENTRAS", "Estructural_INCREMENTO", "Estructural_SI", "Estructural_SINO", "Estructural_SINO_SI", "logico", "imprimir", "leer", "fin_Bloque", "fin" };
        //Eso de var número aú no lo puedo corroboara, cre que deberá irse, sino tendrás que hacer un montón... y como no debes exe :) xD

        public AutomataDePila() {
            marcaDeFin.crearTerminal("fin");//puesto que aquí se guarda el tipo que le corresponde según el análisis léxico...
            noTerminalInicial.crearNoTerminal("M");

            Elemento[] elementosIniciales = new Elemento[2];
            elementosIniciales[0] = marcaDeFin;
            elementosIniciales[1] = noTerminalInicial;

            pila = new Pila<Elemento>(elementosIniciales);               
        }

        public int buscarEstado(String estado)
        {
            for (int estadoActual = 0; estadoActual < noTerminales.Length; estadoActual++)
            {
                if (noTerminales[estadoActual].darNombre().Equals(estado))
                {
                    indiceNTActual = estadoActual;
                    if (noTerminales[estadoActual].darGeneralidad()) {                        
                        listaNoTerminalesGeneralesEnEstudio.anadirAlFinal(noTerminales[estadoActual].darNombreCompleto());
                        listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().establecerNombre(Convert.ToString(pila.darIndiceTope()));
                    }                    
                    return estadoActual;
                }
            }
            return 0;//pero nunca llegará acá puesto que los estados los ingresé yo y por la inclusión de los T, hice una excepción y por ello está asegurado que no habrá errores xD
        }

        public int buscarTerminal(String terminal, String tokenSiguiente)
        {
            for (int terminalActual = 0; terminalActual < terminales.Length; terminalActual++)
            {
                if (terminales[terminalActual].Equals(terminal))//ya no es necesario el método de dar parte de IMPORTANCIA,porque ahora lo hace el analizador sintáctico xD
                {
                    indiceTerminalActual = terminalActual;
                    return darOpcionCorrespondiente(tokenSiguiente);                    
                }
            }
            return 0;
        }

        private int darOpcionCorrespondiente(String tokenSiguiente)
        { //será llamado en la parte del parámetro del token de "darProduccion" para obtener la correspondiente debido a los caminos alternos...
            if ((indiceTerminalActual==3 && tokenSiguiente.Equals("=")))
            {
                return 28;
            }
            return indiceTerminalActual;
        }

        public bool esTerminal(String tipo)
        {
            if (tipo.Equals("Terminal"))
            {
                return true;
            }
            return false;
        }//dependiendo del resultado que devuelva este método se "reducirá" ó "reemplazará"

      
        public bool reducir(String contenidoToken, String tokenTerminal, int numeroFila) {//reduce
            String parteComparacion = tokenTerminal;//el analizador sintáctico es quien da ahora la parte de IMPORTANCIA pora resolver el problema con los valores numéricos cuando la estructura general es una operaíón o ciclo xD...

            if (tokenTerminal.Equals("e") || parteComparacion.Equals(pila.inspeccionarTope().darContenido()))
            { //y aquí el elemento del tope de la pila             
                pila.desapilar();

                if (!listaNoTerminalesGeneralesEnEstudio.estaVacia() &&  pila.darIndiceTope() == (Convert.ToInt32(listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().darNombre())-1)) {
                    listaNoTerminalesGeneralesEnEstudio.eliminarUltimoNodo();//y así se elimina correctamente el NT general cuando se han acabado todas sus producciones xD                    
                }
                return true;
            }
            //Sino pues aquí se trata el error...
            eludirExcepcion();
            excepcionSintactico.reaccionarAnteNoIgualdad(noTerminales[indiceNTActual].nombreCompleto, contenidoToken, numeroFila);                            
            return false;//devulevo esto con tal de no tener qu erecibir el analizador Sintáctico solo para hacer esto... si llegaras a necesitarlo para otra operación entonces ahí si, deplano que habrá que establecerlo, pero quizá por medio de otro método que se exe antes de llegar al for para analizar el código...
        }//no se si sea mejor manejar los errores aquí o en el sintác directamente...

        public void reemplazar(ListaEnlazada<Elemento> listaElementos) { //pop = sacar el estado anterior & shift = reemplazar por las respectivas producciones
           
            Elemento[] elementos = new Elemento[listaElementos.darTamanio()];

            Nodo<Elemento> nodoAuxiliar = listaElementos.darPrimerNodo();//Se pasan los elementos a un arreglo para que puedan ser almacenados en la pila...
            for (int elementoActual =0; elementoActual< elementos.Length; elementoActual++) {
                elementos[elementoActual] = nodoAuxiliar.contenido;
                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }

            pila.apilar(elementos); //recuerda que el método comineza a llenarla a partir del último espacio, para hacer el "pop"
        }
        //OJO la pila será la que se encargue de pasar uno a uno los elementos del arreglo que se le pasó...

        public void eludirExcepcion() { //Aplicado a los 2 tipos [caer en casilla nula, la no igualdad entre el T y el tkn recibido
            //SE llega hasta una posición antes de donde estaba el NT general, y además
            //Se ingnoran [o pasan] todos los tkns hasta llegar a un ; ó {, si es que el elemento fallido no fue }, puesto que se arruinaría [Esto se hace en el analizador sintáctico xD]
            //El proceso puesto que la estructura completa, la forma el solo...
            pasarElementos();
        }

        public void pasarElementos() {
            //Se borrarán hasta llegar a una posición antes de donde se encontraba el NT en cuestión...
            while (!listaNoTerminalesGeneralesEnEstudio.estaVacia() && pila.darIndiceTope()>= Convert.ToInt32(listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().darNombre())) {//aunque bastaría con revisar que no esté vacía porque por la forma de trabajar, se que el último nodo no podría ser null a menos que no tenga nada...
                pila.desapilar();//puesto que en esa situación, no es de mi interés revisar las producciones de los NT que estuvieran ahí presentes...
            }
            listaNoTerminalesGeneralesEnEstudio.eliminarUltimoNodo();//puesto que se sabe que se llegó a la posi antes de la que ocupaba dicho NT...
        }//tendo que agregar lo de I

        public void establecerObjetoExcepcion(ExcepcionSintactico excepcion) {
            excepcionSintactico = excepcion;
        }

        public Pila<Elemento> darPila()
        {
            return pila;
        }

        public ListaEnlazada<String> darListadoNoTerminalesEnEstudio() {
            return listaNoTerminalesGeneralesEnEstudio;
        }
    }  
}

//PROCEDIMIENTO A EXE
/*  a.- Solicitar tkn
 *  
    ->  1.- Revisar tipo elemento en el tope [puesto que por defecto se tendrá el estado inicial en la "cima"           
 *  |   1.1- Si tope es un NT
 *  |        ubicarse en la celda corresp al NT y al tkn solicitado
 *  |---     recibir producciones y reemplazar el tkn NT revisado
 *  |           1.1.1 cambiarDeToken [se cambiará al siguiente o hasta llegar a un indicador de fin, dependiendo del resultado del proceso [correcto/incorrecto]
 *  |    1.2- Si tope es un T
 *  |        comparar con el tkn recibido
 *  |---         SI son  == reducri
 *  |--?         SINO diferente -> ERROR [habrá que tratarlo]
    
*/



////usando clase peculiaridad.. desechada por mucho trabajo xD
//if (terminal.StartsWith("var") || terminal.StartsWith("valor")) {
//    if (listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().contenido.darGeneralidad()) {
//        revisarPeculiaridad(terminal);
//    }
//    else {
//        String[] partes = terminal.Split('_');
//        parteImportancia = partes[0];
//    }
//}


//public bool revisarPeculiaridad(String tokenTerminal) {
//    bool resultado = false;

//    if (listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().contenido.GetType().Equals("I") || listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().contenido.GetType().Equals("L")) { //Si no funciona entonces ahí si tendrás que asignar el nombre que le corresponde a cada NT :|
//        resultado = peculiaridad.esNumerico(tokenTerminal, terminales[indiceTerminalActual]);
//    }
//    if (listaNoTerminalesGeneralesEnEstudio.darUltimoNodo().contenido.GetType().Equals("E")) {
//        resultado = peculiaridad.esBoolean(tokenTerminal, terminales[indiceTerminalActual]);
//    }
//    //Aquí mismo se tratarían las excepciones... mejor en el método para reducir, pues de todos modos deberá tratarse como uno de los casos generales... "se han ingresado partes que no concuerdan con... y el nombre de la clase... con tal de no decir que tiene que ver con el tipo, puesto que no estoy seguira si tuve que especificarlo, pero lo hice porque el tipo es parte de la gramática del cilo, condición u operación...
//    return resultado;            
//}debido a qeu era muy trabajoso...