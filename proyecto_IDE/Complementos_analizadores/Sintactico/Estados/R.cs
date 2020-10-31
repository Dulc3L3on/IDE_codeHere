﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class R: NoTerminal
    {
        public R() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = false;
            nombre = "R";
            nombreCompleto = "FuncionLectura";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();

            producciones[0].agregarTerminal("asignacion_fin");
            producciones[0].agregarTerminal("parentesis_Cierre");
            producciones[0].agregarTerminal("var");
            producciones[0].agregarTerminal("parentesis_Apertura");
            producciones[0].agregarTerminal("leer");
        }

    }
}
