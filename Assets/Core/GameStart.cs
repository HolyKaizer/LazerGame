using UnityEngine;

namespace Core
{
    public sealed class GameStart : MonoBehaviour
    {
        [SerializeField] private MainBase _mainPrefab;
        
        private void Start()
        {
            Instantiate(_mainPrefab, transform, false);
        }
    }
}