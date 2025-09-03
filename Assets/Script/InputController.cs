using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputController : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer; // Layer để filter đối tượng cần check
    [SerializeField] private float rayDistance = 10f; // Độ dài của tia raycast

    // Update is called once per frame
    public CirclePlay circleCurrent; 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
           var temp = PlayerPrefs.GetInt("CurrentLevel",0) + 1;
                    PlayerPrefs.SetInt("CurrentLevel",temp);        
                    SceneManager.LoadScene(0);
        }
        if(Input.GetMouseButton(0))
        {
      // Lấy vị trí chuột trong không gian màn hình
        Vector3 mousePosition = Input.mousePosition;
        
        // Chuyển đổi từ vị trí màn hình sang world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        // Tạo điểm bắt đầu cho raycast (đặt z = 0 vì làm việc trong 2D)
        Vector2 rayStart = new Vector2(worldPosition.x, worldPosition.y);
        
        // Bắn tia raycast xuống dưới (Vector2.down = (0, -1))
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, rayDistance, targetLayer);
        
        // Kiểm tra nếu raycast chạm vào collider
        if (hit.collider != null && hit.collider.gameObject.GetComponent<CirclePlay>() != null)
        {
            if(circleCurrent == null)
            {
                circleCurrent = hit.collider.gameObject.GetComponent<CirclePlay>();
                circleCurrent.transform.position = new Vector3(worldPosition.x,worldPosition.y + 2,0);
            }
        }
         if(circleCurrent != null)
            {
               
                circleCurrent.transform.position = new Vector3(worldPosition.x,worldPosition.y + 2,0);
       
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(circleCurrent != null)
            {
               if(circleCurrent.isFull)
               {
                circleCurrent.gameObject.SetActive(false);
                circleCurrent = null;

            
                if(GamePlayController.Instance.playerContaint.levelData.wasComplete )
                {
                    var temp = PlayerPrefs.GetInt("CurrentLevel",0) + 1;
                    PlayerPrefs.SetInt("CurrentLevel",temp);
                        Initiate.Fade("GamePlayScene", Color.black, 2f);
                   }
                
               }
               else
               {
                  
                 circleCurrent.HandleReset();
                 circleCurrent = null;
               }
            }
        }
    }
}
