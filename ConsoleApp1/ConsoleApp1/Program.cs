namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] gameMap = new char[10, 10]; // Array que representa el juego de tamaño 10x10
            int playerX = 0, playerY = 0; // Coordenadas del jugador.
            Random randomNumber = new Random();
            GenerateBoard(gameMap, randomNumber);
            ShowBoard(gameMap);
        }
        static void GenerateBoard(char[,] gameMap, Random random)
        {
            for (int x = 0; x < 10; x++) // Filas del tablero
            {
                for (int y = 0; y < 10; y++) // Columnas del tablero
                {
                    if (x == 0 && y == 0) // Cuando las filas y las columnas son 0 en el bucle, poner una "P", consiguiendo la posición inicial del jugador (0, 0)
                    {
                        gameMap[x, y] = 'P'; // Posición inicial del jugador.
                    }

                    int Chances = random.Next(0, 10); // Generar un número entre el 0 y el 10. El 10 está incluido porque se empieza desde 0.

                    if (Chances < 3)
                    {
                        gameMap[x, y] = 'X'; // La probabilidad de que se cree un obstáculo es 20%.
                    }
                    else if (Chances < 4)
                    {
                        gameMap[x, y] = 'M'; // La probabilidad de que se cree una mina es 10%.
                    }
                    else
                    {
                        gameMap[x, y] = ' '; // El resto, será un 70% de probabilidad de que sea un espacio vacío.
                    }
                }
            }
        }
        static void ShowBoard(char[,] gameMap)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; x < 10; y++)
                {
                    Console.Write(gameMap[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void BoardMovement(char[,] gameMap, int playerX, int playerY, ConsoleKey key)
        {
            int updatePlayerX = playerX;
            int updatePlayerY = playerY;

            switch (key)
            {
                case ConsoleKey.W: updatePlayerY++; break;
                case ConsoleKey.A: updatePlayerX--; break;
                case ConsoleKey.S: updatePlayerY--; break;
                case ConsoleKey.D: updatePlayerY++; break;
            }

        }
    }
}