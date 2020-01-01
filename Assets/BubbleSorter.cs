using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSorter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 5, 2, 4, 10, 1, 0, 9, 6 };
        DoBubbleSort(arr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoBubbleSort(int[] arr)
    {
       for(int i = 0; i < arr.Length-1; i++)
       {
            for(int j = i+1; j< arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    PrintArray(arr);
                }
            }
        
       }
    }

    private void PrintArray(int[] arr)
    {
        string str = "";
        for(int i = 0; i < arr.Length; i++)
        {
            str += arr[i]+",";
        }

        print(str);
    }
}
