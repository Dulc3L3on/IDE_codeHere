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
        Produccion produccion1;
        Produccion produccion2;

        public G() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal("e");

            produccion2.agregarNoTerminal("G");
            produccion2.agregarTerminal("logico_negacion");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }

    }
}
