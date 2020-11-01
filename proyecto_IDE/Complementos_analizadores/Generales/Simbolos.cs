using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Objetos_Estudio;

namespace proyecto_IDE.Complementos_analizadores
{
    [Serializable]
    class Simbolos
    {
        private ListaEnlazada<Variable> listaIdentificadores = new ListaEnlazada<Variable>();
        private ListaEnlazada<Metodo> listaMetodos = new ListaEnlazada<Metodo>();
        private ListaEnlazada<String> listaSimbolosSimples = new ListaEnlazada<String>();
        private ListaEnlazada<String> listaSimbolosCompuestos = new ListaEnlazada<String>();

        private String[] reservadas = {"principal"};//:v xD... si porque irán las palabras con que se reconoce la clase, el método principial.. paquetes... entre otros xD
        private String[] reservadasEstructurales = { "SI", "SINO", "SINO_SI", "MIENTRAS", "HACER", "DESDE", "HASTA", "INCREMENTO" };
        private String[] reservadasFuncionales = { "imprimir", "leer" };
        private String[] reservadasTipado = { "entero", "decimal", "cadena", "booleano", "caracter" };
        private String[] reservadasBooleanas = { "verdadero", "falso"};

        public Simbolos() {
            establecerListadoSimbolosSimples();
            establecerListadoSimbolosCompuesto();
        }
        
        private void establecerListadoSimbolosSimples() {
            listaSimbolosSimples.anadirAlFinal("{");
            listaSimbolosSimples.establecerNombreNodoCreado("inicio_Bloque");
            listaSimbolosSimples.anadirAlFinal("}");
            listaSimbolosSimples.establecerNombreNodoCreado("fin_Bloque");
            listaSimbolosSimples.anadirAlFinal("(");
            listaSimbolosSimples.establecerNombreNodoCreado("parentesis_Apertura");
            listaSimbolosSimples.anadirAlFinal(")");
            listaSimbolosSimples.establecerNombreNodoCreado("parentesis_Cierre");
            listaSimbolosSimples.anadirAlFinal("+");
            listaSimbolosSimples.establecerNombreNodoCreado("signo_mas");
            listaSimbolosSimples.anadirAlFinal("-");
            listaSimbolosSimples.establecerNombreNodoCreado("signo_menos");
            listaSimbolosSimples.anadirAlFinal("*");
            listaSimbolosSimples.establecerNombreNodoCreado("signo_multiplicacion");      
            listaSimbolosSimples.anadirAlFinal("<");
            listaSimbolosSimples.establecerNombreNodoCreado("relacional_menorQue");
            listaSimbolosSimples.anadirAlFinal(">");
            listaSimbolosSimples.establecerNombreNodoCreado("relacional_mayorQue");
            listaSimbolosSimples.anadirAlFinal("!");
            listaSimbolosSimples.establecerNombreNodoCreado("logico_negacion");
            listaSimbolosSimples.anadirAlFinal("=");
            listaSimbolosSimples.establecerNombreNodoCreado("asignacion_igualA");
            listaSimbolosSimples.anadirAlFinal(";");
            listaSimbolosSimples.establecerNombreNodoCreado("asignacion_fin");
            listaSimbolosSimples.anadirAlFinal(",");
            listaSimbolosSimples.establecerNombreNodoCreado("coma");//:v xD
        }//por si acaso se complica un poquis con la enumeración...

        private void establecerListadoSimbolosCompuesto() {
            listaSimbolosCompuestos.anadirAlFinal("++");
            listaSimbolosCompuestos.establecerNombreNodoCreado("aritmetico_incremento");
            listaSimbolosCompuestos.anadirAlFinal("--");
            listaSimbolosCompuestos.establecerNombreNodoCreado("aritmetico_decremento");
            listaSimbolosCompuestos.anadirAlFinal("<=");
            listaSimbolosCompuestos.establecerNombreNodoCreado("comparacion_menorIgual");
            listaSimbolosCompuestos.anadirAlFinal(">=");
            listaSimbolosCompuestos.establecerNombreNodoCreado("comparacion_mayorIgual");
            listaSimbolosCompuestos.anadirAlFinal("==");
            listaSimbolosCompuestos.establecerNombreNodoCreado("comparacion_igualQue");
            listaSimbolosCompuestos.anadirAlFinal("!=");
            listaSimbolosCompuestos.establecerNombreNodoCreado("comparacion_diferenteQue");
            listaSimbolosCompuestos.anadirAlFinal("||");
            listaSimbolosCompuestos.establecerNombreNodoCreado("logico_O");
            listaSimbolosCompuestos.anadirAlFinal("&&");
            listaSimbolosCompuestos.establecerNombreNodoCreado("logico_Y");
        }        

        public String buscarEnPalabrasReservadas(String palabraBuscar)
        {
            String hallazgo = "";

            hallazgo = buscarEnReservadas(palabraBuscar);

            if (hallazgo.Equals("erronea"))
            {
                hallazgo = buscarEnFuncionales(palabraBuscar);

                if (hallazgo.Equals("erronea"))
                {
                    hallazgo = buscarEnEstructurales(palabraBuscar);

                    if (hallazgo.Equals("erronea"))
                    {
                        hallazgo = buscarEnTipado(palabraBuscar);

                        if (hallazgo.Equals("erronea"))
                        {
                            hallazgo = buscarEnValoresBooleanos(palabraBuscar);
                        }
                    }
                }

            }
            return hallazgo;
        }

        public String buscarEnReservadas(String aBuscar)
        {
            if (aBuscar.Equals(reservadas[0])) {
                return "Reservada_" + reservadas[0];
            }
            return "erronea";
        }

        private String buscarEnEstructurales(String palabraABuscar)
        {
            for (int palabraActual = 0; palabraActual < reservadasEstructurales.Length; palabraActual++)
            {
                if (palabraABuscar.Equals(reservadasEstructurales[palabraActual]))
                {
                    return "Estructural_" + reservadasEstructurales[palabraActual];
                }
            }
            return "erronea";
        }

        private String buscarEnFuncionales(String palabraABuscar)
        {
            for (int palabraActual = 0; palabraActual < reservadasFuncionales.Length; palabraActual++)
            {
                if (palabraABuscar.Equals(reservadasFuncionales[palabraActual]))
                {
                    return "Funcional_" + reservadasFuncionales[palabraActual];
                }
            }
            return "erronea";
        }

        private String buscarEnTipado(String palabraABuscar)
        {
            for (int palabraActual = 0; palabraActual < reservadasTipado.Length; palabraActual++)
            {
                if (palabraABuscar.Equals(reservadasTipado[palabraActual]))
                {
                    return "tipo_" + reservadasTipado[palabraActual];//Esto será útil hasta que se ensamble el analizador sintáctico
                }
            }

            return "erronea";
        }

        public String buscarEnValoresBooleanos(String palabraABuscar) {
            for (int valorActual = 0; valorActual < reservadasBooleanas.Length; valorActual++) {
                if (palabraABuscar.Equals(reservadasBooleanas[valorActual])) {
                    return "valor_booleano";//después debería agregársele _ y su valor para saber a cual de los dos se refiere
                }
            }
            return "erronea";
        }

        public ListaEnlazada<String> darListadoSimbolosSimples() {
            return listaSimbolosSimples;
        }

        public ListaEnlazada<String> darListadoSimbolosCompuestos() {
            return listaSimbolosCompuestos;
        }

        public String[] darTipos() {
            return reservadasTipado;
        }

        public String[] darBooleanos() {
            return reservadasBooleanas;
        }

        public String[] darFuncionales() {
            return reservadasFuncionales;
        }
    }
}
