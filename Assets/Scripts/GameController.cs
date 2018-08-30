using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  private static int leftButton = 0;
  private static int[] shipLength = {5, 4, 3, 3, 2};
  private int shipCount;
  private int shipDir;
  private GameObject floorObj;
  private List<Transform> floorList;
  
  void Start() {
    shipCount = 0;
    shipDir = 10;
    floorObj = GameObject.Find("Floor");
    floorList = new List<Transform>();
    SearchFloorObject();
  }
  
  void Update() {
    CheckShipDir();
    if (Input.GetMouseButtonDown(leftButton)) {
      GameObject obj = GetClickFloor();
      if (obj != null) {
        PutShip(obj);
      }
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
  
  void CheckShipDir() {
    if (Input.GetKey(KeyCode.A)) {
      shipDir = -10;
    } else if (Input.GetKey(KeyCode.D)) {
      shipDir = 10;
    } else if (Input.GetKey(KeyCode.S)) {
      shipDir = -1;
    } else if (Input.GetKey(KeyCode.W)) {
      shipDir = 1;
    }
  }
  
  void PutShip(GameObject obj) {
    int pos;
    
    for (pos = 0; pos < floorList.Count; pos++) {
      if (floorList[pos].name.CompareTo(obj.name) == 0) {
        break;
      }
    }
    
    if (IsLegalPos(pos)) {
      for (int i = 0; i < shipLength[shipCount]; i++) {
        ChangeFloorColor(floorList[pos]);
        pos += shipDir;
      }
      shipCount++;
    }
  }
  
  bool IsLegalPos(int pos) {
    for (int i = 0; i < shipLength[shipCount]; i++) {
      if (pos < 0 || pos > 99) {
        return false;
      }
      if (Math.Abs(shipDir) == 1) {
        if ((pos - shipDir) / 10 - pos / 10 != 0) {
          return false;
        }
      }
      pos += shipDir;
    }
    
    return true;
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
  
  void ChangeFloorColor(Transform obj) {
    obj.GetComponent<Renderer>().material.color = Color.blue;
  }
}
