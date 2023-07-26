using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton(int index)
        {
            GameManager.Instance.DifficultyIndex = index;
            GameManager.Instance.LoadScene("GameScene");
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

