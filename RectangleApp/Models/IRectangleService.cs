namespace RectangleApp.Models
{
    public interface IRectangleService
    {
        void AddRectangle(Rectangle rectangle);
        IEnumerable<Rectangle> GetAllRectangles();
        Rectangle GetRectangleById(int id);
        void DeleteRectangle(int id);
        void UpdateRectangle(int id, Rectangle rectangle);
    }
}
