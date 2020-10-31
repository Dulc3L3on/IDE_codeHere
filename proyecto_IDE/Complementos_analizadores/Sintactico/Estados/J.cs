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
        public J() {
            producciones = new Produccion[2];
            
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "J";
            nombreCompleto = "TipoValor";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarTerminal("var_numero");//Creo que este NT desaparecerá puesto que no puedo revisar el tipo para decir que es numérico... bueno sí, pero habría que hacer algunas excepciones por el hecho de tener que revisar en algunos el 1ros y en otros el 2do...

            producciones[1].agregarTerminal("valor_numero");
        }

    }
}
