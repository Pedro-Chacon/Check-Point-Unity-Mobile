using UnityEngine;

public class TouchTrail : MonoBehaviour
{
    LineRenderer lineRenderer;
    int index = 0;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

   
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Ended)
            {
                index = 0;
                lineRenderer.positionCount = 0;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 12f));
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(index, pos);
                index++;


            }




        }



        
    }
}
