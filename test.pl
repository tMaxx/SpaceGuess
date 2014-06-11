%t(l, w, r).

inBST(t(X, _, _), X) :- !.
inBST(t(X, L, R), Elem) :- !,
	R \= nil, Elem > X, inBST(R, Elem) ;
	L \= nil, Elem < X, inBST(L, Elem).

