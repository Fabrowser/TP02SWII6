namespace TP02_SWII6.Models
{
    public class Container
    {

        public int ContainerId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }
        public int BLId { get; set; }
        public BL BL { get; set; }
    }
}
