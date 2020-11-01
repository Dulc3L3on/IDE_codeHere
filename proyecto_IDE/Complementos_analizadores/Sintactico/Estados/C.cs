using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class C : NoTerminal
    {
        public C() {
            producciones = new Produccion[7];//Debido a que la alternativa es oficial, entonces ocupa un lugar...
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
            nombre = "C";
            nombreCompleto = "Cuerpo";
        }
               
        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();//declaración
            producciones[1] = new Produccion();//Asignacion
            producciones[2] = new Produccion();//operacion
            producciones[3] = new Produccion();//ciclo
            producciones[4] = new Produccion();//estructuraCondicional
            producciones[5] = new Produccion();//escritura
            producciones[6] = new Produccion();//lectura

            producciones[0].agregarNoTerminal("D");

            producciones[1].agregarNoTerminal("A");//Recuerda que antes de apilar esta habrá que corroborar que si el signo que viene después de la variable o valor es "="

            producciones[2].agregarTerminal("asignacion_fin");
            producciones[2].agregarNoTerminal("I");            

            producciones[3].agregarNoTerminal("L");

            producciones[4].agregarNoTerminal("E");

            producciones[5].agregarNoTerminal("W");

            producciones[6].agregarNoTerminal("R");
        }

    }
}
