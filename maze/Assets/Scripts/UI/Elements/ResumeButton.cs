using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель кнопки Resume
    /// </summary>
    public class ResumeButton : ButtonModel
    {
        protected override string Title => "Resume";

        public override void ButtonClick()
        {
            Core.Instance.Notify(Notification.ResumePlay, gameObject);
        }
    }
}