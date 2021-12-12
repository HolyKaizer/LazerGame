using Core.Controllers;
using Core.Controllers.Containers;
using Core.Interfaces.Controllers;
using UnityEngine;

namespace Core
{
    public sealed class GameStart : MonoBehaviour
    {
        [SerializeField] private Main _mainPrefab;
        [SerializeField] private SplashScreenContainer _screenContainer;
        private ISplashScreen _splashScreen;
        
        private void Start()
        {
#if LG_DEVELOP
            if (!CheckHasMain())
            {
#endif
                var main = Instantiate(_mainPrefab);
                _splashScreen = new SplashScreen(_screenContainer);

                main.SetSplash(_splashScreen);
                main.SetLoadingProgress(0);
                _splashScreen.SetProgress(main);
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
            return FindObjectsOfType<Main>().Length > 0;
        }
#endif
    }
}