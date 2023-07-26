using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UdemyProject2.Controllers;
using UdemyProject2.Enums;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class EnemyManager : SingeltonMonoBehaviourObject<EnemyManager>
    {
        [SerializeField] EnemyController[] _enemyPrefabs;
        [SerializeField] float _addDelayTime = 50f;
        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        float _moveSpeed;

        public float AddDelayTime => _addDelayTime;

        public int Count => _enemyPrefabs.Length;

        void Awake()
        {
            SingletonThisObject(this);
        }

        void Start()
        {
            InitializePool();
        }

        void InitializePool()
        {
            for (int j = 0; j < _enemyPrefabs.Length; j++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int i = 0; i < 10; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[j]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = transform;
                    enemyControllers.Enqueue(newEnemy);
                }
                _enemies.Add((EnemyEnum)j, enemyControllers);

            }

        }
        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);

        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }
            }
            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);
            return enemyController;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        public void SetDelayTime(float addDelayTime)
        {
            _addDelayTime = addDelayTime;
        }
    }
}

