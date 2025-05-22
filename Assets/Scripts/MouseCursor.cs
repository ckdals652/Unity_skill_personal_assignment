using UnityEngine;

namespace DefaultNamespace
{
    public class MouseCursor:MonoBehaviour
    {
        void start()
        {
            //마우스 커서 안 보이게하기
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}