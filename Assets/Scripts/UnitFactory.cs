using UnityEngine;

public interface IUnitFactory
{
    UnitBase CreateUnit(UnitConfig config, Vector3 position, Quaternion rotation, Transform parent, TeamType team);
}

public class UnitFactory : MonoBehaviour, IUnitFactory
{
    public UnitBase CreateUnit(UnitConfig config, Vector3 position, Quaternion rotation, Transform parent, TeamType team)
    {
        if (config == null || config.prefab == null)
        {
            Debug.LogError("UnitConfig или prefab не задан!");
            return null;
        }
        GameObject go = Instantiate(config.prefab, position, rotation, parent);
        UnitBase unit = go.GetComponent<UnitBase>();
        if (unit == null)
        {
            Debug.LogError($"Prefab {config.prefab.name} не содержит UnitBase!");
            Destroy(go);
            return null;
        }
        unit.InitFromConfig(config, team);
        return unit;
    }
} 