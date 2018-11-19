<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int theScore);
    public static event SendScore OnSendScore;
    public int score = 10;
    public void OnDestroy()
    {
        if (OnSendScore != null)
        {
            OnSendScore(score);
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int theScore);
    public static event SendScore OnSendScore;
}
>>>>>>> 53b62b3d3ec3e78c50d028d45b1c18c60bf7158a
