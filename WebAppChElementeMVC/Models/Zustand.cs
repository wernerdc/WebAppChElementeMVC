namespace WebAppChElementeMVC.Models
{
    public class Zustand
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        // navigation-properties
        public List<Element> Elemente { get; set; } = new List<Element>();
    }
}
