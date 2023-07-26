using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Abstracts.Movements;
using UdemyProject2.Inputs;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MyCharacterController, IEntityController
    {

        [SerializeField] float _jumpForce = 150f;
        [SerializeField] bool _isJump;

        IMover _mover;
        IJump _jumpWithRigidbody;
        IInputReader _input;
        float _horizontal;
        bool _isDead = false;



        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jumpWithRigidbody = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }
        private void Update()
        {
            if (_isDead) return;

            _horizontal = _input.Horizontal;

            if (_input.IsJump)
            {
                _isJump = true;
            }
        }
        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal);
            if (_isJump)
            {
                _jumpWithRigidbody.FixedTick(_jumpForce);
            }
            _isJump = false;

        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();
            if (entityController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}

