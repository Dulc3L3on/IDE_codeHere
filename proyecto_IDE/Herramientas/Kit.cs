using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Herramientas
{
    class Kit
    {
        public char determinarTipoCaracter(char caracterInicial)
        {
            if (((int)caracterInicial >= 65 && (int)caracterInicial <= 90) || (int)caracterInicial >= 97 && (int)caracterInicial <= 122)
            {
                return 'l';//De letra
            }

            if ((int)caracterInicial >= 48 && (int)caracterInicial <= 57)
            {
                return 'd';//de digito
            }

            if ((int)caracterInicial == 46)
            {
                return 'p';//de punto
            }

            if ((int)caracterInicial == 34 || (int)caracterInicial == 47)
            {
                return 'c';//De necesita cierre -> "", / [en este caso no pero por el hecho de colorear todo lo que dentro de él esté] /**/
            }

            return 'o';//De otros, que hasta el momento no se sabe si correponden o no al alfabeto...
        }

        public String cerrarComentario(char caracaterAnterior, char caracterPosterior)
        {//será el primero en ser llamado por el hecho de contener menos condiciones que revisar... auqneu talvez sea el menos empleado de todos...
            if ((int)caracaterAnterior == 47 && (int)caracaterAnterior == 42)
            {
                char barraComentario = (char)47;
                String comentarioMultiLinCierre = "*" + barraComentario;
                return comentarioMultiLinCierre;
            }

            return null;
        }
        public char cerrarAperturado(char signoApertura)
        {//será llamado por el keyTyped para que revise y cuando sea alguno de estos tipos que devuelva el caracter correspondiente...
            if (((int)signoApertura) == 34)
            {
                return (char)34;
            }
            if ((int)signoApertura == 40)
            {
                return (char)41;
            }//cuando sea incluido también irían aquí los [] y las {}

            return (char)32;//devuelve un espacio en blanco...

        }


    }
}
