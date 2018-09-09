using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель кнопки Exit
    /// </summary>
    public class ExitButton : ButtonModel
    {
        protected override string Title => "Exit";

        public override void ButtonClick()
        {
            Core.Instance.Notify(Notification.Exit, gameObject);
        }
    }
}