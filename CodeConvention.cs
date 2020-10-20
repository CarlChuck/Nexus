using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeConvention : MonoBehaviour
{
    private int aPrivateField;
    public int aPublicField; 
    public const int A_CONSTANT_INT = 10;

    public int APublicProperty { get; set; }

    public void APublicMethod(int aPublicParameter)
    {
        //Encapsulation even for single line
        if (aPrivateField > aPublicField)
        {
            aPrivateField = aPublicParameter;
        }
    }
}
