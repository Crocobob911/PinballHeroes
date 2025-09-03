using UnityEngine;

/// <summary>
/// 장애물에 닿았을 때 실행될 동작의 기본 클래스입니다.
/// ScriptableObject로 만들어 재사용 가능한 액션 에셋을 생성할 수 있습니다.
/// </summary>
public abstract class ObstacleAction : ScriptableObject
{
    /// <summary>
    /// 이 액션의 로직을 실행합니다.
    /// </summary>
    /// <param name="obstacle">액션을 실행한 장애물 GameObject</param>
    public abstract void Execute(GameObject obstacle);
}
