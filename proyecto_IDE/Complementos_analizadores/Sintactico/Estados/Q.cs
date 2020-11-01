using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class Q : NoTerminal
    {
        public Q()
        {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "Q";
            nombreCompleto = "Multiple condicion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();            

            producciones[0].agregarNoTerminal("N");
            producciones[0].agregarTerminal("logico");

            producciones[1].agregarTerminal("e");
        }

    }
}
