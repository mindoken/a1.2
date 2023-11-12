using System;
using UnityEngine;

public abstract class AbstractBall : MonoBehaviour {
  abstract public void Launch(Vector2 force);
  abstract public Action SubscribeDestroy(Action callback);
  abstract public void UnsubscribeDestroy(Action callback);
}
