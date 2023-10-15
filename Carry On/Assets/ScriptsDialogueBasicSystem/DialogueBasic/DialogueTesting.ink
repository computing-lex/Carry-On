// Health and battery value
VAR health = 10
VAR battery = 10
VAR days = 0
VAR kits = 1

INCLUDE Repair.ink
INCLUDE EndGame.ink

-> Hot_Dog

=== Hot_Dog ===
You found a 100 year old hot dog.
Would you like to eat it?

    + [1. Yes] <> 
        You can't eat. Who do you think you are? -> What
    + [2. No] -> No
    + [3. What] -> What


== No == 
The hotdog gets mad and beats you up.
-> Repair(-> Hot_Dog)

== What == 
You heard me.
-> END
