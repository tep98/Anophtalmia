#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [CustomEditor(typeof(CameraTriggerZone))] [CanEditMultipleObjects]
    public class CameraTriggerZoneEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty alwaysShowZone;
        SerializedProperty cameraRig;
        SerializedProperty triggerColour;
        SerializedProperty triggerOutlineColour;

        bool InfoGroup = false;

        private void OnEnable()
        {
            alwaysShowZone = serializedObject.FindProperty("alwaysShowZone");
            cameraRig = serializedObject.FindProperty("cameraRig");
            triggerColour = serializedObject.FindProperty("triggerColour");
            triggerOutlineColour = serializedObject.FindProperty("triggerOutlineColour");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            CameraTriggerZone CcmeraTriggerZone = (CameraTriggerZone)target;
            serializedObject.Update();

            // draw banner if turned on in Gaskellgames settings
            EditorWindowUtility.DrawInspectorBanner("Assets/Gaskellgames/Camera Controller/Editor/Icons/inspectorBanner_CameraController.png");

            // custom inspector
            EditorGUILayout.PropertyField(alwaysShowZone);
            EditorGUILayout.PropertyField(cameraRig);
            EditorGUILayout.Space();

            InfoGroup = EditorGUILayout.BeginFoldoutHeaderGroup(InfoGroup, "Sensor Info");
            if (InfoGroup)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(triggerColour);
                EditorGUILayout.PropertyField(triggerOutlineColour);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space();

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
    } // class end
}

#endif
