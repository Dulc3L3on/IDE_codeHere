using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class Y: NoTerminal
    {
        public Y() {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "Y";
            nombreCompleto = "Asignacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();
            producciones[2] = new Produccion();

            producciones[0].agregarNoTerminal("Y");
            producciones[0].agregarTerminal("valor");
            producciones[0].agregarTerminal("asignacion_igualA");

            producciones[1].agregarTerminal("asignacion_fin");

            producciones[2].agregarNoTerminal("Y");
            producciones[2].agregarTerminal("var");
            producciones[2].agregarTerminal("coma");
        }

    }
}

