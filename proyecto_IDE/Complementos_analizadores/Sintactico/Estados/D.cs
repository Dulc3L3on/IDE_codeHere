using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class D : NoTerminal
    {
        public D() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
            nombre = "D";
            nombreCompleto = "Declaracion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();

            producciones[0].agregarNoTerminal("Y");
            producciones[0].agregarTerminal("var");
            producciones[0].agregarTerminal("tipo");                        
        }

    }
}
