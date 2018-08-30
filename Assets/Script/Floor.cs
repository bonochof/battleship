using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
  void Update() {
    GameObject obj = GetClickFloor();
    
    if (obj != null) {
      ChangeFloorColor(obj);
      Debug.Log(obj.name);
    }
  }
  
  GameObject GetClickFloor() {
    GameObject result = null;
    if(Input.GetMouseButtonDown(0)) {
　　　   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
　　　   RaycastHit hit = new RaycastHit();
　　　   if (Physics.Raycast(ray, out hit)){
　　　　　   result = hit.collider.gameObject;
　　　   }
  　 }
　   return result;
  }
  
  void ChangeFloorColor(GameObject obj) {
    //GameObject myObj;
    //myObj = GameObject.Find(obj.name);
    //Renderer rend = obj.GetComponent<Renderer>();
    //Debug.Log(rend.material.color);
    obj.GetComponent<Renderer>().material.color = Color.blue;
  }
}
