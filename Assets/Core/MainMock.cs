using System.Collections;

namespace Core
{
#if LG_DEVELOP
    public sealed class MainMock : MainBase
    {
        protected override IEnumerator StartGameAsync()
        {
            yield return LoadGame();
            
            CustomLogger.LogAssertion("Mock StartCompleted");
        }
    }
#endif
}