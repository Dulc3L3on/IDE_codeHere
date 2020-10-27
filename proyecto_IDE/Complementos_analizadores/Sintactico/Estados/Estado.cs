using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class Estado
    {
        public Produccion[] producciones;             

        public virtual void definirProducciones() { }

        public virtual bool definirRestricciones(String tipoTknSiguiente) {//creo que dejará de ser...
            return true;//si se llegara a necesitar algo más que true o false, por los demás casos de indecisión [de op [siendo lo únicos que faltan...]] este método desaparecerá y se colocará directamente en devolver ele u op...
        }//Esto solo será empleado por algunos "estados"...

        public virtual String darElemento(String tknSiguiente) {//es decir el ter o no ter...                      
            //Eso es para saber qué devolver en base a lo que viene, pero debes revisar...
            return null;
        }

        public virtual void darOpcion() {//esto será útil para aquellos estados que tenga más de 1 "camino" por escoger, lo cual dependerá de algunas características como el número de elementos que pueda leer el estado actual... [como para condición [N]]
        
        }

        public Produccion[] darProducciones()
        {
            return producciones;
        }

        public Produccion darProduccion(int numeroProduccion) {
            return producciones[numeroProduccion];
        }


    }
}
