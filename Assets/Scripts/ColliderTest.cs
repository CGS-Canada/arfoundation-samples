using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
  void OnTriggerEnter(Collider collision)
  {
    // GameObject obj1 = this.gameObject;
    // GameObject obj2 = collision.gameObject;

    // // Debug.Log("Triggered Obj1: " + obj1.name);
    // // Debug.Log("Triggered obj2: " + obj2.name + " " + obj2.transform.localPosition);

    // MeshFilter planeMesh = obj2.gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;

    // int count = 1;
    // int i = 0;
    // Vector3[] vertices = new Vector3[3];
    // vertices[0] = planeMesh.mesh.vertices[0];
    // // Debug.Log(planeMesh.mesh.vertices.Length);
    // while (count < 3 || i < planeMesh.mesh.vertices.Length)
    // {
    //   if (
    //     count == 1 &&
    //     (vertices[0].x != planeMesh.mesh.vertices[i].x ||
    //     vertices[0].y != planeMesh.mesh.vertices[i].y ||
    //     vertices[0].z != planeMesh.mesh.vertices[i].z)
    //   )
    //   {
    //     vertices[1] = planeMesh.mesh.vertices[i];
    //     count++;
    //   }
    //   else if (
    //   count == 2 &&
    //   (vertices[0].x != planeMesh.mesh.vertices[i].x &&
    //   vertices[0].y != planeMesh.mesh.vertices[i].y ||
    //   vertices[0].x != planeMesh.mesh.vertices[i].x &&
    //   vertices[0].z != planeMesh.mesh.vertices[i].z ||
    //   vertices[0].x != planeMesh.mesh.vertices[i].x &&
    //   vertices[0].y != planeMesh.mesh.vertices[i].y ||
    //   vertices[0].z != planeMesh.mesh.vertices[i].z &&
    //   vertices[0].y != planeMesh.mesh.vertices[i].y) ||
    //   (vertices[1].x != planeMesh.mesh.vertices[i].x &&
    //   vertices[1].y != planeMesh.mesh.vertices[i].y ||
    //   vertices[1].x != planeMesh.mesh.vertices[i].x &&
    //   vertices[1].z != planeMesh.mesh.vertices[i].z ||
    //   vertices[1].x != planeMesh.mesh.vertices[i].x &&
    //   vertices[1].y != planeMesh.mesh.vertices[i].y ||
    //   vertices[1].z != planeMesh.mesh.vertices[i].z &&
    //   vertices[1].y != planeMesh.mesh.vertices[i].y)
    // )
    //     vertices[2] = planeMesh.mesh.vertices[i];
    //   count++;
    //   i++;

    // }
    // // Debug.Log(vertices[0] + " " + vertices[1] + " " + vertices[2]);

    // Plane myPlane = new Plane(vertices[0] + obj2.transform.localPosition, vertices[1] + obj2.transform.localPosition, vertices[2] + obj2.transform.localPosition);

    // Mesh mesh = GetComponent<MeshFilter>().mesh;
    // Vector3[] vertices2 = mesh.vertices;

    // // create new colors array where the colors will be created.
    // Color[] colors = new Color[vertices2.Length];


    // for (int j = 0; j < vertices2.Length; j++)
    // {
    //   if (myPlane.GetSide(vertices2[j]))
    //   {
    //     Debug.Log(myPlane.GetSide(vertices2[j]));
    //   }
    //   colors[j] = Color.Lerp(Color.red, Color.green, vertices2[j].y);
    // };

    // // assign the array of colors to the Mesh.
    // mesh.colors = colors;

  }

  void OnTriggerExit(Collider collision)
  {
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

  void OnTriggerStay(Collider collision)
  {
    GameObject obj1 = this.gameObject;
    GameObject obj2 = collision.gameObject;

    // Debug.Log("Triggered Obj1: " + obj1.name);
    Debug.Log("Triggered obj2: " + obj2.name + " " + obj2.transform.localToWorldMatrix);

    MeshFilter planeMesh = obj2.gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;

    int count = 2;
    int i = 0;
    Vector3[] vertices = new Vector3[3];
    vertices[0] = planeMesh.mesh.vertices[0];
    vertices[1] = planeMesh.mesh.vertices[1];
    // Debug.Log(planeMesh.mesh.vertices.Length);
    while (count < 3 || i < planeMesh.mesh.vertices.Length)
    {
      if (
        count == 1 &&
        (vertices[0].x != planeMesh.mesh.vertices[i].x ||
        vertices[0].y != planeMesh.mesh.vertices[i].y ||
        vertices[0].z != planeMesh.mesh.vertices[i].z)
      )
      {
        vertices[1] = planeMesh.mesh.vertices[i];
        count++;
      }
      else if (
      count == 2 &&
      (vertices[0].x != planeMesh.mesh.vertices[i].x &&
      vertices[0].y != planeMesh.mesh.vertices[i].y ||
      vertices[0].x != planeMesh.mesh.vertices[i].x &&
      vertices[0].z != planeMesh.mesh.vertices[i].z ||
      vertices[0].x != planeMesh.mesh.vertices[i].x &&
      vertices[0].y != planeMesh.mesh.vertices[i].y ||
      vertices[0].z != planeMesh.mesh.vertices[i].z &&
      vertices[0].y != planeMesh.mesh.vertices[i].y) &&
      (vertices[1].x != planeMesh.mesh.vertices[i].x &&
      vertices[1].y != planeMesh.mesh.vertices[i].y ||
      vertices[1].x != planeMesh.mesh.vertices[i].x &&
      vertices[1].z != planeMesh.mesh.vertices[i].z ||
      vertices[1].x != planeMesh.mesh.vertices[i].x &&
      vertices[1].y != planeMesh.mesh.vertices[i].y ||
      vertices[1].z != planeMesh.mesh.vertices[i].z &&
      vertices[1].y != planeMesh.mesh.vertices[i].y)
    )
        vertices[2] = planeMesh.mesh.vertices[i];
      count++;
      i++;

    }
    // Debug.Log(vertices[0] + " " + vertices[1] + " " + vertices[2]);
    // Debug.Log((obj2.transform.localPosition + vertices[0]) + " " + (obj2.transform.localPosition + vertices[1]) + " " + (obj2.transform.localPosition + vertices[2]));
    Plane myPlane = new Plane(obj2.transform.localPosition + vertices[0], obj2.transform.localPosition + vertices[1], obj2.transform.localPosition + vertices[2]);
    Mesh mesh = GetComponent<MeshFilter>().mesh;
    Vector3[] vertices2 = mesh.vertices;
    // Debug.Log(myPlane.normal + " " + myPlane.distance);
    // Debug.Log(myPlane.GetDistanceToPoint(new Vector3(0, 0, 0)));
    // Debug.Log(myPlane.GetDistanceToPoint(new Vector3(1, 1, 1)));
    // Debug.Log(myPlane.GetDistanceToPoint(new Vector3(1, 0, 1)));
    // create new colors array where the colors will be created.
    Color[] colors = new Color[vertices2.Length];
    for (int j = 0; j < vertices2.Length; j++)
    {
      if (myPlane.GetSide(vertices2[j]))
      {
        colors[j] = Color.green;
        // Lerp(Color.red, Color.green, vertices2[j].y);
      }
      else
      {
        colors[j] = Color.red;
        // colors[j] = Color.Lerp(Color.green, Color.green, vertices2[j].y);
      }
    };

    // assign the array of colors to the Mesh.
    mesh.colors = colors;
  }
}
