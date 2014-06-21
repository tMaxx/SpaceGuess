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
