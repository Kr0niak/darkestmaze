using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель кнопки Options
    /// </summary>
    public class OptionsButton : ButtonModel
    {
        protected override string Title => "Options";

        public override void ButtonClick()
        {
            Core.Instance.Notify(Notification.OptionsMenu, gameObject);
        }
    }
}