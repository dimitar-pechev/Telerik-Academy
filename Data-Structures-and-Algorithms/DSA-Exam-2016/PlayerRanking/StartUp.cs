using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerRanking
{
    public class StartUp
    {
        public static void Main()
        {
            var game = new Game();
            var result = new StringBuilder();

            var line = Console.ReadLine();
            while (line != "end")
            {
                var command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        var player = Player.Parse(command.Arguments);
                        var message = game.Add(player);
                        if (string.IsNullOrEmpty(message))
                        {
                            break;
                        }
                        result.AppendLine(message);
                        break;
                    case "find":
                        var type = command.Arguments[0];
                        var res = game.Find(type);
                        result.AppendLine(res);
                        break;
                    case "ranklist":
                        var from = int.Parse(command.Arguments[0]);
                        var to = int.Parse(command.Arguments[1]);
                        var mes = game.Ranklist(from, to);
                        if (string.IsNullOrEmpty(mes))
                        {
                            break;
                        }
                        result.AppendLine(mes);
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            var finalRes = result.ToString().TrimEnd('\r', '\n');

            Console.WriteLine(finalRes);
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public int CurrentPosition { get; set; }

        public static Player Parse(IList<string> args)
        {
            var player = new Player()
            {
                Name = args[0],
                Type = args[1],
                Age = int.Parse(args[2]),
                CurrentPosition = int.Parse(args[3])
            };

            return player;
        }

        public int CompareTo(Player other)
        {
            var result = this.CurrentPosition.CompareTo(other.CurrentPosition);
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

    public class Command
    {
        public string Name { get; set; }

        public IList<string> Arguments { get; set; }

        public static Command Parse(string commandAsString)
        {
            var commandParts = commandAsString.Split(' ');

            var name = commandParts[0];

            var newListOfStrings = new List<string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                newListOfStrings.Add(commandParts[i]);
            }

            return new Command
            {
                Name = name,
                Arguments = newListOfStrings
            };
        }
    }

    public class Game
    {
        private SortedSet<Player> playersByRank;
        private static int counter = 1;

        public Game()
        {
            this.playersByRank = new SortedSet<Player>();
        }

        public string Add(Player player)
        {
            if (player.Name.Length < 1 || player.Name.Length > 20 || player.Type.Length < 1 ||
                player.Type.Length > 10 || player.Age > 50 || player.Age < 10 ||
                player.CurrentPosition < 1 || player.CurrentPosition > counter)
            {
                throw new Exception();
            }

            foreach (Player pl in playersByRank)
            {
                if (player.CurrentPosition <= pl.CurrentPosition)
                {
                    pl.CurrentPosition++;
                }
            }

            this.playersByRank.Add(player);
            counter++;
            return string.Format("Added player {0} to position {1}", player.Name, player.CurrentPosition);
        }
        
        public string Find(string type)
        {
            var players = this.playersByRank.Where(x => x.Type == type).OrderBy(x => x.Name).ThenByDescending(x => x.Age).Take(5).ToList();

            var result = new StringBuilder();
            result.Append(string.Format("Type {0}:", type));
            foreach (var player in players)
            {
                //Type Aggressive: Ivan(20); Stamat(40); Stamat(22)
                result.Append(string.Format(" {0};", player.ToString()));
            }

            if (players.Count == 0)
            {
                return string.Format("Type {0}: ", type);
            }
            else
            {
                return result.ToString().Trim(' ', ';');
            }            
        }

        public string Ranklist(int from, int to)
        {
            var count = this.playersByRank.Count();
            if (from < 1 || to > count + 1 || from > to)
            {
                return null;
            }

            var players = this.playersByRank.Skip(from - 1).Take(to - from + 1).ToList();

            if (players.Count == 0)
            {
                return null;
            }

            var result = new StringBuilder();
            foreach (Player pl in players)
            {
                //1. Stamat(40); 2. Ivan(20); 3. Stamat(22); 4. Pesho(25); 5. Georgi(30)
                result.Append(string.Format("{0}. {1}; ", from++, pl.ToString()));
            }

            return result.ToString().Trim(' ', ';');
        }
    }
}
