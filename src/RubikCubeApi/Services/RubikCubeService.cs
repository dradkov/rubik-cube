using RubikCubeApi.Enums;
using RubikCubeApi.Services.Interfaces;

namespace RubikCubeApi.Services
{
    public class RubikCubeService(ICubeService cubeService) : IRubikCubeService
    {
        private readonly Dictionary<Face, Colors[,]> _faces = cubeService.GetInitialCubeFaces();

        public Dictionary<Face, Colors[,]> Rotate(Face face, Rotation direction)
        {
            RotateEdges(face, direction);
            RotateFaceMatrix(face, direction);
            return _faces;
        }

        private void RotateEdges(Face face, Rotation direction)
        {
            switch (face)
            {
                case Face.Front:
                    if (direction == Rotation.Clockwise)
                    {
                        var tempColor1 = _faces[Face.Up][2, 0];
                        var tempColor2 = _faces[Face.Up][2, 1];
                        var tempColor3 = _faces[Face.Up][2, 2];

                        _faces[Face.Up][2, 0] = _faces[Face.Left][2, 2];
                        _faces[Face.Up][2, 1] = _faces[Face.Left][1, 2];
                        _faces[Face.Up][2, 2] = _faces[Face.Left][0, 2];

                        _faces[Face.Left][0, 2] = _faces[Face.Down][0, 0];
                        _faces[Face.Left][1, 2] = _faces[Face.Down][0, 1];
                        _faces[Face.Left][2, 2] = _faces[Face.Down][0, 2];

                        _faces[Face.Down][0, 0] = _faces[Face.Right][2, 0];
                        _faces[Face.Down][0, 1] = _faces[Face.Right][1, 0];
                        _faces[Face.Down][0, 2] = _faces[Face.Right][0, 0];

                        _faces[Face.Right][0, 0] = tempColor1;
                        _faces[Face.Right][1, 0] = tempColor2;
                        _faces[Face.Right][2, 0] = tempColor3;
                    }
                    else
                    {
                        var tempColor1 = _faces[Face.Up][2, 0];
                        var tempColor2 = _faces[Face.Up][2, 1];
                        var tempColor3 = _faces[Face.Up][2, 2];

                        _faces[Face.Up][2, 0] = _faces[Face.Right][0, 0];
                        _faces[Face.Up][2, 1] = _faces[Face.Right][1, 0];
                        _faces[Face.Up][2, 2] = _faces[Face.Right][2, 0];

                        _faces[Face.Right][0, 0] = _faces[Face.Down][0, 2];
                        _faces[Face.Right][1, 0] = _faces[Face.Down][0, 1];
                        _faces[Face.Right][2, 0] = _faces[Face.Down][0, 0];

                        SetTopRowWithBottomRow(Face.Down, Face.Left);

                        _faces[Face.Left][0, 2] = tempColor3;
                        _faces[Face.Left][1, 2] = tempColor2;
                        _faces[Face.Left][2, 2] = tempColor1;
                    }

                    break;

                case Face.Right:
                    if (direction == Rotation.Clockwise)
                    {
                        var tempColor1 = _faces[Face.Up][0, 2];
                        var tempColor2 = _faces[Face.Up][1, 2];
                        var tempColor3 = _faces[Face.Up][2, 2];

                        SetRightCol(Face.Up, Face.Front);
                        SetRightCol(Face.Front, Face.Down);

                        _faces[Face.Down][0, 2] = _faces[Face.Back][2, 0];
                        _faces[Face.Down][1, 2] = _faces[Face.Back][1, 0];
                        _faces[Face.Down][2, 2] = _faces[Face.Back][0, 0];

                        _faces[Face.Back][0, 0] = tempColor3;
                        _faces[Face.Back][1, 0] = tempColor2;
                        _faces[Face.Back][2, 0] = tempColor1;
                    }
                    else
                    {
                        var tempColor1 = _faces[Face.Up][2, 2];
                        var tempColor2 = _faces[Face.Up][1, 2];
                        var tempColor3 = _faces[Face.Up][0, 2];

                        _faces[Face.Up][0, 2] = _faces[Face.Back][2, 0];
                        _faces[Face.Up][1, 2] = _faces[Face.Back][1, 0];
                        _faces[Face.Up][2, 2] = _faces[Face.Back][0, 0];

                        SetLeftColWithRightCol(Face.Back, Face.Down);

                        _faces[Face.Down][0, 2] = _faces[Face.Front][0, 2];
                        _faces[Face.Down][1, 2] = _faces[Face.Front][1, 2];
                        _faces[Face.Down][2, 2] = _faces[Face.Front][2, 2];

                        _faces[Face.Front][0, 2] = tempColor3;
                        _faces[Face.Front][1, 2] = tempColor2;
                        _faces[Face.Front][2, 2] = tempColor1;
                    }

                    break;
                case Face.Up:
                    if (direction == Rotation.Clockwise)
                    {
                        var tempColor1 = _faces[Face.Left][0, 0];
                        var tempColor2 = _faces[Face.Left][0, 1];
                        var tempColor3 = _faces[Face.Left][0, 2];

                        SetTopRow(Face.Left, Face.Front);
                        SetTopRow(Face.Front, Face.Right);
                        SetTopRow(Face.Right, Face.Back);

                        _faces[Face.Back][0, 0] = tempColor1;
                        _faces[Face.Back][0, 1] = tempColor2;
                        _faces[Face.Back][0, 2] = tempColor3;
                    }
                    else
                    {
                        var tempColor1 = _faces[Face.Left][0, 0];
                        var tempColor2 = _faces[Face.Left][0, 1];
                        var tempColor3 = _faces[Face.Left][0, 2];

                        SetTopRow(Face.Left, Face.Back);
                        SetTopRow(Face.Back, Face.Right);
                        SetTopRow(Face.Right, Face.Front);

                        _faces[Face.Front][0, 0] = tempColor1;
                        _faces[Face.Front][0, 1] = tempColor2;
                        _faces[Face.Front][0, 2] = tempColor3;
                    }

                    break;

                case Face.Back:
                    if (direction == Rotation.Clockwise)
                    {
                        var tempColor1 = _faces[Face.Right][0, 2];
                        var tempColor2 = _faces[Face.Right][1, 2];
                        var tempColor3 = _faces[Face.Right][2, 2];

                        _faces[Face.Right][0, 2] = _faces[Face.Down][2, 2];
                        _faces[Face.Right][1, 2] = _faces[Face.Down][2, 1];
                        _faces[Face.Right][2, 2] = _faces[Face.Down][2, 0];

                        _faces[Face.Down][2, 0] = _faces[Face.Left][0, 0];
                        _faces[Face.Down][2, 1] = _faces[Face.Left][1, 0];
                        _faces[Face.Down][2, 2] = _faces[Face.Left][2, 0];
                        
                        _faces[Face.Left][0, 0] = _faces[Face.Up][0, 2];
                        _faces[Face.Left][1, 0] = _faces[Face.Up][0, 1];
                        _faces[Face.Left][2, 0] = _faces[Face.Up][0, 0];

                        _faces[Face.Down][0, 2] = _faces[Face.Left][2, 2];
                        _faces[Face.Down][0, 1] = _faces[Face.Left][1, 2];
                        _faces[Face.Down][0, 0] = _faces[Face.Left][0, 2];

                        _faces[Face.Up][0, 0] = tempColor1;
                        _faces[Face.Up][0, 1] = tempColor2;
                        _faces[Face.Up][0, 2] = tempColor3;
                    }
                    else
                    {
                        var tempColor1 = _faces[Face.Right][0, 2];
                        var tempColor2 = _faces[Face.Right][1, 2];
                        var tempColor3 = _faces[Face.Right][2, 2];

                        _faces[Face.Right][0, 2] = _faces[Face.Up][0, 0];
                        _faces[Face.Right][1, 2] = _faces[Face.Up][0, 1];
                        _faces[Face.Right][2, 2] = _faces[Face.Up][0, 2];
                        
                        _faces[Face.Up][0, 0] = _faces[Face.Left][2, 0];
                        _faces[Face.Up][0, 1] = _faces[Face.Left][1, 0];
                        _faces[Face.Up][0, 2] = _faces[Face.Left][0, 0];

                        _faces[Face.Left][0, 0] = _faces[Face.Down][2, 0];
                        _faces[Face.Left][1, 0] = _faces[Face.Down][2, 1];
                        _faces[Face.Left][2, 0] = _faces[Face.Down][2, 2];

                        _faces[Face.Down][2, 0] = tempColor3;
                        _faces[Face.Down][2, 1] = tempColor2;
                        _faces[Face.Down][2, 2] = tempColor1;
                    }

                    break;

                case Face.Left:
                    if (direction == Rotation.Clockwise)
                    {
                        var tempColor1 = _faces[Face.Front][0, 0];
                        var tempColor2 = _faces[Face.Front][1, 0];
                        var tempColor3 = _faces[Face.Front][2, 0];

                        SetLeftCol(Face.Front, Face.Up);
                        SetLeftColWithRightCol(Face.Up, Face.Back);

                        _faces[Face.Back][0, 2] = _faces[Face.Down][2, 0];
                        _faces[Face.Back][1, 2] = _faces[Face.Down][1, 0];
                        _faces[Face.Back][2, 2] = _faces[Face.Down][0, 0];
                        
                        _faces[Face.Down][0, 0] = tempColor1;
                        _faces[Face.Down][1, 0] = tempColor2;
                        _faces[Face.Down][2, 0] = tempColor3;
                    }
                    else
                    {
                        var tempColor1 = _faces[Face.Front][0, 0];
                        var tempColor2 = _faces[Face.Front][1, 0];
                        var tempColor3 = _faces[Face.Front][2, 0];

                        SetLeftCol(Face.Front, Face.Down);
                        SetLeftColWithRightCol(Face.Down, Face.Back);
                        
                        _faces[Face.Back][0, 2] = _faces[Face.Up][2, 0];
                        _faces[Face.Back][1, 2] = _faces[Face.Up][1, 0];
                        _faces[Face.Back][2, 2] = _faces[Face.Up][0, 0];
                        
                        _faces[Face.Up][0, 0] = tempColor1;
                        _faces[Face.Up][1, 0] = tempColor2;
                        _faces[Face.Up][2, 0] = tempColor3;
                    }

                    break;

                case Face.Down:
                    if (direction == Rotation.Clockwise)
                    {
                        var tempColor1 = _faces[Face.Front][2, 0];
                        var tempColor2 = _faces[Face.Front][2, 1];
                        var tempColor3 = _faces[Face.Front][2, 2];

                        SetBottomRow(Face.Front, Face.Left);
                        SetBottomRow(Face.Left, Face.Back);
                        SetBottomRow(Face.Back, Face.Right);

                        _faces[Face.Right][2, 2] = tempColor3;
                        _faces[Face.Right][2, 1] = tempColor2;
                        _faces[Face.Right][2, 0] = tempColor1;
                    }
                    else
                    {
                        var tempColor1 = _faces[Face.Front][2, 0];
                        var tempColor2 = _faces[Face.Front][2, 1];
                        var tempColor3 = _faces[Face.Front][2, 2];

                        SetBottomRow(Face.Front, Face.Right);
                        SetBottomRow(Face.Right, Face.Back);
                        SetBottomRow(Face.Back, Face.Left);

                        _faces[Face.Left][2, 2] = tempColor3;
                        _faces[Face.Left][2, 1] = tempColor2;
                        _faces[Face.Left][2, 0] = tempColor1;
                    }

                    break;

                default:
                    return;
            }
        }

