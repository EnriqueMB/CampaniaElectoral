using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;


namespace CampaniaElectoral.ClasesAux
{
    public static class Autenticacion
    {

        //public static bool Autenticar(string Usuario, string Password)
        //{
        //    bool Band = false;


        //    //DB
        //    if (Usuario.Equals("root") && Password.Equals("123456"))
        //    {
        //        Band = true;
        //        //asignar datos a la clase usuario
                   
        //    //lista de modulos que tiene asignado
        //    //for -- separar lista de Menu y submeno


        //    }
        //    return Band;
        //}
        public static WN_Usuario Autenticar(WN_Usuario user)
        {
            DA_AutenticarNegocio autnegocio = new DA_AutenticarNegocio();
            return autnegocio.Autenticar(user);
        }

        public static WN_Usuario AutenticarSeccion(WN_Usuario user)
        {
            DA_AutenticarNegocio autnegocio = new DA_AutenticarNegocio();
            return autnegocio.AutenticarSeccion(user);
        }
    }
}