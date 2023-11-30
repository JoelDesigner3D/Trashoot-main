using UnityEngine;

public class TrashGenerator : TrashFactory
{
    [SerializeField] private GameObject[] trashTypes;

    public override GameObject Generate(Vector2 position, Quaternion rotation)    
    {
        int nazard = Random.Range(0, trashTypes.Length);
        GameObject enemyType = trashTypes[nazard];

        GameObject enemy = Instantiate(enemyType);
        enemy.transform.position = position;
        enemy.transform.rotation = rotation;

        return enemy;
    }
}