using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class J: NoTerminal
    {
        Produccion produccion1;
        Produccion produccion2;

        public J() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal("var_numero");//Creo que este NT desaparecerá puesto que no puedo revisar el tipo para decir que es numérico... bueno sí, pero habría que hacer algunas excepciones por el hecho de tener que revisar en algunos el 1ros y en otros el 2do...
            produccion2.agregarTerminal("valor_numero");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }

    }
}
