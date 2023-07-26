using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Enums;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] float _maxLifeTime = 10f;
        [SerializeField] EnemyEnum _enemyEnum;

        VerticalMover _verticalMover;
        float _currentLifeTime = 0f;

        public EnemyEnum EnemyType => _enemyEnum;

        private void Awake()
        {
            _verticalMover = new VerticalMover(this);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }

        private void FixedUpdate()
        {
            _verticalMover.FixedTick();
        }

        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            if (moveSpeed < _moverSpeed) return;
            _moverSpeed = moveSpeed;
        }
    }
}

