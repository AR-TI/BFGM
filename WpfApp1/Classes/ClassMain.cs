using System;
using System.Collections.Generic;
using BFGM.Models;

namespace BFGM.Classes
{
    public class ClassMain
    {
        #region Lists
        public List<ModelBook> ListBooks { get; } = new List<ModelBook>();

        public List<ModelFilmsFilms> ListFilmsFilms { get; } = new List<ModelFilmsFilms>();
        public List<ModelFilmsSerial> ListFilmsSerials { get; } = new List<ModelFilmsSerial>();
        public List<ModelFilmsCartoon> ListFilmsCartoons { get; } = new List<ModelFilmsCartoon>();

        public List<ModelGamesPlayStation> ListGamesPlayStation { get; } = new List<ModelGamesPlayStation>();
        public List<ModelGamesHorror> ListGamesHorrors { get; } = new List<ModelGamesHorror>();
        public List<ModelGamesPlatformer> ListGamesPlatformers { get; } = new List<ModelGamesPlatformer>();

        public List<ModelMusicReleases> ListMusicReleases { get; } = new List<ModelMusicReleases>();
        public List<ModelMusicWaiting> ListMusicWaiting { get; } = new List<ModelMusicWaiting>();
        public List<ModelMusicListen> ListMusicListen { get; } = new List<ModelMusicListen>();
        #endregion

        #region GiveToList()
        public void GiveToListBooks(string nameBooksBook, string nameBooksAuthor)
        {
            ListBooks.Add(new ModelBook(nameBooksBook, nameBooksAuthor));
        }

        public void GiveToListFilmsFilm(string nameFilmsFilm)
        {
            ListFilmsFilms.Add(new ModelFilmsFilms(nameFilmsFilm));
        }
        public void GiveToListFilmsSerials(string nameFilmsSerials)
        {
            ListFilmsSerials.Add(new ModelFilmsSerial(nameFilmsSerials));
        }
        public void GiveToListFilmsCartoons(string nameFilmsCartoons)
        {
            ListFilmsCartoons.Add(new ModelFilmsCartoon(nameFilmsCartoons));
        }

        public void GiveToListGamesPlayStation(string nameGamesPlayStation)
        {
            ListGamesPlayStation.Add(new ModelGamesPlayStation(nameGamesPlayStation));
        }
        public void GiveToListGamesHorrors(string nameGamesHorror)
        {
            ListGamesHorrors.Add(new ModelGamesHorror(nameGamesHorror));
        }
        public void GiveToListGamesPlatformers(string nameGamesPlatformer)
        {
            ListGamesPlatformers.Add(new ModelGamesPlatformer(nameGamesPlatformer));
        }

        public void GiveToListMusicReleases(string nameMusicGroup, string nameMusicAlbum, DateTime nameMusicDate)
        {
            ListMusicReleases.Add(new ModelMusicReleases(nameMusicGroup, nameMusicAlbum, nameMusicDate));
        }
        public void GiveToListMusicWaiting(string nameMusicWaiting)
        {
            ListMusicWaiting.Add(new ModelMusicWaiting(nameMusicWaiting));
        }
        public void GiveToListMusicListen(string nameMusicListen)
        {
            ListMusicListen.Add(new ModelMusicListen(nameMusicListen));
        }
        #endregion

        #region Delete()
        public void DeleteBooks(int selectedIndex)
        {
            ListBooks.RemoveAt(selectedIndex);
        }

        public void DeleteFilmsFilms(string selectedName)
        {
            for (int i = 0; i < ListFilmsFilms.Count; i++)
            {
                if (ListFilmsFilms[i].NameFilmsFilm == selectedName)
                {
                    ListFilmsFilms.RemoveAt(i);
                    break;
                }
            }
            //listFilmsFilms.RemoveAt(selectedIndex);
        }
        public void DeleteFilmsSerials(string selectedName)
        {
            for (int i = 0; i < ListFilmsSerials.Count; i++)
            {
                if (ListFilmsSerials[i].NameFilmsSerial == selectedName)
                {
                    ListFilmsSerials.RemoveAt(i);
                }
            }
            //listFilmsSerials.RemoveAt(selectedIndex);
        }
        public void DeleteFilmsCartoons(string selectedName)
        {
            for (int i = 0; i < ListFilmsCartoons.Count; i++)
            {
                if (ListFilmsCartoons[i].NameFilmsCartoon == selectedName)
                {
                    ListFilmsCartoons.RemoveAt(i);
                }
            }
            //listFilmsCartoons.RemoveAt(selectedIndex);
        }

        public void DeleteGamesPlayStation(string selectedName)
        {
            for (int i = 0; i < ListGamesPlayStation.Count; i++)
            {
                if (ListGamesPlayStation[i].NameGamesPlayStation == selectedName)
                {
                    ListGamesPlayStation.RemoveAt(i);
                }
            }
            //listGamesPlayStation.RemoveAt(selectedIndex);
        }
        public void DeleteGamesHorrors(string selectedName)
        {
            for (int i = 0; i < ListGamesHorrors.Count; i++)
            {
                if (ListGamesHorrors[i].NameGamesHorror == selectedName)
                {
                    ListGamesHorrors.RemoveAt(i);
                }
            }
            //listGamesHorrors.RemoveAt(selectedIndex);
        }
        public void DeleteGamesPlatformers(string selectedName)
        {
            for (int i = 0; i < ListGamesPlatformers.Count; i++)
            {
                if (ListGamesPlatformers[i].NameGamesPlatformer == selectedName)
                {
                    ListGamesPlatformers.RemoveAt(i);
                }
            }
            //listGamesPlatformers.RemoveAt(selectedIndex);
        }

        public void DeleteMusicReleases(string selectedName)
        {
            for (int i = 0; i < ListMusicReleases.Count; i++)
            {
                if (ListMusicReleases[i].NameMusicReleasesGroup == selectedName || ListMusicReleases[i].NameMusicReleasesAlbum == selectedName)
                {
                    ListMusicReleases.RemoveAt(i);
                    break;
                }
            }
            //listMusicReleases.RemoveAt(selectedIndex);
        }
        public void DeleteMusicWaiting(string selectedName)
        {
            for (int i = 0; i < ListMusicWaiting.Count; i++)
            {
                if (ListMusicWaiting[i].NameMusicWaiting == selectedName)
                {
                    ListMusicWaiting.RemoveAt(i);
                }
            }
            //listMusicWaiting.RemoveAt(selectedIndex);
        }
        public void DeleteMusicListen(string selectedName)
        {
            for (int i = 0; i < ListMusicListen.Count; i++)
            {
                if (ListMusicListen[i].NameMusicListen == selectedName)
                {
                    ListMusicListen.RemoveAt(i);
                }
            }
            //listMusicListen.RemoveAt(selectedIndex);
        }
        #endregion
    }
}
