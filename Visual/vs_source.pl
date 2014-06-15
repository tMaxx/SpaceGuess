% Candidate Elimination Algorithm

%run_candidate_elim :- candidate_elim([[_,_,_]], [], 
%	[[small, medium, large], [red, blue, green], [ball, brick, cube]]).

% Candidate_elim implements a top level read-process loop
% It prints out the current G set 
% the S set
%
% and calls process to process the input.
%candidate_elim([G],[S],_) :-
%	covers(G,S),covers(S,G),
%	write("target concept is "), write(G),nl.

%candidate_elim(G, S, Types) :-
%	write("G= "), write(G),nl,
%	write("S= "), write(S),nl,
%	write("Enter Instance "),
%	read(Instance),
%	process(Instance, G, S, Updated_G, Updated_S, Types),
%	candidate_elim(Updated_G, Updated_S, Types).

% Process takes the instance, 
%	a set of concepts, G and 
%	and a set of concepts, S
% it implements a step of the candidate elimination algorithm.


process(negative(Instance), G, S, Updated_G, Updated_S, Types) :- 
	delete(X, S, covers(X, Instance), Updated_S),
	specialize_set(G,Spec_G, Instance, Types),
	delete(X, Spec_G, (member(Y, Spec_G), more_general(Y, X)), Pruned_G),
	delete(X, Pruned_G, (member(Y, Updated_S), not(covers(X, Y))), Updated_G).

process(positive(Instance), G, [], Updated_G, [Instance],_):- 
% Initialize S
delete(X, G, not(covers(X, Instance)), Updated_G).

process(positive(Instance), G, S, Updated_G, Updated_S,_) :- 
	delete(X, G, not(covers(X, Instance)), Updated_G),
	generalize_set(S,Gen_S, Instance),
	delete(X, Gen_S, (member(Y, Gen_S), more_general(X, Y)), Pruned_S),
	delete(X, Pruned_S, not((member(Y, Updated_G), covers(Y, X))), Updated_S).

process(Input, G, P, G, P,_):- 
	Input \= positive(_),
	Input \= negative(_),
	write("Enter either positive(Instance) or negative(Instance) "), nl.

% The following predicate definitions are duplicated in either
% the general to specific searches or the specific to genearal searches.
% 
specialize_set([], [], _, _).
specialize_set([Hypothesis|Rest],Updated_H,Instance, Types):-	
	covers(Hypothesis, Instance),			
	(bagof(Hypothesis, specialize(Hypothesis, Instance, Types), Updated_head); Updated_head = []),
	specialize_set(Rest, Updated_rest, Instance, Types),
	append(Updated_head, Updated_rest, Updated_H).

specialize_set([Hypothesis|Rest],[Hypothesis|Updated_rest],Instance, Types):-
	not (covers(Hypothesis, Instance)),			
	specialize_set(Rest,Updated_rest, Instance, Types).

specialize([Prop|_], [Inst_prop|_], [Instance_values|_]):-
 	var(Prop),
	member(Prop, Instance_values),
	Prop \= Inst_prop.

specialize([_|Tail], [_|Inst_tail], [_|Types]):-
	specialize(Tail, Inst_tail, Types).

%

generalize_set([], [], _).

generalize_set([Hypothesis|Rest],Updated_H,Instance):-			
	not(covers(Hypothesis, Instance)),
	(bagof(X, generalize(Hypothesis, Instance, X), Updated_H); Updated_head = []),
	generalize_set(Rest,Updated_rest, Instance),
	append(Updated_head, Updated_rest, Updated_H).

generalize_set([Hypothesis|Rest],[Hypothesis|Updated_rest],Instance):-
	covers(Hypothesis, Instance),
	generalize_set(Rest,Updated_rest, Instance).

%

generalize([],[],[]).	
generalize([Feature|Rest], [Inst_prop|Rest_inst], [Feature|Rest_gen]) :-
	not(Feature \= Inst_prop),
	generalize(Rest, Rest_inst, Rest_gen).

generalize([Feature|Rest], [Inst_prop|Rest_inst], [_|Rest_gen]) :-
	Feature \= Inst_prop,
	generalize(Rest, Rest_inst, Rest_gen).

% more_general(Feature_vector_1, Feature_vector_2) :- succeeds if
%	Feature_vector_1 is strictly more general than Feature_vector_2

more_general(X, Y) :-  not(covers(Y, X)), covers(X, Y).

% covers(Feature_list_1, Feature_list_2) :- Succeeds if Feature_list_1
%	covers Feature_list_2.  Note that covers, unlike unification is
%	not symmetric: variables in Feature_list_2 will not match constants
%	in Feature_list_1.

covers([],[]).
covers([H1|T1], [H2|T2]) :-
	var(H1), var(H2), 
	covers(T1, T2).
covers([H1|T1], [H2|T2]) :-
	var(H1), atom(H2), 
	covers(T1, T2).	
covers([H1|T1], [H2|T2]) :-
	atom(H1), atom(H2), H1 = H2,
covers(T1, T2).

% delete(Element, List1, Goal, List2) :- List2 contains all bindings
%	of Element to a member of List1 except those that cause 
%	Goal to succeed

delete(X, L, Goal, New_L) :-
	(bagof(X, (member(X, L), not(Goal)), New_L);New_L = []).  
