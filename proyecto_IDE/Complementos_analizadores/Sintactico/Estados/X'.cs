using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class X_: NoTerminal
    {
        public X_() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "X'";
            nombreCompleto = "Operacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();
            producciones[2] = new Produccion();

            producciones[0].agregarNoTerminal("T");
            producciones[0].agregarTerminal("signo_mas");

            producciones[1].agregarNoTerminal("T");
            producciones[1].agregarTerminal("signo_menos");

            producciones[2].agregarTerminal("e");
        }
    }
}