        private void SetTopRow(Face faceToBeSet, Face faceValue)
        {
            _faces[faceToBeSet][0, 0] = _faces[faceValue][0, 0];
            _faces[faceToBeSet][0, 1] = _faces[faceValue][0, 1];
            _faces[faceToBeSet][0, 2] = _faces[faceValue][0, 2];
        }

        private void SetTopRowWithBottomRow(Face faceToBeSet, Face faceValue)
        {
            _faces[faceToBeSet][0, 0] = _faces[faceValue][0, 2];
            _faces[faceToBeSet][0, 1] = _faces[faceValue][1, 2];
            _faces[faceToBeSet][0, 2] = _faces[faceValue][2, 2];
        }

        private void SetBottomRow(Face faceToBeSet, Face faceValue)
        {
            _faces[faceToBeSet][2, 0] = _faces[faceValue][2, 0];
            _faces[faceToBeSet][2, 1] = _faces[faceValue][2, 1];
            _faces[faceToBeSet][2, 2] = _faces[faceValue][2, 2];
        }

        private void SetLeftCol(Face faceToBeSet, Face faceValue)
        {
            _faces[faceToBeSet][0, 0] = _faces[faceValue][0, 0];
            _faces[faceToBeSet][1, 0] = _faces[faceValue][1, 0];
            _faces[faceToBeSet][2, 0] = _faces[faceValue][2, 0];
        }

