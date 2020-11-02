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

        Produccion[,] producciones = new Produccion[30, 28];//ya no se requieren alternativas xD pues el problema ya está resuelto [por medio de un modo más facilito xd]
            
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
        S estado; R lectura; Q multipleCondicion; K multipleComparacion;
  

        public Transicion()
        {
            inicializarNoTerminales();
            entablar();
        }

        public void entablar() {
            producciones[0,0] = principal.darProduccion(0);
            producciones[0,27] = principal.darProduccion(1);//2
            producciones[1, 1] = bloque.darProduccion(0);//1
            producciones[2, 2] = bloquePrima.darProduccion(0);
            producciones[2, 3] = bloquePrima.darProduccion(0);
            producciones[2, 6] = bloquePrima.darProduccion(0);
            producciones[2, 10] = bloquePrima.darProduccion(0);
            producciones[2, 16] = bloquePrima.darProduccion(0);
            producciones[2, 17] = bloquePrima.darProduccion(0);
            producciones[2, 18] = bloquePrima.darProduccion(0);
            producciones[2, 20] = bloquePrima.darProduccion(0);
            producciones[2, 24] = bloquePrima.darProduccion(0);
            producciones[2, 25] = bloquePrima.darProduccion(0);
            producciones[2, 26] = bloquePrima.darProduccion(1);//11
            producciones[3, 2] = cuerpo.darProduccion(0);
            producciones[3, 3] = cuerpo.darProduccion(1);//dependerá del token siguiente...
            producciones[3, 6] = cuerpo.darProduccion(2);
            producciones[3, 10] = cuerpo.darProduccion(2);
            producciones[3, 16] = cuerpo.darProduccion(3);
            producciones[3, 17] = cuerpo.darProduccion(3);
            producciones[3, 18] = cuerpo.darProduccion(3);
            producciones[3, 20] = cuerpo.darProduccion(4);
            producciones[3, 24] = cuerpo.darProduccion(5);
            producciones[3, 25] = cuerpo.darProduccion(6);//10                
            producciones[4, 2] = declaracion.darProduccion(0);//1
            producciones[5, 9] = igualacion.darProduccion(0);
            producciones[5, 13] = igualacion.darProduccion(1);
            producciones[5, 14] = igualacion.darProduccion(2);//3
            producciones[6, 3] = asignacion.darProduccion(0);//1        
            producciones[7, 3] = operacion.darProduccion(0);
            producciones[7, 4] = operacion.darProduccion(0);
            producciones[7, 6] = operacion.darProduccion(0);
            producciones[7, 10] = operacion.darProduccion(0);//4
            producciones[8, 3] = sumaResta.darProduccion(0);
            producciones[8, 4] = sumaResta.darProduccion(0);
            producciones[8, 6] = sumaResta.darProduccion(0);
            producciones[8, 10] = sumaResta.darProduccion(0);//4
            producciones[9, 3] = multiplicacionDivision.darProduccion(0);
            producciones[9, 4] = multiplicacionDivision.darProduccion(0);
            producciones[9, 6] = multiplicacionDivision.darProduccion(0);
            producciones[9, 10] = multiplicacionDivision.darProduccion(0);//4
            producciones[10, 3] = menosUnario.darProduccion(1);
            producciones[10, 4] = menosUnario.darProduccion(1);
            producciones[10, 6] = menosUnario.darProduccion(0);
            producciones[10, 10] = menosUnario.darProduccion(1);//4
            producciones[11, 5] = sumaRestaPrima.darProduccion(0);
            producciones[11, 6] = sumaRestaPrima.darProduccion(1);
            producciones[11, 11] = sumaRestaPrima.darProduccion(2);//Ya no fue necesidad xD
            producciones[11, 13] = sumaRestaPrima.darProduccion(2);//4
            producciones[12, 5] = multiplicacionDivisionPrima.darProduccion(0);
            producciones[12, 6] = multiplicacionDivisionPrima.darProduccion(0);
            producciones[12, 7] = multiplicacionDivisionPrima.darProduccion(1);
            producciones[12, 8] = multiplicacionDivisionPrima.darProduccion(2);
            producciones[12, 11] = multiplicacionDivisionPrima.darProduccion(0);//este fue agregado por necesidad...
            producciones[12, 13] = multiplicacionDivisionPrima.darProduccion(0);//6
            producciones[13, 3] = estado.darProduccion(0);
            producciones[13, 4] = estado.darProduccion(0);
            producciones[13, 10] = estado.darProduccion(1);//se elimino J :'(       3
            producciones[14, 16] = ciclo.darProduccion(0);
            producciones[14, 17] = ciclo.darProduccion(1);
            producciones[14, 18] = ciclo.darProduccion(2);//3
            producciones[15, 20] = estructuraCondicional.darProduccion(0);//1
            producciones[16, 2] = estructuraPrima.darProduccion(0);
            producciones[16, 3] = estructuraPrima.darProduccion(0);
            producciones[16, 6] = estructuraPrima.darProduccion(0);
            producciones[16, 10] = estructuraPrima.darProduccion(0);
            producciones[16, 16] = estructuraPrima.darProduccion(0);
            producciones[16, 17] = estructuraPrima.darProduccion(0);
            producciones[16, 18] = estructuraPrima.darProduccion(0);
            producciones[16, 20] = estructuraPrima.darProduccion(0);
            producciones[16, 21] = estructuraPrima.darProduccion(1);
            producciones[16, 24] = estructuraPrima.darProduccion(0);
            producciones[16, 25] = estructuraPrima.darProduccion(0);
            producciones[16, 26] = estructuraPrima.darProduccion(0);//12            
            producciones[17, 20] = condicional.darProduccion(0);//1
            producciones[18, 2] = condicionalPrima.darProduccion(0);
            producciones[18, 3] = condicionalPrima.darProduccion(0);
            producciones[18, 6] = condicionalPrima.darProduccion(0);
            producciones[18, 10] = condicionalPrima.darProduccion(0);
            producciones[18, 16] = condicionalPrima.darProduccion(0);
            producciones[18, 17] = condicionalPrima.darProduccion(0);
            producciones[18, 18] = condicionalPrima.darProduccion(0);
            producciones[18, 20] = condicionalPrima.darProduccion(1);
            producciones[18, 21] = condicionalPrima.darProduccion(0);
            producciones[18, 22] = condicionalPrima.darProduccion(2);
            producciones[18, 24] = condicionalPrima.darProduccion(0);
            producciones[18, 25] = condicionalPrima.darProduccion(0);
            producciones[18, 26] = condicionalPrima.darProduccion(0);//13            
            producciones[19, 3] = condicion.darProduccion(0);
            producciones[19, 4] = condicion.darProduccion(0);
            producciones[19, 10] = condicion.darProduccion(0);            
            producciones[19, 12] = condicion.darProduccion(0);//4
            producciones[20, 11] = multipleCondicion.darProduccion(1);
            producciones[20, 23] = multipleCondicion.darProduccion(0);//2
            producciones[21, 3] = cuerpoCondicion.darProduccion(0);
            producciones[21, 4] = cuerpoCondicion.darProduccion(0);
            producciones[21, 10] = cuerpoCondicion.darProduccion(1);            
            producciones[21, 12] = cuerpoCondicion.darProduccion(0);//4            
            producciones[22, 11] = multipleComparacion.darProduccion(1);
            producciones[22, 15] = multipleComparacion.darProduccion(0);
            producciones[22, 23] = multipleComparacion.darProduccion(1);//3
            producciones[23, 3] = iteracionNegacion.darProduccion(0);
            producciones[23, 4] = iteracionNegacion.darProduccion(0);            
            producciones[23, 12] = iteracionNegacion.darProduccion(0);//3
            producciones[24, 3] = negacion.darProduccion(0);
            producciones[24, 4] = negacion.darProduccion(0);
            producciones[24, 10] = negacion.darProduccion(0);
            producciones[24, 12] = negacion.darProduccion(1);//4
            producciones[25, 3] = valVar.darProduccion(0);
            producciones[25, 4] = valVar.darProduccion(1);//2
            producciones[26, 3] = concatenacion.darProduccion(0);
            producciones[26, 4] = concatenacion.darProduccion(0);//2
            producciones[27, 5] = concatenacionPrima.darProduccion(0);
            producciones[27, 11] = concatenacionPrima.darProduccion(1);//2
            producciones[28, 24] = impresion.darProduccion(0);//1
            producciones[29, 25] = lectura.darProduccion(0);//1
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
            principal = new M();   
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
            lectura = new R(); multipleCondicion = new Q(); multipleComparacion = new K();
        }

        //deberá crearse un método para rellenar los espacios que quedaron vacíos pero con la producción "erronea" que servirá para tratar los erroes... al menos eso pienso por ahora...
    }
}
