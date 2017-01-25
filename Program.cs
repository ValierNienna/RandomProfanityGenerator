using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomProfanityGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            XDocument profanityXml = XDocument.Load(@"C:\Users\Katelyn\Documents\RandomProfanityGenerator\swearWords.xml");
            XDocument sentenceXml = XDocument.Load(@"C:\Users\Katelyn\Documents\RandomProfanityGenerator\sentenceStructures.xml");

            var firstPartSentence = (from g in sentenceXml.Descendants("sentence")
                                     select g.Descendants("first").OrderBy(r => rnd.Next()).First()).First().Value;

            var secondPartSentence = (from g in sentenceXml.Descendants("sentence")
                                     select g.Descendants("second").OrderBy(r => rnd.Next()).First()).First().Value;

            var thirdPartSentence = (from g in sentenceXml.Descendants("sentence")
                                     select g.Descendants("third").OrderBy(r => rnd.Next()).First()).First().Value;

            var randomProfanityFirst = (from g in profanityXml.Descendants("words")
                                        select g.Descendants("word").OrderBy(r => rnd.Next()).First()).First().Value;

            var randomProfanityMiddle = (from g in profanityXml.Descendants("words")
                                         select g.Descendants("word").OrderBy(r => rnd.Next()).First()).First().Value;

            var randomProfanityLast = (from g in profanityXml.Descendants("words")
                                       select g.Descendants("word").OrderBy(r => rnd.Next()).First()).First().Value;

            Console.WriteLine(firstPartSentence + " " + randomProfanityFirst + " " + randomProfanityMiddle + " " + randomProfanityLast);
            Console.ReadLine();

        }
    }
}
