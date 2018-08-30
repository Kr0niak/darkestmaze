using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Обьекты этого класса хранят информацию о настройках поведения игрока
    /// </summary>
    [CreateAssetMenu(menuName = "Config/Player")]
    public class PlayerConfig : ScriptableObject
    {   
        /// <summary>
        /// Скорость перемещения игрока по умолчанию
        /// </summary>
        public float NormalSpeed = 10f;
        /// <summary>
        /// Скорость перемещения игрока при ускорении
        /// </summary>
        public float AccelerationSpeed = 15f;
        /// <summary>
        /// Чувствительность мыши
        /// </summary>
        public float Sensitivity = 5.0f;
        /// <summary>
        /// Уровень плавности поворота
        /// </summary>
        public float Smoothing = 2.0f;
        /// <summary>
        /// Максимальный угол поворота камеры за один кадр
        /// </summary>
        public float MaxRotationAngle = 50.0f;        
    }
}