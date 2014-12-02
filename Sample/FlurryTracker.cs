using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlurryTracker : MonoBehaviour {
  public static FlurryTracker Instance;

#if UNITY_ANDROID
  private string FLURRY_API_KEY = "[insert android flurry key here]";
#elif UNITY_IPHONE
  private string FLURRY_API_KEY = "[insert ios flurry key here]";
#else
  private string FLURRY_API_KEY = "x";
#endif

  void Awake() {
    if(Instance == null) {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    } else { 
      DestroyImmediate(this);
    }
  }

  void Start() {
    Debug.Log("Flurry Tracker Initialized");
    FlurryAgent.Instance.onStartSession(FLURRY_API_KEY);
  }

  void OnApplicationQuit(){
    Debug.Log("Flurry Tracker Session End");
    FlurryAgent.Instance.onEndSession();
  }

  public void LogEvent(string eventId, Dictionary<string, string> parameters) {
    Debug.Log("Flurry LogEvent: " + eventId);
    FlurryAgent.Instance.logEvent(eventId, parameters);
  }
}
