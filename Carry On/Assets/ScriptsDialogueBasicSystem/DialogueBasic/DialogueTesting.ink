INCLUDE globals.ink
INCLUDE Repair.ink
INCLUDE EndGame.ink

->Pick_Knot

=== Pick_Knot ===

{~ ->Hot_Dog|->Test}

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

=== Test === 
Yeet

-> END