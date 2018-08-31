using DarkestMaze;
using UnityEngine;

/// <summary>
/// Генератор лабиринта компонент
/// </summary>
public class Generator
{

    private readonly int _num;
    private readonly int _height;
    private readonly int _width;

    private Transform _rootMaze;
    private readonly Room[,] _rooms = new Room[4, 4];

    public Generator(int height, int width, int num)
    {
        _height = height;
        _width = width;
        _num = num;
    }

    /// <summary>
    /// Генерация лабиринта
    /// </summary>
    public void GenerateMaze()
    {
        _rootMaze = new GameObject("RootMaze").transform;
        for (var i = 0; i <= _height - 1; i++)
        {
            for (var j = 0; j <= _width - 1; j++)
            {
                float fX = i * _height;
                float fZ = j * _width;

                _rooms[i, j] = new Room()
                {
                    X = fX,
                    Y = 0.0f,
                    Z = fZ,
                    num = Random.Range(1, 10)
                };



                #region генерируем разные комнаты

                if (_rooms[i, j].num >= 1 && _rooms[i, j].num <= 4)
                {
                    _rooms[i, j].Prefab = "Floor_A";
                }
                else if (_rooms[i, j].num >= 5 && _rooms[i, j].num <= 9)
                {
                    _rooms[i, j].Prefab = "Floor_B";
                }

                #endregion


                #region генерируем пол

                ObjectLabirint(_rooms[i, j].Prefab, new Vector3(_rooms[i, j].X, _rooms[i, j].Y, _rooms[i, j].Z), 0);

                #endregion


                #region генерируем стены

                if (i == 0)
                {
                    ObjectLabirint("Wall_C", new Vector3(_rooms[i, j].X - (0.68f * 2) - 0.4f, 0.0f, _rooms[i, j].Z), 0);
                }

                if (i == _width - 1)
                {
                    ObjectLabirint("Wall_C", new Vector3(_rooms[i, j].X + (0.68f * 2) + 0.4f, 0.0f, _rooms[i, j].Z), 0);
                }

                if (j == 0)
                {
                    ObjectLabirint("Wall_C", new Vector3(_rooms[i, j].X, 0.0f, _rooms[i, j].Z - (0.68f * 2) - 0.4f), 90);
                }

                if (j == _height - 1)
                {
                    ObjectLabirint("Wall_C", new Vector3(_rooms[i, j].X, 0.0f, _rooms[i, j].Z + (0.68f * 2) + 0.4f), 90);
                }


                if (i > 0 || i < _width - 1 || j == 0)
                {
                    ObjectLabirint("Doorway_C", new Vector3(_rooms[i, j].X - (0.68f * 2) - 0.4f, 0.0f, _rooms[i, j].Z), 0);
                }

                if (j > 0 || j < _height - 1 || i == 0)
                {
                    ObjectLabirint("Doorway_C", new Vector3(_rooms[i, j].X, 0.0f, _rooms[i, j].Z - (0.68f * 2) - 0.4f), 90);
                }

                #endregion


            }
        }
    }

    private void ObjectLabirint(string prefab = "", Vector3 pos = default(Vector3), int rotate = 0)
    {
        GameObject.Instantiate(Resources.Load(prefab), new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(0, rotate, 0), _rootMaze);
    }
}
