using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UdemyProject2.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : SingeltonMonoBehaviourObject<GameManager>
    {
        [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];

        public event System.Action OnGameStop;
        int _difficultyIndex;

        public int DifficultyIndex
        {
            get => _difficultyIndex;
            set
            {
                if (_difficultyIndex < 0 || _difficultyIndex > _levelDifficultyDatas.Length)
                {
                    LoadSceneAsync("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }

        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Exit Succed");
            Application.Quit();
        }


    }
}

