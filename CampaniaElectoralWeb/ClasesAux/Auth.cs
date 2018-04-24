using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CampaniaElectoral.ClasesAux
{
    
        public class Auth : IPrincipal, IMyAppPrincipal
        {
            private IIdentity _identity;
            private string[] _roles;
            private string _Perfil;

            public IIdentity Identity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Auth(IIdentity identity, string[] roles)
            {
                _identity = identity;
                _roles = roles;
                //_Perfil = Perfil;
            }
            //...
            //Propiedad que utilizaremos para saber si el usuario tiene o no habilitado
            //el acceso a una determinada página
            public bool IsPageEnabled(string pageName)
            {
            //return Perfiles.IsPageEnabled(pageName, this._Perfil);
            return true;
            }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
        //...
    }

    internal interface IMyAppPrincipal
    {
    }
}