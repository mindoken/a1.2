using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    GetComponent<Camera>().orthographicSize = GameConfig.CameraHeightUnits;
  }
}