        private void SetRightCol(Face faceToBeSet, Face faceValue)
        {
            _faces[faceToBeSet][0, 2] = _faces[faceValue][0, 2];
            _faces[faceToBeSet][1, 2] = _faces[faceValue][1, 2];
            _faces[faceToBeSet][2, 2] = _faces[faceValue][2, 2];
        }

        private void SetLeftColWithRightCol(Face faceToBeSet, Face faceValue)
        {
            _faces[faceToBeSet][0, 0] = _faces[faceValue][2, 2];
            _faces[faceToBeSet][1, 0] = _faces[faceValue][1, 2];
            _faces[faceToBeSet][2, 0] = _faces[faceValue][0, 2];
        }

        private void RotateFaceMatrix(Face face, Rotation direction)
        {
            const int matrixSize = 3;
            var rotated = new Colors[matrixSize, matrixSize];

            for (var row = 0; row < matrixSize; row++)
            {
                for (var col = 0; col < matrixSize; col++)
                {
                    if (direction == Rotation.Clockwise)
                    {
                        rotated[col, matrixSize - 1 - row] = _faces[face][row, col];
                    }
                    else
                    {
                        rotated[matrixSize - 1 - col, row] = _faces[face][row, col];
                    }
                }
            }

            _faces[face] = rotated;
        }
    }
}