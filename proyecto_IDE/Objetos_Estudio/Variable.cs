using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Objetos_Estudio
{
    class Variable
    {
        String tipo;
        String nombre;
        String valor;

        public Variable(String elTipo, String elNombre, String elValor) {
            tipo = elTipo;
            nombre = elNombre;
            if (valor == null)
            {
                valor = establecerValorDefault(elTipo);
            }
            else {
                valor = elValor;
            }           
        }

        public String establecerValorDefault(String tipo) {
            if (tipo.Equals("entero")) {
                return "0";
            }
            if (tipo.Equals("decimal")) {
                return "0.0";
            }
            if (tipo.Equals("cadena")) {
                return "null";//:v xD
            }
            if (tipo.Equals("booleano")) {
                return "false";
            }
            if (tipo.Equals("caracter")) {
                return "A";//xD
            }
            return null;
        }

        public void cambiarValor(String nuevoValor) {//este es el único atrib que de´bería poder ser cambiado, puesto que si cb el nombre, es otra var xD :v
            valor = nuevoValor;
        }

        public String darNombre() {
            return nombre;
        }
        public String darValor() {
            return valor;
        }
        public String darTipo() {
            return tipo;
        }

    }
}
