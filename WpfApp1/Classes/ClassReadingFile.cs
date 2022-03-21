using BFGM.Classes;
using System;
using System.IO;
using System.Threading.Tasks;
using WpfApp1.Constants;

namespace BFGM
{
    public class ClassReadingFile : ClassPathFile
    {
        public ClassReadingFile(ClassMain classMain) : base(classMain)
        {
        }

        public void ReadingFileBooksBooks()
        {
            FileStream fs = new FileStream(PathFiles.BooksPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameBooksBook = sr.ReadLine();
                string nameBooksAuthor = sr.ReadLine();
                classMain.GiveToListBooks(nameBooksBook, nameBooksAuthor);

                //classMain.Add(new Models.ModelBook()
                //{
                //    NameBooksBook = sr.ReadLine(),
                //    NameBooksAuthor = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }

        public void ReadingFileFilmsFilms()
        {
            FileStream fs = new FileStream(PathFiles.FilmsFilmsPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameFilmsFilm = sr.ReadLine();
                classMain.GiveToListFilmsFilm(nameFilmsFilm);

                //listFilmsFilms.Add(new Models.ModelFilmsFilms()
                //{
                //    NameFilmsFilm = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }
        public void ReadingFileFilmsSerials()
        {
            FileStream fs = new FileStream(PathFiles.FilmsSerialsPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameFilmsSerials = sr.ReadLine();
                classMain.GiveToListFilmsSerials(nameFilmsSerials);

                //listFilmsSerials.Add(new Models.ModelFilmsFilms()
                //{
                //    NameFilmsSerial = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }
        public void ReadingFileFilmsCartoons()
        {
            FileStream fs = new FileStream(PathFiles.FilmsCartoonsPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameFilmsCaartoons = sr.ReadLine();
                classMain.GiveToListFilmsCartoons(nameFilmsCaartoons);

                //listFilmsCartoons.Add(new Models.ModelFilmsFilms()
                //{
                //    NameFilmsCartoon = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }

        public void ReadingFileGamesPlayStation()
        {
            FileStream fs = new FileStream(PathFiles.GamesPlayStationPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameGamesPlayStation = sr.ReadLine();
                classMain.GiveToListGamesPlayStation(nameGamesPlayStation);

                //listGamesPlayStation.Add(new Models.ModelGamesPlayStation()
                //{
                //    NameGamesPlayStation = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }
        public void ReadingFileGamesHorrors()
        {
            FileStream fs = new FileStream(PathFiles.GamesHorrorsPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameGamesHorrors = sr.ReadLine();
                classMain.GiveToListGamesHorrors(nameGamesHorrors);

                //listGamesHorrors.Add(new Models.ModelGamesPlayStation()
                //{
                //    NameGamesHorrors = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }
        public void ReadingFileGamesPlatformers()
        {
            FileStream fs = new FileStream(PathFiles.GamesPlatformersPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameGamesPlatformers = sr.ReadLine();
                classMain.GiveToListGamesPlatformers(nameGamesPlatformers);

                //listGamesPlatformers.Add(new Models.ModelGamesPlayStation()
                //{
                //    NameGamesPlatformer = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }

        public async Task ReadingFileMusicReleases()
        {
            using (StreamReader sr = new StreamReader(PathFiles.MusicReleasesPath))
            {
                string group, album, date;
                while (sr.Peek() > -1)
                {
                    group = await sr.ReadLineAsync();
                    album = await sr.ReadLineAsync();
                    date = await sr.ReadLineAsync();
                    classMain.GiveToListMusicReleases(group, album, DateTime.Parse(date));
                }
            }
        }
        public void ReadingFileMusicWaiting()
        {
            FileStream fs = new FileStream(PathFiles.MusicWaitingPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameMusicWaiting = sr.ReadLine();
                classMain.GiveToListMusicWaiting(nameMusicWaiting);

                //listMusicWaiting.Add(new Models.ModelMusicReleases()
                //{
                //    NameMusicWaiting = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }
        public void ReadingFileMusicListen()
        {
            FileStream fs = new FileStream(PathFiles.MusicListenPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string nameMusicListen = sr.ReadLine();
                classMain.GiveToListMusicListen(nameMusicListen);

                //listMusicListen.Add(new Models.ModelMusicReleases()
                //{
                //    NameMusicListen = sr.ReadLine()
                //});
            }
            sr.Close();
            fs.Close();
        }
    }
}
