using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] Players;
        public GameObject Exit;


        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable

        // 7. declare Exit variable 


        public void Start()
        {
            // 1. random player at the position <0, 0> map
           

            // 2. create obstacles
            

            // 3. create floor
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    GameObject toInstantiate = floorTiles[UnityEngine.Random.Range(0, floorTiles.Length)];
                    GameObject tile = Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
                    Console.Write(tile.name);
                }
                Console.WriteLine();
            }

            // 4. create walls
            for (int y = -1; y < rows + 1; y++)
            {
                for (int x = -1; x < columns + 1; x++)
                {
                    if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        GameObject toInstantiate = wallTiles[UnityEngine.Random.Range(0, wallTiles.Length)];
                        Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
                    }
                }
            }

            // 5. random foods
            int numberOfFoods = UnityEngine.Random.Range(2, 3);
            for (int i = 0; i < numberOfFoods; i++)
            {
                int x = UnityEngine.Random.Range(0, columns);
                int y = UnityEngine.Random.Range(0, rows);
                GameObject toInstantiate = foodTiles[UnityEngine.Random.Range(0, foodTiles.Length)];
                Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
            }

            // 6. generate item along with the saveItemMap
            for (int y = 0; y < saveItemMap.GetLength(0); y++)
            {
                for (int x = 0; x < saveItemMap.GetLength(1); x++)
                {
                    string item = saveItemMap[y, x];
                    int foodIndex = -1;
                    if (!string.IsNullOrEmpty(item))
                    {
                        foreach (var foodTile in foodTiles)
                        {
                            if (foodTile.name == item)
                            {
                                var instantiatedFood = Instantiate(foodTile, new Vector2(x, y), Quaternion.identity);
                            }
                        }
                    }
                }
            }

            // 7. place exit
            Instantiate(Exit, new Vector2(columns - 1, rows - 1), Quaternion.identity);
        }
    }

}
