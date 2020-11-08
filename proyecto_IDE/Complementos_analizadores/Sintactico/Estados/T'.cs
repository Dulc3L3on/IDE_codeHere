using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class T_: NoTerminal
    {
        public T_() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "T'";
            nombreCompleto = "Operacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();
            producciones[2] = new Produccion();

            producciones[0].agregarTerminal("e");

            producciones[1].agregarTerminal("U");
            producciones[1].agregarNoTerminal("signo_multiplicacion");

            producciones[2].agregarTerminal("U");
            producciones[2].agregarNoTerminal("signo_division");            
        }


    }
}
