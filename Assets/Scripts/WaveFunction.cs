using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunction : MonoBehaviour
{
   private int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("test waves");
        
    }

    // Update is called once per frame
    void Update()
    {

     frames++;
     if (frames % 3 == 0) { //If the remainder of the current frame divided by 10 is 0 run the function.
        transform.localScale = Vector3.Lerp(
          transform.localScale, new Vector3(transform.localScale.x + 1F, transform.localScale.y + 1F, 0.01F), 0.1F
        );
        if (transform.localScale.x > 10F) {
          transform.localScale = new Vector3(0.001F, 0.001F, 0.001F);
        }
     }
    }
}
