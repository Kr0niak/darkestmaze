using System;
using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Параметры для создания игрового меню
    /// </summary>
    [CreateAssetMenu(menuName = "Config/Menu")]
    public class MenuConfig : ScriptableObject
    {
        /// <summary>
        /// Путь к папке с элементами интерфейса в Resources
        /// </summary>
        [Header("Common Settings:")]
        public string ResourceUiPrefabsPath = "UI/";

        /// <summary>
        /// Имя префаба панели для игрового меню
        /// </summary>
        public string DefaultMenuPanel = "MenuPanel";

        /// <summary>
        /// Имя объекта в иерархии панели меню для содержания элементов интерфейса
        /// </summary>
        public string MenuPanelUiElementsContainer = "Content";

        /// <summary>
        /// Пространство имен классов элементов интерфейса
        /// </summary>
        public string UiNamespace = "DarkestMaze.UI";

        /// <summary>
        /// Заголовок элемента интерфейса
        /// </summary>
        [Header("Individual Settings:")]
        public string Title;

        /// <summary>
        /// Массив элементов интерфейса
        /// </summary>
        public MenuElement[] Elements;
    }
}