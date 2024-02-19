using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2,camera.pixelHeight / 2,0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
           

    //Launch in response to hit
    StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }
    private IEnumerator
    SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        //pause the coroutine here
        //before deleting the sphere
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        //display text on screen in a label
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

}





