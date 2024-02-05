namespace RectangleApp.Models
{
    public class RectangleServiceInMemory : IRectangleService
    {
        private readonly List<Rectangle> _rectangles = new List<Rectangle>();
        private int _nextId = 1;

        public void AddRectangle(Rectangle rectangle)
        {
            rectangle.Id = _nextId++;
            _rectangles.Add(rectangle);
        }

        public IEnumerable<Rectangle> GetAllRectangles()
        {
            return _rectangles;
        }
        public Rectangle GetRectangleById(int id)
        {
            return _rectangles.FirstOrDefault(r => r.Id == id);
        }


        public void DeleteRectangle(int id)
        {
            _rectangles.RemoveAll(r => r.Id == id);
        }


        public void UpdateRectangle(int id, Rectangle rectangle)
        {
            var index = _rectangles.FindIndex(r => r.Id == id);
            if (index != -1)
            {
                _rectangles[index] = rectangle;
            }
        }
    }
}
