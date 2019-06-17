using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunction : MonoBehaviour
{
   private int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     frames++;
     if (frames % 3 == 0) { //If the remainder of the current frame divided by 10 is 0 run the function.
        transform.localScale += new Vector3(transform.localScale.x + 0.001F, transform.localScale.x + 0.001F, 0.001F);
        if (transform.localScale.x > 10F) {
          transform.localScale = new Vector3(0, 0, 0);
        }
     }
    }
}
