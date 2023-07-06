using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Tegment.RequestFormatter
{
    public class SignUpRequestFormatter
    {
        public string email;
        public string password;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}