using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.ArbolDerivaciones
{
    class Padre
    {
        private int numeroNodoCreado;
        private String nombre;
        private int mensaje;//pendiente
        private bool yaFuiEstudiado = false;

        public Padre(String nombrePadre, int numeroCreacion) {
            nombre = nombrePadre;
            numeroNodoCreado = numeroCreacion;
        }

        public void cambiarEstadoEstudio() {
            yaFuiEstudiado = true;
        }

        public String darNombre() {
            return nombre;
        }

        public int darNumeroCreacion() {
            return numeroNodoCreado;
        }

        public bool darEstadoEstudio() {
            return yaFuiEstudiado;
        }             

    }
}
