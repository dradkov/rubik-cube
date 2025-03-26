using RubikCubeApi.Enums;

namespace RubikCubeApi.Services.Interfaces
{
    public interface ICubeService
    {
        Dictionary<Face, Colors[,]> GetInitialCubeFaces();
    }
}