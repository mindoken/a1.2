using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  [SerializeField] private AbstractBackgroundController backgroundControllerPrefab;
  [SerializeField] private AbstractBoardController boardControllerPrefab;

  private GameObject boardControllerHolder;
  private AbstractBackgroundController backgroundController;

  public GameState gameData;

  static bool _gameStarted; // false by default

  private void InitGameState() {
    if (_gameStarted) return;
    _gameStarted = true;
    if (gameData.resetOnStart) gameData.Load(); // gameData.Reset();
  }

  private void Start() {
    Cursor.visible = false;
    backgroundController = Instantiate(backgroundControllerPrefab);
    InitGameState();
    InitLevel(gameData.level);
  }

  // TODO: move to input manager
  private void Update() {
    if (Input.GetKeyDown(KeyCode.M)) gameData.IsMusicOn = !gameData.IsMusicOn;
    if (Input.GetKeyDown(KeyCode.S)) gameData.IsSoundOn = !gameData.IsSoundOn;
    if (Input.GetKeyDown(KeyCode.N)) {
      gameData.Reset();
      SceneManager.LoadScene("Main");
    }
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    if (Input.GetButtonDown("Pause")) {
      if (Time.timeScale > 0) Time.timeScale = 0;
      else Time.timeScale = 1;
    }
  }

  public void OnBlockDestroyed(AbstractBlock blockInstance)
  {
    gameData.points += blockInstance.points;
    gameData.pointsToBall += blockInstance.points;
    if (gameData.pointsToBall >= gameData.requiredPointsToBall) {
      Debug.Log("Ball added to inventory");
      gameData.BallsCapacity++;
      gameData.pointsToBall -= gameData.requiredPointsToBall;
    }
  }

  private void InitLevel(int level) {
    Debug.Log($"Initializing level {level}...");

    backgroundController.SetBackground(level - 1);

    Destroy(boardControllerHolder);
    boardControllerHolder = new("BoardController");

    AbstractBoardController boardController = Instantiate(boardControllerPrefab);
    boardController.InitBoard(new(0, 0), level, OnBlockDestroyed);
    boardController.SubscribeBlocksEnd(() => {
      Debug.Log($"Level {level} COMPLETE!");
      if (gameData.level < LevelsConfig.MaxLevel) gameData.level += 1;
      SceneManager.LoadScene("Main");
    });
    gameData.SubscribeBallsEnd(() => {
      Debug.Log($"Level {level} lose.");
      gameData.Reset();
      SceneManager.LoadScene("Main");
    });

    boardController.transform.SetParent(boardControllerHolder.transform);

    Debug.Log($"Level {level} initialization complete!");
  }

  private void OnDestroy() {
    Destroy(boardControllerHolder);
  }

  string OnOff(bool boolVal) {
    return boolVal ? "on" : "off";
  }

  // TODO: move to some view layer
  void OnGUI() {
    GUI.Label(
      new Rect(5, 4, Screen.width - 10,
        100),
    string.Format(
          "<color=yellow><size=30>Level <b>{0}</b> Balls <b>{1}</b>"+
          " Score <b>{2}</b></size></color>",
          gameData.level, gameData.balls, gameData.points
          )
    );
    GUIStyle style = new GUIStyle();
    style.alignment = TextAnchor.UpperRight;
    GUI.Label(new Rect(5, 14, Screen.width - 10, 100),
    string.Format("<color=yellow><size=20><color=white>Space</color>-pause {0}" +
    " <color=white>N</color>-new" +
    " <color=white>J</color>-jump" +
    " <color=white>M</color>-music {1}" +
    " <color=white>S</color>-sound {2}" +
    " <color=white>Esc</color>-exit</size></color>",
    OnOff(Time.timeScale > 0), OnOff(!gameData.music),
    OnOff(!gameData.sound)), style);
  }
  void OnApplicationQuit() {
    gameData.Save();
  }
}
