using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class CsvReader
    {
        private int positionCount = 4;
        private int costMultiplier = 150;
        private int costRngRange = 300;
        public List<List<Player>> ReadCsv(string path)
        {
            // 0 goalkeepers 1 defence 2 midfield 3 attack
            List<List<Player>> playerPopulation = new List<List<Player>>();
            for (int i=0; i< positionCount; i++)
            {
                playerPopulation.Add(new List<Player>());
            }
            Random random = new Random();
            int lineCount = 0;
            using (var fs = File.OpenRead(path))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (lineCount != 0)
                    {
                        var values = line.Split(',');
                        int cost = CalculateCost(values[3], random)
                        , position = ReadPosition(values[4], random)
                        , speed = int.Parse(values[10])
                        , dribbling = int.Parse(values[11])
                        , shooting = int.Parse(values[12])
                        , defence = int.Parse(values[13])
                        , passing = int.Parse(values[14]);
                        Player newPlayer = new Player(lineCount - 1, speed, dribbling, defence, passing, shooting, cost, position);
                        /*   structure of the csv file    */
                        //3 length + rng
                        //4 indeks position
                        //10 speed
                        //11 indeks dribbling
                        //12 shooting
                        //13 defence
                        //14 passing
                        SetPosition(playerPopulation, newPlayer);
                    }
                    lineCount++;
                }
            }
            Shuffle(playerPopulation, random);

            return playerPopulation;
        }

        private void Shuffle(List<List<Player>> list, Random random)
        {
            int n = list.Count;
            foreach (var l in list)
            {
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Player value = l[k];
                    l[k] = l[n];
                    l[n] = value;
                }
            }
        }
        private void SetPosition(List<List<Player>> playerPopulation, Player newPlayer)
        {
            if (newPlayer.Position == 0)
            {
                playerPopulation[0].Add(newPlayer);
            }
            else if (newPlayer.Position < 5)
            {
                playerPopulation[1].Add(newPlayer);
            }
            else if (newPlayer.Position < 9)
            {
                playerPopulation[2].Add(newPlayer);
            }
            else
            {
                playerPopulation[3].Add(newPlayer);
            }
        }
        private int ReadPosition(string position, Random random)
        {
            // attack       
            if (position == "RW" || position == "LW" || position == "ST")
            {
                return random.Next(9, 11);
            }
            else if (position == "CM" || position == "LM" || position == "RM" || position == "CDM" || position == "CAM")
            {
                return random.Next(5, 9);
            }
            else if (position == "CB" || position == "RB" || position == "LB")
            {
                return random.Next(1, 5);
            }
            else if (position == "GK")
            {
                return 0;
            }
            else
                return random.Next(0, 11);
        }

        private int CalculateCost(string sekretMnicha, Random random)
        {
            int rngValue = random.Next(0, costRngRange);
            return sekretMnicha.Length * costMultiplier + rngValue;
        }
    }
}
