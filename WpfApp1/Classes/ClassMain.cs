using System;
using System.Collections.Generic;
using System.IO;
using BFGM.Models;
using WpfApp1.Constants;

namespace BFGM.Classes
{
    public class ClassMain
    {
        #region Lists
        public List<Book> ListBooks { get; } = new List<Book>();

        public List<Film> ListFilms { get; } = new List<Film>();
        public List<Serial> ListSerials { get; } = new List<Serial>();
        public List<Cartoon> ListCartoons { get; } = new List<Cartoon>();

        public List<PlayStation> ListPlayStation { get; } = new List<PlayStation>();
        public List<Horror> ListHorrors { get; } = new List<Horror>();
        public List<Platformer> ListPlatformers { get; } = new List<Platformer>();

        public List<Release> ListReleases { get; } = new List<Release>();
        public List<Wait> ListWait { get; } = new List<Wait>();
        public List<Listen> ListListen { get; } = new List<Listen>();
        #endregion

        #region GiveToList()
        public void GiveToListBooks(string nameBooksBook, string nameBooksAuthor)
        {
            ListBooks.Add(new Book(nameBooksBook, nameBooksAuthor));
        }

        public void GiveToListFilms(string nameFilmsFilm)
        {
            ListFilms.Add(new Film(nameFilmsFilm));
        }
        public void GiveToListSerials(string nameFilmsSerials)
        {
            ListSerials.Add(new Serial(nameFilmsSerials));
        }
        public void GiveToListCartoons(string nameFilmsCartoons)
        {
            ListCartoons.Add(new Cartoon(nameFilmsCartoons));
        }

        public void GiveToListPlayStation(string nameGamesPlayStation)
        {
            ListPlayStation.Add(new PlayStation(nameGamesPlayStation));
        }
        public void GiveToListHorrors(string nameGamesHorror)
        {
            ListHorrors.Add(new Horror(nameGamesHorror));
        }
        public void GiveToListPlatformers(string nameGamesPlatformer)
        {
            ListPlatformers.Add(new Platformer(nameGamesPlatformer));
        }

        public void GiveToListReleases(Release release)
        {
            ListReleases.Add(release);
        }
        public void GiveToListWait(string nameMusicWaiting)
        {
            ListWait.Add(new Wait(nameMusicWaiting));
        }
        public void GiveToListListen(string nameMusicListen)
        {
            ListListen.Add(new Listen(nameMusicListen));
        }
        #endregion

        #region Delete()
        public void DeleteBook(Book book)
        {
            for (int i = 0; i < ListBooks.Count; i++)
            {
                if (ListBooks[i].Title == book.Title && ListBooks[i].Author == book.Author)
                {
                    ListBooks.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteFilm(string selectedName)
        {
            for (int i = 0; i < ListFilms.Count; i++)
            {
                if (ListFilms[i].Title == selectedName)
                {
                    ListFilms.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteSerial(string selectedName)
        {
            for (int i = 0; i < ListSerials.Count; i++)
            {
                if (ListSerials[i].Title == selectedName)
                {
                    ListSerials.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteCartoon(string selectedName)
        {
            for (int i = 0; i < ListCartoons.Count; i++)
            {
                if (ListCartoons[i].Title == selectedName)
                {
                    ListCartoons.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeletePlayStation(string selectedName)
        {
            for (int i = 0; i < ListPlayStation.Count; i++)
            {
                if (ListPlayStation[i].Title == selectedName)
                {
                    ListPlayStation.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteHorrors(string selectedName)
        {
            for (int i = 0; i < ListHorrors.Count; i++)
            {
                if (ListHorrors[i].Title == selectedName)
                {
                    ListHorrors.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeletePlatformers(string selectedName)
        {
            for (int i = 0; i < ListPlatformers.Count; i++)
            {
                if (ListPlatformers[i].Title == selectedName)
                {
                    ListPlatformers.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteRelease(Release release)
        {
            for (int i = 0; i < ListReleases.Count; i++)
            {
                if (ListReleases[i].Band == release.Band && ListReleases[i].Album == release.Album && ListReleases[i].Date == release.Date)
                {
                    ListReleases.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteWait(string selectedName)
        {
            for (int i = 0; i < ListWait.Count; i++)
            {
                if (ListWait[i].Band == selectedName)
                {
                    ListWait.RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteListen(string selectedName)
        {
            for (int i = 0; i < ListListen.Count; i++)
            {
                if (ListListen[i].Band == selectedName)
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
            for (int i = 0; i < ListReleases.Count; i++)
            {
                if (ListReleases[i].Band == oldRelease.Band && ListReleases[i].Album == oldRelease.Album && ListReleases[i].Date == oldRelease.Date)
                {
                    ListReleases.RemoveAt(i);
                    ListReleases.Insert(i, newRelease);
                    break;
                }
            }
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
