using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    private RaycastHit hit;
    private bool showHitLabel = false;

    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 24;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        size = 40;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = size;

        GUI.Label(new Rect(posX, posY, size, size), "*", style); 

        
        if (showHitLabel)
        {
            float hitPosX = 20f;
            float hitPosY = 20f;

            style = new GUIStyle(GUI.skin.label);
            style.fontSize = 13;

            GUI.Label(new Rect(hitPosX, hitPosY, 200, 30), "Hit Point Coordinates: " + hit.point.ToString(), style);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);

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

                showHitLabel = true;
            }
            else
            {
                showHitLabel = false;
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}