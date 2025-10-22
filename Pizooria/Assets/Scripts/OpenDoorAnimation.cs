using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class OpenDoorAnimation : MonoBehaviour
{


    
     public float flipDuration = 1.5f;
     public  bool isOpen = false;
     public Vector3 closedScale;
     public Vector3 openScale; 
     void Start()
     {
        closedScale = transform.localScale;
        openScale = new Vector3(-closedScale.x, closedScale.y, closedScale.z);
        StopAllCoroutines();
        StartCoroutine(FlipDoor(isOpen ? closedScale : openScale));
        isOpen = !isOpen;
    }

    
       
            
         

     IEnumerator FlipDoor(Vector3 targetScale)
     {
            Vector3 startScale = transform.localScale;
            float timer = 0f;

            while (timer < flipDuration)
            {
                timer += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startScale, targetScale, timer / flipDuration);
                yield return null;
            }
   
       transform.localScale = targetScale; 
     }
    
}

