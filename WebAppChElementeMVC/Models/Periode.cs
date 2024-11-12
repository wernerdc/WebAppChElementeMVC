namespace WebAppChElementeMVC.Models
{
    public class Periode
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public string Name { get; set; }

        // navigation-properties
        public List<Element> Elemente { get; set; } = new List<Element>();
    }
}
