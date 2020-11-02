using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class N : NoTerminal
    {
        public N() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
            nombre = "N";
            nombreCompleto = "Condicion";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();//ya no es fusionada xD            

            producciones[0].agregarNoTerminal("Q");
            producciones[0].agregarNoTerminal("Z");
            producciones[0].agregarNoTerminal("G");            
        }
    }
}

/*NOTA: Lo que se hará por el hecho de tener que escoger entre 1 u otra opción de producción y tener los mismo elementos iniciales es
 * Crear una producción, en este caso la que tiene más elementos, esto por el hecho de que coinciden los inicios
 * entonces como se creará un método para cuando no coincida el tkn con lo que devo´lvió el estado en el "tope" de la semi pila 
 *      [semi porque cada NT tendrá su propia pila que tendrá que ser lída totalmente para pasar al elemento siguiente de la pila en la
 *      que se encuentra el NT de dónde salió...]
 * se tendrá una excepción o solamente un if en el que se especificará si donde no se cumplió la igualdad de elemntos fue en la producción
 * generada debido a que se había entrado a una condición [N], específicamente en sikmb_log [luego de Z], de tal manera que al quitar [reducir]
 * sin evaluar los ele que restaban de la semi pila hasta llegar a la pila madre [es decir donde está el estado más general por el cual se formaron
 * dichsa pilas [operación, declaración, asignación, condición...] no se marque como error esa agrupación, sino como una condición... puesto que lo 
 * es, solo que sin uniones [por medio del && U ||]
*/


//solo para aclarar, el hecho de tener que ingnorar los ele generados por el estado más general, implica ignorar todas las pilas de menor jerarquía
//que aquella donde se encuentra dicho estado [´donde los generales son las prod de C]... 