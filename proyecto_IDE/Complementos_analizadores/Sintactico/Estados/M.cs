using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class M : NoTerminal
    {
        Produccion produccion1;
        Produccion produccion2;

        public M() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            produccion1 = new Produccion();
            produccion2 = new Produccion();

            produccion1.agregarNoTerminal("B");
            produccion1.agregarTerminal("parentesis_Apertura");
            produccion1.agregarTerminal("parentesis_Cierre");
            produccion1.agregarTerminal("Estructura_principal");                                   

            produccion2.agregarTerminal("e");//recuerda que con este se hace un reduce de inmediato...

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }
    }
}
    