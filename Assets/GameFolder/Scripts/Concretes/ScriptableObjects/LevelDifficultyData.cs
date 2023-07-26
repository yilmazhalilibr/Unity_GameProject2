using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New", order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefab;
        [SerializeField] GameObject _spawnersPrefabs;
        [SerializeField] Material _skyBoxMaterial;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _addDelayTime = 50f;


        public FloorController FloorPrefab => _floorPrefab;
        public GameObject SpawnersPrefab => _spawnersPrefabs;
        public Material SkyBoxMaterial => _skyBoxMaterial;
        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;
    }
}

