using System;
using System.IO;
using System.Threading.Tasks;
using BFGM.Classes;
using BFGM.Models;
using WpfApp1.Constants;

namespace BFGM
{
    public class ClassWriteFile : ClassPathFile
    {
        public ClassWriteFile(ClassMain classMain) : base(classMain)
        {
        }

        #region Books
        public void WriteFileBooks(Book book)
        {
            FileStream fs = new FileStream(PathFiles.BooksPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(book.Title);
            sw.WriteLine(book.Author);

            classMain.ListBooks.Add(book);

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteBooks()
        {
            FileStream fs = new FileStream(PathFiles.BooksPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListBooks.Count; i++)
            {
                sw.WriteLine(classMain.ListBooks[i].Title);
                sw.WriteLine(classMain.ListBooks[i].Author);
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region Films
        public void WriteFileFilms(string title)
        {
            FileStream fs = new FileStream(PathFiles.FilmsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(title);
            classMain.ListFilms.Add(new Film(title));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteFilms()
        {
            FileStream fs = new FileStream(PathFiles.FilmsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListFilms.Count; i++)
            {
                sw.WriteLine(classMain.ListFilms[i].Title);
            }
            sw.Close();
            fs.Close();
        }

        public void WriteFileSerials(string title)
        {
            FileStream fs = new FileStream(PathFiles.SerialsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(title);
            classMain.ListSerials.Add(new Serial(title));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteSerials()
        {
            FileStream fs = new FileStream(PathFiles.SerialsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListSerials.Count; i++)
            {
                sw.WriteLine(classMain.ListSerials[i].Title);
            }
            sw.Close();
            fs.Close();
        }

        public void WriteFileCartoons(string title)
        {
            FileStream fs = new FileStream(PathFiles.CartoonsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(title);
            classMain.ListCartoons.Add(new Cartoon(title));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteCartoons()
        {
            FileStream fs = new FileStream(PathFiles.CartoonsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListCartoons.Count; i++)
            {
                sw.WriteLine(classMain.ListCartoons[i].Title);
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region Games
        public void WriteFilePlayStation(string title)
        {
            FileStream fs = new FileStream(PathFiles.PlayStationPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(title);
            classMain.ListPlayStation.Add(new PlayStation(title));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeletePlayStation()
        {
            FileStream fs = new FileStream(PathFiles.PlayStationPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListPlayStation.Count; i++)
            {
                sw.WriteLine(classMain.ListPlayStation[i].Title);
            }
            sw.Close();
            fs.Close();
        }

        public void WriteFileHorrors(string title)
        {
            FileStream fs = new FileStream(PathFiles.HorrorsPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(title);
            classMain.ListHorrors.Add(new Horror(title));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteHorrors()
        {
            FileStream fs = new FileStream(PathFiles.HorrorsPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListHorrors.Count; i++)
            {
                sw.WriteLine(classMain.ListHorrors[i].Title);
            }
            sw.Close();
            fs.Close();
        }

        public void WriteFilePlatformers(string title)
        {
            FileStream fs = new FileStream(PathFiles.PlatformersPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(title);
            classMain.ListPlatformers.Add(new Platformer(title));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeletePlatformers()
        {
            FileStream fs = new FileStream(PathFiles.PlatformersPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListPlatformers.Count; i++)
            {
                sw.WriteLine(classMain.ListPlatformers[i].Title);
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region Music
        public void WriteFileReleases(Release release)
        {
            using (StreamWriter sw = new StreamWriter(PathFiles.ReleasesPath, true))
            {
                sw.WriteLine(release.Band);
                sw.WriteLine(release.Album);
                sw.WriteLine(release.Date.ToString("d MMMM yyyy"));
                classMain.ListReleases.Add(release);
            }
        }
        public async Task RewriteFileAfterDeleteReleases()
        {
            using (StreamWriter sw = new StreamWriter(PathFiles.ReleasesPath, false))
            {
                for (int i = 0; i < classMain.ListReleases.Count; i++)
                {
                    await sw.WriteLineAsync(classMain.ListReleases[i].Band);
                    await sw.WriteLineAsync(classMain.ListReleases[i].Album);
                    await sw.WriteLineAsync(classMain.ListReleases[i].Date.ToString("d MMMM yyyy"));
                }
            }
        }

        public void WriteFileWait(string band)
        {
            FileStream fs = new FileStream(PathFiles.WaitPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(band);
            classMain.ListWait.Add(new Wait(band));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteWait()
        {
            FileStream fs = new FileStream(PathFiles.WaitPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListWait.Count; i++)
            {
                sw.WriteLine(classMain.ListWait[i].Band);
            }
            sw.Close();
            fs.Close();
        }

        public void WriteFileListen(string band)
        {
            FileStream fs = new FileStream(PathFiles.ListenPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(band);
            classMain.ListListen.Add(new Listen(band));

            sw.Close();
            fs.Close();
        }
        public void RewriteFileAfterDeleteListen()
        {
            FileStream fs = new FileStream(PathFiles.ListenPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < classMain.ListListen.Count; i++)
            {
                sw.WriteLine(classMain.ListListen[i].Band);
            }
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
