using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class G: NoTerminal
    {
        public G() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "G";
            nombreCompleto = "Condicion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarTerminal("e");

            producciones[1].agregarNoTerminal("G");
            producciones[1].agregarTerminal("negacion");//por la ambiguedad con simbolo_logico... xD
        }

    }
}
