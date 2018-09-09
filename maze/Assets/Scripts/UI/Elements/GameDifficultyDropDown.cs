using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkestMaze.Services;
using UnityEngine;
using UnityEngine.UI;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель выпадающего списка уровней сложности игры
    /// </summary>
    public class GameDifficultyDropDown : DropDownModel
    {
        protected override string Title => "Difficulty";

        /// <summary>
        /// Коллекция уровней сложности
        /// </summary>
        protected override List<string> Options => Config.Instance.DifficultyLevels.Select(x => x.ToString()).ToList();

        protected override void Awake()
        {
            base.Awake();

            ((Dropdown) UiElement).value = Options.IndexOf(Core.Instance.DifficultyLevel.ToString());
        }

        public override void ValueChanged(int value)
        {
            Core.Instance.Notify(Notification.ChangeGameDifficulty, gameObject,value);
        }
    }
}