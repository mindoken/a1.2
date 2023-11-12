using System.Collections.Generic;
using UnityEngine;

static class GameConfig {
  public static readonly float CameraHeightUnits = 10;

  /// <todo>
  /// public static float ViewportAspectRatio {
  ///   get {
  ///     if (ratioBuffer == -1 || Camera.current == prevCamera) {
  ///       prevCamera = Camera.current;
  ///       Rect rect = prevCamera.pixelRect;
  ///       float ratio = rect.width / rect.height;
  ///       ratioBuffer = ratio;
  ///     }
  ///     return ratioBuffer;
  ///   }
  /// }
  /// </todo>
  public static float ViewportAspectRatio = 1920f / 1080f;

  public static float CameraWidthUnits => ViewportAspectRatio * CameraHeightUnits;

  // Game balance controls

  public static float yellowMovingProbability = 0.5f;
  public static float yellowMoveSpeed = 5f;

  public static Dictionary<int, int> blockHPs = new Dictionary<int, int>()
    {
      {1, 2},
      {2, 4},
      {3, 1},
      {4, 30}
    };

  public static Dictionary<int, int> blockPoints = new Dictionary<int, int>()
    {
      {1, 20},
      {2, 40},
      {3, 10},
      {4, 100}
    };
}
