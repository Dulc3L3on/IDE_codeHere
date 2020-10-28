using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Automatas;
using proyecto_IDE.Complementos_analizadores;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Analizadores
{
    class AnalizadorSintactico
    {
        Transicion transicion;
        Buscador buscador;
        AutomataDePila automataPilas;//xD
        ListaEnlazada<Token> listaEnlazadaToken;
        int tokenPorDar = 1;

        public AnalizadorSintactico(ListaEnlazada<Token> listaTokenResultado) {
            transicion = new Transicion();
            buscador = new Buscador();//Esto serpa empleado hasta el semiSemán
            automataPilas = new AutomataDePila();
            listaEnlazadaToken = listaTokenResultado;
        }

        public Token darTokenSiguiente() { //se lo hará al léx y el pedido de producciones a la TTS en transicion xD dobi XD
            Nodo<Token> nodoAuxiliar = listaEnlazadaToken.darPrimerNodo();

            for (int numeroToken=1; numeroToken <= listaEnlazadaToken.darTamanio(); numeroToken++) {
                if (numeroToken< tokenPorDar) {
                    nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
                }                
            }
            tokenPorDar++;
            return nodoAuxiliar.contenido;
        }

        public void analizarCodigo() {//Aquí convergerá todos los métodos para realizar el análisis
            Token tokenSolicitado;
            
            while (!automataPilas.darPila().esVacia() || (tokenPorDar <= listaEnlazadaToken.darTamanio())) {//realmente esto no sucederá por el la resiliencia... [reposición ante los errores], es decir que                                                                                                        
                tokenSolicitado = darTokenSiguiente();                                                      //todos los errores se tratarán dentro de este método y no más xD y por ello bastaría con decir que el indice halla sobrepasado el tamaño ó que la pila esté vacía para parar...
                if (automataPilas.esTerminal(automataPilas.darPila().inspeccionarTope().darTipo()))
                {
                    //if (tokenSolicitado.darToken().Equals(automataPilas.darPila().inspeccionarTope().darContenido()))
                    //{
                        automataPilas.reducir(tokenSolicitado.darToken());
                    //} lo comenté por si acaso decides tratar los errores acá..
                }
                else {
                    automataPilas.reemplazar(transicion.darProduccion(automataPilas.buscarEstado(automataPilas.darPila().inspeccionarTope().darTipo()), automataPilas.buscarTerminal(tokenSolicitado.darToken())));                    
                }
            }//no creo que se pueda crear un bucle infinito xD
        }//y ahí está xd ya hace las trancisiones... lo único que debe hacer es devolver una excepción si es que sucedió, sino no mostrará nada nadín nadita xD     
        
        
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
