using UnityEngine;

namespace Core
{
    public sealed class GameStart : MonoBehaviour
    {
        [SerializeField] private MainBase _mainPrefab;
        private IMain _currentMain;
        
        private void Start()
        {
#if LG_DEVELOP
            if (!CheckHasMain())
            {
#endif
                _currentMain = Instantiate(_mainPrefab, transform, false);
#if LG_DEVELOP
                
            }
            else
            {
                DestroyImmediate(gameObject);
            }
#endif
        }

#if LG_DEVELOP
        private static bool CheckHasMain()
        {
            return FindObjectsOfType<MainBase>().Length > 0;
        }
#endif
    }
}