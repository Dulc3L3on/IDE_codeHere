using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class L : NoTerminal
    {
        B bloque;

        public L()
        {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = true;//esta var será útil para saber si hay que exe la parte en la que se susti esta lista por la más reciente para ir agrgando en ella y también para saber si se debe revisar el listado [esto lo hará el semi semántico...]
            bloque = new B(true);//puesto que debe tener su lista de no terminales por si acaso elusuario le asignó cuerpo xD
            nombre = "L";
            nombreCompleto = "Ciclo";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();//HACER
            producciones[1] = new Produccion();//DESDE
            producciones[2] = new Produccion();//MIENTRAS

            producciones[0].agregarTerminal("parentesis_Cierre");
            producciones[0].agregarNoTerminal("N");
            producciones[0].agregarTerminal("parentesis_Apertura");
            producciones[0].agregarTerminal("Estructural_MIENTRAS");
            producciones[0].agregarNoTerminal("B");
            producciones[0].agregarTerminal("Funcional_HACER");

            producciones[1].agregarNoTerminal("B");
            producciones[1].agregarNoTerminal("V");
            producciones[1].agregarTerminal("Estructural_INCREMENTO");
            producciones[1].agregarNoTerminal("V");
            producciones[1].agregarTerminal("asignacion_igualA");
            producciones[1].agregarTerminal("var");
            producciones[1].agregarTerminal("Funcional_HASTA");
            producciones[1].agregarNoTerminal("V");
            producciones[1].agregarTerminal("asignacion_igualA");
            producciones[1].agregarTerminal("var");
            producciones[1].agregarTerminal("Estructural_DESDE");

            producciones[2].agregarNoTerminal("B");
            producciones[2].agregarTerminal("parentesis_Cierre");
            producciones[2].agregarNoTerminal("N");
            producciones[2].agregarTerminal("parentesis_Apertura");
            producciones[2].agregarTerminal("Estructural_MIENTRAS");
        }

        public B darBloque() {
            return bloque;
        }
        //Este método solo es para aquellos que contienen cuerpo...
        //Te falta asignarles a los demás las 2 var y el cuerpo si es el caso
        //crear el método para crear una instancia propia, eso en cada NT general, sin importar si tiene o no cuerpo
        //Crear la TTS :v Xd pero antes los métodos del autómata,
        //primero cambiar de estado y caracter [ en cb de estado van todas estas especialidadse agregadas xd]
    }
}
