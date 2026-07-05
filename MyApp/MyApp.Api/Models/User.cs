#pragma warning disable IDE0130 // El espacio de nombres no coincide con la estructura de carpetas

namespace MyApp.Api.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
