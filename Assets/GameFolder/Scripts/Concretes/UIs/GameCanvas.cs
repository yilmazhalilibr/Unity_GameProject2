using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.UIs
{
    public class GameCanvas : MonoBehaviour
    {

        [SerializeField] MenuGameOverPanel _gameOverPanel;

        private void Awake()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;

        }
        private void HandleOnGameStop()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }

}
