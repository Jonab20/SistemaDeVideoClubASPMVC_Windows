﻿using SistemaDeVideoClubASPMVC.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class LocalidadesEntityTypeConfigurations:EntityTypeConfiguration<Localidad>
    {
        public LocalidadesEntityTypeConfigurations()
        {
            ToTable("Localidades");
        }
    }
}
