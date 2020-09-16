using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Objetos_Estudio;

namespace proyecto_IDE.Complementos_analizadores
{
    class TablaDeSimbolos
    {
        private ListaEnlazada<Variable> listaIdentificadores = new ListaEnlazada<Variable>();
        private ListaEnlazada<Metodo> listaMetodos = new ListaEnlazada<Metodo>();
        private ListaEnlazada<String> listaSimbolosSimples = new ListaEnlazada<String>();
        private ListaEnlazada<String> listaSimbolosCompuestos = new ListaEnlazada<String>();

        //estos valores ya definidos podría trabajarlos de 2 maneras: por medio de arreglos y por medio de enueraciones, para el primer caso, almacenaría al valor como tal y en el 2do a su valor numérico correspondiente al respectivo código ascii...
        //private char[] operadoresAritmeticos = { '' };//por el momento aún no he definido si se tendrá un arreglo o enum y si habrá uno por cada una de las clasificaicones que pueden almacenar o habrá solo 1 donde no haya más de 1 mismo término en una misma agrupación... pero pensándolo bien, creo que sería mejor separarlas por el hecho de que aunque sean repetidas represntar un tipo de clasificación diferente, aunque ahora creo que esto encaja bastante con la forma en que trabajaste anteriormente el analizador ya qie no estaría redundando en los caracteres, pero eso sí podría llevarte más tiempectio la pensada...

        private String[] reservadasFuncionales = { "SI", "SINO", "SINO_SI", "MIENTRAS", "HACER", "DESDE", "HASTA", "INCREMENTO" };
        private String[] reservadasTipado = { "entero", "decimal", "cadena", "booleano", "caracter" };        

        public TablaDeSimbolos() {
            establecerListadoSimbolosSimples();
            establecerListadoSimbolosCompuesto();
        }

        public enum simbolosSimples
        {
            aritmetico_mas = 43,
            aritmetico_menos = 45,
            aritmetico_multiplicaion1 = 158,
            aritmetico_multiplicaion2 = 42,
            aritmetico_division = 47,//ya no lo empleo...
            relacional_menorQue = 60,
            relacional_mayoQue = 62,
            logico_negacion = 33,
            //estos dos por el momento no serán empleados ya que no fueron agregados al alfabeto, pero si llegara a crecer puede que sean necesarios, asi que mientras no sean 2 se tomará como incorrecta la entrada
            /*logico_o = 179,//este es ó exclusivo
            logico_y = 38,*/
            asignacion_igualA = 61,
            asignacion_fin = 59
        }

        public enum simbolosCompuestos
        {
            aritmetico_incremento = 86,
            aritmetico_decremento = 90,
            relacional_menorIgual = 121,
            relacional_mayorIgual = 123,
            relacional_igualQue = 122,
            relacional_diferenteQue = 94,
            logico_O = 358,//este es o inclusiva
            logico_Y = 76,
        }
        
        private void establecerListadoSimbolosSimples() {
            listaSimbolosSimples.anadirAlFinal("+");
            listaSimbolosSimples.establecerNombreNodoCreado("aritmetico_mas");
            listaSimbolosSimples.anadirAlFinal("-");
            listaSimbolosSimples.establecerNombreNodoCreado("aritmetico_menos");
            listaSimbolosSimples.anadirAlFinal("*");
            listaSimbolosSimples.establecerNombreNodoCreado("aritmetico_multiplicaion");
            listaSimbolosSimples.anadirAlFinal("/");
          /*listaSimbolosSimples.establecerNombreNodoCreado("aritmetico_division");//aunque este ya se contempla en nec cierre, pero talvez si serí mejor */
            listaSimbolosSimples.anadirAlFinal("<");
            listaSimbolosSimples.establecerNombreNodoCreado("relacional_menorQue");
            listaSimbolosSimples.anadirAlFinal(">");
            listaSimbolosSimples.establecerNombreNodoCreado("relacional_mayoQue");
            listaSimbolosSimples.anadirAlFinal("!");
            listaSimbolosSimples.establecerNombreNodoCreado("logico_negacion");
            listaSimbolosSimples.anadirAlFinal("=");
            listaSimbolosSimples.establecerNombreNodoCreado("asignacion_igualA");
            listaSimbolosSimples.anadirAlFinal(";");
            listaSimbolosSimples.establecerNombreNodoCreado("asignacion_fin");
        }//por si acaso se complica un poquis con la enumeración...

        private void establecerListadoSimbolosCompuesto() {
            listaSimbolosCompuestos.anadirAlFinal("++");
            listaSimbolosCompuestos.establecerNombreNodoCreado("aritmetico_incremento");
            listaSimbolosCompuestos.anadirAlFinal("--");
            listaSimbolosCompuestos.establecerNombreNodoCreado("aritmetico_decremento");
            listaSimbolosCompuestos.anadirAlFinal("<=");
            listaSimbolosCompuestos.establecerNombreNodoCreado("relacional_menorIgual");
            listaSimbolosCompuestos.anadirAlFinal(">=");
            listaSimbolosCompuestos.establecerNombreNodoCreado("relacional_mayorIgual");
            listaSimbolosCompuestos.anadirAlFinal("==");
            listaSimbolosCompuestos.establecerNombreNodoCreado("relacional_igualQue");
            listaSimbolosCompuestos.anadirAlFinal("!=");
            listaSimbolosCompuestos.establecerNombreNodoCreado("relacional_diferenteQue");
            listaSimbolosCompuestos.anadirAlFinal("||");
            listaSimbolosCompuestos.establecerNombreNodoCreado("logico_O");
            listaSimbolosCompuestos.anadirAlFinal("&&");
            listaSimbolosCompuestos.establecerNombreNodoCreado("logico_Y");
        }

        public String buscarEnPalabrasReservadas(String palabraBuscar)
        {
            String hallazgo = "erronea";

            hallazgo = buscarEnFuncionales(palabraBuscar);
            if (hallazgo.Equals("erronea")) {
                hallazgo = buscarEnTipado(palabraBuscar);

                if (hallazgo.Equals("erronea")) {
                    hallazgo = buscarEnValoresBooleanos(palabraBuscar);
                }
            }            
            return hallazgo;
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
                    return "Tipado_" + reservadasTipado[palabraActual];//Esto será útil hasta que se ensamble el analizador sintáctico
                }
            }

            return "erronea";
        }

        public String buscarEnValoresBooleanos(String palabraABuscar) {
            if (palabraABuscar.Equals("verdadero")) {
                return "booleano";//después debería agregársele _ y su valor para saber a cual de los dos se refiere
            }
            if(palabraABuscar.Equals("falso")) {
                return "booleano";
            }

            return "erronea";
        }

        public ListaEnlazada<String> darListadoSimbolosSimples() {
            return listaSimbolosSimples;
        }

        public ListaEnlazada<String> darListadoSimbolosCompuestos() {
            return listaSimbolosCompuestos;
        }

    }



}
