namespace DRMusicCollection.Model
{
    public class Music
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public int PublicationYear { get; set; }

        public override string ToString()
        {
            return $"{Title}, {Artist}, {Duration}, {PublicationYear}";
        }

        public void Validate()
        {
            {
                if (Title == null)
                    throw new ArgumentNullException(nameof(Title), "Title is null");
                if (Title.Length < 2)
                    throw new ArgumentException("Title must be at least 2 characters:" + Title);
                if (Duration < 0)
                    throw new ArgumentOutOfRangeException(nameof(Duration), "Duration must be above 0 seconds:" + Duration);
            }
        }
    }
}
