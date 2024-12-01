namespace webAscensor.Models
{
    public class AscensorStatus
    {

        public int CurrentFloor { get; set; }
        public bool IsMoving { get; set; }
        public bool DoorsOpen { get; set; }
        public string? Description { get; set; }

    }
}
