using UnityEngine;

public class Boundary
{
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;

    public Boundary()
    {
    }
}

public class RandomPosGenerator
{
    private float _offsetX;
    private float _offsetY;
    private Boundary _boundary;

    public RandomPosGenerator()
    {
        _offsetX = 1;
        _offsetY = 1;
        _boundary = GeneralConstants.mapBoundaries;
    }

    public RandomPosGenerator(float offsetX, float offSetY)
    {
        _offsetX = offsetX;
        _offsetY = offSetY;
        _boundary = GeneralConstants.mapBoundaries;
    }

    public RandomPosGenerator(Boundary boundary, float offsetX, float offSetY)
    {
        _offsetX = offsetX;
        _offsetY = offSetY;
        _boundary = boundary;
    }

    public Vector3 Generate()
    {
        float randomX = Random.Range(_boundary.xmin + _offsetX, _boundary.xmax - _offsetX);
        float randomY = Random.Range(_boundary.ymin + _offsetY, _boundary.ymax - _offsetY);
        return new Vector3(randomX, randomY, 0f);
    }

    public Vector3 GenerateSpawnPos(float playerOffset)
    {
        var playerPosition = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform.position;
        float randomX = Random.Range(_boundary.xmin + _offsetX, _boundary.xmax - _offsetX);
        float randomY;

        if (randomX < playerPosition.x + playerOffset && randomX > playerPosition.x - playerOffset)
        {
            var randomInt = (int)Random.Range(0, 2);
            if (randomInt == 0)
                randomY = Random.Range(_boundary.ymin + _offsetY, playerPosition.y - playerOffset);
            else
                randomY = Random.Range(playerPosition.y + playerOffset, _boundary.ymax - _offsetY);
        }
        else
            randomY = Random.Range(_boundary.ymin + _offsetY, _boundary.ymax - _offsetY);

        return new Vector3(randomX, randomY, 0f);
    }
}