using System;

namespace BFGM.Models
{
    public class ModelMusicReleases
    {
        public string NameMusicReleasesGroup { get; set; }
        public string NameMusicReleasesAlbum { get; set; }
        public DateTime NameMusicReleasesDate { get; set; }

        public ModelMusicReleases(string nameMusicReleasesGroup, string nameMusicReleasesAlbum, DateTime nameMusicReleasesDate)
        {
            NameMusicReleasesGroup = nameMusicReleasesGroup;
            NameMusicReleasesAlbum = nameMusicReleasesAlbum;
            NameMusicReleasesDate = nameMusicReleasesDate;
        }
    }
}
