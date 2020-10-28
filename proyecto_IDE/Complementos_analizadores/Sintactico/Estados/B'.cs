using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class B_: NoTerminal
    {
        Produccion repetida;
        Produccion produccion2;

        public B_() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            repetida = new Produccion();
            produccion2 = new Produccion();

            repetida.agregarNoTerminal("B'");
            repetida.agregarNoTerminal("C");            

            produccion2.agregarTerminal("}");

            producciones[0] = repetida;
            producciones[1] = produccion2;
        }

    }
}
