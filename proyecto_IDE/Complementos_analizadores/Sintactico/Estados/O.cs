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
        B bloque;

        public O() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = true;
            bloque = new B(true);
            nombre = "O";
            nombreCompleto = "Condicional";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();

            producciones[0].agregarNoTerminal("O'");
            producciones[0].agregarNoTerminal("B");
            producciones[0].agregarTerminal("parentesis_Cierre");
            producciones[0].agregarNoTerminal("N");
            producciones[0].agregarTerminal("parentesis_Apertura");
            producciones[0].agregarTerminal("Funcional_SI");
        }

        public B darBloque() {
            return bloque;
        }

    }
}
