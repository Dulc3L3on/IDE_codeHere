using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class D : NoTerminal
    {
        Produccion produccion1;
        
        public D() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarNoTerminal("Y");
            produccion1.agregarTerminal("var");
            produccion1.agregarTerminal("tipo");                        

            producciones[0] = produccion1;
        }

    }
}
