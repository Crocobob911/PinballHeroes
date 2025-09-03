using UnityEngine;

/// <summary>
/// 점수를 추가하는 ObstacleAction입니다.
/// </summary>
[CreateAssetMenu(fileName = "NewAddScoreAction", menuName = "Pinball/Actions/Add Score Action")]
public class AddScoreAction : ObstacleAction
{
    public int scoreToAdd = 1;

    public override void Execute(GameObject obstacle)
    {
        // TODO: 점수 관리자(ScoreManager)를 찾아서 점수를 올리는 로직을 여기에 구현해야 합니다.
        // 예: FindObjectOfType<ScoreManager>().AddScore(scoreToAdd);
        Debug.Log($"{scoreToAdd}점 획득!");
    }
}
