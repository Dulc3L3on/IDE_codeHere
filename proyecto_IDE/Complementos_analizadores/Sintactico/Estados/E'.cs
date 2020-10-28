using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class E_ : NoTerminal
    {
        Produccion produccion1;
        Produccion produccion2;

        public E_() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;//Es decir que no puede ni debe xD ser agregado a la lista en lazada de NT a entregar al semi semán
            contengoCuerpo = false;            
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal("e");
                                    
            produccion2.agregarNoTerminal("E'");
            produccion2.agregarNoTerminal("B");
            produccion2.agregarTerminal("Funcional_SINO");
            

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }

    }
}