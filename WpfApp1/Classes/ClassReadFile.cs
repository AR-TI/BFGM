using BFGM.Classes;
using BFGM.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using WpfApp1.Constants;

namespace BFGM
{
    public class ClassReadFile : ClassPathFile
    {
        public ClassReadFile(ClassMain classMain) : base(classMain)
        {
        }

        public void ReadFileBooks()
        {
            using (StreamReader sr = new StreamReader(PathFiles.BooksPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    string author = sr.ReadLine();
                    classMain.GiveToListBooks(title, author);
                }
            }
        }

        public void ReadFileFilms()
        {
            using (StreamReader sr = new StreamReader(PathFiles.FilmsPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    classMain.GiveToListFilms(title);
                }
            }
        }
        public void ReadFileSerials()
        {
            using (StreamReader sr = new StreamReader(PathFiles.SerialsPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    classMain.GiveToListSerials(title);
                }
            }
        }
        public void ReadFileCartoons()
        {
            using (StreamReader sr = new StreamReader(PathFiles.CartoonsPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    classMain.GiveToListCartoons(title);
                }
            }
        }

        public void ReadFilePlayStation()
        {
            using (StreamReader sr = new StreamReader(PathFiles.PlayStationPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    classMain.GiveToListPlayStation(title);
                }
            }
        }
        public void ReadFileHorrors()
        {
            using (StreamReader sr = new StreamReader(PathFiles.HorrorsPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    classMain.GiveToListHorrors(title);
                }
            }
        }
        public void ReadFilePlatformers()
        {
            using (StreamReader sr = new StreamReader(PathFiles.PlatformersPath))
            {
                while (sr.Peek() > -1)
                {
                    string title = sr.ReadLine();
                    classMain.GiveToListPlatformers(title);
                }
            }
        }

        public async Task ReadFileReleases()
        {
            using (StreamReader sr = new StreamReader(PathFiles.ReleasesPath))
            {
                string band, album, date;
                while (sr.Peek() > -1)
                {
                    band = await sr.ReadLineAsync();
                    album = await sr.ReadLineAsync();
                    date = await sr.ReadLineAsync();
                    classMain.GiveToListReleases(new Release(band, album, DateTime.Parse(date)));
                }
            }
        }
        public void ReadFileWait()
        {
            using (StreamReader sr = new StreamReader(PathFiles.WaitPath))
            {
                while (sr.Peek() > -1)
                {
                    string band = sr.ReadLine();
                    classMain.GiveToListWait(band);
                }
            }
        }
        public void ReadFileListen()
        {
            using (StreamReader sr = new StreamReader(PathFiles.ListenPath))
            {
                while (sr.Peek() > -1)
                {
                    string band = sr.ReadLine();
                    classMain.GiveToListListen(band);
                }
            }
        }
    }
}
