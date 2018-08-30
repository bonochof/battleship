using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  private static int leftButton = 0;
  private static int[] shipLength = {5, 4, 3, 3, 2};
  private int shipCount;
  private GameObject floorObj;
  private List<Transform> floorList;
  
  void Start() {
    shipCount = 0;
    floorObj = GameObject.Find("Floor");
    floorList = new List<Transform>();
    SearchFloorObject();
  }
  
  void Update() {
    if (Input.GetMouseButtonDown(leftButton)) {
      GameObject obj = GetClickFloor();
      if (obj != null) {
        ChangeFloorColor(obj);
        shipCount++;
      }
      Debug.Log(shipCount);
    }
  }
  
  void SearchFloorObject() {
    var children = floorObj.GetComponentInChildren<Transform>();
    foreach (Transform child in children) {
      var grandChildren = child.GetComponentInChildren<Transform>();
      foreach (Transform grandChild in grandChildren) {
        floorList.Add(grandChild);
      }
    }
  }
  
  GameObject GetClickFloor() {
    GameObject result = null;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit = new RaycastHit();
    if (Physics.Raycast(ray, out hit)) {
      result = hit.collider.gameObject;
    }
    return result;
  }
  
  void ChangeFloorColor(GameObject obj) {
    obj.GetComponent<Renderer>().material.color = Color.blue;
  }
}
