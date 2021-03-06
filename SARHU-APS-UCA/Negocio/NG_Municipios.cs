﻿using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Municipios
    {
        private DT_Municipios dtMunicipios = DT_Municipios.Instanciar();

        private static NG_Departamentos ngDepartamentos = NG_Departamentos.Instanciar();

        private static NG_Municipios ngMunicipios = null;

        private NG_Municipios()
        {
            // Singleton
        }

        public static NG_Municipios Instanciar()
        {
            if (ngMunicipios == null)
            {
                ngMunicipios = new NG_Municipios();
            }
            return ngMunicipios;
        }

        public List<Municipio> Listar()
        {
            return dtMunicipios.Listar();
        }

        public List<Municipio> ObtenerMunicipios(int DepartamentoId)
        {
            return dtMunicipios.ObtenerMunicipios(DepartamentoId);
        }

        public Municipio Consultar(int id)
        {
            return dtMunicipios.Consultar(id);
        }

        public Departamento ObtenerDepartamento(int MunicipioId)
        {
            Municipio m = Consultar(MunicipioId);
            return ngDepartamentos.Consultar(m.DepartamentoId);
        }
    }
}
