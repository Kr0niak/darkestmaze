using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель кнопки Back
    /// </summary>
    public class BackButton : ButtonModel
    {
        protected override string Title => "Back";

        public override void ButtonClick()
        {
            Core.Instance.Notify(Notification.BackInMenu, gameObject);
        }
    }
}