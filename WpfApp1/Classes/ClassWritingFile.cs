using System;
using System.IO;
using BFGM.Classes;
using BFGM.Models;
using WpfApp1.Constants;

namespace BFGM
{
    public class ClassWritingFile : ClassPathFile
    {
        public ClassWritingFile(ClassMain classMain) : base(classMain)
        {
        }

        #region Books
        public void WritingFileBooks(string nameBooksBook, string nameBooksAuthor)
        {
            FileStream fs = new FileStream(PathFiles.BooksPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameBooksBook);
            sw.WriteLine(nameBooksAuthor);

            classMain.ListBooks.Add(new ModelBook(nameBooksBook, nameBooksAuthor));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteBooks()
        {
            FileStream fs = new FileStream(PathFiles.BooksPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListBooks.Count; i++)
            {
                sw.WriteLine(classMain.ListBooks[i].NameBooksBook);
                sw.WriteLine(classMain.ListBooks[i].NameBooksAuthor);
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region Films
        public void WritingFileFilmsFilms(string nameFilmsFilm)
        {
            FileStream fs = new FileStream(PathFiles.FilmsFilmsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameFilmsFilm);
            classMain.ListFilmsFilms.Add(new ModelFilmsFilms(nameFilmsFilm));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteFilmsFilms()
        {
            FileStream fs = new FileStream(PathFiles.FilmsFilmsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListFilmsFilms.Count; i++)
            {
                sw.WriteLine(classMain.ListFilmsFilms[i].NameFilmsFilm);
            }
            sw.Close();
            fs.Close();
        }

        public void WritingFileFilmsSerials(string nameFilmsSerial)
        {
            FileStream fs = new FileStream(PathFiles.FilmsSerialsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameFilmsSerial);
            classMain.ListFilmsSerials.Add(new ModelFilmsSerial(nameFilmsSerial));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteFilmsSerials()
        {
            FileStream fs = new FileStream(PathFiles.FilmsSerialsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListFilmsSerials.Count; i++)
            {
                sw.WriteLine(classMain.ListFilmsSerials[i].NameFilmsSerial);
            }
            sw.Close();
            fs.Close();
        }

        public void WritingFileFilmsCartoons(string nameFilmsCartoon)
        {
            FileStream fs = new FileStream(PathFiles.FilmsCartoonsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameFilmsCartoon);
            classMain.ListFilmsCartoons.Add(new ModelFilmsCartoon(nameFilmsCartoon));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteFilmsCartoons()
        {
            FileStream fs = new FileStream(PathFiles.FilmsCartoonsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListFilmsCartoons.Count; i++)
            {
                sw.WriteLine(classMain.ListFilmsCartoons[i].NameFilmsCartoon);
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region Games
        public void WritingFileGamesPlayStation(string nameGamesPlayStation)
        {
            FileStream fs = new FileStream(PathFiles.GamesPlayStationPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameGamesPlayStation);
            classMain.ListGamesPlayStation.Add(new ModelGamesPlayStation(nameGamesPlayStation));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteGamesPlayStation()
        {
            FileStream fs = new FileStream(PathFiles.GamesPlayStationPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListGamesPlayStation.Count; i++)
            {
                sw.WriteLine(classMain.ListGamesPlayStation[i].NameGamesPlayStation);
            }
            sw.Close();
            fs.Close();
        }

        public void WritingFileGamesHorrors(string nameGamesHorror)
        {
            FileStream fs = new FileStream(PathFiles.GamesHorrorsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameGamesHorror);
            classMain.ListGamesHorrors.Add(new ModelGamesHorror(nameGamesHorror));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteGamesHorrors()
        {
            FileStream fs = new FileStream(PathFiles.GamesHorrorsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListGamesHorrors.Count; i++)
            {
                sw.WriteLine(classMain.ListGamesHorrors[i].NameGamesHorror);
            }
            sw.Close();
            fs.Close();
        }

        public void WritingFileGamesPlatformers(string nameGamesPlatformers)
        {
            FileStream fs = new FileStream(PathFiles.GamesPlatformersPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameGamesPlatformers);
            classMain.ListGamesPlatformers.Add(new ModelGamesPlatformer(nameGamesPlatformers));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteGamesPlatformers()
        {
            FileStream fs = new FileStream(PathFiles.GamesPlatformersPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListGamesPlatformers.Count; i++)
            {
                sw.WriteLine(classMain.ListGamesPlatformers[i].NameGamesPlatformer);
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region Music
        public void WritingFileMusicReleases(string nameMusicReleaseGroup, string nameMusicReleaseAlbum, DateTime nameMusicReleaseDate)
        {
            FileStream fs = new FileStream(PathFiles.MusicReleasesPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameMusicReleaseGroup);
            sw.WriteLine(nameMusicReleaseAlbum);
            sw.WriteLine(nameMusicReleaseDate.ToString("d MMMM yyyy"));
            classMain.ListMusicReleases.Add(new ModelMusicReleases(nameMusicReleaseGroup, nameMusicReleaseAlbum, nameMusicReleaseDate));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteMusicReleases()
        {
            FileStream fs = new FileStream(PathFiles.MusicReleasesPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListMusicReleases.Count; i++)
            {
                sw.WriteLine(classMain.ListMusicReleases[i].NameMusicReleasesGroup);
                sw.WriteLine(classMain.ListMusicReleases[i].NameMusicReleasesAlbum);
                sw.WriteLine(classMain.ListMusicReleases[i].NameMusicReleasesDate.ToString("d MMMM yyyy"));
            }
            sw.Close();
            fs.Close();
        }

        public void WritingFileMusicWaiting(string nameMusicWaiting)
        {
            FileStream fs = new FileStream(PathFiles.MusicWaitingPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameMusicWaiting);
            classMain.ListMusicWaiting.Add(new ModelMusicWaiting(nameMusicWaiting));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteMusicWaiting()
        {
            FileStream fs = new FileStream(PathFiles.MusicWaitingPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListMusicWaiting.Count; i++)
            {
                sw.WriteLine(classMain.ListMusicWaiting[i].NameMusicWaiting);
            }
            sw.Close();
            fs.Close();
        }

        public void WritingFileMusicListen(string nameMusicListen)
        {
            FileStream fs = new FileStream(PathFiles.MusicListenPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nameMusicListen);
            classMain.ListMusicListen.Add(new ModelMusicListen(nameMusicListen));

            sw.Close();
            fs.Close();
        }
        public void RewritingFileAfterDeleteMusicListen()
        {
            FileStream fs = new FileStream(PathFiles.MusicListenPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListMusicListen.Count; i++)
            {
                sw.WriteLine(classMain.ListMusicListen[i].NameMusicListen);
            }
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
