using UnityEngine;

public class BallsDestroyer : AbstractBallsDestroyer {
  public override void SetSize((float horizontal, float vertical) size) {
    transform.localScale = new(size.horizontal, size.vertical);
  }

  private void OnTriggerExit2D(Collider2D other) {
    AbstractBall ball = other.GetComponent<AbstractBall>();

    if (!ball) return;

    Destroy(ball.gameObject);
  }
}
