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
        B bloque;//tednrías que ser creado luego de haber revisado el atributo de poseer cuerpo, el cual es cumplido por este NT, para así crear una instancia de este NT para depués almacenar los respectivos valores cambiantes en la TS de su bloque xd

        public E_() {
            producciones = new Produccion[2];
            definirProducciones();
            soyGeneral = false;//Es decir que no puede ni debe xD ser agregado a la lista en lazada de NT a entregar al semi semán
            contengoCuerpo = true;
            bloque = new B(true);
            nombre ="E'";
            nombreCompleto = "Condicional";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();
            producciones[1] = new Produccion();

            producciones[0].agregarTerminal("e");

            producciones[1].agregarNoTerminal("E'");
            producciones[1].agregarNoTerminal("B");
            producciones[1].agregarTerminal("Estructural_SINO");      
        }

        public B darBloque() {
            return bloque;
        }

    }
}