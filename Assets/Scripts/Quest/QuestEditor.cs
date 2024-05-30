using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Quest quest = (Quest)target;
        
        quest.isQuestToCollectItem = EditorGUILayout.Toggle("Is Quest To Collect Item", quest.isQuestToCollectItem);
        quest.isQuestToKillEnemy = EditorGUILayout.Toggle("Is Quest To Kill Enemy", quest.isQuestToKillEnemy);

        if (quest.isQuestToKillEnemy)
        {
            SerializedProperty enemyToKill = serializedObject.FindProperty("enemyToKill");
            EditorGUILayout.PropertyField(enemyToKill, true);
        }
        if (quest.isQuestToCollectItem)
        {
            SerializedProperty itemToCollect = serializedObject.FindProperty("itemToCollect");
            EditorGUILayout.PropertyField(itemToCollect, true);
        }
    }
}
