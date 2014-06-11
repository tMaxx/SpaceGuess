% philosopher - solver dla uczenia maszynowego
% gdyba, co ma jakie właściwości ;)


%przydatne komendy:
%halt.
%consult(file).
%make.


% drukuje wszystkie elementy z listy, jeden po drugim
printlist([]).
printlist([X]) :- !,
	write(X), nl, nl.

printlist([X|List]) :- !,
	write(X), write(', '),
	printlist(List).


% fakty, kilka przykładów do bazy

color(ball, blue).
shape(ball, round).
size(ball, small).
other(ball, rough).

positive(shape(X, Y)) :-
	shape(X, Y).
positive(color(X, Y)) :-
	color(X, Y).
positive(size(X, Y)) :-
	size(X, Y).
positive(other(X, Y)) :-
	other(X, Y).


is(ball, shape, round).
is(ball, color, red).
is(ball, size, big).


%% czy jeżeli W1 jest zrobione z P1 to czy





%% has_prop(ball, blue).
%% has_prop(ball, round).



%desc_prop(X) :-
%	has_prop(X, ?).
	%% printlist(Y).


