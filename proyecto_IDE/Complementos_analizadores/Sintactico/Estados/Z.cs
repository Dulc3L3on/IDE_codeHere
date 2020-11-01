using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class Z : NoTerminal
    {
        public Z() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "Z";
            nombreCompleto = "Condicion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();
            producciones[2] = new Produccion();            
            
            producciones[0].agregarNoTerminal("K");
            producciones[0].agregarNoTerminal("H");

            producciones[1].agregarTerminal("parentesis_Cierre");
            producciones[1].agregarNoTerminal("K");            
            producciones[1].agregarNoTerminal("H");
            producciones[1].agregarTerminal("parentesis_Apertura");

            producciones[2].agregarTerminal("e");
        }
    }
}

