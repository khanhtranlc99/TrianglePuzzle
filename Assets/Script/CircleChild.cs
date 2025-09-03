using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleChild : MonoBehaviour
{
     public bool isOK;
     public CircleBG circleBG;
     void Start()
     {
        isOK = false;
     }
    void OnTriggerStay2D(Collider2D other)
    {
      if(other.gameObject.GetComponent<CircleBG>() != null && !other.gameObject.GetComponent<CircleBG>().isFill)
      {
        if(circleBG == null)
        {
             other.gameObject.GetComponent<SpriteRenderer>().sprite =   this.gameObject.GetComponent<SpriteRenderer>().sprite;
             other.gameObject.GetComponent<CircleBG>().isFill = true;
            circleBG = other.gameObject.GetComponent<CircleBG>();
            
        }
       
      }
    }
      void OnTriggerExit2D(Collider2D other)
    {
       if(other.gameObject.GetComponent<CircleBG>() != null && !isOK)
        {
            other.gameObject.GetComponent<CircleBG>().HandleReset();
            other.gameObject.GetComponent<CircleBG>().isFill = false;
            circleBG = null;
    
       }
    }
}
