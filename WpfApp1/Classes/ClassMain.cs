using BFGM.Constants;
using BFGM.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

        public async Task<List<T>> Read<T>(string path)
        {
            await Task.Delay(0);
            return Task.Run(() => JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path))).Result;
        }
        public async Task Write<T>(List<T> list, string path)
        {
            await Task.Run(() => File.WriteAllText(path, JsonConvert.SerializeObject(list, Formatting.Indented)));
        }
        public async Task Add<T>(List<T> list, T title)
        {
            await Task.Run(() => list.Add(title));
        }
        public async Task Remove<T>(List<T> list, T title)
        {
            await Task.Run(() => list.Remove(title));
        }
        public async Task Edit<T>(List<T> list, T oldData, T newData)
        {
            await Task.Run(() =>
            {
                int index = list.IndexOf(oldData);
                list.Remove(oldData);
                list.Insert(index, newData);
            });
        }

        public void CheckDirectoryAndFilesExist()
        {
            if (!Directory.Exists(@"Data\"))
                Directory.CreateDirectory(@"Data\");
            if (!File.Exists(PathFiles.BooksPath))
                File.WriteAllText(PathFiles.BooksPath, JsonConvert.SerializeObject(ListBooks, Formatting.Indented));
            if (!File.Exists(PathFiles.FilmsPath))
                File.WriteAllText(PathFiles.FilmsPath, JsonConvert.SerializeObject(ListFilms, Formatting.Indented));
            if (!File.Exists(PathFiles.SerialsPath))
                File.WriteAllText(PathFiles.SerialsPath, JsonConvert.SerializeObject(ListSerials, Formatting.Indented));
            if (!File.Exists(PathFiles.CartoonsPath))
                File.WriteAllText(PathFiles.CartoonsPath, JsonConvert.SerializeObject(ListCartoons, Formatting.Indented));
            if (!File.Exists(PathFiles.PlayStationPath))
                File.WriteAllText(PathFiles.PlayStationPath, JsonConvert.SerializeObject(ListPlayStation, Formatting.Indented));
            if (!File.Exists(PathFiles.HorrorsPath))
                File.WriteAllText(PathFiles.HorrorsPath, JsonConvert.SerializeObject(ListHorrors, Formatting.Indented));
            if (!File.Exists(PathFiles.PlatformersPath))
                File.WriteAllText(PathFiles.PlatformersPath, JsonConvert.SerializeObject(ListPlatformers, Formatting.Indented));
            if (!File.Exists(PathFiles.ReleasesPath))
                File.WriteAllText(PathFiles.ReleasesPath, JsonConvert.SerializeObject(ListReleases, Formatting.Indented));
            if (!File.Exists(PathFiles.ListenPath))
                File.WriteAllText(PathFiles.ListenPath, JsonConvert.SerializeObject(ListListen, Formatting.Indented));
            if (!File.Exists(PathFiles.WaitPath))
                File.WriteAllText(PathFiles.WaitPath, JsonConvert.SerializeObject(ListWait, Formatting.Indented));
        }
    }
}
