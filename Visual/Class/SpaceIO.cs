using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual.Class
{
	class SpaceIO : Prolog.BasicIo
	{
		readonly protected string prepend;

		public SpaceIO(string pre) : base()
		{
			this.prepend = pre;
		}

		public override string ReadLine()
		{
			throw new NotImplementedException();
		}

		public override int ReadChar()
		{
			throw new NotImplementedException();
		}

		public override void Write(string s)
		{
			SpaceForm.self.tbVSPrologOut.AppendText(s);
		}

		public override void WriteLine(string s)
		{
			SpaceForm.self.tbVSPrologOut.AppendText(this.prepend + s + Environment.NewLine);
		}

		public override void WriteLine()
		{
			SpaceForm.self.tbVSPrologOut.AppendText(Environment.NewLine);
		}

		public override void Clear()
		{
			SpaceForm.self.tbVSPrologOut.AppendText("[P] Clear" + Environment.NewLine);
		}

		public override void Reset()
		{
		}

		public static void loadSource(ref Prolog.PrologEngine pe)
		{
			try
			{ //launched in /bin/debug|release
				pe.Consult(@"../../source.pl");
			}
			catch
			{ //standalone program
				try
				{
					pe.Consult(@"./source.pl");
				}
				catch
				{
					MessageBox.Show("Nie znaleziono pliku z kodem źródłowym algorytmów."
						+ Environment.NewLine + Environment.NewLine
						+ "Należy go umieścić w katalogu razem z plikiem wykonywalnym aplikacji, w pliku o nazwie 'source.pl'."
						+ Environment.NewLine
						+ "Bez powyższego pliku aplikacja nie może kontynuować działania.", "Nie znaleziono pliku źródłowego",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					Environment.Exit(1);
				}
			}
		}
	}
}
