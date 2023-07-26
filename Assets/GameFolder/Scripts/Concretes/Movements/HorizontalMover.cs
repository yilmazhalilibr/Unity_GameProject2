using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;
using UdemyProject2.Controllers;
using UnityEngine;


namespace UdemyProject2.Movements
{
    public class HorizontalMover : IMover
    {
        IEntityController _entityController;

        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float direction)
        {
            if (direction == 0) return;

            _entityController.transform.Translate(Vector3.right * direction * Time.deltaTime * _entityController.MoveSpeed);

            float xboundary = Mathf.Clamp(_entityController.transform.position.x, -_entityController.MoveBoundary, _entityController.MoveBoundary);
            _entityController.transform.position = new Vector3(xboundary, _entityController.transform.position.y, 0);
        }


    }
}

