using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class I : NoTerminal
    {
        Produccion unica;        

        public I() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarNoTerminal("X");//emplearemos _ para separar los términos alternos, que serían entregados según el tkn recibido...
            
            producciones[0] = unica;            
        }    
      
    }
}

