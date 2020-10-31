using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class A : NoTerminal
    {        
        public A() {
            producciones = new Produccion[1];
                            
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
            nombre = "A";
            nombreCompleto = "Asignacion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[0].agregarTerminal("asignacion_fin");
            producciones[0].agregarTerminal("valor");
            producciones[0].agregarTerminal("asignacion_igualA");
            producciones[0].agregarTerminal("var");                                               
        }
    }
}
