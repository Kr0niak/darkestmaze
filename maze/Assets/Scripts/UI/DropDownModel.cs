using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Модешь выпадающего списка
    /// </summary>
    public abstract class DropDownModel : UiElementModel
    {
        protected Text Text;

        protected abstract string Title { get; }

        /// <summary>
        /// Опции списка
        /// </summary>
        protected abstract List<string> Options { get; }

        public override Type UiElementType => typeof(Dropdown);

        protected override void Awake()
        {
            base.Awake();

            UiElement = GetComponentInChildren<Dropdown>();
            ((Dropdown)UiElement).AddOptions(Options);
            ((Dropdown)UiElement).onValueChanged.AddListener(ValueChanged);

            Text = transform.GetComponentInChildren<Text>();
            Text.text = Title;
        }

        public abstract void ValueChanged(int value);
    }
}