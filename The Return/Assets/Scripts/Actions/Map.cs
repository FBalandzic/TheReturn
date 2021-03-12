using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Map")]
public class Map : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.DisplayLocation();
    }
}
