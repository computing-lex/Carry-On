=== Repair(-> return_to) ===
{ kits > 0: It looks like I can repair myself now. Should I?} {kits == 0: I don't have any kits to repair myself with.}
    
    + {kits > 0} [1. Yes.]
        { health < 10: 
            ~ health = health + 1
            ~ kits = kits - 1
            Your health is now at {health}.
        -else: 
           You feel fine, it would be a waste of resources to repair now.
        } -> return_to
    + {kits > 0} [2. No]
        You decide against repairing now.
        -> return_to

-> return_to

=== Update_Stats(-> return_to) === 
// Update all variables and begin new cycle.

{battery == 0: 
    WARNING: BATTERY DEPLETED!
    ~ health = health - 1
- else :
    ~ battery = battery - 1
}

{health == 0: 
    -> Dead
 - else: 
    The day starts anew, and you are alive.
}

~ days = days + 1

-> return_to