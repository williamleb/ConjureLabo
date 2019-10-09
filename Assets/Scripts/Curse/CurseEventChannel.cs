using UnityEngine;

namespace Game
{
    public delegate void BaseCurseEventChannelEventManager();
    public delegate void PositionCurseEventChannelEventManager(Vector3 position);
        
    public class CurseEventChannel : MonoBehaviour
    {
        public event BaseCurseEventChannelEventManager OnCurseStarted;
        public event BaseCurseEventChannelEventManager OnCurseFinished;
        public event PositionCurseEventChannelEventManager OnCursePositionUpdated;

        public void PublishCurseStarted()
        {
            OnCurseStarted?.Invoke();
        }
        
        public void PublishCurseFinished()
        {
            OnCurseFinished?.Invoke();
        }

        public void PublishNewCursePosition(Vector3 cursePosition)
        {
            OnCursePositionUpdated?.Invoke(cursePosition);
        }
    }
}