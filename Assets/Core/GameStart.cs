using UnityEngine;

namespace Core
{
    public sealed class GameStart : MonoBehaviour
    {
        [SerializeField] private MainBase _mainPrefab;
        private IMain _currentMain;
        
        private void Start()
        {
            if (!CheckHasMain())
            {
                _currentMain = Instantiate(_mainPrefab, transform, false);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        private static bool CheckHasMain()
        {
            return FindObjectsOfType<MainBase>().Length > 0;
        }
    }
}