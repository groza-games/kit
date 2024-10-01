using System.Text;
using UnityEngine;

namespace GrozaGames.Kit
{
    public static class LogPrefix
    {
        private static readonly StringBuilder StringBuilder = new StringBuilder();
        
        /// <summary>
        /// String format [ffffff | hh.mm.ss.tttt | className]
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static string Get(string className = null)
        {
            StringBuilder.Clear();

            StringBuilder.Append("[");
            var frame = Time.frameCount.ToString().PadLeft(6);
            StringBuilder.Append(frame);
            StringBuilder.Append(" | ");
            var time = System.DateTime.Now.ToString("HH:mm:ss.fff");
            StringBuilder.Append(time);
            if (!string.IsNullOrEmpty(className))
            {
                StringBuilder.Append(" | ");
                StringBuilder.Append(className);
            }
            StringBuilder.Append("] ");
            
            return StringBuilder.ToString();
        }
    }
}