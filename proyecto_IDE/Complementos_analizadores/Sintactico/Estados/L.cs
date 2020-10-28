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
        Produccion hacer;
        Produccion desde;
        Produccion mientras;
        B bloque;

        public L()
        {
            producciones = new Produccion[3];
            definirProducciones();
            soyGeneral = true;
            contengoCuerpo = true;//esta var será útil para saber si hay que exe la parte en la que se susti esta lista por la más reciente para ir agrgando en ella y también para saber si se debe revisar el listado [esto lo hará el semi semántico...]
            bloque = new B(true);//puesto que debe tener su lista de no terminales por si acaso elusuario le asignó cuerpo xD
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            hacer.agregarTerminal("parentesis_Cierre");
            hacer.agregarNoTerminal("N");
            hacer.agregarTerminal("parentesis_Apertura");
            hacer.agregarTerminal("Funcional_MIENTRAS");
            hacer.agregarNoTerminal("B");
            hacer.agregarTerminal("Funcional_HACER");

            desde.agregarNoTerminal("B");
            desde.agregarNoTerminal("J");
            desde.agregarTerminal("Funcional_INCREMENTO");
            desde.agregarNoTerminal("N");
            desde.agregarTerminal("Funcional_HASTA");
            desde.agregarNoTerminal("J");
            desde.agregarTerminal("igual");
            desde.agregarNoTerminal("J");
            desde.agregarTerminal("Funcional_DESDE");

            mientras.agregarNoTerminal("B");
            mientras.agregarTerminal("parentesis_Cierre");
            mientras.agregarNoTerminal("N");
            mientras.agregarTerminal("parentesis_Apertura");
            mientras.agregarTerminal("Funcional_MIENTRAS");

            producciones[0] = hacer;
            producciones[1] = desde;
            producciones[2] = mientras;

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
