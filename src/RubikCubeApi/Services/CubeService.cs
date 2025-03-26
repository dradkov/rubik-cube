using RubikCubeApi.Enums;
using RubikCubeApi.Services.Interfaces;

namespace RubikCubeApi.Services
{
    public class CubeService : ICubeService
    {
        private readonly Dictionary<Face, Colors[,]> Faces;

        public CubeService()
        {
            Faces = InitialSetup();
        }

        public CubeService(Dictionary<Face, Colors[,]> customSetup)
        {
            Faces = customSetup ?? InitialSetup();
        }

        public Dictionary<Face, Colors[,]> GetInitialCubeFaces() => Faces;

        private static Colors[,] CreateFace(Colors color)
        {
            return new[,]
            {
                { color, color, color },
                { color, color, color },
                { color, color, color }
            };
        }

        private static Dictionary<Face, Colors[,]> InitialSetup()
            => new()
            {
                { Face.Front, CreateFace(Colors.Green) },
                { Face.Back, CreateFace(Colors.Blue) },
                { Face.Left, CreateFace(Colors.Orange) },
                { Face.Right, CreateFace(Colors.Red) },
                { Face.Up, CreateFace(Colors.White) },
                { Face.Down, CreateFace(Colors.Yellow) }
            };
    }
}