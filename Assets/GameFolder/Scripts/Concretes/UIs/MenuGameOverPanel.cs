using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.UIs
{
    public class MenuGameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene("GameScene");
        }

        public void NoButton()
        {
            GameManager.Instance.LoadScene("Menu");

        }
    }
}

