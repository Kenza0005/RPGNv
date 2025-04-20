using UnityEngine;
using UnityEditor;

public class MissingScriptsCleaner
{
    [MenuItem("Tools/Clean Missing Scripts in Scene")]
    static void CleanMissingScripts()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject go in allObjects)
        {
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
            if (removed > 0)
            {
                Debug.Log($"Removed {removed} missing scripts from '{go.name}'");
                count += removed;
            }
        }

        Debug.Log($"Finished cleaning. Total scripts removed: {count}");
    }
}
