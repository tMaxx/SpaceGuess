using System;
using Prolog;

//http://www.cs.ccsu.edu/~markov/ccsu_courses/mlprograms/
namespace SpaceGuess {
	class MainClas {
		public static void Main(string[] args) {
			PrologEngine pe = new PrologEngine();
			SolutionSet ss = pe.GetAllSolutions("../../../MLAiP_VersionSpace.pl",
				"candidate_elim([[_,_,_]], [], [[small, medium, large], [red,blue,green], [ball, brick, cube]]).");

			if (ss.Success) {
				foreach (Solution s in ss.NextSolution) {
					Console.WriteLine();

					foreach (Variable v in s.NextVariable)
						Console.WriteLine(string.Format("{0} = {1}", v.Name, v.Value));
				}

			} else {
				Console.WriteLine();
				Console.WriteLine(ss.ErrMsg);
			}
			//Console.WriteLine("Hello World!");
		}
	}
}
