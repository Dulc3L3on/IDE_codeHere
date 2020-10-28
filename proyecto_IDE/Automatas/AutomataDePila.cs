using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Complementos_analizadores.Sintactico.Elementos;
using proyecto_IDE.Complementos_analizadores.Sintactico.Estados;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Automatas
{
    class AutomataDePila
    {
        //Aquí la llamada a la pila xD
        Pila<Elemento> pila;
        Elemento noTerminalInicial = new Elemento();
        Elemento marcaDeFin = new Elemento();

        M principal; L ciclo;
        B bloque; E estructuraCondicional;
        B_ bloquePrima; E_ estructuraPrima;
        C cuerpo; O condicional;
        D declaracion; O_ condicionalPrima;
        Y igualacion; N condicion;
        A asignacion; Z cuerpoCondicion;
        I operacion; H iteracionNegacion;
        X sumaResta; G negacion;
        T multiplicaionDivision; V tipoValor;
        U menosUnario; F concatenacion;
        X_ sumaRestaPrima; F_ concatenacionPrima;
        T_ multiplicaionDivisionPrima; W impresion;
        S estado; R lectura;
        J numerico;//no se si las vaya a emplear... según lo que recuerdo iba a hcerlos igual a la posición correspondiene del arr, pero por lo que veo ahora... no tendría utilidad...        

        String[] noTerminalesPorRecorrer = {"M","B", "B'", "C", "D", "Y", "A", "I", "X", "T", "U", "X'", "T'", "S",
            "J", "L", "E", "E'", "O", "O'", "N", "Z", "H", "G", "V", "F", "F'", "W", "R"};
        String[] terminales = {"Estructura_principal", "inicio_Bloque", "tipo", "booleano", "var", "valor", "signo_mas",
            "signo_menos", "signo_multiplicacion", "signo_division", "asignacion_igualA", "parentesis_Apertura", "parentesis_Cierre",
            "logico_negacion", "asignacion_fin", "coma", "comparacion", "var_numero", "valor_numero", "Funcional_HACER", "Funcional_DESDE",
            "Funcional_MIENTRAS", "Funcional_INCREMENTO", "Funcional_SI", "Funcional_SINO", "Funcional_SINO_SI", "logico", "imprimir", "leer", "fin_Bloque" };
        //Eso de var número aú no lo puedo corroboara, cre que deberá irse, sino tendrás que hacer un montón... y como no debes exe :) xD

        public AutomataDePila() {
            marcaDeFin.crearTerminal("$");
            noTerminalInicial.crearNoTerminal("M");

            Elemento[] elementosIniciales = new Elemento[2];
            elementosIniciales[0] = marcaDeFin;
            elementosIniciales[1] = noTerminalInicial;

            pila = new Pila<Elemento>(elementosIniciales);               
        }

        public int buscarEstado(String estado)
        {
            for (int estadoActual = 0; estadoActual < noTerminalesPorRecorrer.Length; estadoActual++)
            {
                if (noTerminalesPorRecorrer[estadoActual].Equals(estado))
                {
                    return estadoActual;
                }
            }
            return 0;//pero nunca llegará acá puesto que los estados los ingresé yo y por la inclusión de los T, hice una excepción y por ello está asegurado que no habrá errores xD
        }

        public int buscarTerminal(String terminal)
        {
            for (int terminalActual = 0; terminalActual < terminales.Length; terminalActual++)
            {
                if (terminales[terminalActual].Equals(terminal))
                {
                    return terminalActual;
                }
            }
            return 0;
        }

        public bool esTerminal(String tipo)
        {
            if (tipo.Equals("Terminal"))
            {
                return true;
            }
            return false;
        }//dependiendo del resultado que devuelva este método se "reducirá" ó "reemplazará"

        public void reducir(String terminal) {//reduce
            if (terminal.Equals("e") || terminal.Equals(pila.inspeccionarTope().darContenido())) { //y aquí el elemento del tope de la pila             
                pila.desapilar();
            }            

            //Sino pues aquí se trata el error...
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

        public Pila<Elemento> darPila()
        {
            return pila;
        }
    }  
}

//PROCEDIMIENTO A EXE
/*  ->  a.- Solicitar tkn
    |  1.- Revisar tipo elemento en el tope [puesto que por defecto se tendrá el estado inicial en la "cima"           
 *  |   1.1- Si tope es un NT
 *  |        ubicarse en la celda corresp al NT y al tkn solicitado
 *  |---     recibir producciones y reemplazar el tkn NT revisado
 *  |    1.2- Si tope es un T
 *  |        comparar con el tkn recibido
 *  |---         SI son  == reducri
 *  |--?         SINO diferente -> ERROR [habrá que tratarlo]
    
*/
