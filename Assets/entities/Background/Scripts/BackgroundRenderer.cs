using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundRenderer : AbstractBackgroundRenderer {

  private Image spriteRenderer;

  void Awake() {
    Canvas canvas = GetComponent<Canvas>();
    spriteRenderer = GetComponent<Image>();

    GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

    canvas.worldCamera = camera.GetComponent<Camera>();
  }

  override public void SetBackgroundSprite(Sprite newSprite) {
    if (spriteRenderer == null) return;

    spriteRenderer.sprite = newSprite;
  }
}
