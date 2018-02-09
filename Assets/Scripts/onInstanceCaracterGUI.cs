using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
[CanEditMultipleObjects]
public class onInstanceCaracterGUI : Editor
{

    public override void OnInspectorGUI()
    {
        Character character = (Character)target;
        EditorGUILayout.LabelField("Персонаж");
        character.Heals = EditorGUILayout.IntField("Heals",character.Heals);
        character.SpeedMove =EditorGUILayout.FloatField("SpeedMove", character.SpeedMove);
        //EditorGUILayout.ObjectField("TextureCart", character.TextureCart);

        EditorGUILayout.LabelField("Атака");
        character.atPhysical = EditorGUILayout.IntField("atPhysical", character.atPhysical);
        character.atMagic = EditorGUILayout.IntField("atMagic", character.atMagic);
        character.atCriticalDamage = EditorGUILayout.IntField("atCriticalDamage", character.atCriticalDamage);
        character.atRange = EditorGUILayout.FloatField("atRange", character.atRange);
        character.GetComponent<SphereCollider>().radius = character.atRange;
        character.atSplash= EditorGUILayout.Toggle("atSplash", character.atSplash);
        character.atSpeed = EditorGUILayout.FloatField("atSpeed", character.atSpeed);
        character.atType = (Character.TypeAttackEnum) EditorGUILayout.EnumPopup("atType", character.atType);

        EditorGUILayout.LabelField("Защита");
        character.defPhysical = EditorGUILayout.IntField("defPhysical", character.defPhysical);
        character.defMagic= EditorGUILayout.IntField("defMagic", character.defMagic);
    }
     
}