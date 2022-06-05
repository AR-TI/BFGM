using BFGM.Models;
using System.Collections.Generic;
using System.IO;
using WpfApp1.Constants;

namespace BFGM.Classes
{
    public class ClassMain
    {
        #region Lists
        public List<Book> ListBooks { get; set; } = new List<Book>();

        public List<Film> ListFilms { get; set; } = new List<Film>();
        public List<Serial> ListSerials { get; set; } = new List<Serial>();
        public List<Cartoon> ListCartoons { get; set; } = new List<Cartoon>();

        public List<PlayStation> ListPlayStation { get; set; } = new List<PlayStation>();
        public List<Horror> ListHorrors { get; set; } = new List<Horror>();
        public List<Platformer> ListPlatformers { get; set; } = new List<Platformer>();

        public List<Release> ListReleases { get; set; } = new List<Release>();
        public List<Wait> ListWait { get; set; } = new List<Wait>();
        public List<Listen> ListListen { get; set; } = new List<Listen>();
        #endregion

        #region Add()
        public void Add<T, K>(T list, K model) where T : List<K>
        {
            list.Add(model);
        }

        public void AddBook(Book book)
        {
            ListBooks.Add(book);
        }

        public void AddFilm(Film film)
        {
            ListFilms.Add(film);
        }
        public void AddSerial(Serial serial)
        {
            ListSerials.Add(serial);
        }
        public void AddCartoon(Cartoon cartoon)
        {
            ListCartoons.Add(cartoon);
        }

        public void AddPlayStation(PlayStation playStation)
        {
            ListPlayStation.Add(playStation);
        }
        public void AddHorror(Horror horror)
        {
            ListHorrors.Add(horror);
        }
        public void AddPlatformer(Platformer platformer)
        {
            ListPlatformers.Add(platformer);
        }

        public void AddRelease(Release release)
        {
            ListReleases.Add(release);
        }
        public void AddWait(Wait wait)
        {
            ListWait.Add(wait);
        }
        public void AddListen(Listen listen)
        {
            ListListen.Add(listen);
        }
        #endregion

        #region Delete()
        public void DeleteBook(Book book)
        {
            ListBooks.Remove(book);
        }

        public void DeleteFilm(string name)
        {
            for (int i = 0; i < ListFilms.Count; i++)
            {
                if (ListFilms[i].Title == name)
                {
                    ListFilms.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteSerial(string name)
        {
            for (int i = 0; i < ListSerials.Count; i++)
            {
                if (ListSerials[i].Title == name)
                {
                    ListSerials.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteCartoon(string name)
        {
            for (int i = 0; i < ListCartoons.Count; i++)
            {
                if (ListCartoons[i].Title == name)
                {
                    ListCartoons.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeletePlayStation(string name)
        {
            for (int i = 0; i < ListPlayStation.Count; i++)
            {
                if (ListPlayStation[i].Title == name)
                {
                    ListPlayStation.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteHorrors(string name)
        {
            for (int i = 0; i < ListHorrors.Count; i++)
            {
                if (ListHorrors[i].Title == name)
                {
                    ListHorrors.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeletePlatformers(string name)
        {
            for (int i = 0; i < ListPlatformers.Count; i++)
            {
                if (ListPlatformers[i].Title == name)
                {
                    ListPlatformers.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteRelease(Release release)
        {
            ListReleases.Remove(release);
        }
        public void DeleteWait(string name)
        {
            for (int i = 0; i < ListWait.Count; i++)
            {
                if (ListWait[i].Band == name)
                {
                    ListWait.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteListen(string name)
        {
            for (int i = 0; i < ListListen.Count; i++)
            {
                if (ListListen[i].Band == name)
                {
                    ListListen.RemoveAt(i);
                    break;
                }
            }
        }
        #endregion

        #region Edit()
        public void EditRelease(Release oldRelease, Release newRelease)
        {
            int index = ListReleases.IndexOf(oldRelease);
            ListReleases.Remove(oldRelease);
            ListReleases.Insert(index, newRelease);
        }
        #endregion

        public void CheckDirectoryAndFilesExist()
        {
            if (!Directory.Exists(@"Data\"))
                Directory.CreateDirectory(@"Data\");
            if (!File.Exists(PathFiles.BooksPath))
                File.Create(PathFiles.BooksPath);
            if (!File.Exists(PathFiles.FilmsPath))
                File.Create(PathFiles.FilmsPath);
            if (!File.Exists(PathFiles.SerialsPath))
                File.Create(PathFiles.SerialsPath);
            if (!File.Exists(PathFiles.CartoonsPath))
                File.Create(PathFiles.CartoonsPath);
            if (!File.Exists(PathFiles.PlayStationPath))
                File.Create(PathFiles.PlayStationPath);
            if (!File.Exists(PathFiles.HorrorsPath))
                File.Create(PathFiles.HorrorsPath);
            if (!File.Exists(PathFiles.PlatformersPath))
                File.Create(PathFiles.PlatformersPath);
            if (!File.Exists(PathFiles.ReleasesPath))
                File.Create(PathFiles.ReleasesPath);
            if (!File.Exists(PathFiles.ListenPath))
                File.Create(PathFiles.ListenPath);
            if (!File.Exists(PathFiles.WaitPath))
                File.Create(PathFiles.WaitPath);
        }
    }
}
