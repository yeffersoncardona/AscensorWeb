namespace webAscensor.Models
{
    public class AscensorRequest
    {
        public int Floor { get; set; }
        public string Direction { get; set; } // "up" or "down"
    }
}
