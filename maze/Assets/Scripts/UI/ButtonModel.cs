using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модель кнопки
    /// </summary>
    public abstract class ButtonModel : UiElementModel
    {
        protected Text Text;

        protected abstract string Title { get; }

        public override Type UiElementType => typeof(Button);

        protected override void Awake()
        {
            base.Awake();

            UiElement = GetComponent<Button>();
            ((Button)UiElement).onClick.AddListener(ButtonClick);

            Text = transform.GetComponentInChildren<Text>();
            Text.text = Title;
        }

        public abstract void ButtonClick();
    }
}