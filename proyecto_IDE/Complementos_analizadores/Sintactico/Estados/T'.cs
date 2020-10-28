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
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;

        public T_() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            produccion1.agregarTerminal("U");
            produccion1.agregarNoTerminal("signo_multiplicacion");

            produccion2.agregarTerminal("U");
            produccion2.agregarNoTerminal("signo_division");

            produccion3.agregarTerminal("e");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }


    }
}
