using RubikCubeApi.Enums;
using RubikCubeApi.Services;
using Xunit;

namespace RubikCubeTests
{
    public class PrintServiceTests
    {
        private readonly PrintService _printService;
        private readonly Dictionary<Face, Colors[,]> initialFaces;

        public PrintServiceTests()
        {
            initialFaces = new Dictionary<Face, Colors[,]>
            {
                { Face.Front, GenerateMockFace(Colors.Green.ToString()) },
                { Face.Back, GenerateMockFace(Colors.Blue.ToString()) },
                { Face.Left, GenerateMockFace(Colors.Orange.ToString()) },
                { Face.Right, GenerateMockFace(Colors.Red.ToString()) },
                { Face.Up, GenerateMockFace(Colors.White.ToString()) },
                { Face.Down, GenerateMockFace(Colors.Yellow.ToString()) }
            };

            _printService = new PrintService();
        }

        [Fact]
        public void Rotate_FrontClockwise_ChangesState()
        {
            //Arrange
            const string expected = "Orange Orange Orange  Green Green Green  Red Red Red  Blue Blue Blue";

            // Act
            var result = _printService.PrintFlat(initialFaces);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(expected, result.Trim());
        }

        private static Colors[,] GenerateMockFace(string color)
        {
            var face = new Colors[3, 3];
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    face[i, j] = Enum.Parse<Colors>(color);
                }
            }

            return face;
        }
    }
}