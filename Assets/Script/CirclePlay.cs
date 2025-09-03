using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlay : MonoBehaviour
{
     public List<CircleChild> listCircleChild;
     public Vector3 offset;
     public bool isFull
     {
      get
      {
        foreach (var item in listCircleChild)
        {
            if(item.circleBG == null)
            {
                return false;
            }
        }

       foreach (var item in listCircleChild)
        {
           item.isOK = true;
           item.circleBG.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
         return true;
      }

     }

     private float lastClickTime;
     private float doubleClickDelay = 0.3f; // Thời gian giữa 2 lần click (có thể điều chỉnh)
     public List<DataRotate> lsDataRotate;
     private int currentRotateIndex = 0; // Thêm biến để theo dõi index hiện tại

     private void Start()
     {
        offset = transform.position;
     }
     public void HandleReset()
     {
        transform.position = offset;
     }

     private void OnMouseDown()
     {
        float timeSinceLastClick = Time.time - lastClickTime;
        
        if (timeSinceLastClick <= doubleClickDelay)
        {
            if (lsDataRotate != null && lsDataRotate.Count > 0)
            {
                // Xoay và scale theo giá trị hiện tại
                transform.localScale = lsDataRotate[currentRotateIndex].scale;
                transform.localEulerAngles = lsDataRotate[currentRotateIndex].rotate;
                
                // Tăng index và quay vòng lại nếu đã hết danh sách
                currentRotateIndex = (currentRotateIndex + 1) % lsDataRotate.Count;
                
                Debug.Log($"Changed to rotation: {lsDataRotate[currentRotateIndex].rotate}, scale: {lsDataRotate[currentRotateIndex].scale}");
            }
        }
        
        lastClickTime = Time.time;
     }
}
[System.Serializable]
public class DataRotate
{
    public Vector3 rotate;
    public Vector3 scale = Vector3.one;
}
