using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
      Debug.Log("here");
    }
}
