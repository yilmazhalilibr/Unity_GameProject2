using UdemyProject2.Managers;
using UdemyProject2.ScriptableObjects;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class LevelInitializerController : MonoBehaviour
    {
        LevelDifficultyData _levelDifficultyData;

        private void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }

        private void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyBoxMaterial;
            Instantiate(_levelDifficultyData.FloorPrefab);
            Instantiate(_levelDifficultyData.SpawnersPrefab);
            EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
            EnemyManager.Instance.SetDelayTime(_levelDifficultyData.AddDelayTime);
        }


    }
}

