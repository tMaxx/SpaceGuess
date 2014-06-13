using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Class
{
	class SpaceIO : Prolog.BasicIo
	{
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
			SpaceForm.self.tbVSPrologOut.AppendText(s + Environment.NewLine);
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
	}
}
