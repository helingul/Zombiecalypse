using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler

{
    private Image treshold;
    private Image touch;

    [HideInInspector]
    public Vector3 inputDir;
    
    public bool shoot;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(treshold.rectTransform,
            eventData.position,eventData.pressEventCamera,out position)){
            position.x = (position.x / treshold.rectTransform.sizeDelta.x);
            position.y = (position.y / treshold.rectTransform.sizeDelta.y);


            float x = (treshold.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (treshold.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

            inputDir = new Vector3(x, y, 0);
            inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;
            inputDir.Normalize();

            touch.rectTransform.anchoredPosition = new Vector3(inputDir.x * (treshold.rectTransform.sizeDelta.x / 2.5f),
                inputDir.y * (treshold.rectTransform.sizeDelta.y / 2.5f));
            
            if (shoot)
            {
                FindObjectOfType<Player>().canShoot = true;
            }

        }
            
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!shoot) { 
            inputDir = Vector3.zero;
        }
        else
        {
            FindObjectOfType<Player>().canShoot = false;
        }
           
        touch.rectTransform.anchoredPosition = Vector3.zero;

        
    }
    // Start is called before the first frame update
    void Start()
    {
        treshold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector3.zero;
    }

}
