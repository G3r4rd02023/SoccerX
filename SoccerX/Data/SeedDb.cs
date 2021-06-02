using SoccerX.Data.Entities;
using SoccerX.Enums;
using SoccerX.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerX.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckTeamsAsync();
            await CheckTournamentsAsync();
            await CheckUserAsync("0801198713256", "Gerardo", "Lanza", "glanza007@gmail.com", "3307 7964", "Tegucigalpa,FM", UserType.Admin);
            await CheckUserAsync("0810199828920", "Odir", "Fernandez", "odirfer@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckUserAsync("0801199023030", "Isabel", "Zambrano", "isabel@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckUserAsync("0801199724040", "Miguel", "Herrera", "miguel2480@yopmailcom", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckPreditionsAsync();
        }

        private async Task CheckPreditionsAsync()
        {
            if (!_context.Predictions.Any())
            {
                foreach (var user in _context.Users)
                {
                    if (user.UserType == UserType.User)
                    {
                        AddPrediction(user);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        private void AddPrediction(User user)
        {
            var random = new Random();
            foreach (var match in _context.Matches)
            {
                _context.Predictions.Add(new Prediction
                {
                    GoalsLocal = random.Next(0, 5),
                    GoalsVisitor = random.Next(0, 5),
                    Match = match,
                    User = user
                });
            }
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    Team = _context.Teams.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task CheckTeamsAsync()
        {
            if (!_context.Teams.Any())
            {
                AddTeam("America");
                AddTeam("Argentina");
                AddTeam("Bolivia");
                AddTeam("Brasil");              
                AddTeam("Canada");
                AddTeam("Chile");
                AddTeam("Colombia");
                AddTeam("Costa Rica");
                AddTeam("Ecuador");
                AddTeam("Honduras");             
                AddTeam("Mexico");               
                AddTeam("Panama");
                AddTeam("Paraguay");
                AddTeam("Peru");              
                AddTeam("Uruguay");
                AddTeam("USA");
                AddTeam("Venezuela");
                await _context.SaveChangesAsync();
            }
        }

        private void AddTeam(string name)
        {
            _context.Teams.Add(new Team { Name = name, LogoPath = $"~/images/teams/{name}.jpg" });
        }

        private async Task CheckTournamentsAsync()
        {
            if (!_context.Tournaments.Any())
            {
                var startDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                var endDate = DateTime.Today.AddMonths(3).ToUniversalTime();

                _context.Tournaments.Add(new Tournament
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true,
                    LogoPath = $"~/images/tournaments/Copa America 2020.png",
                    Name = "Copa America 2020",
                    Groups = new List<Group>
                    {
                        new Group
                        {
                             Name = "A",
                             GroupDetails = new List<GroupDetail>
                             {
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Colombia") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Panama") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Canada") }
                             },
                             Matches = new List<Match>
                             {
                                 new Match
                                 {
                                     Date = startDate.AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Panama"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Canada")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(4).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Panama")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(4).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Canada")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(9).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Canada"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Colombia")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(9).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Panama")
                                 }
                             }
                        },
                        new Group
                        {
                             Name = "B",
                             GroupDetails = new List<GroupDetail>
                             {
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Argentina") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Mexico") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Chile") }
                             },
                             Matches = new List<Match>
                             {
                                 new Match
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Mexico"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chile")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(5).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(5).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chile")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Chile"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Argentina")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                 }
                             }
                        },
                        new Group
                        {
                             Name = "C",
                             GroupDetails = new List<GroupDetail>
                             {
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Brasil") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "USA") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Peru") }
                             },
                             Matches = new List<Match>
                             {
                                 new Match
                                 {
                                     Date = startDate.AddDays(2).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(2).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "USA"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Peru")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(6).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "USA")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(6).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Peru")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(11).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Peru"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Brasil")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(11).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "USA")
                                 }
                             }
                        },
                        new Group
                        {
                             Name = "D",
                             GroupDetails = new List<GroupDetail>
                             {
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica") },
                                 new GroupDetail { Team = _context.Teams.FirstOrDefault(t => t.Name == "Honduras") }
                             },
                             Matches = new List<Match>
                             {
                                 new Match
                                 {
                                     Date = startDate.AddDays(3).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(3).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(7).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(7).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(12).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Honduras"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay")
                                 },
                                 new Match
                                 {
                                     Date = startDate.AddDays(12).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                 }
                             }
                        }
                    }
                });

                startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                endDate = DateTime.Today.AddMonths(4).ToUniversalTime();             
                await _context.SaveChangesAsync();
            }
        }
    }
}
