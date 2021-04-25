﻿using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class Socio
    {
        public int SocioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDeDocumentoId { get; set; }
        public TipoDeDocumento TipoDeDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public bool Sancionado { get; set; }
        public bool Activo { get; set; }

    }
}