using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class O_: NoTerminal
    {
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;
        B bloque;

        public O_() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = true;
            bloque = new B(true);
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal("e");

            produccion2.agregarNoTerminal("O'");
            produccion2.agregarNoTerminal("B");
            produccion2.agregarTerminal("parentesis_Cierre");
            produccion2.agregarNoTerminal("N");
            produccion2.agregarTerminal("parentesis_Apertura");
            produccion2.agregarTerminal("Funcional_SI");//tendré que agregarle la alternativa???

            produccion2.agregarNoTerminal("O'");
            produccion2.agregarNoTerminal("B");
            produccion2.agregarTerminal("parentesis_Cierre");
            produccion2.agregarNoTerminal("N");
            produccion2.agregarTerminal("parentesis_Apertura");
            produccion2.agregarTerminal("Funcional_SINO_SI");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }

        public B darBloque() {
            return bloque;
        }

    }
}
