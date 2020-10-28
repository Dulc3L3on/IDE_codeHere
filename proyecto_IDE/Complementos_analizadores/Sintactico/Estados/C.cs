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
        Produccion declaracion;
        Produccion asignacion;
        Produccion operacion;
        Produccion ciclo;
        Produccion condicional;
        Produccion escritura;
        Produccion lectura;

        public C() {
            producciones = new Produccion[7];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
        }
               
        public override void definirProducciones()
        {
            base.definirProducciones();
            declaracion = new Produccion();
            asignacion = new Produccion();
            operacion = new Produccion();
            ciclo = new Produccion();
            condicional = new Produccion();
            escritura = new Produccion();
            lectura = new Produccion();

            declaracion.agregarNoTerminal("D");

            asignacion.agregarNoTerminal("A");

            operacion.agregarNoTerminal("I");
            operacion.agregarTerminal("asignacion_fin");

            ciclo.agregarNoTerminal("L");

            escritura.agregarNoTerminal("W");

            lectura.agregarNoTerminal("R");

            producciones[0] = declaracion;
            producciones[1] = asignacion;
            producciones[2] = operacion;
            producciones[3] = ciclo;
            producciones[4] = condicional;
            producciones[5] = escritura;
            producciones[6] = lectura;
        }


    }
}
