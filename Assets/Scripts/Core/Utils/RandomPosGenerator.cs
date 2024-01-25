using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Boundary
{
    public float _xmin;
    public float _xmax;
    public float _ymin;
    public float _ymax;

    public Boundary(float xmin, float xmax, float ymin, float ymax)
    {
        _xmin = xmin;
        _xmax = xmax;
        _ymin = ymin;
        _ymax = ymax;
    }
}

public class RandomPosGenerator
{
    private float _offsetX;
    private float _offsetY;
    private Boundary _boundary = new Boundary(-14, 21, -8, 9);

    public RandomPosGenerator(float offsetX, float offSetY)
    {
        _offsetX = offsetX;
        _offsetY = offSetY;
    }

    public Vector3 Generate()
    {
        float randomX = Random.Range(_boundary._xmin + _offsetX, _boundary._xmax - _offsetX);
        float randomY = Random.Range(_boundary._ymin + _offsetY, _boundary._ymax - _offsetY);
        return new Vector3(randomX, randomY, 0f);
    }

    public Vector3 GenerateSpawnPos()
    {
        float randomX = Random.Range(_boundary._xmin + _offsetX, _boundary._xmax - _offsetX);
        float randomY = 0;
        if (randomX < 6 && randomX > -4)
        {
            var randomInt = (int)Random.Range(0,2);
            if(randomInt == 0)
                randomY = Random.Range(_boundary._ymin + _offsetY, -1);
            else
                randomY = Random.Range(8, _boundary._ymax - _offsetY);
        }
        else
            randomY = Random.Range(_boundary._ymin + _offsetY, _boundary._ymax - _offsetY);

        return new Vector3(randomX, randomY, 0f);
    }
}
