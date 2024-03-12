using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab; // �� ������
    public GameObject player; // �÷��̾� ������Ʈ
    public float spawnInterval = 2f; // ���� �����Ǵ� �ð� ���� (��)
    private float timer = 0f; // Ÿ�̸�

    // �����ϰ� ������ x ��ǥ
    private float[] spawnXPositions = new float[] { -18.5f, -3.5f, 3.5f, 18.5f };

    void Update()
    {
        // Ÿ�̸Ӹ� ������Ʈ�ϰ� ������ ���ݸ��� �� ����
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Ÿ�̸� �缳��
        }
    }

    void SpawnEnemy()
    {
        // x ��ǥ�� �����ϰ� ����
        int randomIndex = Random.Range(0, spawnXPositions.Length);
        // �÷��̾� z ��ġ�� 300�� ���� ��ġ ���
        float spawnZPosition = player.transform.position.z + 300;

        // ���õ� ��ġ�� �� ����
        Vector3 spawnPosition = new Vector3(spawnXPositions[randomIndex], 0f, spawnZPosition);
        // ���� ���� ��ġ�� ���� �����̸� 180�� ȸ���ؼ� ����
        Quaternion rotation = Quaternion.identity;
        if (spawnXPositions[randomIndex] == -18.5f || spawnXPositions[randomIndex] == -3.5f)
        {
            rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        Instantiate(enemyPrefab, spawnPosition, rotation);
    }
}
