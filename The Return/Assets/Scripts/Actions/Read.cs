using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (readItem(controller, controller.player.currentLocation.items, noun))
            return;

        //read item in inventory
        if (readItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "Nothing to read :(";
    }

    private bool readItem(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName.ToLower() == noun.ToLower())
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
