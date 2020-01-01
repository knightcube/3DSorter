using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = {5,1,4,3,2,7,9,6,10};
        PrintArray(arr);
        DoSelectionSort(arr);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void DoSelectionSort(int[] arr)
    {
        int min;
        int temp;
        for(int i = 0; i < arr.Length-1; i++)
        {
            min = i;
            for(int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }

            if (min != i)
            {
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
                PrintArray(arr);
            }


        }

    }

    private void PrintArray(int[] arr)
    {
        string str = "";
        for(int i = 0; i < arr.Length; i++)
        {
            str = str + "," + arr[i];
        }
        print(str);
    }
}
