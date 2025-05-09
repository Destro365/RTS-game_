using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeing : MonoBehaviour
{
    public Vector3 place;
    public GameObject Well;

    private RaycastHit _Hit;

    public bool placeNow;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && placeNow == true)
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
            {
                if(_Hit.transform.tag == "terrain")
                {
                    place = new Vector3(_Hit.point.x, _Hit.point.y, _Hit.point.z);
                    Instantiate(Well, place, Quaternion.identity);

                    placeNow = false;

                }
            }
        }
    }

    public void PlaceWell()
    {
        placeNow = true;
    }

}
