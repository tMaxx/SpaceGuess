covers([ ], [ ]).
covers([H1 | T1], [H2 | T2]) :-
	var(H1), var(H2), covers(T1, T2).
	% variables cover each other
covers([H1 | T1], [H2 | T2]) :-
	var(H1), atom(H2), covers(T1, T2).
	% a variable covers a constant
covers([H1 | T1], [H2 | T2]) :-
	atom(H1), atom(H2), H1 = H2,
	covers(T1, T2).
	% matching constants

delete(X, L, Goal, New_L) :-
	(bagof(X, (member(X, L), not(Goal)), New_L); New_L = []).

more_general(X, Y) :- not(covers(Y,X)),covers(X,Y).

%specific to general
generalize([ ], [ ], [ ]).
generalize([Feature | Rest],[Inst_prop | Rest_inst],
	[Feature | Rest_gen]) :-
	not(Feature \= Inst_prop),
	generalize(Rest, Rest_inst, Rest_gen).
generalize([Feature | Rest],[Inst_prop | Rest_inst],
	[_ | Rest_gen]) :-
	Feature \= Inst_prop,
	generalize(Rest, Rest_inst, Rest_gen).

generalize_set([ ], [ ], _).
generalize_set([Hypothesis | Rest], Updated_H, Instance):-
	not(covers(Hypothesis, Instance)),
	(bagof(X, generalize(Hypothesis, Instance, X),
	Updated_head); Updated_head = [ ]),
	generalize_set(Rest, Updated_rest, Instance),
	append(Updated_head, Updated_rest, Updated_H).
generalize_set([Hypothesis | Rest], [Hypothesis | Updated_rest], Instance) :-
	covers(Hypothesis, Instance),
	generalize_set(Rest, Updated_rest, Instance).


%process from general: generalization
process(positive(Instance), [ ], N, [Instance], N).
process(positive(Instance), H, N, Updated_H, N) :-
	generalize_set(H, Gen_H, Instance),
	delete(X, Gen_H,(member(Y, Gen_H),
	more_general(X, Y)), Pruned_H),
	delete(X, Pruned_H, (member(Y, N),
	covers(X, Y)), Updated_H).

process(negative(Instance), H, N, Updated_H, [InstanceN]) :-
	delete(X, H, covers(X, Instance), Updated_H).

process(Input, H, N, H, N):- %Catches bad input
	Input \= positive(_),
	Input \= negative(_),
	write('Enter either positive(Instance) or negative(Instance) '), nl.
%END OF generalize
%main function: generalization
specific_to_general(H, N) :-
	write('H = '), write(H), nl, write('N = '),
	write(N), nl,
	write('Enter Instance:'), nl, read(Instance),
	process(Instance, H, N, Updated_H, Updated_N),
	specific_to_general(Updated_H, Updated_N).



%specialization
specialize_set([ ], [ ], _, _).
specialize_set([HypothesisRest], Updated_H, Instance, Types) :-
	covers(Hypothesis, Instance),
	(bagof(Hypothesis, specialize(Hypothesis, Instance,Types), Updated_head);
	Updated_head = [ ]),
	specialize_set(Rest, Updated_rest, Instance, Types),
	append(Updated_head, Updated_rest, Updated_H).

specialize_set([HypothesisRest], [HypothesisUpdated_rest],Instance,Types) :-
	not(covers(Hypothesis, Instance)),
	specialize_set(Rest, Updated_rest,
	Instance, Types).

specialize([Prop_], [Inst_prop_], [Instance_values_]) :-
	var(Prop), member(Prop, Instance_values),
	Prop \= Inst_prop.
specialize([_Tail], [_Inst_tail], [_Types]) :-
	specialize(Tail, Inst_tail, Types).


%main function: specification
process(negative(Instance), G, S, Updated_G, Updated_S, Types) :-
	delete(X, S, covers(X, Instance), Updated_S),
	specialize_set(G, Spec_G, Instance, Types),
	delete(X, Spec_G, (member(Y, Spec_G),
	more_general(Y, X)), Pruned_G),
	delete(X, Pruned_G, (member(Y, Updated_S),
	not(covers(X, Y))), Updated_G).
process(positive(Instance), G, [ ], Updated_G, [Instance],_) :- %Initialize S
	delete(X, G, not(covers(X, Instance)), Updated_G).
process(positive(Instance), G, S, Updated_G, Updated_S,_) :-
	delete(X, G, not(covers(X, Instance)), Updated_G),
	generalize_set(S, Gen_S, Instance),
	delete(X, Gen_S, (member(Y, Gen_S),
	more_general(X, Y)), Pruned_S),
	delete(X, Pruned_S, not((member(Y, Updated_G),
	covers(Y, X))), Updated_S).
process(Input, G, P, G, P,_) :-
	Input \= positive(_), Input \= negative(_),
	write('Enter a positive(Instance) or negative(Instance): '), nl.
%END OF specify


%repl for auto procesing
candidate_elim([G],[S],_) :-
	covers(G,S),covers(S,G),
	write('target concept is: '), write(G),nl.
candidate_elim(G, S, Types) :-
	write('G= '), write(G), nl, write('S= '),
	write(S), nl, write('Enter Instance:'), nl,
	read(Instance),
	process(Instance, G, S, Updated_G,
	Updated_S, Types),
	candidate_elim(Updated_G, Updated_S, Types).


