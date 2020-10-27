using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class C: Estado
    {
        Produccion repetida;
        Produccion produccion2;

        public C() {
            producciones = new Produccion[2];
            definirProducciones();
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
