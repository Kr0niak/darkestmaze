using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель игрового меню
    /// </summary>
    public class MenuModel : MonoBehaviour
    {
        /// <summary>
        /// Заголовок меню
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Коллекция элементов интерфейса меню
        /// </summary>
        public List<UiElementModel> UiElements { get; set; }

        private void Awake()
        {
            UiElements = new List<UiElementModel>();
        }
    }
}