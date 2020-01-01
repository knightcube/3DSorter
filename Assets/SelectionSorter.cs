using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSorter : MonoBehaviour
{
    public int NumberOfCubes = 10;
    public int CubeHeightMax = 10;
    public GameObject[] Cubes;


    // Start is called before the first frame update
    void Start()
    {
        InitializeRandom();
        StartCoroutine(DoBubbleSort(Cubes));
    }

    private void InitializeRandom()
    {
        Cubes = new GameObject[NumberOfCubes];
        for(int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = UnityEngine.Random.Range(1, CubeHeightMax + 1);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);
            cube.transform.parent = this.transform;
            Cubes[i] = cube;
        }

        transform.position = new Vector3(-NumberOfCubes / 2f, -CubeHeightMax / 2f, 0);
    }

    IEnumerator DoSelectionSort(GameObject[] arr)
    {
        int min;
        
        Vector3 tempPosition;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            min = i;
            yield return new WaitForSeconds(1);

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j].transform.localScale.y < arr[min].transform.localScale.y)
                {
                    min = j;
                }
            }

            if (min != i)
            {
                yield return new WaitForSeconds(1);
                GameObject temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;

                // Swap position of cubes in the world
                tempPosition = arr[i].transform.localPosition;

                // SwapWithoutLeanTween(arr,tempPosition,min,i);
                SwapWithLeanTween(arr, tempPosition, min, i);
                LeanTween.color(arr[i], Color.blue, 1f);
            }


        }

    }

    IEnumerator DoBubbleSort(GameObject[] arr)
    {
        Vector3 tempPosition;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length-i-1; j++)
            {
                yield return new WaitForSeconds(1);

                if (arr[j].transform.localScale.y > arr[j+1].transform.localScale.y)
                {
                    LeanTween.color(arr[j], Color.blue, 1f);

                    GameObject temp = arr[j];
                    arr[j] = arr[j+1];
                    arr[j+1] = temp;

                    tempPosition = arr[j].transform.localPosition;
                    SwapWithLeanTween(arr, tempPosition, j+1, j);
                    // arr[j].transform.localPosition = new Vector3(arr[j+1].transform.localPosition.x, tempPosition.y, tempPosition.z);
                    // arr[j+1].transform.localPosition = new Vector3(tempPosition.x, arr[j+1].transform.localPosition.y, arr[j].transform.localPosition.z);
                    // SwapWithLeanTween(arr, tempPosition, j, i);


                }
            }

        }
    }

    private void SwapWithLeanTween(GameObject[] arr, Vector3 tempPosition, int min, int i)
    {
        LeanTween.moveLocalX(arr[i], arr[min].transform.localPosition.x, 1);
        LeanTween.moveLocalZ(arr[i], -3, .5f).setLoopPingPong(1);
        LeanTween.moveLocalX(arr[min], tempPosition.x, 1);
        LeanTween.moveLocalZ(arr[min], 3,.5f).setLoopPingPong(1);
    }

    private void SwapWithoutLeanTween(GameObject[] arr, Vector3 tempPosition, int min, int i)
    {
        arr[i].transform.localPosition = new Vector3(arr[min].transform.localPosition.x, tempPosition.y, tempPosition.z);
        arr[min].transform.localPosition = new Vector3(tempPosition.x, arr[min].transform.localPosition.y, arr[min].transform.localPosition.z);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
