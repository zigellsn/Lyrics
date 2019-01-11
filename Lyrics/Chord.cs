using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lyrics
{
    class Chord : IComparable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private int syllable = 0;
        public int Syllable
        {
            get { return syllable; }
            set { syllable = value; }
        }
        private string syllableName = "";
        public string SyllableName
        {
            get { return syllableName; }
            set { syllableName = value; }
        }
        private int transpose = 0;
        public int Transpose
        {
            get { return transpose; }
            set { transpose = value; }
        }
        private int line = 0;
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        public Chord(string chordname, int position, int row)
        {
            line = row;
            name = chordname;
            switch (name)
            {
                case "a":
                    number = 0;
                    break;
                case "b":
                    number = 1;
                    break;
            }
            syllable = position;
        }

        public void GetLocation(ref List<Chord> Chords, int Line)
        {
            if (line == Line) Chords.Add(this);
        }

        public void GetPosition(int Line, int Position, ref bool Exists)
        {
            if (Exists == false)
            {
                if (line == Line && (Position >= syllable && Position < syllable + name.Length)) Exists = true;
            }
        }

        #region IComparable Member

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
