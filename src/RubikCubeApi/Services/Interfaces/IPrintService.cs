using RubikCubeApi.Enums;

namespace RubikCubeApi.Services.Interfaces
{
    public interface IPrintService
    {
        void PrintBasic(Dictionary<Face, Colors[,]> faces);
        
        string PrintFlat(Dictionary<Face, Colors[,]> faces);
    }
}