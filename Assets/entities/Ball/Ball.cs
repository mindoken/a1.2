using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : AbstractBall {
  private new Rigidbody2D rigidbody;
  private List<Action> destroyCallbacks = new();

  public override void Launch(Vector2 force) {
    if (rigidbody.bodyType == RigidbodyType2D.Dynamic) return;

    rigidbody.bodyType = RigidbodyType2D.Dynamic;
    rigidbody.AddForce(force);
  }

  private void Awake() {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    if (!rigidbody.isKinematic && Input.GetKeyDown(KeyCode.J)) {
      var v = rigidbody.velocity;
      if (Random.Range(0,2) == 0) v.Set(v.x - 0.1f, v.y + 0.1f);
      else v.Set(v.x + 0.1f, v.y - 0.1f);
      rigidbody.velocity = v;
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    AbstractBlock wall = other.gameObject.GetComponent<AbstractBlock>();

    if (!wall) return;

    wall.DealDamage();
  }

   public override Action SubscribeDestroy(Action callback) {
    destroyCallbacks.Add(callback);

    return () => destroyCallbacks.Remove(callback);
  }
  public override void UnsubscribeDestroy(Action callback) {
    destroyCallbacks.Remove(callback);
  }

  private void OnDestroy() {
    destroyCallbacks.ForEach(item => item());
  }
}
