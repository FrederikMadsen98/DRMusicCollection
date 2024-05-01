using DRMusicCollection.Model;
using System.Linq;

namespace DRMusicCollection.Repository
{
    public class MusicRepository
    {
        private static string newTitle = "Default Title";
        private static readonly List<Music> Data = new()
        {

                new Music() {Title="House of Rock", Artist="Elvis", Duration = 3, PublicationYear=1989},
                new Music() {Title="House of Pop", Artist="Frederik", Duration = 4, PublicationYear=1990},
                new Music() {Title="House of Jazz", Artist="Awais", Duration = 5, PublicationYear=1991},
                new Music() {Title="House of Metal", Artist="Ibo", Duration = 6, PublicationYear=1992}
        };
        public List<Music> GetAll(string title = null, string SortBy = null)
        {
            List<Music> musics = new (Data);
            if(title != null)
            {
                musics = musics.FindAll(music => music.Title.StartsWith(title));

            }
            if (SortBy != null)
            {
                switch(SortBy.ToLower())
                {
                    case "title":
                        musics = musics.OrderBy(music => music.Title).ToList();
                        break;
                    case "artist":
                        musics = musics.OrderBy(music => music.Artist).ToList();
                        break;
                    case "duration":
                        musics = musics.OrderBy(music => music.Duration).ToList();
                        break;
                    case "publicationYear":
                        musics = musics.OrderBy(music => music.PublicationYear).ToList();
                        break;
                }
            }
            return musics;
        }
        public Music? GetById(int id)
        {
            return Data.Find(music => music.Id == id);
        }
        public Music Add(Music newMusic)
        {
            newMusic.Validate();
            Data.Add(newMusic);
            return newMusic;
        }
        public Music Delete(string title)
        {
            Music music = Data.Find(music1 => music1.Title == title);
            if (music == null) return null;
            Data.Remove(music);
            return music;
        }
        public Music? Update(int id, Music updates)
        {
            updates.Validate();
            Music? music = Data.Find(music1 =>music1.Id == id);
            if (music == null) return null;
            music.Title = updates.Title;
            music.Artist = updates.Artist;
            music.Duration = updates.Duration;
            music.PublicationYear = updates.PublicationYear;
            return music;
        }

    }
}
