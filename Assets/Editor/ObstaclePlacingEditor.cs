using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ObstaclePlacingManager))]
    public class ObstaclePlacingEditor : UnityEditor.Editor
    {
        private const string FOLDER_PATH = "Assets/Resources/StageData/";
        private const int stageCount = 10;
        
        private int selectedObstacleIdx = 0;
        private int selectedLevelKey = 0;
        
        public override void OnInspectorGUI()
        {
            ObstaclePlacingManager myTarget = (ObstaclePlacingManager)target;
            DrawDefaultInspector();
            
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Obstacle 설치", EditorStyles.boldLabel);

            string[] levelKeys = new string[ stageCount ];
            for (int i = 0; i < stageCount; i++)
            {
                levelKeys[i] = i.ToString();
            }
            selectedLevelKey = EditorGUILayout.Popup("LevelKey",selectedLevelKey, levelKeys);
                               
            // Save, Load 버튼
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save", GUILayout.Width(120)))
            {
                SaveObstaclePositions( selectedLevelKey );
            }
            if (GUILayout.Button("Load", GUILayout.Width(120)))
            {
                LoadObstaclePositions( selectedLevelKey );
            }
            GUILayout.EndHorizontal();
            
            // ---------------------
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            // ---------------------
            
            string[] prefabNames = new string[myTarget.GetObstacles().Length];
            for (int i = 0; i < myTarget.GetObstacles().Length; i++)
            {
                if (myTarget.GetObstacles()[i] is not null)
                {
                    prefabNames[i] = myTarget.GetObstacles()[i].name;
                }
                else
                {
                    prefabNames[i] = "---NULL---";
                }
            }
            selectedObstacleIdx = EditorGUILayout.Popup("Obstacel Type", selectedObstacleIdx, prefabNames);
            
            if (GUILayout.Button("장애물 생성", GUILayout.Height(30)))
            {
                GameObject newObstacle = (GameObject)PrefabUtility.InstantiatePrefab(myTarget.GetObstacle( selectedObstacleIdx ), myTarget.transform);

                if (newObstacle is not null)
                {
                    newObstacle.transform.position = myTarget.transform.position;
                    EditorUtility.SetDirty(myTarget);
                }
                else
                {
                    Debug.LogError("선택된 Obstacle이 없습니다.");
                }
            }
        }

        private void SaveObstaclePositions( int levelKey )
        {
            
        }

        private void LoadObstaclePositions( int levelKey )
        {
            
        }
    }

    
    
    [Serializable]
    public class ObstaclePositionData
    {
        public int obstacleKey;
        public Vector2 position;
        // public Quaternion rotation;
    }

    [Serializable]
    public class StageData
    {
        public int stageKey;
        public List<ObstaclePositionData> obstaclePositions;
    }
}
