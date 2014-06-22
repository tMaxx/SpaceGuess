//#define LL1_tracing
namespace Prolog
{
  using System;
  using System.IO;
  using System.Text;
  using System.Xml;
  using System.Collections;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using System.Globalization;
  using System.Threading;
  using System.Diagnostics;
  using System.Security.Principal;

/* _______________________________________________________________________________________________
  |                                                                                               |
  |  C#Prolog -- Copyright (C) 2007 John Pool -- j.pool@ision.nl                                  |
  |                                                                                               |
  |  This library is free software; you can redistribute it and/or modify it under the terms of   |
  |  the GNU General Public License as published by the Free Software Foundation; either version  |
  |  2 of the License, or any later version.                                                      |
  |                                                                                               |
  |  This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;    |
  |  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.    |
  |  See the GNU General Public License for details, or enter 'license.' at the command prompt.   |
  |_______________________________________________________________________________________________|
*/

// Parser Generator version 4.0 -- Date/Time: 1-5-2013 11:56:26


  public partial class PrologEngine
  {
    #region JsonParser
    public partial class JsonParser : BaseParser<object>
    {
      public static readonly string VersionTimeStamp = "2013-05-01 11:56:26";
      
      
      #region Terminal definition
      
      /* The following constants are defined in BaseParser.cs:
      const int Undefined = 0;
      const int Comma = 1;
      const int LeftParen = 2;
      const int RightParen = 3;
      const int Identifier = 4;
      const int IntLiteral = 5;
      const int ppDefine = 6;
      const int ppUndefine = 7;
      const int ppIf = 8;
      const int ppIfNot = 9;
      const int ppIfDef = 10;
      const int ppIfNDef = 11;
      const int ppElse = 12;
      const int ppEndIf = 13;
      const int RealLiteral = 14;
      const int ImagLiteral = 15;
      const int StringLiteral = 16;
      const int CharLiteral = 17;
      const int CommentStart = 18;
      const int CommentSingle = 19;
      const int EndOfLine = 20;
      const int ANYSYM = 21;
      const int EndOfInput = 22;
      */
      const int LSqBracket = 23;
      const int RSqBracket = 24;
      const int LCuBracket = 25;
      const int RCuBracket = 26;
      const int Colon = 27;
      const int TrueSym = 28;
      const int FalseSym = 29;
      const int NullSym = 30;
      // Total number of terminals:
      public const int terminalCount = 31;
      
      public static void FillTerminalTable (BaseTrie terminalTable)
      {
        terminalTable.Add (Undefined, "Undefined");
        terminalTable.Add (Comma, "Comma", ",");
        terminalTable.Add (LeftParen, "LeftParen", "(");
        terminalTable.Add (RightParen, "RightParen", ")");
        terminalTable.Add (Identifier, "Identifier");
        terminalTable.Add (IntLiteral, "IntLiteral");
        terminalTable.Add (ppDefine, "ppDefine", "#define");
        terminalTable.Add (ppUndefine, "ppUndefine", "#undefine");
        terminalTable.Add (ppIf, "ppIf", "#if");
        terminalTable.Add (ppIfNot, "ppIfNot", "#ifnot");
        terminalTable.Add (ppIfDef, "ppIfDef", "#ifdef");
        terminalTable.Add (ppIfNDef, "ppIfNDef", "#ifndef");
        terminalTable.Add (ppElse, "ppElse", "#else");
        terminalTable.Add (ppEndIf, "ppEndIf", "#endif");
        terminalTable.Add (RealLiteral, "RealLiteral");
        terminalTable.Add (ImagLiteral, "ImagLiteral");
        terminalTable.Add (StringLiteral, "StringLiteral");
        terminalTable.Add (CharLiteral, "CharLiteral");
        terminalTable.Add (CommentStart, "CommentStart", "/*");
        terminalTable.Add (CommentSingle, "CommentSingle", "%");
        terminalTable.Add (EndOfLine, "EndOfLine");
        terminalTable.Add (ANYSYM, "ANYSYM");
        terminalTable.Add (EndOfInput, "EndOfInput");
        terminalTable.Add (LSqBracket, "LSqBracket", "[");
        terminalTable.Add (RSqBracket, "RSqBracket", "]");
        terminalTable.Add (LCuBracket, "LCuBracket", "{");
        terminalTable.Add (RCuBracket, "RCuBracket", "}");
        terminalTable.Add (Colon, "Colon", ":");
        terminalTable.Add (TrueSym, "TrueSym", "true");
        terminalTable.Add (FalseSym, "FalseSym", "false");
        terminalTable.Add (NullSym, "NullSym", "null");
      }
      
