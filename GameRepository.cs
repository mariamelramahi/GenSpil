//using System;
//using static Genspil.GameStorage;


//namespace Gamelist
//{
//    public class GameRepository
//    {
//        public string DataFileName { get; }

//        public GameRepository(string dataFileName)
//        {
//            DataFileName = dataFileName;
//        }


//        public void SaveGame(GameStorage.GameInfo gameInfo)
//        {
//            string filename = DataFileName;

//            try
//            {
//                using (StreamWriter writer = new StreamWriter(filename))
//                {
//                    writer.Write(gameInfo.MakeTitle());
//                }
//            }
//            catch (Exception exp)
//            {
//                Console.Write(exp.ToString());
//            }
//        }
//        public GameInfo? LoadGameInfo()
//        {
//            string filename = DataFileName;
//            try
//            {
//                using (StreamReader reader = new StreamReader(DataFileName))
//                {
//                    string line;
//                    while ((line = reader.ReadLine()) != null)
//                    {
//                        string[] parts = line.Split(';');

//                        string title = parts[0];
//                        string edition = parts[1];
//                        decimal basePrice = decimal.Parse(parts[2]);
//                        string genre = parts[3];
//                        int numberOfPlayers = int.Parse(parts[4]);
//                        GameCondition condition = enum.Parse(parts[5]);
//                        GameStatus status = enum.Parse(parts[6]);
//    }
//}
//            }
//            catch (Exception exp)
//            {
//                Console.WriteLine(exp.Message);
                
//            }
//             return null; 
//        }

        
//public void SaveGameInfo(GameInfo[] games)

//    try
//{
//    string filename = DataFileName;

//    using (StreamWriter writer = new StreamWriter(filename))
//    {
//        foreach (var game in games)
//        {
//            writer.WriteLine(game.MakeTitle());
//        }
//    }
//}
//catch (Exception exp)
//{
//    Console.WriteLine(exp.Message);
//}

//}
//public GameInfo[] LoadGameInfo()
//{
//    try
//    {
//        string filename = DataFileName;

//        if (!File.Exists(filename))
//        {
//            throw new FileNotFoundException("Data file does not exist.");
//        }

//        List<Gameinfo> games = new List<GameInfo>();

//        using (StreamReader reader = new StreamReader(filename))
//        {
//            string line;
//            while ((line = reader.ReadLine()) != null)
//            {
//                string[] parts = line.Split(';');

//                string title = parts[0];
//                string edition = parts[1];
//                decimal basePrice = decimal.Parse(parts[2]);
//                string genre = parts[3];
//                int numberOfPlayers = int.Parse(parts[4]);
//                GameCondition condition = enum.Parse(parts[5]);
//GameStatus status = enum.Parse(parts[5]);

//games.Add(new GameInfo((title, edition, basePrice, genre, numberOfPlayers, GameStatus)));
//                    }
//                }

//                return games.ToArray();

//            }

//            catch (Exception exp)
//            {
//                Console.WriteLine(exp.Message);
//            }

//            return null;


//        }
//}   }
