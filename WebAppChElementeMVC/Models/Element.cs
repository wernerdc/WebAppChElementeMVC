namespace WebAppChElementeMVC.Models
{
    public class Element
    {
        public int Id { get; set; }
        public int GruppeId { get; set; }
        public int PeriodeId { get; set; }
        public int ZustandId { get; set; }

        public int Ordnungszahl { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        
        // navigation-properties
        public Gruppe? Gruppe { get; set; }
        public Periode? Periode { get; set; }
        public Zustand? Zustand { get; set; }
    }
}
