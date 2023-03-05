namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();
            //Reset DB
            //IF already exists -> Drop
            //Create new instance of the Db using Code-First approach
            DbInitializer.ResetDatabase(context);


            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albumsInfo = context
                .Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .ToArray()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        Writer = s.Writer.Name
                    }).OrderByDescending(s => s.SongName).ThenBy(s => s.Writer).ToArray(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();

            foreach (var album in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");
                int count = 1;
                foreach (var songs in album.Songs)
                {
                    sb.AppendLine($"---#{count++}")
                        .AppendLine($"---SongName: {songs.SongName}")
                        .AppendLine($"---Price: {songs.Price:f2}")
                        .AppendLine($"---Writer: {songs.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songsDuration = context
                .Songs                
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(s => s.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)                
                .Select(s => new
                {
                    s.Name,
                    PerformerName = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumPRoducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerName)
                .ToArray();
            int songCounter = 1;
            foreach (var s in songsDuration)
            {
                sb.AppendLine($"-Song #{songCounter++}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}")
                    .AppendLine($"---Performer: {s.PerformerName}")
                    .AppendLine($"---AlbumProducer: {s.AlbumPRoducer}")
                    .AppendLine($"---Duration: {s.Duration}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
