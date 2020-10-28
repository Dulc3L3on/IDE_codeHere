using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores
{
    [Serializable]
    class Token//por el hecho de guardarse en una lista enlazada, se tendría el orden de aparicion, puesto que el primero en aparecer en la lista también sería el primero de la linea...
    {
        String elementoEstudiado;
        String clasificacion;//esta es la clasificación del conjunto de caracteres mismo
        String tipoAgrupacion;//esta es la agrupación que será determinada a partir de donde se encuentre su debido agrupador [los parentesis]... le será establecida mientras no encuentre el signo de cierre, cuando no se haya encontrado ninguno, esta var no será empleada, porque basta con la clasificacion inidividual... entre los tipos de agrupaciones está -> condicion, ->opMatematica, -> conversion y así xd...
        //Creo que este valor será establecido por el sintác... los tkns que pertenezcan a la misma agrupación tendrán el mismo valor... así que deberá ser eli, porque esto irá en el lexema...
        int filaInicio, columnaInicio, columnaFin, filaFin;

        public Token()
        {
        }

        public Token(String elemento, String tipo, int numeroFilaInicio, int numeroColumnaInicio, int numeroColumnaFin)
        {
            elementoEstudiado = elemento;
            clasificacion = tipo;
            filaInicio = numeroFilaInicio;
            filaFin = numeroFilaInicio;//no creo que provoque problemas... esto lo hago porque aún no se si vaya a revisar siempre esta col o no, lo cual dependerá si se tienen métodos personalizados para cada tipo, lo cual facilitaría más el proceso...
            columnaInicio = numeroColumnaInicio;
            columnaFin = numeroColumnaFin;
        }

        public String darToken()
        {
            return elementoEstudiado;
        }

        public String darClasificacion()
        {
            return clasificacion;
        }

        public int darFilaUbicacionInicio()
        {
            return filaInicio;
        }

        public void establecerFilaFin(int numeroFilaFin) {
            filaFin = numeroFilaFin;
        }//para el caso de los primitivos será la misma en la que inicio...

        public int darFilaUbicacionFin()
        {
            return filaFin;
        }

        public int darColumnaInicio()
        {
            return columnaInicio;
        }

        public int darColumnaFin()
        {
            return columnaFin;
        }

        public void establecerTipoAgrupacion(String tipoDeAgrupacion) {
            tipoAgrupacion = tipoDeAgrupacion;
        }

        public String darMembresia() {//será emeplado por el semi o totalmente emán.. puesto que el sent+ac se encargará de llenar eso... pero esto iría en el obj lexema, ahora que recuerdo, sip porque este alamacena el token y los datos como la agrupación que determinó el sintac...
            return tipoAgrupacion;
        }
    }

    //la razón por la cual puede autocompletar un IDE
    //es por la tabla de datos, en donde almacena las
    //referencias, de un obj primitivo o no primitivo xD

}
