using UnityEditor;
using UnityEngine;

namespace EditorUtils
{
    public sealed class PlayerPrefsClear : EditorWindow
    {
        [MenuItem("Utils/PlayerPrefs (All)")]
        private static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}