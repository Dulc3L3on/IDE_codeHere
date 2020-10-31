using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Elementos;
using proyecto_IDE.Complementos_analizadores.Sintactico.Estados;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico
{
    class Transicion
    {//aquí se definirán todas las transicicones que se realizarán en la tabla de trancisiones        

        Produccion[,] producciones = new Produccion[29, 31];//se usará esta forma... conlleva menos trabajo        
            
        M principal; L ciclo;
        B bloque; E estructuraCondicional;
        B_ bloquePrima; E_ estructuraPrima;
        C cuerpo; O condicional;
        D declaracion; O_ condicionalPrima;
        Y igualacion; N condicion;
        A asignacion; Z cuerpoCondicion;
        I operacion; H iteracionNegacion;
        X sumaResta; G negacion;
        T multiplicacionDivision; V valVar;
        U menosUnario; F concatenacion;
        X_ sumaRestaPrima; F_ concatenacionPrima;
        T_ multiplicacionDivisionPrima; W impresion;
        S estado; R lectura;
        J numerico;

        public Transicion()
        {
            inicializarNoTerminales();
            entablar();
        }

        public void entablar() {
            producciones[0,0] = principal.darProduccion(0);
            producciones[0,30] = principal.darProduccion(1);
            producciones[1, 1] = bloque.darProduccion(0);
            producciones[2, 2] = bloquePrima.darProduccion(0);
            producciones[2, 4] = bloquePrima.darProduccion(0);
            producciones[2, 7] = bloquePrima.darProduccion(0);
            producciones[2, 11] = bloquePrima.darProduccion(0);
            producciones[2, 17] = bloquePrima.darProduccion(0);
            producciones[2, 18] = bloquePrima.darProduccion(0);
            producciones[2, 19] = bloquePrima.darProduccion(0);
            producciones[2, 20] = bloquePrima.darProduccion(0);
            producciones[2, 21] = bloquePrima.darProduccion(0);
            producciones[2, 23] = bloquePrima.darProduccion(0);
            producciones[2, 27] = bloquePrima.darProduccion(0);
            producciones[2, 28] = bloquePrima.darProduccion(0);
            producciones[2, 29] = bloquePrima.darProduccion(1);
            producciones[3, 2] = cuerpo.darProduccion(0);
            producciones[3, 4] = cuerpo.darProduccion(1);
            producciones[3, 7] = cuerpo.darProduccion(2);
            producciones[3, 11] = cuerpo.darProduccion(2);
            producciones[3, 17] = cuerpo.darProduccion(2);
            producciones[3, 18] = cuerpo.darProduccion(2);
            producciones[3, 19] = cuerpo.darProduccion(3);
            producciones[3, 20] = cuerpo.darProduccion(3);
            producciones[3, 21] = cuerpo.darProduccion(3);
            producciones[3, 23] = cuerpo.darProduccion(4);
            producciones[3, 27] = cuerpo.darProduccion(5);
            producciones[3, 28] = cuerpo.darProduccion(6);
            producciones[4, 2] = declaracion.darProduccion(0);
            producciones[5, 10] = igualacion.darProduccion(0);
            producciones[5, 14] = igualacion.darProduccion(1);
            producciones[5, 15] = igualacion.darProduccion(2);
            producciones[6, 4] = asignacion.darProduccion(0);          
            producciones[7, 7] = operacion.darProduccion(0);
            producciones[7, 11] = operacion.darProduccion(0);
            producciones[7, 17] = operacion.darProduccion(0);
            producciones[7, 18] = operacion.darProduccion(0);
            producciones[8, 7] = sumaResta.darProduccion(0);
            producciones[8, 11] = sumaResta.darProduccion(0);
            producciones[8, 17] = sumaResta.darProduccion(0);
            producciones[8, 18] = sumaResta.darProduccion(0);
            producciones[9, 7] = multiplicacionDivision.darProduccion(0);
            producciones[9, 11] = multiplicacionDivision.darProduccion(0);
            producciones[9, 17] = multiplicacionDivision.darProduccion(0);
            producciones[9, 18] = multiplicacionDivision.darProduccion(0);
            producciones[10, 7] = menosUnario.darProduccion(0);
            producciones[10, 11] = menosUnario.darProduccion(1);
            producciones[10, 17] = menosUnario.darProduccion(1);
            producciones[10, 18] = menosUnario.darProduccion(1);
            producciones[11, 6] = sumaRestaPrima.darProduccion(0);
            producciones[11, 7] = sumaRestaPrima.darProduccion(1);
            producciones[11, 12] = sumaRestaPrima.darProduccion(2);//este fue agregado por necesidad...
            producciones[11, 14] = sumaRestaPrima.darProduccion(2);
            producciones[12, 6] = multiplicacionDivisionPrima.darProduccion(0);
            producciones[12, 7] = multiplicacionDivisionPrima.darProduccion(0);
            producciones[12, 8] = multiplicacionDivisionPrima.darProduccion(1);
            producciones[12, 9] = multiplicacionDivisionPrima.darProduccion(2);
            producciones[12, 12] = multiplicacionDivisionPrima.darProduccion(0);//este fue agregado por necesidad...
            producciones[12, 14] = multiplicacionDivisionPrima.darProduccion(0);
            producciones[13, 11] = estado.darProduccion(0);
            producciones[13, 17] = estado.darProduccion(1);
            producciones[13, 18] = estado.darProduccion(1);
            producciones[14, 17] = numerico.darProduccion(0);
            producciones[14, 18] = numerico.darProduccion(1);
            producciones[15, 19] = ciclo.darProduccion(0);
            producciones[15, 20] = ciclo.darProduccion(1);
            producciones[15, 21] = ciclo.darProduccion(2);
            producciones[16, 23] = estructuraCondicional.darProduccion(0);
            producciones[17, 2] = estructuraPrima.darProduccion(0);
            producciones[17, 4] = estructuraPrima.darProduccion(0);
            producciones[17, 7] = estructuraPrima.darProduccion(0);
            producciones[17, 11] = estructuraPrima.darProduccion(0);
            producciones[17, 17] = estructuraPrima.darProduccion(0);
            producciones[17, 18] = estructuraPrima.darProduccion(0);
            producciones[17, 19] = estructuraPrima.darProduccion(0);
            producciones[17, 20] = estructuraPrima.darProduccion(0);
            producciones[17, 21] = estructuraPrima.darProduccion(0);
            producciones[17, 23] = estructuraPrima.darProduccion(0);
            producciones[17, 24] = estructuraPrima.darProduccion(1);
            producciones[17, 27] = estructuraPrima.darProduccion(0);
            producciones[17, 28] = estructuraPrima.darProduccion(0);
            producciones[17, 29] = estructuraPrima.darProduccion(0);
            producciones[18, 23] = condicional.darProduccion(0);
            producciones[19, 2] = condicionalPrima.darProduccion(0);
            producciones[19, 4] = condicionalPrima.darProduccion(0);
            producciones[19, 7] = condicionalPrima.darProduccion(0);
            producciones[19, 11] = condicionalPrima.darProduccion(0);
            producciones[19, 17] = condicionalPrima.darProduccion(0);
            producciones[19, 18] = condicionalPrima.darProduccion(0);
            producciones[19, 19] = condicionalPrima.darProduccion(0);
            producciones[19, 20] = condicionalPrima.darProduccion(0);
            producciones[19, 21] = condicionalPrima.darProduccion(0);
            producciones[19, 23] = condicionalPrima.darProduccion(1);
            producciones[19, 24] = condicionalPrima.darProduccion(0);
            producciones[19, 25] = condicionalPrima.darProduccion(2);
            producciones[19, 27] = condicionalPrima.darProduccion(0);
            producciones[19, 28] = condicionalPrima.darProduccion(0);
            producciones[19, 29] = condicionalPrima.darProduccion(0);
            producciones[20, 3] = condicion.darProduccion(0);
            producciones[20, 11] = condicion.darProduccion(0);
            producciones[20, 13] = condicion.darProduccion(0);
            producciones[21, 3] = cuerpoCondicion.darProduccion(0);
            producciones[21, 4] = cuerpoCondicion.darProduccion(1);
            producciones[21, 5] = cuerpoCondicion.darProduccion(1);
            producciones[21, 11] = cuerpoCondicion.darProduccion(2);
            producciones[21, 13] = cuerpoCondicion.darProduccion(1);
            producciones[22, 4] = iteracionNegacion.darProduccion(0);
            producciones[22, 5] = iteracionNegacion.darProduccion(0);
            producciones[22, 12] = iteracionNegacion.darProduccion(1);
            producciones[22, 13] = iteracionNegacion.darProduccion(2);
            producciones[22, 16] = iteracionNegacion.darProduccion(2);
            producciones[23, 12] = negacion.darProduccion(0);
            producciones[23, 13] = negacion.darProduccion(0);
            producciones[23, 16] = negacion.darProduccion(1);
            producciones[24, 5] = valVar.darProduccion(0);
            producciones[24, 4] = valVar.darProduccion(1);
            producciones[25, 5] = concatenacion.darProduccion(0);
            producciones[25, 4] = concatenacion.darProduccion(0);
            producciones[26, 6] = concatenacionPrima.darProduccion(0);
            producciones[26, 12] = concatenacionPrima.darProduccion(1);
            producciones[27, 27] = impresion.darProduccion(0);
            producciones[28, 28] = lectura.darProduccion(0);
        }

        public Produccion[,] darTablaTrancisiones() {
            return producciones;
        }//útil para el analizador sintáctico... pero, no es necesario, pues basta con recibir las producciones...

        public  ListaEnlazada<Elemento> darProduccion(int noTerminal, int token) {//Esto s valores los recibirá de los métodos del auto, de forma directa, luego de haber corroborado que el tope es un NT, con el correspondiente símbolo...
            if (producciones[noTerminal, token]!=null) {
                return producciones[noTerminal, token].darElementosProduccion();
            }
            return null;//xD, es que no podría devolver nada más a menos que cree algo xD
        }

        public void inicializarNoTerminales()
        {
            principal = new M(); numerico = new J();
            bloque = new B(false); ciclo = new L();
            bloquePrima = new B_(); estructuraCondicional = new E();
            cuerpo = new C(); estructuraPrima = new E_();
            declaracion = new D(); condicional = new O();
            igualacion = new Y(); condicionalPrima = new O_();
            asignacion = new A(); condicion = new N();
            operacion = new I(); cuerpoCondicion = new Z();
            sumaResta = new X(); iteracionNegacion = new H();
            multiplicacionDivision = new T(); negacion = new G();
            menosUnario = new U(); valVar = new V();
            sumaRestaPrima = new X_(); concatenacion = new F();
            multiplicacionDivisionPrima = new T_(); concatenacionPrima = new F_();
            estado = new S(); impresion = new W();
            lectura = new R();
        }

        //deberá crearse un método para rellenar los espacios que quedaron vacíos pero con la producción "erronea" que servirá para tratar los erroes... al menos eso pienso por ahora...
    }
}
