using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель кнопки New Game
    /// </summary>
    public class NewGameButton : ButtonModel
    {
        protected override string Title => "New Game";

        public override void ButtonClick()
        {
            Core.Instance.Notify(Notification.NewGame,gameObject);
        }
    }
}