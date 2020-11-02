using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Excepciones
{
    class ExcepcionSintactico
    {
        //serían los tres tipos mencionados en el doc: repetido [atrás], falta [adelante], tkn erróneo... ya no será tan así, sino que se generalizará xd lleva menos trabajo xD
        ListaEnlazada<String> listaErrores = new ListaEnlazada<String>();//crei que se devolvía a una lista general.. pero si se hace eso, habría que crear una clase con tal que eso pueda suceder... y como que no me cuadra tener que crear una solo para eso...

        public void reaccionarAnteProduccionNoExistente(String NTgeneral, String NTenCuestion, int numeroFila)//donde dicho NT corresponde al nombre [normal xd] del estado al cual se movió para cambiar de fila por el hecho de estar en el tope...
        {
            String mensajeError ="Error: línea "+ numeroFila + ">>>"  ;
            mensajeError += (NTgeneral != null) ? " En " + NTgeneral + "-> " : "";

            switch (NTenCuestion) {
                case "M":
                    mensajeError =mensajeError+ "El codigo DEBE ser englobado por el método PRINCIPAL";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "B":
                    mensajeError = mensajeError + "El bloque debe iniciarse con {";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "B'": case "C":
                    mensajeError = mensajeError + "Solo puedes emplear: ciclos, asignaciones, declaraciones, condiciones, operaciones, escritura y lectura";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                
                case "D":
                    mensajeError = mensajeError + "La declaracion debe iniciar SIEMPRE con un Tipo";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "Y":
                    mensajeError = mensajeError + "Solo puedes asginar valores o variables a un identificador";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "A":
                    mensajeError = mensajeError + "La asginación obedece la regla -> variable = valor ;";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "I": case "X": case "T": case "U": case "S":
                    mensajeError = mensajeError + "Las operaciones algebraicas solo involucran valores/varibales numéricas, signos de operación y asignación";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;                               
                case "X'":
                    mensajeError = mensajeError + "La adición y sustracción solo emplean los signos + y -";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "T'":
                    mensajeError = mensajeError + "La multiplicacion y división solo emplean los signos * y /";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;                
                case "J":
                    mensajeError = mensajeError + "Era necesario colocar un valor o identificador numérico";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "L":
                    mensajeError = mensajeError + "El inicio de un ciclo, contiene solo las palabras HACER, DESDE O MIENTRAS";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "E": case "O":
                    mensajeError = mensajeError + "Las condiciones SIEMPRE inician con un si";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "E'": case "O'":
                    mensajeError = mensajeError + "Se esperaba un único SINO, uno o más SINO_ SI ó que cambiaras de estructura";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;                                
                case "N": case "Q": case "Z": case "K":
                    mensajeError = mensajeError + "La condicion requiere comparar uno o más valores";//esto lo digo puesto que el if en realidad retorna valores de verdad...
                    listaErrores.anadirAlFinal(mensajeError);
                    break;                
                case "H": case "G":
                    mensajeError = mensajeError + "Solo puedes negar valores booleanos e incluir variables o valores";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;                
                case "V":
                    mensajeError = mensajeError + "Se esperaba un valor o variable";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "F": case "F'":
                    mensajeError = mensajeError + "Solo puedes concatenar [+] valores y variables";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;                
                case "W":
                    mensajeError = mensajeError + "La función imprimir, REQUIERE iniciar con la palabra imprimir";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
                case "R":
                    mensajeError = mensajeError + "La función lectura, REQUIERE iniciar con la palabra leer";
                    listaErrores.anadirAlFinal(mensajeError);
                    break;
            }//no son exactamente correspondientes, puesto que 

        }//fin del método que se encarga de alertar sobre el tipo de error sucedido, cuando se calló en una celda nula...

        public void reaccionarAnteNoIgualdad(String nombreNT, String token, int numeroFila) {
            String mensajeError;

            if (token.Equals(";")) {
                mensajeError = "Error: linea "+ numeroFila +" >>> Indicacion de fin de estructura fuera de lugar";
            }
            if (token.Equals("{"))
            {
                mensajeError = "Error: linea " + numeroFila + ">>> Inicio de bloque mal posicionado";
            }
            else {
                mensajeError = "Error: linea " + numeroFila+" >>> No se esperaba \""+ token+"\" en la estructura "+ nombreNT;
            }            
            listaErrores.anadirAlFinal(mensajeError);
        }

        public ListaEnlazada<String> darListadoErrores() {
            return listaErrores;
        }

    }
}
