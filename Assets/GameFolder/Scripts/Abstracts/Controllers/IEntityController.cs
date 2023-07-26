using UnityEngine;

namespace UdemyProject2.Abstracts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
        public float MoveSpeed { get; }
        public float MoveBoundary { get; }
    }
}

