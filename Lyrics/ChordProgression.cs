using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lyrics
{
    class ChordProgression
    {
        public delegate void Locations(ref List<Chord> Chords, int Line);
        public Locations GetLocations;

        public delegate void Position(int Line, int Position, ref bool Exists);
        public Position GetPositions;

        public ChordProgression()
        {
        }

        public void Add (string chordname, int Position, int LineNumber)
        {
            bool ex = false;
            if (GetPositions != null && GetLocations != null)
            {
                GetPositions(LineNumber, Position, ref ex);
                if (ex == false)
                {
                    Chord chord = new Chord(chordname, Position, LineNumber);
                    GetLocations += chord.GetLocation;
                    GetPositions += chord.GetPosition;
                }
            }
            else
            {
                Chord chord = new Chord(chordname, Position, LineNumber);
                GetLocations += chord.GetLocation;
                GetPositions += chord.GetPosition;
            }
        }

        public string RenderLine(int Line)
        {
            List<Chord> Chords = new List<Chord>();
            GetLocations(ref Chords, Line);

            string ChordLine = "";

            foreach (Chord crd in Chords)
            {
                int SpaceLength =  ChordLine.Length;
                for (int i = 0; i < crd.Syllable - SpaceLength; i++) ChordLine = ChordLine + " ";
                ChordLine = ChordLine + crd.Name;
            }
            return ChordLine;


        }
    }
}
