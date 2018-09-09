using UnityEngine;

namespace DarkestMaze
{
    public class Trap : MonoBehaviour
    {
        private Player _player;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                gameObject.GetComponent<MeshCollider>().enabled = false; // отключаем коллайдер пола, на котором есть этот скрипт
                _player.Death(); // смерть игрока
            }
        }
    }
}