using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Footballers.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var cotchesTeam = context.Coaches.Where(c => c.Footballers.Count >= 1).ToArray()
                .Select(x => new ExportCoatchesDto()
                {
                    FootballersCount = x.Footballers.Count,
                    CoachName = x.Name,
                    Footballer = x.Footballers.Select(f => new ExportFoobleresDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString(),
                    }).OrderBy(x => x.Name).ToArray()
                }).OrderByDescending(x => x.Footballer.Count()).ThenBy(x => x.CoachName).ToArray();
            return Serialize(cotchesTeam, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var topFiveTeams = context.Teams
                .Where(x => x.TeamsFootballers.Any(x => x.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(x => new
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers.Where(x => x.Footballer.ContractStartDate >= date)
                        .OrderByDescending(c => c.Footballer.ContractEndDate)
                        .ThenBy(x => x.Footballer.Name)
                        .Select(z => new
                        {
                            FootballerName = z.Footballer.Name,
                            ContractStartDate =
                                z.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = z.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = z.Footballer.BestSkillType.ToString(),
                            PositionType = z.Footballer.PositionType.ToString(),

                        }).ToArray()
                }).OrderByDescending(x => x.Footballers.Length).ThenBy(x => x.Name).Take(5).ToArray();

            return JsonConvert.SerializeObject(topFiveTeams, Formatting.Indented);
        }
    private static string Serialize<T>(T dto, string rootName)
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, dto, namespaces);

        return sb.ToString().TrimEnd();
    }
}
}
