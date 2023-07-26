using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Movements;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class JumpWithRigidbody : IJump
    {
        Rigidbody _rigidbody;

        PlayerController _playerController;

        public bool CanJump => _rigidbody.velocity.y != 0f;

        public JumpWithRigidbody(PlayerController playerController)
        {
            _playerController = playerController;

            _rigidbody = _playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(float jumpForce)
        {
            if (CanJump) return;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        }
    }

}
