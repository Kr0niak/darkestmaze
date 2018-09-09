
namespace DarkestMaze
{
    /// <summary>
    /// Предмет, представляющий собой батарейку для фонарика
    /// </summary>
    public class Battery : Item
    {
        /// <summary>
        /// Ёмкость заряда батарейки
        /// </summary>
        public readonly float Charge = 10.0f;

        
        public void AddEnergy(FlashLight flashLight)
        {
            flashLight.WorkTime -= Charge;

            if (flashLight.WorkTime < 0)
                flashLight.WorkTime = 0;
        }
    }
}