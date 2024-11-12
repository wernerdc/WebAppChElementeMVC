using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppChElementeMVC.Models
{
    public class Periode
    {
        public int Id { get; set; }
        [Range(1,7)]
        public int Nummer { get; set; }
        //[NotMapped]
        public string Name { get; set; } = string.Empty;

        // navigation-properties
        public List<Element> Elemente { get; set; } = new List<Element>();

        public void SetName() 
        {
            switch (Nummer)
            {
                case 1:
                    Name = "I";
                    break;
                case 2:
                    Name = "II";
                    break;
                case 3:
                    Name = "III";
                    break;
                case 4:
                    Name = "IV";
                    break;
                case 5:
                    Name = "V";
                    break;
                case 6:
                    Name = "VI";
                    break;
                case 7:
                    Name = "VII";
                    break;
                default:
                    break;
            }
        }
    }
}
