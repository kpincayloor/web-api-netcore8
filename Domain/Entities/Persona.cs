﻿namespace Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? NumeroCompleto => $"{NumeroIdentificacion} - {TipoIdentificacion}";
        public string? NombreCompleto => $"{Nombres} {Apellidos}";
    }
}
