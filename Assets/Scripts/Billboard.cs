using UnityEngine;

namespace Game
{
    // This class was inspired by https://wiki.unity3d.com/index.php/CameraFacingBillboard
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Camera cameraToLookAt;

        // Orient the camera after all movement is completed this frame to avoid jittering
        void LateUpdate()
        {
            var rotation = cameraToLookAt.transform.rotation;
            
            transform.LookAt(transform.position + rotation * Vector3.forward,
                rotation * Vector3.up);
        }
    }
}