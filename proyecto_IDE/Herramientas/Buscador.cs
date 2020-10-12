using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores;

namespace proyecto_IDE.Herramientas
{
    class Buscador
    {
        ListaEnlazada<String> listadoCoincidentes = new ListaEnlazada<String>();
        TablaDeSimbolos tabla = new TablaDeSimbolos();

        public ListaEnlazada<String> hallarCoincidentes(String porcion)
        {
            listadoCoincidentes.limpiarLista();

            buscarEnTipados(porcion);
            buscarEnBooleanos(porcion);
            buscarEnFuncionales(porcion);

            return listadoCoincidentes;
        }

        private void buscarEnTipados(String porcion)
        {
            String[] tipos = tabla.darTipos();

            for (int tipadoActual = 0; tipadoActual < tipos.Length; tipadoActual++)
            {
                if (tipos[tipadoActual].StartsWith(porcion))
                {
                    listadoCoincidentes.anadirAlFinal(porcion);
                }
            }
        }

        private void buscarEnBooleanos(String porcion)
        {
            String[] booleanos = tabla.darBooleanos();

            for (int booleanActual = 0; booleanActual < booleanos.Length; booleanActual++)
            {
                if (booleanos[booleanActual].StartsWith(porcion))
                {
                    listadoCoincidentes.anadirAlFinal(porcion);
                }
            }
        }

        private void buscarEnFuncionales(String porcion)
        {
            String[] funcionales = tabla.darFuncionales();

            for (int funcionalActual = 0; funcionalActual < funcionales.Length; funcionalActual++)
            {
                if (funcionales[funcionalActual].StartsWith(porcion))
                {
                    listadoCoincidentes.anadirAlFinal(porcion);
                }
            }

        }
    }
}
