namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdPersona { get; set; } 
        public Persona Persona { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
