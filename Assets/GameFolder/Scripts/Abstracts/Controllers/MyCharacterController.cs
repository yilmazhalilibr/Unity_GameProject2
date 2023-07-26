using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstracts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {

        [SerializeField] float _moveBoundary = 4.5f;
        [SerializeField] protected float _moverSpeed = 1f;

        public float MoveSpeed => _moverSpeed;
        public float MoveBoundary => _moveBoundary;
    }
}

