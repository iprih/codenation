using System;
using System.Linq;
using System.Collections.Generic;
using Codenation.Challenge.Exceptions;
using Source;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        //lista com chave e valor -> chave long / valor Team (exemplo aula)
        private Dictionary<long, Team> team;

        //lista com chave e valor -> chave long / valor Player (exemplo aula)
        private Dictionary<long, Player> player;

        public SoccerTeamsManager()
        {
            //ao instanciar a classe squad e dev são instanciados
            team = new Dictionary<long, Team>();
            player = new Dictionary<long, Player>();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (team.ContainsKey(id))
                throw new UniqueIdentifierException();

            var Team = new Team()
            {
                Id = id,
                Name = name,
                CreateDate = createDate,
                MainShirtColor = mainShirtColor,
                SecondaryShirtColor = secondaryShirtColor
            };
            team.Add(id, Team);
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (player.ContainsKey(id))
                throw new UniqueIdentifierException(); 
            if (!team.ContainsKey(teamId))
                throw new TeamNotFoundException();

            var Player = new Player()
            {
                Id = id,
                TeamId = teamId,
                Name = name,
                BirthDate = birthDate,
                SkillLevel = skillLevel,
                Salary = salary               
            };
            player.Add(id, Player);
        }

        public void SetCaptain(long playerId)
        {//rever
         Player jogador;

         if (!player.TryGetValue(playerId, out jogador))
             throw new PlayerNotFoundException();

            team[jogador.TeamId].Captain = playerId;
        }

        public long GetTeamCaptain(long teamId)
        {
            Team time;

            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();

            if (!time.Captain.HasValue)
                throw new CaptainNotFoundException();

            return time.Captain.Value;
        }

        public string GetPlayerName(long playerId)
        {
            Player jogador;

            if(!player.TryGetValue(playerId, out jogador))
                throw new PlayerNotFoundException();

            return jogador.Name;
        }

        public string GetTeamName(long teamId)
        {
            Team time;
            
            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();
            
            return time.Name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            Team time;

            IEnumerable<Player> playerTeam;
            playerTeam = player.Values.Where(x => x.TeamId == teamId);

            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();
            //lambda é uma maneira sucinta de declarar uma função, sendo os parametros da função antes do =>, e o conteúdo da função depois.
            return playerTeam.
                Select(x => x.Id).
                OrderBy(x => x).
                ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            Team time;

            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();

            int bestSkillLevel = player.Values.
                Where(x => x.TeamId == teamId).
                Max(x => x.SkillLevel);

            return player.Values.
                Where(x => x.TeamId == teamId).
                Where(x => x.SkillLevel == bestSkillLevel).
                Min(x => x.Id);
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            Team time;

            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();

            DateTime maisVelho = player.Values.
                Where(x => x.TeamId == teamId).
                Min(x => x.BirthDate);

            return player.Values.
                Where(x => x.TeamId == teamId).
                Where(x => x.BirthDate == maisVelho).
                Min(x => x.Id);
        }

        //Retorna uma lista com o id de todos os times cadastrado, ordenada pelo id. Retornar uma lista vazia caso não encontre times cadastrados.
        public List<long> GetTeams()
        {
            List<long> getTeams = new List<long>();

            foreach (Team team in team.Values)
            {
                getTeams.Add(team.Id);
            }
            getTeams.Sort();
            return getTeams; 
        }



        public long GetHigherSalaryPlayer(long teamId)
        {
            Team time;

            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();

            decimal maiorSalario = player.Values.
                Where(x => x.TeamId == teamId).
                Max(x => x.Salary);

            return player.Values.
                Where(x => x.TeamId == teamId).
                Where(x => x.Salary == maiorSalario).
                Min(x => x.Id);
        }

        public decimal GetPlayerSalary(long playerId)
        {
            Player jogador;

            if (!player.TryGetValue(playerId, out jogador))
                throw new PlayerNotFoundException();

            return jogador.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            List<long> list1 = new List<long>();
            List<long> list2 = new List<long>();
            IEnumerable<Player> topPlayersTeam;
            topPlayersTeam = player.Values.OrderByDescending(x => x.SkillLevel);

            foreach (Player jogador in topPlayersTeam)
            {
                list1.Add(jogador.Id);
            }

            for (int i = 0; i < top; i++)
            {
                list2.Add(list1[i]);
            }

            return list2;
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            Team time;

            if (!team.TryGetValue(teamId, out time))
                throw new TeamNotFoundException();

            string MainShirtColorCasa = time.MainShirtColor;
            //string SecondaryShirtColorCasa = time.SecondaryShirtColor;

            if (!team.TryGetValue(visitorTeamId, out time))
                throw new TeamNotFoundException();

            string MainShirtColorOut = time.MainShirtColor;
            string SecondaryShirtColorOut = time.SecondaryShirtColor;

            if (MainShirtColorCasa == MainShirtColorOut) return SecondaryShirtColorOut;

            return MainShirtColorOut;
        }

    }
}