      #endregion Terminal definition

      #region Constructor
      public JsonParser ()
      {
        terminalTable = new BaseTrie (terminalCount, false);
        FillTerminalTable (terminalTable);
        symbol = new Symbol (this);
        streamInPrefix = "";
        streamInPreLen = 0;
      }
      #endregion constructor

      #region NextSymbol, GetSymbol
      protected override bool GetSymbol (TerminalSet followers, bool done, bool genXCPN)
      {
        string s;

        if (symbol.IsProcessed) NextSymbol ();

        symbol.SetProcessed (done);
        if (parseAnyText || followers.IsEmpty ()) return true;

        if (syntaxErrorStat) return false;

        if (symbol.Terminal == ANYSYM || followers.Contains (symbol.Terminal)) return true;

        switch (symbol.Terminal)
        {
          case EndOfLine:
            if (seeEndOfLine) s = "<EndOfLine>"; else goto default;
            s = "<EndOfLine>";
            break;
          case EndOfInput:
            s = "<EndOfInput>";
            break;
          default:
            s = String.Format ("\"{0}\"", symbol.ToString ());
            break;
        }

        s = String.Format ("*** Unexpected symbol: {0}{1}*** Expected one of: {2}", s,
                           Environment.NewLine, terminalTable.TerminalImageSet (followers));
        if (genXCPN)
          SyntaxError = s;
        else
          errorMessage = s;

        return true;
      }
      #endregion NextSymbol, GetSymbol

      #region PARSER PROCEDURES
      public override void RootCall ()
      {
        JsonStruct (new TerminalSet (terminalCount, EndOfInput));
      }


      public override void Delegates ()
      {
        
      }

      
      #region JsonStruct
      void JsonStruct (TerminalSet _TS)
      {
        #if LL1_tracing
        ReportParserProcEntry ("JsonStruct");
        #endif
        GetSymbol (new TerminalSet (terminalCount, LSqBracket, LCuBracket), false, true);
        if (symbol.Terminal == LCuBracket)
        {
          JsonObject (_TS, out jsonListTerm);
        }
        else
        {
          JsonArray (_TS, out jsonListTerm);
        }
        #if LL1_tracing
        ReportParserProcExit ("JsonStruct");
        #endif
      }
      #endregion
      
      #region JsonObject
      void JsonObject (TerminalSet _TS, out BaseTerm t)
      {
        #if LL1_tracing
        ReportParserProcEntry ("JsonObject");
        #endif
        BaseTerm e;
        List<BaseTerm> listItems = new List<BaseTerm> ();
        GetSymbol (new TerminalSet (terminalCount, LCuBracket), true, true);
        GetSymbol (new TerminalSet (terminalCount, StringLiteral, RCuBracket), false, true);
        if (symbol.Terminal == StringLiteral)
        {
          while (true)
          {
            JsonPair (new TerminalSet (terminalCount, Comma, RCuBracket), out e);
            listItems.Add (e);
            GetSymbol (new TerminalSet (terminalCount, Comma, RCuBracket), false, true);
            if (symbol.Terminal == Comma)
            {
              symbol.SetProcessed ();
            }
            else
              break;
          }
        }
        GetSymbol (new TerminalSet (terminalCount, RCuBracket), true, true);
        t = JsonTerm.FromArray (listItems.ToArray ());
        #if LL1_tracing
        ReportParserProcExit ("JsonObject");
        #endif
      }
      #endregion
      
