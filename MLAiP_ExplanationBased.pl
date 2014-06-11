% domain theory - training

cup(X) :- liftable(X), holds_liquid(X).
holds_liquid(Z) :-
 part(Z, W), concave(W), points_up(W).
liftable(Y) :-
 light(Y), part(Y, handle).
 light(A):- small(A).
 light(A):- made_of(A, feathers).

small(obj1).
owns(bob, obj1).
part(obj1, handle).
part(obj1, bottom).
part(obj1, bowl).
points_up(bowl).
concave(bowl).
color(obj1, red).

operational(small(_)).
operational(part(_, _)).
operational(owns(_, _)).
operational(points_up(_)).
operational(concave(_)).




%functions
extract_support(Proof, Proof) :- operational(Proof).
extract_support((A :- _), A) :- operational(A).
extract_support((AProof, BProof), (A, B)) :-
	extract_support(AProof, A),
	extract_support(BProof, B).
extract_support((_ :- Proof), B) :-
	extract_support(Proof, B).

duplicate(Old, New) :-
	assert('$marker'(Old)),
	retract('$marker'(New)).

prolog_ebg(A, GenA, A, GenA) :- clause(A, true).
prolog_ebg((A, B), (GenA, GenB), (AProof, BProof), (GenAProof, GenBProof)) :- !,
	prolog_ebg(A, GenA, AProof, GenAProof),
	prolog_ebg(B, GenB, BProof, GenBProof).
prolog_ebg(A, GenA, (A :- Proof), (GenA :- GenProof)) :-
	clause(GenA, GenB),
	duplicate((GenA :- GenB), (A :- B)),
	prolog_ebg(B, GenB, Proof, GenProof).


ebg(Goal, Gen_goal, (Gen_goal :- Premise)) :-
	prolog_ebg(Goal, Gen_goal, _, Gen_proof),
	extract_support(Gen_proof, Premise).


