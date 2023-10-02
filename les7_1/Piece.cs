namespace les7_1
{
    public class Piece
    {
        private string title;
        private string author;
        private string genre;
        private int year;
        private bool disposed = false;        
        public Piece(string title, string author, string genre, int year)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.year = year;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Назва п'єси: {title}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Жанр: {genre}");
            Console.WriteLine($"Рік: {year}");
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
        public void Dispose()
        {
            Dispose(true);            
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Об'єкт п'єси '{title}' було знищено.");                    
                }                
                disposed = true;
            }
        }     
        ~Piece()
        {
            Dispose(false);           
        }
    }
}
