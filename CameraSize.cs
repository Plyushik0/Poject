using UnityEngine;
namespace GameDevSanya.Tools
{

    public class CameraSize : MonoBehaviour
    {
        private const float SizeX = 1920.0f;
        private const float SizeY = 1080.0f;
        private float _TargetSizeX = 0f;
        private float _TargetSizeY = 0f;
        private const float HalfSize = 200.0f; // половина выстоы в пикселях
        [SerializeField] private bool _isHorizontal = true;
        
        private void Awake()
        {
            _TargetSizeX = _isHorizontal ? SizeX : SizeY;
            _TargetSizeY = _isHorizontal ? SizeY : SizeX;

        }

        private void CameraResize()
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = _TargetSizeX / _TargetSizeY;
            if(screenRatio >= targetRatio)
            {
                Resize();
            }
            else
            {
                float differentSize = targetRatio / screenRatio;
                Resize(differentSize);
            }

        }
        
        private void Resize(float differentSize = 1.0f)
        {
            Camera.main.orthographicSize = _TargetSizeY / HalfSize * differentSize;
        }

    }
}