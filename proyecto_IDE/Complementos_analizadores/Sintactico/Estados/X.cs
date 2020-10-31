using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class X : NoTerminal
    {
        public X() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "X";
            nombreCompleto = "Operacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();

            producciones[0].agregarNoTerminal("X'");
            producciones[0].agregarNoTerminal("T");          
        }
    }
}
