using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkestMaze.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Контроллер поведения игрового меню
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        /// <summary>
        /// Модель меню
        /// </summary>
        public MenuModel MenuModel { get; private set; }

        /// <summary>
        /// Флаг активности игрого меню
        /// </summary>
        public bool IsMenuActive { get; private set; }

        /// <summary>
        /// Конфигурация текущего активного меню
        /// </summary>
        private MenuConfig _menuConfig;

        /// <summary>
        /// Конфигурация предыдущего активного меню
        /// </summary>
        private MenuConfig _previousMenuConfig;

        /// <summary>
        /// Создание меню
        /// </summary>
        /// <param name="menu">Конфигурация меню</param>
        /// <param name="parent">Объект-родитель для меню</param>
        public void CreateMenu(MenuConfig menu, Transform parent)
        {
            _previousMenuConfig = _menuConfig;
            _menuConfig = menu;

            var menuPrefab = Resources.Load<GameObject>(_menuConfig.ResourceUiPrefabsPath + _menuConfig.DefaultMenuPanel);
            MenuModel = Instantiate(menuPrefab, parent.position,
                Quaternion.identity, parent).AddComponent<MenuModel>();

            SetTitle(_menuConfig.Title);
            SetContent(_menuConfig.Elements);
            IsMenuActive = true;
        }

        /// <summary>
        /// Установка заголовка
        /// </summary>
        /// <param name="title"></param>
        private void SetTitle(string title)
        {
            MenuModel.transform.Find("Title").GetComponent<Text>().text = title;
            MenuModel.Title = title;
        }

        /// <summary>
        /// Установка элементов интерфейса меню
        /// </summary>
        /// <param name="elements">Массив элементов интерфейса меню</param>
        private void SetContent(MenuElement[] elements)
        {
            var contentPanel = MenuModel.transform.Find(_menuConfig.MenuPanelUiElementsContainer);

            foreach (var menuElement in elements)
            {
                AddElement(menuElement, contentPanel);
            }
        }

        /// <summary>
        /// Добавление элемента интерфейса меню
        /// </summary>
        /// <param name="element">Элемент интерфейса</param>
        /// <param name="parent">Объект-родитель для элементов интерфейса меню</param>
        private void AddElement(MenuElement element, Transform parent)
        {
            var uiType = Type.GetType(_menuConfig.UiNamespace + "." + element.ScriptName);
            var uiElementGameobject = Instantiate(Resources.Load<GameObject>(_menuConfig.ResourceUiPrefabsPath + element.PrefabName), parent);
            var uiElement = (UiElementModel)uiElementGameobject.AddComponent(uiType);
            MenuModel.UiElements.Add(uiElement);
        }

        /// <summary>
        /// Создание меню с предыдущей конфигурацией
        /// </summary>
        /// <param name="parent">Объект-родитель для меню</param>
        public void CreatePreviousMenu(Transform parent)
        {
            CreateMenu(_previousMenuConfig, parent);
        }

        /// <summary>
        /// Удаление игрового меню со сцены
        /// </summary>
        public void DestroyMenu()
        {
            Destroy(MenuModel.gameObject);
            IsMenuActive = false;
        }
    }
}