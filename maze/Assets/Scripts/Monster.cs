using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {

    private NavMeshAgent _agent;
    [SerializeField]
    private Transform _eyesTransform; // откуда будем стрелять лучами
    [SerializeField]
    private float _searchDistance; // расстояние, с которого начинаем следить за игроком
    [SerializeField]
    private float _attackDistance; // расстояние, с которого атакуем, даже если не увидели игрока
    [SerializeField]
    private GameObject _target; // игрок
    private bool _hasTarget; // видим цель или нет

    private float _time = 0;     // для отсчета времени, когда не видим игрока

    [SerializeField]
    private float timeToRandomRoom = 20f; // сколько времени понадобиться, чтобы переместиться в другую комнату 
    private int countRooms = 4; // кол-во комнат (потом его надо будет вытащить из core или из генератора)

    private float _roomTargetX; // коор-ты для перемещения в рандомную комнату
    private float _roomTargetZ;

   // private Generator _generator = new Generator(); // для того, чтобы узнать длину и ширину комнаты

    protected void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();   // берем агента
    }

    private void Update()
    {
        if (!_target) // если вообще нет цели, то выходим
            return;

        print(_time);

        float dist = Vector3.Distance(transform.position, _target.transform.position); // смотрим расстояние между монстром и игроком

        if (dist < _attackDistance)
        {
            _hasTarget = true;  // видим игрока
            _agent.SetDestination(_target.transform.position); // бежим к игроку
            _time = 0; // скидываем время(мы увидели игрока)
        }
        else if (dist < _searchDistance)
        {
            _hasTarget = !CheckBlocked(); // проверяем видит ли монстр игрока
            if (_hasTarget)
            {
                _agent.SetDestination(_target.transform.position);
                _time = 0;
            }
        }
        else
        {
            _hasTarget = false; // если не видит, то вызываем метод для рандомного перемещения по комнатам

            MoveToRandomRoom(Time.deltaTime);          
        }
    }

    private void MoveToRandomRoom(float deltaTime)
    {
        _time += Time.deltaTime; // добавляем время пока монстр не видит игрока

        if (_time >= timeToRandomRoom) 
        {
           /* _roomTargetX = Random.Range(0, countRooms) * _generator.height; // считаем координаты для рандомной комнаты
            _roomTargetZ = Random.Range(0, countRooms) * _generator.width;

            _agent.ResetPath(); // делаем ресет, чтобы он стоял там где его поставили
            _agent.transform.position = new Vector3(_roomTargetX, 0, _roomTargetZ); // перемещаем монстра
            _time = 0; */
        }
    }

    private bool CheckBlocked()
    {
        Vector3 raycastPos = new Vector3(0, _target.GetComponent<CapsuleCollider>().height * 0.475f, 0) + _target.transform.position; // куда будем стрелять лучом
        RaycastHit hit;

        Debug.DrawLine(_eyesTransform.position, _target.transform.position, Color.red); // рисуем лучи
        Debug.DrawLine(_eyesTransform.position, raycastPos, Color.red);

        if (Physics.Linecast(_eyesTransform.position, _target.transform.position, out hit)) // стреляем лучами в игрока
        {
            if (hit.transform == _target.transform)                                         // если луч не заблокировался чем-нибудь и попал в игрока, 
                return false;                                                               //то выдаем false
        }
        else if (Physics.Linecast(_eyesTransform.position, raycastPos, out hit))
        {
            if (hit.transform == _target.transform)
                return false;
        }

        return true; // если луч заблокировался обо что-то, то выдаем true
    }
}
