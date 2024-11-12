namespace WebAppChElementeMVC.Models
{
    public class Gruppe
    {
        public int Id { get; set; }
        public int Nummer { get; set; }

        // navigation-properties
        public List<Element> Elemente { get; set; } = new List<Element>();
    }
}
