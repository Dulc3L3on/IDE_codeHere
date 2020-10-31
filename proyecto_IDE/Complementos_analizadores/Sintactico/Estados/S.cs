using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class S : NoTerminal
    {
        public S() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "S";
            nombreCompleto = "Operacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarTerminal("parentesis_Cierre");
            producciones[0].agregarNoTerminal("X");
            producciones[0].agregarTerminal("parentesis_Apertura");

            producciones[1].agregarNoTerminal("J");
        }

    }
}
