using UnityEngine;

namespace DarkestMaze
{
    public class Player : MonoBehaviour
    {
        private GameObject _bat;  // для того, чтобы потом убрать со сцены батарейку

        private FlashLight _flashLight;  // фонарик
        public GameObject inscription;  // надпись(Нажмите кнопку F)

        private Battery _battery = new Battery();  // батарейка 
        private ThingForVictory _thingForVictory = new ThingForVictory();  // предмет для победы

        private bool _enterBattery = false;  // попали ли мы лучом в батарейку или предмет победы
        private bool _enterFinish = false;

        private float _dist;  // расстояние между игроком и монстром
        public float distForLoss = 2f;  // расстояние между игроком и монстром, чтобы игрок погиб


        [SerializeField]
        private GameObject _monster;  // монстр

        [SerializeField]
        private int MaxSearchDist = 3;  // максимальное расстояние, на котором игрок будет определять предметы(батарейки, двери, и т.д.)

        private void Awake()
        {
            _flashLight = FindObjectOfType<FlashLight>();
        }

        public void UpdatePlayer(float deltaTime)
        {
            _flashLight.UpdateFlashLight(deltaTime);  // вызываем Update у фонарика
            #region Старый код
            //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            //transform.Rotate(0, x, 0);
            //transform.Translate(0, 0, z);
            #endregion
            SearchObjects();  // Ищем объекты

            ShowInscription();  // Выводим надпись, если она нужна

            TakeObject();  // Берем предмет

            DistToMonster();  // Смотрим расстояние от монстра до игрока

            IsBatteryEmpty();  // Проверяем заряд батарейки
        }

        private void SearchObjects()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxSearchDist))  // стреляем вперед лучом из камеры
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); // рисуем луч

                switch (hit.transform.tag) // смотрим тэг предмета, в который попали
                {
                    case "Battery":
                        _enterBattery = true;  // игрок попал лучом в батарейку 
                        _bat = hit.transform.gameObject;  // запоминаем предмет, чтобы потом удалить, когда подберем его
                        break;
                    case "Finish":
                        _enterFinish = true;  // игрок попал лучом в предмет для победы 
                        break;
                    default:
                        break;
                }
            }
            else   // если игрок никуда не попал лучом
            {
                _enterBattery = false;
                _enterFinish = false;
            }
        }

        private void IsBatteryEmpty()
        {
            if (_flashLight.WorkTime >= _flashLight.MaxWorkTime) // если заряд фонарика иссяк, то игрок погибает
                Death();
        }

        private void DistToMonster()
        {
            _dist = Vector3.Distance(transform.position, _monster.transform.position); // расстояние между монстром и игроком

            if (_dist <= distForLoss)  // если расстояние между монстром и игроком меньше расстояния для проигрыша, то игрок погибает
                Death();
        }

        public void Death()
        {         
            print("Игрок погиб");
        }

        private void TakeObject()
        {
            if (_enterBattery && UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                _battery.AddEnergy(_flashLight);  // добавляем заряд к батарейке
                Destroy(_bat);  // уничтожаем батарейку
            }

            if (_enterFinish && UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                _thingForVictory.Victory(); // вызываем метод победы
                print("Победа");
            }
        }

        private void ShowInscription()
        {
            if (_enterBattery == true || _enterFinish == true) // если мы подошли к какому-нибудь предмету, выводим надпись
                inscription.gameObject.SetActive(true);
            else
                inscription.gameObject.SetActive(false);
        }
    }
}