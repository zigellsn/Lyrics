using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lyrics
{
    sealed class LineDiscr
    {
        private ChordProgression cp;
        private LineDiscr()
        {
            cp = new ChordProgression();
        }         
        private static volatile LineDiscr instance = null;
        public static LineDiscr getInstance()
        {
            // DoubleLock 
            if (instance == null)
                lock (m_lock) 
                { 
                    if (instance == null) instance = new LineDiscr(); 
                }
            return instance;
        }
        // Hilfsfeld für eine sichere Threadsynchronisierung
        private static object m_lock = new object();

        public string Analyze(string Line, int LineNumber)
        {
            //"[A-G](b|#|bb|x)?((m(aj)?|M|aug|dim|sus)([2-7]|9|13)?)?(\\/[A-G](b|#|bb|x)?)?"
            Regex reg = new Regex ("[A-G](b|#|bb|x)?((m(aj)?|M|aug|dim|sus)([2-7]|9|13)?)?(\\/[A-G](b|#|bb|x)?)?");
            MatchCollection collection = reg.Matches(Line);
            if (collection.Count > 0)
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    cp.Add(collection[i].Value.ToString(), collection[i].Index, LineNumber);
                }
                return cp.RenderLine(LineNumber);
            }
            else return Line;
        }
    }
}
