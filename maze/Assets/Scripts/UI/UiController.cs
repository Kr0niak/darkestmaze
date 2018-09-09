using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Interfaces;
using DarkestMaze.Services;
using UnityEngine;
using UnityEngine.UI;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Контроллер пользовательского интерфейса
    /// </summary>
    public class UiController : MonoBehaviour, ISubscribe
    {
        public MenuController MenuController { get; private set; }

        /// <summary>
        /// Корневой объект пользовательского интерфейса
        /// </summary>
        private GameObject UiRoot { get; set; }

        /// <summary>
        /// Имя корневого объекта пользовательского интерфейса
        /// </summary>
        private const string UiRootName = "UI";

        private void Awake()
        {
            UiRoot = new GameObject
            {
                name = UiRootName
            };

            var canvas = UiRoot.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            var canvasScaler = canvas.gameObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            canvas.gameObject.AddComponent<GraphicRaycaster>();

            MenuController = gameObject.AddComponent<MenuController>();
            MenuController.CreateMenu(Config.Instance.MainMenu, UiRoot.transform);
        }

        private void NewGameStartOrContinue()
        {
            MenuController.DestroyMenu();
        }

        private void OptionsMenu()
        {
            MenuController.DestroyMenu();
            MenuController.CreateMenu(Config.Instance.OptionsMenu, UiRoot.transform);
        }

        private void BackInMenu()
        {
            MenuController.DestroyMenu();
            MenuController.CreatePreviousMenu(UiRoot.transform);
        }

        private void PausePlay()
        {
            if (MenuController.IsMenuActive)
            {
                MenuController.DestroyMenu();
            }
            else
            {
                MenuController.CreateMenu(Config.Instance.PauseMenu, UiRoot.transform);
            }
        }

        public void OnNotification(Notification notification, GameObject target, params object[] data)
        {
            switch (notification)
            {
                case Notification.PausePlay:
                    PausePlay();
                    break;

                case Notification.NewGame:
                case Notification.ResumePlay:
                    NewGameStartOrContinue();
                    break;

                case Notification.OptionsMenu:
                    OptionsMenu();
                    break;

                case Notification.BackInMenu:
                    BackInMenu();
                    break;
            }
        }
    }
}