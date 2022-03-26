using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhakuTesti : MonoBehaviour
{
    public int[] array = new int[7] { 1, 3, 4, 5, 7, 8, 9 };
    int search = 11;
    int n, last;
    int first = 0;
    // tee bin��rihaku. Etsit��n vaikka numeroa 2. 
    // ensin pit�� selvitt�� array pituus ja etsit��n sen perusteella keskimm�inen alkio
    // sitten l�hdet��n joko eteenp�in tai taaksep�in. Nyt haettavana on vain [0] - uusi viimeinen tai uusi viimein - viimeinen

    void Start()
    {
        n = array.Length;
        last = n ;
        var bin = BinarySearch(search, array);
        print(" bin function, l�ytyi indeksist� " + bin);


    }

    public int BinarySearch(int search,  int[] arr) {
        if(search > arr.Length) {
            return -1;
        }

        while (first <= last) {
            var middle = (first + last) / 2;
            if (arr[middle]== search) {
                first = 0;
                last = n;
                return middle;
                
            }
             if (arr[middle] > search) {
                last = middle - 1;
            } else {
                first = middle + 1;
            }
            
        }
        
        return -1;
    }


}
