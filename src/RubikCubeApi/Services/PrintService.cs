using System.Text;
using RubikCubeApi.Enums;
using RubikCubeApi.Services.Interfaces;

namespace RubikCubeApi.Services
{
    public class PrintService : IPrintService
    {
        public void PrintBasic(Dictionary<Face, Colors[,]> faces)
        {
            foreach (var face in faces)
            {
                Console.WriteLine($"{face.Key}:");
                for (var i = 0; i < 3; i++)
                {
                    Console.WriteLine(string.Join(" ", face.Value[i, 0], face.Value[i, 1], face.Value[i, 2]));
                }

                Console.WriteLine();
            }
        }
        
        public string PrintFlat(Dictionary<Face, Colors[,]> faces)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < 3; i++)
            {
                sb.AppendLine(new string(' ', 22) +
                    string.Join(" ", faces[Face.Up][i, 0], faces[Face.Up][i, 1], faces[Face.Up][i, 2]));
            }

            for (var i = 0; i < 3; i++)
            {
                sb.AppendLine(
                    string.Join(" ", faces[Face.Left][i, 0], faces[Face.Left][i, 1], faces[Face.Left][i, 2]) + "  " +
                    string.Join(" ", faces[Face.Front][i, 0], faces[Face.Front][i, 1], faces[Face.Front][i, 2]) + "  " +
                    string.Join(" ", faces[Face.Right][i, 0], faces[Face.Right][i, 1], faces[Face.Right][i, 2]) + "  " +
                    string.Join(" ", faces[Face.Back][i, 0], faces[Face.Back][i, 1], faces[Face.Back][i, 2])
                );
            }

            for (var i = 0; i < 3; i++)
            {
                sb.AppendLine(new string(' ', 22) +
                    string.Join(" ", faces[Face.Down][i, 0], faces[Face.Down][i, 1], faces[Face.Down][i, 2]));
            }

            return sb.ToString();
        }
    }
}