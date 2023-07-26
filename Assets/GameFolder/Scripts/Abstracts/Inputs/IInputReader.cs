using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstracts.Inputs
{
    public interface IInputReader
    {
        float Horizontal { get; }
        bool IsJump { get; }
    }
}

