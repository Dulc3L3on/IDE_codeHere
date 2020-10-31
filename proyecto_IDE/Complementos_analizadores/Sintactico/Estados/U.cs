using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class U : NoTerminal
    {
        public U() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "U";
            nombreCompleto = "Operacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarNoTerminal("S");
            producciones[0].agregarTerminal("signo_menos");

            producciones[1].agregarNoTerminal("S");
        }
    }
}
