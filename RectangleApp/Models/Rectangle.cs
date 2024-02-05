namespace RectangleApp.Models
{
    public class Rectangle
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string HeightUnit { get; set; }
        public string WidthUnit { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
