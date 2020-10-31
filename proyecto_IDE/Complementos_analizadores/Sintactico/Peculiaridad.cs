using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico
{
    class Peculiaridad
    {

        public bool esNumerico(String token, String terminal) {
            if (terminal.Equals(token)) {//el terminal podría ser val_numero ó var_mumero
                return true;
            }
            return false;
        }

        public bool esBoolean(String token, String terminal) {
            String[] tipo = token.Split('_');

            if (terminal.Equals(tipo[1])) {//puesto que sé que la parte de interés aparece en la segunda parte
                return true;
            }

            return false;
        }
    }
}//que pequeña :v
