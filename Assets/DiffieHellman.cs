using EasyButtons;
using UnityEngine;
using System.Numerics;

// Implementation based on https://www.youtube.com/watch?v=Yjrfm_oRO0w
public class DiffieHellman : MonoBehaviour
{
    private static readonly BigInteger G = 23; // Is often very small, and usually a small prime number
    private static readonly BigInteger N = ulong.MaxValue; // Is often very big, and it needs to be big for the security of this to work, is often 2000bits or 4000bits

    [Button]
    private void ExchangeKeys()
    {
        // Generate private keys
        BigInteger privateA = Random.Range(1, int.MaxValue);
        BigInteger privateB = Random.Range(1, int.MaxValue);
        Log("private", privateA, privateB);

        // Generate public keys
        var publicA = BigInteger.ModPow(G, privateA, N);
        var publicB = BigInteger.ModPow(G, privateB, N);
        Log("public", publicA, publicB);

        // Generate shared keys
        var sharedA = BigInteger.ModPow(publicB, privateA, N);
        var sharedB = BigInteger.ModPow(publicA, privateB, N);
        Log("shared", sharedA, sharedB);
    }

    private static void Log(string kind, BigInteger a, BigInteger b)
    {
        const string format = "{0} {1} key → {2:X8}";
        Debug.Log(string.Format(format, "A", kind, a));
        Debug.Log(string.Format(format, "B", kind, b));
    }
}