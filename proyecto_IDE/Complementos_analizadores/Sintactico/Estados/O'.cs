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
        B bloque;

        public O_() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = true;
            bloque = new B(true);
            nombre = "O'";
            nombreCompleto = "Condicional";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();
            producciones[2] = new Produccion();

            producciones[0].agregarTerminal("e");

            producciones[1].agregarNoTerminal("O'");
            producciones[1].agregarNoTerminal("B");
            producciones[1].agregarTerminal("parentesis_Cierre");
            producciones[1].agregarNoTerminal("N");
            producciones[1].agregarTerminal("parentesis_Apertura");
            producciones[1].agregarTerminal("Funcional_SI");//tendré que agregarle la alternativa???

            producciones[2].agregarNoTerminal("O'");
            producciones[2].agregarNoTerminal("B");
            producciones[2].agregarTerminal("parentesis_Cierre");
            producciones[2].agregarNoTerminal("N");
            producciones[2].agregarTerminal("parentesis_Apertura");
            producciones[2].agregarTerminal("Funcional_SINO_SI");
        }

        public B darBloque() {
            return bloque;
        }

    }
}
