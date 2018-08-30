using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Комната
    /// </summary>
    public class Room : MazeObject
    {
        /// <summary>
        /// Настройки комнаты
        /// </summary>
        public RoomConfig RoomConfig { get; private set; }

        public int num;

        /// <summary>
        /// Список предметов для взаимодействия в комнате
        /// </summary>
        public readonly List<Item> items = new List<Item>();

        public Room(RoomConfig roomConfig)
        {
            RoomConfig = roomConfig;
        }

        /// <summary>
        /// Попытка добавления предмета в комнату
        /// </summary>
        /// <param name="item">Предмет для взаимодействия</param>
        /// <returns></returns>
        public bool TryAddItem(Item item)
        {
            if (items.Count >= RoomConfig.MaxItems)
            {
                return false;
            }
            
            items.Add(item);

            return true;
        }
    }
}
