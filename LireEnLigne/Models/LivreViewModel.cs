namespace LireEnLigne.Models
{
    public class LivreViewModel
    {
        public required Livre Livre { get; set; }
        public required List<Exemplaire> Exemplaires { get; set; }
    }
}
