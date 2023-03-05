using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var coatchDto = Deserialize<ImportCoatchDto[]>(xmlString, "Coaches");
            List<Coach> validCoaches = new List<Coach>();
            foreach (var cd in coatchDto)
            {
                if (!IsValid(cd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Coach coach = new Coach()
                {
                    Name = cd.Name,
                    Nationality = cd.Nationality,
                };

                foreach (var f in cd.Footballers)
                {
                    if (!IsValid(f))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime startDate;
                    bool isValidStartDate = DateTime.TryParseExact(f.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

                    DateTime endDate;
                    bool isValidEndDate = DateTime.TryParseExact(f.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

                    int isValid = DateTime.Compare(startDate, endDate);

                    if (!isValidStartDate || !isValidEndDate || isValid >= 0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = f.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)f.BestSkillType,
                        PositionType = (PositionType)f.PositionType
                    };
                    coach.Footballers.Add(footballer);
                }
                validCoaches.Add(coach);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach,
                    coach.Name, coach.Footballers.Count));
            }
            context.AddRange(validCoaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Team> validTeams = new List<Team>();

            var teamsImport = JsonConvert.DeserializeObject<IEnumerable<ImportTeamDto>>(jsonString);

            foreach (var t in teamsImport)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team
                {
                    Name = t.Name,
                    Nationality = t.Nationality,
                    Trophies = t.Trophies,
                };

                var unique = t.Footballers.Distinct();

                foreach (var p in unique)
                {
                    var unique1 = context.Footballers.FirstOrDefault(x => x.Id == p);

                    if (unique1 == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFoot = new TeamFootballer
                    {
                        Team = team,
                        Footballer = unique1
                    };

                    team.TeamsFootballers.Add(teamFoot);
                }

                validTeams.Add(team);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam,
                    team.Name, team.TeamsFootballers.Count));
            }
            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer.Deserialize(reader);

            return dtos;
        }


    }
}
