using BFGM.Classes;
using BFGM.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WpfApp1.Constants;

namespace BFGM
{
    public class ClassReadFile
    {
        readonly ClassMain classMain;
        public ClassReadFile(ClassMain classMain)
        {
            this.classMain = classMain;
        }

        public async Task ReadFileBooks()
        {
            await Task.Run(() => classMain.ListBooks = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(PathFiles.BooksPath)));
        }

        public async Task ReadFileFilms()
        {
            await Task.Run(() => classMain.ListFilms = JsonConvert.DeserializeObject<List<Film>>(File.ReadAllText(PathFiles.FilmsPath)));
        }
        public async Task ReadFileSerials()
        {
            await Task.Run(() => classMain.ListSerials = JsonConvert.DeserializeObject<List<Serial>>(File.ReadAllText(PathFiles.SerialsPath)));
        }
        public async Task ReadFileCartoons()
        {
            await Task.Run(() => classMain.ListCartoons = JsonConvert.DeserializeObject<List<Cartoon>>(File.ReadAllText(PathFiles.CartoonsPath)));
        }

        public async Task ReadFilePlayStation()
        {
            await Task.Run(() => classMain.ListPlayStation = JsonConvert.DeserializeObject<List<PlayStation>>(File.ReadAllText(PathFiles.PlayStationPath)));
        }
        public async Task ReadFileHorrors()
        {
            await Task.Run(() => classMain.ListHorrors = JsonConvert.DeserializeObject<List<Horror>>(File.ReadAllText(PathFiles.HorrorsPath)));
        }
        public async Task ReadFilePlatformers()
        {
            await Task.Run(() => classMain.ListPlatformers = JsonConvert.DeserializeObject<List<Platformer>>(File.ReadAllText(PathFiles.PlatformersPath)));
        }

        public async Task ReadFileRelease()
        {
            await Task.Run(() => classMain.ListReleases = JsonConvert.DeserializeObject<List<Release>>(File.ReadAllText(PathFiles.ReleasesPath)));
        }
        public async Task ReadFileWait()
        {
            await Task.Run(() => classMain.ListWait = JsonConvert.DeserializeObject<List<Wait>>(File.ReadAllText(PathFiles.WaitPath)));
        }
        public async Task ReadFileListen()
        {
            await Task.Run(() => classMain.ListListen = JsonConvert.DeserializeObject<List<Listen>>(File.ReadAllText(PathFiles.ListenPath)));
        }
    }
}
