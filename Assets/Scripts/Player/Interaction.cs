using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Interaction : MonoBehaviour
{    
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    [FormerlySerializedAs("Interection")] public ItemInterection interection; 
    
    public TextMeshProUGUI promptText;
    private Camera camera;
    
    void Start()
    {
        camera = Camera.main;
    }
    
    void Update()
    {
        if(Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if(hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    interection = curInteractGameObject.GetComponent<ItemInterection>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }
    
    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = interection.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && interection != null)
        {
            curInteractGameObject = null;
            interection = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
