using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class H : NoTerminal
    {
        public H() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "H";
            nombreCompleto = "Condicion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();
            producciones[2] = new Produccion();

            producciones[0].agregarNoTerminal("V");

            producciones[1].agregarTerminal("e");

            producciones[2].agregarTerminal("booleano");
            producciones[2].agregarNoTerminal("G");
        }

    }
}

