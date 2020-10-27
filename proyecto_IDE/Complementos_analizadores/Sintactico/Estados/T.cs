using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class T: Estado
    {
        Produccion unica;

        public T() {
            producciones = new Produccion[1];
            definirProducciones();           
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarNoTerminal("U");
            unica.agregarNoTerminal("T'");
            
            producciones[0] = unica;
        }

    }
}
