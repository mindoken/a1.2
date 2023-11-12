using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabmanger : MonoBehaviour
{
  public static prefabmanger instance;
  [SerializeField]public GameObject bonus;
  public GameState GameData;
    void Awake() {
    if (instance != null && instance != this) {
      Destroy(this);
    }
    else { instance = this; }
  }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
