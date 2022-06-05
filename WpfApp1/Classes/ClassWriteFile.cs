using BFGM.Classes;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using WpfApp1.Constants;

namespace BFGM
{
    public class ClassWriteFile
    {
        readonly ClassMain classMain;
        public ClassWriteFile(ClassMain classMain)
        {
            this.classMain = classMain;
        }

        public async Task WriteFileBooks()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.BooksPath, JsonConvert.SerializeObject(classMain.ListBooks, Formatting.Indented)));
        }

        public async Task WriteFileFilms()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.FilmsPath, JsonConvert.SerializeObject(classMain.ListFilms, Formatting.Indented)));
        }
        public async Task WriteFileSerials()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.SerialsPath, JsonConvert.SerializeObject(classMain.ListSerials, Formatting.Indented)));
        }
        public async Task WriteFileCartoons()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.CartoonsPath, JsonConvert.SerializeObject(classMain.ListCartoons, Formatting.Indented)));
        }

        public async Task WriteFilePlayStation()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.PlayStationPath, JsonConvert.SerializeObject(classMain.ListPlayStation, Formatting.Indented)));
        }
        public async Task WriteFileHorrors()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.HorrorsPath, JsonConvert.SerializeObject(classMain.ListHorrors, Formatting.Indented)));
        }
        public async Task WriteFilePlatformers()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.PlatformersPath, JsonConvert.SerializeObject(classMain.ListPlatformers, Formatting.Indented)));
        }

        public async Task WriteFileReleases()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.ReleasesPath, JsonConvert.SerializeObject(classMain.ListReleases, Formatting.Indented)));
        }
        public async Task WriteFileWait()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.WaitPath, JsonConvert.SerializeObject(classMain.ListWait, Formatting.Indented)));
        }
        public async Task WriteFileListen()
        {
            await Task.Run(() => File.WriteAllText(PathFiles.ListenPath, JsonConvert.SerializeObject(classMain.ListListen, Formatting.Indented)));
        }
    }
}
