using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstracts.Movements
{
    public interface IJump
    {

        void FixedTick(float jumpForce);
    }

}
