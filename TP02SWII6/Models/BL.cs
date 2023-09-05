using System.ComponentModel;

namespace TP02_SWII6.Models
{
    public class BL
    {
        public int BLId { get; set; }
        public string Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }
        public ICollection<Container> Containers { get; set; }
    }
}
