using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : AbstractWall {

  public override void SetSize((float horizontal, float vertical) size) {
    transform.localScale = new(size.horizontal, size.vertical);
  }
}
