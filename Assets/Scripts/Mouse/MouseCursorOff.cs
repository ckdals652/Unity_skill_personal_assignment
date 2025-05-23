using UnityEngine;

namespace DefaultNamespace
{
    public class MouseCursorOff:MonoBehaviour
    {
        private void Start()
        {
            //마우스 커서 안 보이게하기
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}