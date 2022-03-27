using System;

namespace BFGM.Models
{
    public class Release
    {
        public string Band { get; set; }
        public string Album { get; set; }
        public DateTime Date { get; set; }

        public Release(string band, string album, DateTime date)
        {
            Band = band;
            Album = album;
            Date = date;
        }
    }
}
