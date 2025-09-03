using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class CameraScale : MonoBehaviour
{
    public Camera cam;
    public float Speed;
    public Transform leftPost;
    public Transform rightPost;


    public void Start()
    {
           StartCoroutine(   FixScreen(  leftPost.transform.position , rightPost.transform.position  ));
    }
 
    public void Init(Vector3 left, Vector3 right)
    {
       
        leftPost.transform.position = left;
        rightPost.transform.position = right;
        StartCoroutine(   FixScreen(  leftPost.transform.position , rightPost.transform.position  ));
     
    }

    public IEnumerator FixScreen(Vector3 left, Vector3 right)
    {
        float speed = Speed;

        // Tiếp tục scale cho đến khi cả hai điểm đều nằm trong khung nhìn cả trục x và trục y
        while (!IsPointVisible(left) || !IsPointVisible(right))
        {
            if (cam.orthographic)
            {
                cam.orthographicSize += speed;
            }
            else
            {
                cam.fieldOfView += speed;
            }
            speed += 0.001f; // Điều chỉnh tăng tốc độ nếu cần thiết
            yield return null;
        }
    }

    // Hàm kiểm tra xem một điểm có nằm trong khung nhìn hay không
    private bool IsPointVisible(Vector3 point)
    {
        Vector3 viewportPoint = cam.WorldToViewportPoint(point);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1;
    }

    public void HandleZoom(float param, Action callBack)
    {

        cam.DOOrthoSize(param, 2).SetEase(Ease.Linear).OnComplete(delegate {


            callBack?.Invoke();
        });
    }    
}
