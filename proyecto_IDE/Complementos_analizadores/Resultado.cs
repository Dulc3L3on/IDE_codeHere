using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores
{
    class Resultado
    {
        String elementoEstudiado;
        String clasificacion;
        int fila, columnaInicio, columnaFin;

        public Resultado()
        {
        }

        public Resultado(String elemento, String tipo, int numeroFila, int numeroColumnaInicio, int numeroColumnaFin)
        {
            elementoEstudiado = elemento;
            clasificacion = tipo;
            fila = numeroFila;
            columnaInicio = numeroColumnaInicio;
            columnaFin = numeroColumnaFin;
        }

        public String darElemento()
        {
            return elementoEstudiado;
        }

        public String darClasificacion()
        {
            return clasificacion;
        }

        public int darFilaUbicacion()
        {
            return fila;
        }

        public int darColumnaInicio()
        {
            return columnaInicio;
        }

        public int darColumnaFin()
        {
            return columnaFin;
        }
    }

    //la razón por la cual puede autocompletar un IDE
    //es por la tabla de datos, en donde almacena las
    //referencias, de un obj primitivo o no primitivo xD

}
