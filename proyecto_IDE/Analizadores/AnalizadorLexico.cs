﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores;
using proyecto_IDE.Excepciones;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Analizadores
{
    class AnalizadorLexico
    {
        Kit herramienta = new Kit();
        ExcepcionLexico excepcionLexico = new ExcepcionLexico();
        TablaDeSimbolos tablaSimbolos = new TablaDeSimbolos();

        public void analizar(char[] lineaDesglosada, int numeroLinea)
        {//Aquí ya actuó el método sea que aquí mismo se encuantre o lo esté en la clase que tiene contacto directo con la interfaz...
            Resultado resultadosHallados = new Resultado();

            for (int caracterActual = 0; caracterActual < lineaDesglosada.Length; caracterActual++)
            {
                if (!((int)lineaDesglosada[caracterActual] == 32))
                { //Es decir es un espacio en blanco...
                    char tipoCaracter = herramienta.determinarTipoCaracter(lineaDesglosada[caracterActual]);//por este método es que no habrán errores de ubicarse en el caracter sigueinte al último que se estudió puesto que aquí se revisa y por o tanto está bien que en los métodos principales de análisis se estudie 1 más allá...

                    switch (tipoCaracter)
                    {
                        case 'p'://problemas con los identificadores no habrá... por el hecho de que DEBE empezar con un caracter y por ello caerá al método que tiene como primero una letra ya después conforme se vaya desarrollando el proceso xD se decidirá si el método que debe seguir con la revisión se debe cambiar o no...
                            resultadosHallados = analizarOcurrenciaConLetras(numeroLinea, caracterActual, lineaDesglosada);
                            break;

                        case 'd':
                            resultadosHallados = analizarNumero(numeroLinea, caracterActual, lineaDesglosada);
                            break;

                        case 'c':
                            resultadosHallados;
                            break;

                        case 'o':
                            resultadosHallados;
                            break;

                        default:
                            //se manda a llamar al método de Excepciones para que informe el hecho  a la GUI y así pueda marcar y actualizar el área de log
                            break;
                    }//fin del switch                    
                }

                caracterActual = resultadosHallados.darColumnaFin();//Esto para que pueda seguir con el proceso general a partir de donde se quedaron los subprocesos...

            }//fin del for que se encarga de recorrer caracter por caracter la línea que recibió del área de desarrollo


        }

        private Resultado analizarOcurrenciaConLetras(int numeroLinea, int inicioAnalisis, char[] lineaAEstudiar)
        {
            String[] datosHallados = new String[3];


            datosHallados = analizarPalabra(numeroLinea, inicioAnalisis, lineaAEstudiar);

            //al final se manda a llamar al método para buscar en la tabla de símbolos
            if (!datosHallados[1].Equals("erronea"))
            {
                String tipoNuevo = tablaSimbolos.buscarEnPalabrasReservadas(datosHallados[2]);

                if (tipoNuevo != null)
                {
                    datosHallados[1] = tipoNuevo;
                }
            }

            Resultado resultado = new Resultado(datosHallados[2], datosHallados[1], numeroLinea, inicioAnalisis, Convert.ToInt32(datosHallados[0]));//por el momento no me es útil, pero aún así devolveré este elemento para que pueda ser agregado a la lista que almacena en cada nodo un objeto resultado...            
            return resultado;
        }//listo

        private String[] analizarPalabra(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {//recuerda que por el hecho de recibir la línea almacenada en un arr, entonces si el número que corresponda a las col será uno menos a lo ordinario, pero debes averiguar como trabaja con las col el richTextBox... para que cuando necesites hacer manipulaciones alguna vez, no surgan problemas...
            int posicionAnalisis = posicionInicialAnalisis + 1;
            String[] detallesPalabra = { "", "primitiva_caracter", Convert.ToString(lineaAEstudiar[posicionInicialAnalisis]) };//al solo tener un caracter no se entraría a la parte para                     
            bool parar = false;

            while ((int)lineaAEstudiar[posicionAnalisis] != 32 && (parar == false) && (posicionAnalisis < lineaAEstudiar.Length))
            {//Es decir mientras no halle un espacio en blanco...      para cuando ya se agregue el identificador esta condi de !palabra deberá cambiar puesto que sin importar que sea palabra o identificador, deberá parar... ahi si deberá usarse un bool, que cb de val para que ya no siga, media vez entre al if para usar el método de Excepción...
                if (posicionAnalisis == (posicionInicialAnalisis + 1))
                {
                    detallesPalabra[1] = "primitiva_palabra";
                }
                if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionAnalisis]) != 'l')
                {
                    detallesPalabra[1] = excepcionLexico.excepcionPalabra(numeroLinea, posicionAnalisis, lineaAEstudiar);
                    if (detallesPalabra[1].Equals("primitiva_palabra"))
                    {
                        parar = true;
                    }
                }
                if (parar == false)
                {
                    detallesPalabra[2] += lineaAEstudiar[posicionAnalisis];
                }//esto desaperecerá al tener al identificador, porque independientemente de lo que se tenga se debe parar

                posicionAnalisis++;//el quedarse un paso adelante de donde realmente estaba no afecta y realmente así debe ser porque ese caracter ya se ha contemplado en el proceso de estudio...
            }

            detallesPalabra[0] = Convert.ToString(posicionAnalisis);//la posición es justo 1 espacio más allá de donde se quedó a analizando, lo cual es exactamente donde el for debe estar para así asginar ese espacio al método que le corresponda...
            return detallesPalabra;

        }//por el momento puesto que no se tiene que clasificar a los identificadores, mandará de una vez a la lista de Resultados el tipo de dicha palabra como erronea
        //listo

        public void analizarIdentficador()
        {
            //sería llamado en el método de análisisPalabra cuando en la palabra se encontrara con un caracter de valor != a cualquiera de las letras
            //aquí se revisaría si es uno permitido sino a erroneas se iría... esto si es que se acepta algo más que el _

        }//Esto será empleado hasta la 2da fase, creo :v xD

        public Resultado analizarNumero(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {
            String[] hallazgos = analizarEntero(numeroLinea, posicionInicialAnalisis, lineaAEstudiar);

            Resultado resultado = new Resultado(hallazgos[2], hallazgos[1], numeroLinea, posicionInicialAnalisis, Convert.ToInt32(hallazgos[0]));
            return resultado;//recuerda que por medio de esto se puede avanzar a partir del indice siguiente al último que terminó de analizar el método
        }//lsito

        private String[] analizarEntero(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {
            int posicionAnalisis = posicionInicialAnalisis + 1;
            String[] detallesEntero = { "", "primitiva_entero", Convert.ToString(lineaAEstudiar[posicionInicialAnalisis]) };//al solo tener un caracter no se entraría a la parte para                     
            bool parar = false;

            while ((int)lineaAEstudiar[posicionAnalisis] != 32 && (parar == false) && (posicionAnalisis < lineaAEstudiar.Length))
            {//Es decir mientras no halle un espacio en blanco...      para cuando ya se agregue el identificador esta condi de !palabra deberá cambiar puesto que sin importar que sea palabra o identificador, deberá parar... ahi si deberá usarse un bool, que cb de val para que ya no siga, media vez entre al if para usar el método de Excepción...

                if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionAnalisis]) != 'd')
                {
                    detallesEntero[1] = excepcionLexico.excepcionNumero(numeroLinea, posicionAnalisis, lineaAEstudiar);
                    parar = true;//Es útil para cuando se encuentren carcteres diferentes al "." puesto que lo que se había analizado entraría como un entero y como la subcadena final...

                    if (detallesEntero[1].Equals("primitiva_decimal"))
                    {
                        return analizarDecimal(numeroLinea, (posicionAnalisis + 1), lineaAEstudiar);//pues lo que necesita es saber donde debe comenzar a trabajar, no dónde se quedó su antecesor...
                    }
                }
                if (parar == false)
                {
                    detallesEntero[2] += lineaAEstudiar[posicionAnalisis];
                }//esto desaperecerá al tener al identificador, porque independientemente de lo que se tenga se debe parar

                posicionAnalisis++;//el quedarse un paso adelante de donde realmente estaba no afecta y realmente así debe ser porque ese caracter ya se ha contemplado en el proceso de estudio...
            }

            detallesEntero[0] = Convert.ToString(posicionAnalisis);
            return detallesEntero;

        }//listo

        private String[] analizarDecimal(int numeroLinea, int posicionInicialAnalisis, char[] lineaAEstudiar)
        {
            int posicionAnalisis = posicionInicialAnalisis;//en este caso debe eliminarse el incre de 1 por el hecho de que este no tiene el método de análisis para el actual, así como se hace antes de entrar en el switch... sino se estaría brincando un caracter...
            String[] detallesDecimal = { "", "erronea", Convert.ToString(lineaAEstudiar[posicionInicialAnalisis]) };//default erronea porque si no viene un número no entraría a un bloque específico y no tendría donde nombrarle de esta manera, por ello mejor cuando se encuentra que todo esta bien, catalogo respecto a ese bienestar...
            bool parar = false;

            if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionInicialAnalisis]) == 'd')
            {
                detallesDecimal[1] = "primitiva_decimal";
                posicionAnalisis++;//pues sabiendo que mínimo se tiene un dígito, me debo ubicar en el siguiente para saber si ese es su caso...

                while ((int)lineaAEstudiar[posicionAnalisis] != 32 && (parar == false) && (posicionAnalisis < lineaAEstudiar.Length))
                {//Es decir mientras no halle un espacio en blanco...      para cuando ya se agregue el identificador esta condi de !palabra deberá cambiar puesto que sin importar que sea palabra o identificador, deberá parar... ahi si deberá usarse un bool, que cb de val para que ya no siga, media vez entre al if para usar el método de Excepción...

                    if (herramienta.determinarTipoCaracter(lineaAEstudiar[posicionAnalisis]) != 'd')
                    {
                        parar = true;
                        detallesDecimal[1] = excepcionLexico.excepcionDecimal(numeroLinea, posicionAnalisis, lineaAEstudiar);
                    }
                    if (parar == false)
                    {
                        detallesDecimal[2] += lineaAEstudiar[posicionAnalisis];
                    }//esto desaperecerá al tener al identificador, porque independientemente de lo que se tenga se debe parar

                    posicionAnalisis++;//el quedarse un paso adelante de donde realmente estaba no afecta y realmente así debe ser porque ese caracter ya se ha contemplado en el proceso de estudio...
                }
            }

            detallesDecimal[0] = Convert.ToString(posicionAnalisis);
            return detallesDecimal;
        }//listo

    }
}