using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FABRIK : MonoBehaviour
{
    [SerializeField] Transform[] bones;
    private float[] bonesLength;

    [SerializeField] int solverIterations = 5;

    [SerializeField] Transform targetPosition;

    private void Start()
    {
        bonesLength=new float[bones.Length];

        for(int i = 0; i < bonesLength.Length; i++)
        {
            if(i<bones.Length-1)
            {
                bonesLength[i] = (bones[i + 1].position - bones[i].position).magnitude;
            }
            else
            {
                //Si es el último hueso la long es 0
                bonesLength[i] = 0f;
            }
        }

    }

    private void Update()
    {
        SolveIK();
    }

    void SolveIK()
    {
        Vector3[] FinalBonesPositions=new Vector3[bones.Length];

        //Gaurdamos las posiciones actuales de los huesos
        {
            for(int i=0; i<bonesLength.Length; i++)
            {
                FinalBonesPositions[i] = bones[i].position;
            }

            //Aplicamos FABROK tantas veces como se indique en "solveIterations"
            for(int i=0;i<solverIterations; i++)
            {
                FinalBonesPositions = SolveForwardPositions(SolveInversePosition(FinalBonesPositions));
            }

            //Aplicamos los resultados a cada hueso
            for(int i=0;i<bones.Length; i++)
            {
                bones[i].position = FinalBonesPositions[i];

                //Aplicamos rotaciones
                if(i !=bones.Length-1)
                {
                    bones[i].rotation = Quaternion.LookRotation(FinalBonesPositions[i + 1] - bones[i].position);
                }
                else
                {
                    bones[i].rotation = Quaternion.LookRotation(targetPosition.position - bones[i].position);
                }
            }
        }


    }

    Vector3[] SolveInversePosition(Vector3[] forwardPositions)
    {
        Vector3[] inversePosition= new Vector3[forwardPositions.Length];

        //Calculamos las posiciones "ideales" desde el último hasta el primer hueso
        for (int i=(forwardPositions.Length-1);i>=0;i--)
        {
            if(i==forwardPositions.Length-1)
            {
                //Si es el último hueso, la posición prima es la misma que la posicion objetivo
                inversePosition[i]=targetPosition.position;
            }
            else
            {
                Vector3 posPrimaSiguiente = inversePosition[i + 1];
                Vector3 posBaseActual = forwardPositions[i];
                Vector3 direccion=(posBaseActual-posPrimaSiguiente).normalized;
                float longitud = bonesLength[i];
                inversePosition[i]=posPrimaSiguiente+(direccion*longitud);
            }
        }
        return inversePosition;
    }

    Vector3[] SolveForwardPositions(Vector3[] inversePosition)
    {
        Vector3[] forwardPosition=new Vector3[inversePosition.Length];

        //Calculamos las posiciones "reales" desde el primer hasta el último
        for(int i=0;i<inversePosition.Length;i++)
        {
            if(i==0)
            {
                //Si es el primer hueso, la posición es la misma que la posición del primer hueso base
                forwardPosition[i] = bones[0].position;
            }
            else
            {
                Vector3 posPrimaActual = inversePosition[i];
                Vector3 posPirmaSegundaAnterior = forwardPosition[i - 1];
                Vector3 direccion = (posPrimaActual - forwardPosition[i-1]).normalized;
                float longitud = bonesLength[i - 1];
                forwardPosition[i] = posPirmaSegundaAnterior + (direccion * longitud);
            }
        }
        return forwardPosition;
    }
}


