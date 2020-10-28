using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class O : NoTerminal
    {
        Produccion unica;
        B bloque;

        public O() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            bloque = new B(true);
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarNoTerminal("O'");
            unica.agregarNoTerminal("B");
            unica.agregarTerminal("parentesis_Cierre");
            unica.agregarNoTerminal("N");
            unica.agregarTerminal("parentesis_Apertura");
            unica.agregarTerminal("Funcional_SI");

            producciones[0] = unica;
        }

        public B darBloque() {
            return bloque;
        }

    }
}
