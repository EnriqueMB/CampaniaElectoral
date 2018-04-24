﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_DatosRedesSociales
    {
        private string _IDRedSocial;
        public string IDRedSocial
        {
            get { return _IDRedSocial; }
            set { _IDRedSocial = value; }
        }

        private int _IDTipoRedSocial;
        public int IDTipoRedSocial
        {
            get { return _IDTipoRedSocial; }
            set { _IDTipoRedSocial = value; }
        }

        private string _Cuenta;
        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _UrlBase;
        public string UrlBase
        {
            get { return _UrlBase; }
            set { _UrlBase = value; }
        }

        private string _Class;
        public string Class
        {
            get { return _Class; }
            set { _Class = value; }
        }

        private string _FaClass;
        public string FaClass
        {
            get { return _FaClass; }
            set { _FaClass = value; }
        }
        
        private string _Conexion;
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private string _Candidato;
        public string Candidato
        {
            get { return _Candidato; }
            set { _Candidato = value; }
        }


        private int _Resultado;
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private bool _Completado;
        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }

        private string _IDUsuario;
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private DataTable _TablaDatos;
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private bool _NuevoRegistro;
        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }
    }
}
