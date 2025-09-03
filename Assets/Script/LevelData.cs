using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class LevelData : MonoBehaviour
{
 
   public List<CircleBG> listCircleBG; 

   public bool wasComplete
   {
    get
    {
        foreach (var item in listCircleBG)
        {
            if(!item.isFill)
            {
                return false;
            }
        }   
        return true;
    }
   }    

  [Button]
   public void HandleAdd()
   {
    // Tìm tất cả các CircleBG trong các đối tượng con
    CircleBG[] circles = GetComponentsInChildren<CircleBG>(true); // true để tìm cả các object không active
    
    if (circles != null && circles.Length > 0)
    {
        foreach (var circle in circles)
        {
            // Kiểm tra xem đối tượng đã được thêm vào chưa để tránh trùng lặp
            if (!listCircleBG.Contains(circle))
            {
                listCircleBG.Add(circle);
                Debug.Log($"Added {circle.gameObject.name} to the list");
            }
        }
        Debug.Log($"Total circles found: {circles.Length}");
    }
    else
    {
        Debug.Log("No CircleBG components found in children");
    }
   }
   
}
