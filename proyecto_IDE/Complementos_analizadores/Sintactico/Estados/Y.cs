using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class Y: Estado
    {
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;

        public Y() {
            producciones = new Produccion[3];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarNoTerminal("Y");
            produccion1.agregarTerminal("valor");
            produccion1.agregarTerminal("=");
                        
            produccion2.agregarTerminal(";");

            produccion3.agregarNoTerminal("Y");
            produccion3.agregarTerminal("var");
            produccion3.agregarTerminal(",");
                        
            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }

    }
}
