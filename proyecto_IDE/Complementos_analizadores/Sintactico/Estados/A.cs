using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class A : NoTerminal
    {
        Produccion produccion1;

        public A() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal(";");
            produccion1.agregarTerminal("valor");
            produccion1.agregarTerminal("igual");
            produccion1.agregarTerminal("var");                                   

            producciones[0] = produccion1;
        }
    }
}
