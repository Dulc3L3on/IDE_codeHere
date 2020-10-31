using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class F_: NoTerminal
    {
        public F_() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "F_";
            nombreCompleto = "Concatenacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarNoTerminal("F'");
            producciones[0].agregarNoTerminal("V");
            producciones[0].agregarNoTerminal("signo_mas");

            producciones[1].agregarTerminal("e");
        }
    }
}
