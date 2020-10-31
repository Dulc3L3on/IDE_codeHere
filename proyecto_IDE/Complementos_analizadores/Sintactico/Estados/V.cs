using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class V : NoTerminal
    {
        public V() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "V";
            nombreCompleto = "TipoValor";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarTerminal("var");

            producciones[1].agregarTerminal("valor");
        }

    }
}