      #region JsonPair
      void JsonPair (TerminalSet _TS, out BaseTerm t)
      {
        #if LL1_tracing
        ReportParserProcEntry ("JsonPair");
        #endif
        BaseTerm t0, t1;
        GetSymbol (new TerminalSet (terminalCount, StringLiteral), true, true);
        t0 = new StringTerm (symbol.ToString ().Dequoted ());
        GetSymbol (new TerminalSet (terminalCount, Colon), true, true);
        JsonValue (_TS, out t1);
        t = new OperatorTerm (opTable, PrologParser.COLON, t0, t1);
        #if LL1_tracing
        ReportParserProcExit ("JsonPair");
        #endif
      }
      #endregion
      
      #region JsonArray
      void JsonArray (TerminalSet _TS, out BaseTerm t)
      {
        #if LL1_tracing
        ReportParserProcEntry ("JsonArray");
        #endif
        BaseTerm e;
        List<BaseTerm> listItems = new List<BaseTerm> ();
        GetSymbol (new TerminalSet (terminalCount, LSqBracket), true, true);
        GetSymbol (new TerminalSet (terminalCount, IntLiteral, RealLiteral, StringLiteral, LSqBracket, RSqBracket, LCuBracket,
                                                   TrueSym, FalseSym, NullSym), false, true);
        if (symbol.IsMemberOf (IntLiteral, RealLiteral, StringLiteral, LSqBracket, LCuBracket, TrueSym, FalseSym, NullSym))
        {
          while (true)
          {
            JsonValue (new TerminalSet (terminalCount, Comma, RSqBracket), out e);
            listItems.Add (e);
            GetSymbol (new TerminalSet (terminalCount, Comma, RSqBracket), false, true);
            if (symbol.Terminal == Comma)
            {
              symbol.SetProcessed ();
            }
            else
              break;
          }
        }
        GetSymbol (new TerminalSet (terminalCount, RSqBracket), true, true);
        t = new CompoundTerm ("array", ListTerm.ListFromArray (listItems.ToArray (), BaseTerm.EMPTYLIST));
        #if LL1_tracing
        ReportParserProcExit ("JsonArray");
        #endif
      }
      #endregion
      
      #region JsonValue
      void JsonValue (TerminalSet _TS, out BaseTerm t)
      {
        #if LL1_tracing
        ReportParserProcEntry ("JsonValue");
        #endif
        GetSymbol (new TerminalSet (terminalCount, IntLiteral, RealLiteral, StringLiteral, LSqBracket, LCuBracket, TrueSym,
                                                   FalseSym, NullSym), false, true);
        if (symbol.Terminal == LCuBracket)
        {
          JsonObject (_TS, out t);
        }
        else if (symbol.Terminal == LSqBracket)
        {
          JsonArray (_TS, out t);
        }
        else
        {
          JsonLiteral (_TS, out t);
        }
        #if LL1_tracing
        ReportParserProcExit ("JsonValue");
        #endif
      }
      #endregion
      
      #region JsonLiteral
      void JsonLiteral (TerminalSet _TS, out BaseTerm t)
      {
        #if LL1_tracing
        ReportParserProcEntry ("JsonLiteral");
        #endif
        GetSymbol (new TerminalSet (terminalCount, IntLiteral, RealLiteral, StringLiteral, TrueSym, FalseSym, NullSym), false,
                   true);
        if (symbol.IsMemberOf (IntLiteral, RealLiteral))
        {
          GetSymbol (new TerminalSet (terminalCount, IntLiteral, RealLiteral), false, true);
          if (symbol.Terminal == IntLiteral)
          {
            symbol.SetProcessed ();
          }
          else
          {
            symbol.SetProcessed ();
          }
          t = new DecimalTerm (symbol.ToDecimal ());
        }
        else if (symbol.Terminal == StringLiteral)
        {
          symbol.SetProcessed ();
          t = new StringTerm (symbol.ToString ().Dequoted ());
        }
        else if (symbol.Terminal == TrueSym)
        {
          symbol.SetProcessed ();
          t = new AtomTerm ("true");
        }
        else if (symbol.Terminal == FalseSym)
        {
          symbol.SetProcessed ();
          t = new AtomTerm ("false");
        }
        else
        {
          symbol.SetProcessed ();
          t = new AtomTerm ("null");
        }
        #if LL1_tracing
        ReportParserProcExit ("JsonLiteral");
        #endif
      }
      #endregion
      
      
      #endregion PARSER PROCEDURES
    }
    #endregion JsonParser
  }
}
