using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
private Vector3 GetPointOfContact()
{
RaycastHit hit;
if (Physics.Raycast(transform.position, transform.forward, out hit))
{ 
return hit.point;
} else 
{
  return new Vector3(0, 0, 0);
}
}
  void OnTriggerEnter(Collider collider)
  {

    Debug.Log("enter: " + collider.bounds);
    
    GameObject obj1 = this.gameObject;
    GameObject obj2 = collider.gameObject;

    // // Debug.Log("Triggered Obj1: " + obj1.name);
    // Debug.Log("Triggered obj2: " + obj2.name + " " + obj2.transform.localPosition);

    // MeshFilter planeMesh = obj2.gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;

    // bool hasThird = false;
    // int i = 0;
    // Vector3[] vertices = new Vector3[3];
    // vertices[0] = planeMesh.mesh.vertices[0];
    // vertices[1] = planeMesh.mesh.vertices[1];
    // while (!hasThird || i < planeMesh.mesh.vertices.Length)
    // {
    //   if (Vector3CanMakePlane(vertices[0], vertices[1], planeMesh.mesh.vertices[i]))
    //   {
    //     vertices[2] = planeMesh.mesh.vertices[i];
    //     hasThird = true;
    //   };
    //   i++;
    // }
    // if (!hasThird)
    // {
    //   Debug.Log("failed to create plane");
    //   return;
    // }

    // var norm = GetNormal(vertices[0], vertices[1], vertices[2]);
    // // Plane myPlane = new Plane(norm, new Vector3(0, 0, 0));
    // Plane myPlane = new Plane(norm, obj2.transform.localPosition);

    // Mesh mesh = GetComponent<MeshFilter>().mesh;
    // Vector3[] vertices2 = mesh.vertices;
    // // Debug.Log(myPlane.normal + " " + myPlane.distance);

    // // create new colors array where the colors will be created.
    // Color[] colors = new Color[vertices2.Length];
    // for (int j = 0; j < vertices2.Length; j++)
    // {
    //   if (myPlane.GetSide(vertices2[j]))
    //   {
    //     colors[j] = Color.red;
    //     // Lerp(Color.red, Color.green, vertices2[j].y);
    //   }
    //   else
    //   {
    //     colors[j] = Color.green;
    //     // colors[j] = Color.Lerp(Color.green, Color.green, vertices2[j].y);
    //   }
    // };

    // // assign the array of colors to the Mesh.
    // mesh.colors = colors;
  }

  void OnTriggerExit(Collider collision)
  {
    Debug.Log("exit");
    Mesh mesh = GetComponent<MeshFilter>().mesh;
    Vector3[] vertices = mesh.vertices;

    // create new colors array where the colors will be created.
    Color[] colors = new Color[vertices.Length];

    for (int i = 0; i < vertices.Length; i++)
    {
      colors[i] = Color.green;
    };

    // assign the array of colors to the Mesh.
    mesh.colors = colors;
  }

    public bool stay = true;
    private float stayCount = 0.0f;
  void OnTriggerStay(Collider collider)
  {
        if (stay)
        {
            if (stayCount > 0.25f)
            {
    Debug.Log("enter: " + collider.bounds);
                stayCount = stayCount - 0.25f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
  }

  Vector3 GetNormal(Vector3 a, Vector3 b, Vector3 c)
  {
    // Find vectors corresponding to two of the sides of the triangle.
    Vector3 side1 = b - a;
    Vector3 side2 = c - a;

    // Cross the vectors to get a perpendicular vector, then normalize it.
    return Vector3.Cross(side1, side2).normalized;
  }

  bool Vector3CanMakePlane(Vector3 v1, Vector3 v2, Vector3 v3)
  {
    return ((v2.x != v3.x &&
      v2.y != v3.y ||
      v2.x != v3.x &&
      v2.z != v3.z ||
      v2.x != v3.x &&
      v2.y != v3.y ||
      v2.z != v3.z &&
      v2.y != v3.y) &&
      (v1.x != v3.x &&
      v1.y != v3.y ||
      v1.x != v3.x &&
      v1.z != v3.z ||
      v1.x != v3.x &&
      v1.y != v3.y ||
      v1.z != v3.z &&
      v1.y != v3.y));
  }
}
