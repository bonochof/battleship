using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
  void Update() {
    GameObject obj = getClickObject();
    
    if (obj != null) {
      Debug.Log(obj.name);
    }
  }
  
  public GameObject getClickObject() {
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
}
