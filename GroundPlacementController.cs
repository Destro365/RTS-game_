using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeableObjectPrefabs; //this "[]" is an array and it gives me more storage to store in the inspector
    private GameObject currentPlaceableObject;
    private float mouseWheelRotation;



    private void Update()
    {
        if (currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse(); //these 3 are the methods
            RotateFromMouseWheel();
            ReleaseIfClicked();
            
        }

    }

    public void ItemSlot1Button(int index) //the ItemSlot1Button is the variable in the inspector
    {
        if (currentPlaceableObject == null)
        {
            currentPlaceableObject = Instantiate(placeableObjectPrefabs[index]); // the int index and the [index] are giving me the storage to store more prefabs
        }
        else
        {
            Destroy(currentPlaceableObject);
        }
    }



    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0) && currentPlaceableObject != null) //if the prefab is placed on the terrain 
        {
            currentPlaceableObject = null; //releasing it from the mouse and placing it on the terrain
           

        }

        if (Input.GetMouseButtonDown(1) && currentPlaceableObject != null) //if you chosed the wrong building before placing it you can click the right mouse button to destroy it and pick a different building or the same again
        {
            Destroy(currentPlaceableObject);
        }


    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y; //rotating the prefab on the Y 
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 15f); //how fast do we want to rotate the prefab

    }

    private void MoveCurrentPlaceableObjectToMouse()
    {

        //casting the ray from the mouse position to the world scene
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if the raycast hits something we will get the info what it hit
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            int PosX = (int)Mathf.Round(hitInfo.point.x); //novoooooooooooo
            int PosZ = (int)Mathf.Round(hitInfo.point.z); //novoooooooooooo
            currentPlaceableObject.transform.position = new Vector3(PosX, 1f, PosZ);

            //currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal); //if its hitted on the side it will stand normall positioned
        }
    }



}
