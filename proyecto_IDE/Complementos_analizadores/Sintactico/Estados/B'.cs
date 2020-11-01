using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class B_: NoTerminal
    {
        public B_() {
            producciones = new Produccion[2];

            definirProducciones();
            soyGeneral = true;//porque sino cuando empiece el bloque y de casualidad la primer estructura está mal, no se revisarán las demás aunque estén buenas... 
            contengoCuerpo = false;
            nombre = "B'";
            nombreCompleto = "Bloque";//no se colocará prima porque esto es mostrado en el log... y además no hay choque puesto que no es una opción a escoger el nombre completo, sino una opción a mostrar...
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();//la nombrada repetida xD...
            producciones[1] = new Produccion();

            producciones[0].agregarNoTerminal("B'");
            producciones[0].agregarNoTerminal("C");

            producciones[1].agregarTerminal("fin_Bloque");
        }

    }
}
