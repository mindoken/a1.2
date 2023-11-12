using System;
using UnityEngine;

public abstract class AbstractBlock : MonoBehaviour {
  protected int hitPoints = 1;
  public int points;
  public AudioClip SoundOnDestroy;

  abstract public void SetSize((float horizontal, float vertical) size);
  abstract public void SetHitPoints(int points);
  abstract public void SetBlockType(int type);
  abstract public void DealDamage();

  abstract public Action SubscribeDestroy(Action callback);
  abstract public void UnsubscribeDestroy(Action callback);
}
