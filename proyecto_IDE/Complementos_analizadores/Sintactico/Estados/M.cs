using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class M : NoTerminal
    {
        public M() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "M";
            nombreCompleto = "Principal";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarNoTerminal("B");
            producciones[0].agregarTerminal("parentesis_Cierre");
            producciones[0].agregarTerminal("parentesis_Apertura");            
            producciones[0].agregarTerminal("Reservada_principal");

            producciones[1].agregarTerminal("e");//recuerda que con este se hace un reduce de inmediato...
        }
    }
}
    