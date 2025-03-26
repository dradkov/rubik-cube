using Moq;
using RubikCubeApi.Enums;
using RubikCubeApi.Services;
using RubikCubeApi.Services.Interfaces;
using Xunit;

namespace RubikCubeTests
{
    public class RubikCubeServiceTests
    {
        private readonly Mock<ICubeService> _cubeServiceMock;
        private readonly RubikCubeService _rubikCubeService;

        public RubikCubeServiceTests()
        {
            _cubeServiceMock = new Mock<ICubeService>();
            
            var initialFaces = new Dictionary<Face, Colors[,]>
            {
                { Face.Front, GenerateMockFace(Colors.Green.ToString()) },
                { Face.Back, GenerateMockFace(Colors.Blue.ToString()) },
                { Face.Left, GenerateMockFace(Colors.Orange.ToString()) },
                { Face.Right, GenerateMockFace(Colors.Red.ToString()) },
                { Face.Up, GenerateMockFace(Colors.White.ToString()) },
                { Face.Down, GenerateMockFace(Colors.Yellow.ToString()) }
            };

            _cubeServiceMock.Setup(cs => cs.GetInitialCubeFaces()).Returns(initialFaces);
            _rubikCubeService = new RubikCubeService(_cubeServiceMock.Object);
        }

        [Fact]
        public void Rotate_FrontClockwise_ChangesState()
        {
            // Act
            var result = _rubikCubeService.Rotate(Face.Front, Rotation.Clockwise);
        
            // Assert
            Assert.NotNull(result);
            Assert.Equal(Colors.Yellow ,result[Face.Left][0,2]);
            Assert.Equal(Colors.Yellow ,result[Face.Left][1,2]);
            Assert.Equal(Colors.Yellow ,result[Face.Left][2,2]);
        }
    
        [Fact]
        public void Rotate_FrontInverted_ChangesState()
        {
            // Act
            var result = _rubikCubeService.Rotate(Face.Front, Rotation.Inverted);
        
            // Assert
            Assert.NotNull(result);
            Assert.Equal(Colors.White ,result[Face.Left][0,2]);
            Assert.Equal(Colors.White ,result[Face.Left][1,2]);
            Assert.Equal(Colors.White ,result[Face.Left][2,2]);
        }
        
        [Fact]
        public void Rotate_LeftClockwise_ChangesState()
        {
            // Act
            var result = _rubikCubeService.Rotate(Face.Left, Rotation.Clockwise);
        
            // Assert
            Assert.NotNull(result);
            Assert.Equal(Colors.Yellow ,result[Face.Back][0,2]);
            Assert.Equal(Colors.Yellow ,result[Face.Back][1,2]);
            Assert.Equal(Colors.Yellow ,result[Face.Back][2,2]);
        }
    
        [Fact]
        public void Rotate_LeftInverted_ChangesState()
        {
            // Act
            var result = _rubikCubeService.Rotate(Face.Left, Rotation.Inverted);
        
            // Assert
            Assert.NotNull(result);
            Assert.Equal(Colors.White ,result[Face.Back][0,2]);
            Assert.Equal(Colors.White ,result[Face.Back][1,2]);
            Assert.Equal(Colors.White ,result[Face.Back][2,2]);
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