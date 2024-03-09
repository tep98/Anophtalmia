#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    [CustomEditor(typeof(XRInputController))]
    public class XRInputControllerEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty playerInput;
        SerializedProperty leftHand;
        SerializedProperty rightHand;

        private void OnEnable()
        {
            playerInput = serializedObject.FindProperty("playerInput");
            leftHand = serializedObject.FindProperty("leftHand");
            rightHand = serializedObject.FindProperty("rightHand");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            XRInputController xrInputController = (XRInputController)target;
            serializedObject.Update();

            // draw banner if turned on in Gaskellgames settings
            EditorWindowUtility.DrawInspectorBanner("Assets/Gaskellgames/Input Event System/Editor/Icons/inspectorBanner_InputEventSystem.png");

            // custom inspector
            EditorGUILayout.PropertyField(playerInput);
            EditorGUILayout.PropertyField(leftHand);
            EditorGUILayout.PropertyField(rightHand);

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

    } // class end
}

#endif
