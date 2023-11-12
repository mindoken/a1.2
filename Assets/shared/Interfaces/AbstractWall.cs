using UnityEngine;

public abstract class AbstractWall : MonoBehaviour {
  abstract public void SetSize((float horizontal, float vertical) size);
}
