using RubikCubeApi.Enums;

namespace RubikCubeApi.Services.Interfaces
{
    public interface IRubikCubeService
    {
        Dictionary<Face, Colors[,]> Rotate(Face face, Rotation direction);
    }
}