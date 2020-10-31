using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_IDE.Automatas;
using proyecto_IDE.Complementos_analizadores;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Complementos_analizadores.Sintactico.Elementos;
using proyecto_IDE.Excepciones;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Analizadores
{
    class AnalizadorSintactico
    {
        Transicion transicion;
        Buscador buscador;
        AutomataDePila automataPilas;//xD
        ListaEnlazada<Token> listaEnlazadaToken;
        ExcepcionSintactico excepcionSintactico = new ExcepcionSintactico();
        Kit herramientas;

        int tokenPorDar = 1;//por esto, la variable finalizará en un valor 2 pasos más allá del tamaño de la lista xD

        public AnalizadorSintactico(ListaEnlazada<Token> listaTokenResultado, Kit herramienta) {
            transicion = new Transicion();
            buscador = new Buscador();//Esto serpa empleado hasta el semiSemán
            automataPilas = new AutomataDePila();
            herramientas = herramienta;
            automataPilas.establecerObjetoExcepcion(excepcionSintactico);
            listaEnlazadaToken = listaTokenResultado;
        }

        public Token darTokenSiguiente() { //se lo hará al léx y el pedido de producciones a la TTS en transicion xD dobi XD
            Nodo<Token> nodoAuxiliar = listaEnlazadaToken.darPrimerNodo();

            if (tokenPorDar <= (listaEnlazadaToken.darTamanio()))
            {
                for (int numeroToken = 1; numeroToken < tokenPorDar; numeroToken++)
                {                    
                        nodoAuxiliar = nodoAuxiliar.nodoSiguiente;                        
                }
            }
            else {
                herramientas.mostrarError(excepcionSintactico.darListadoErrores());
            }//pues ya terminó su trabajo el sintáctico xD                     

            tokenPorDar++;           
            return nodoAuxiliar.contenido;
        }

        public void analizarCodigo() {//Aquí convergerá todos los métodos para realizar el análisis
            Token tokenSolicitado= darTokenSiguiente();//para que pueda ubicarse en el token inicial y así iniciar el análisis a partir de él...
            
            while (!automataPilas.darPila().esVacia() || (tokenPorDar <= listaEnlazadaToken.darTamanio())) {//realmente esto no sucederá por el la resiliencia... [reposición ante los errores], es decir que                                                                                            
                //todos los errores se tratarán dentro de este método y no más xD y por ello bastaría con decir que el indice halla sobrepasado el tamaño ó que la pila esté vacía para parar...
                if (automataPilas.esTerminal(automataPilas.darPila().inspeccionarTope().darTipo()))
                {
                    //if (tokenSolicitado.darToken().Equals(automataPilas.darPila().inspeccionarTope().darContenido()))
                    //{
                    if (!automataPilas.reducir(tokenSolicitado.darClasificacion(), tokenSolicitado.darFilaUbicacionInicio()))
                    {
                        tokenSolicitado =  pasarTokens(tokenSolicitado);
                    }
                    else {
                        tokenSolicitado= darTokenSiguiente();//pues solo al coincidir los tokens debería pasar con normalidad al siguiente token...
                    }
                    //} lo comenté por si acaso decides tratar los errores acá..
                }
                else {
                    ListaEnlazada<Elemento> listaElementos = transicion.darProduccion(automataPilas.buscarEstado(automataPilas.darPila().inspeccionarTope().darContenido()), automataPilas.buscarTerminal(tokenSolicitado.darClasificacion()));

                    if (listaElementos != null)
                    {
                        automataPilas.reemplazar(listaElementos);
                    }
                    else {
                        pasarTokens(tokenSolicitado);
                        automataPilas.eludirExcepcion();//se ignoran los elementos y se elemina el estado general de la lista, para así trabajr con quine corresponde xD
                        excepcionSintactico.reaccionarAnteProduccionNoExistente(automataPilas.darPila().inspeccionarTope().darTipo(), tokenSolicitado.darFilaUbicacionInicio());
                    }                    
                }
            }//no creo que se pueda crear un bucle infinito xD
        }//y ahí está xd ya hace las trancisiones... lo único que debe hacer es devolver una excepción si es que sucedió, sino no mostrará nada nadín nadita xD     

        public Token pasarTokens(Token tokenSolicitado) {
            Token tokenAnterior;

            do
            {
                tokenAnterior = tokenSolicitado;
                tokenSolicitado = darTokenSiguiente();//imagino que como estoy trabajndo por referencia entonces el valor del token de allá afuera cambiará.. sino entonces haz que este método devuelva el token y ya xd
            } while (tokenPorDar < listaEnlazadaToken.darTamanio() && (!tokenAnterior.Equals("}") || !tokenAnterior.Equals(";") || !tokenAnterior.Equals("{")));
            return tokenSolicitado;
        }
        
        public String[] darSugerencias(String porcion) {            
            ListaEnlazada<String> listadoCoincidentes = buscador.hallarCoincidentes(porcion);
            String[] coincidencias = new String[listadoCoincidentes.darTamanio()];
            Nodo<String> nodoAuxiliar = listadoCoincidentes.darPrimerNodo();

            for (int resultado = 1; resultado < listadoCoincidentes.darTamanio(); resultado++) {
                coincidencias[resultado - 1] = nodoAuxiliar.contenido;

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }
            return coincidencias;//de esta forma no habrá problemas puesto que si la listaEnlazada no tiene tamaño, entonces esto no se exe... xD :) :3
        }


    }
}
