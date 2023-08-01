using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WordFinder.Business
{
    public class WordFinder
    {
        private readonly IEnumerable<string> _matrix;
        private readonly Dictionary<char, List<Position>> _letterDictionary;
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
            _letterDictionary = new Dictionary<char, List<Position>>();

            if (_matrix != null)
            {
                _numberOfRows = _matrix.Count();
                _numberOfColumns = _matrix.FirstOrDefault() == null ? 0 : _matrix.FirstOrDefault().Length;
            }
            else
            {
                _numberOfRows = 0;
                _numberOfColumns = 0;
            }            
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            List<Ocurrence> ocurrences;
            Dictionary<string, List<Ocurrence>> wordsDictionary = new Dictionary<string, List<Ocurrence>>();
            List<string> result = new List<string>();

            foreach (var word in wordStream)
            {
                if (!wordsDictionary.ContainsKey(word))
                {
                    ocurrences = GetOcurrencesOf(word);

                    if (ocurrences.Any() && !wordsDictionary.ContainsKey(word))
                        wordsDictionary.Add(word, ocurrences);
                }        
            }

            return wordsDictionary.OrderByDescending(kvp => kvp.Value.Count()).Select(kvp => kvp.Key).Take(10);
        }

        private List<Ocurrence> GetOcurrencesOf(string word)
        {
            List <Ocurrence> ocurrences = new List<Ocurrence>();
            char firstLetter = word.ElementAt(0);

            if (_letterDictionary.ContainsKey(firstLetter))
            {
                var positions = _letterDictionary[firstLetter];

                foreach (var position in positions)
                {
                    if (IsLeftToRight(word, position.Row, position.Column))
                    {
                        ocurrences.Add(
                            new Ocurrence()
                            {
                                Position = position,
                                Direction = Direction.LeftToRight
                            }
                        );
                    }
                    else if (IsTopToBottom(word, position.Row, position.Column))
                    {
                        ocurrences.Add(
                            new Ocurrence()
                            {
                                Position = position,
                                Direction = Direction.TopToBottom
                            }
                        );
                    }
                }
            }
            else
            {             
                List<Position> firstLetterPositions = new List<Position>();

                for (int i = 0; i < _numberOfRows; i++)
                {
                    var row = _matrix.ElementAt(i);

                    for (int j = 0; j < _numberOfColumns; j++)
                    {
                        var currentLetter = row.ElementAt(j);

                        if (currentLetter == firstLetter)
                        {
                            var currentLetterPosition = new Position() { Row = i, Column = j };
                            firstLetterPositions.Add(currentLetterPosition);

                            if (IsLeftToRight(word, i, j))
                            {
                                ocurrences.Add(
                                    new Ocurrence() {
                                        Position = currentLetterPosition,
                                        Direction = Direction.LeftToRight
                                    }
                                );
                            }
                            else if (IsTopToBottom(word, i, j))
                            {
                                ocurrences.Add(
                                    new Ocurrence()
                                    {
                                        Position = currentLetterPosition,
                                        Direction = Direction.TopToBottom
                                    }
                                );
                            }
                        }
                    }                    
                }

                if (firstLetterPositions.Any())
                    _letterDictionary.Add(firstLetter, firstLetterPositions);                
            }

            return ocurrences;
        }

        private bool IsLeftToRight(string word, int rowIndex, int columnIndex)
        {
            //string row = _matrix.ElementAt(rowIndex);
            int wordLength = word.Length;
            //string matrixWord = row.Substring(columnIndex, wordLength);
            bool isLeftToRight = false;

            //if ((columnIndex + wordLength <= _numberOfColumns) && matrixWord == word)
            if ((columnIndex + wordLength <= _numberOfColumns) && GetHorizontalWord(rowIndex, columnIndex, wordLength) == word)
                isLeftToRight = true;

            return isLeftToRight;
        }

        private string GetHorizontalWord(int rowIndex, int columnIndex, int wordLength)
        {
            return _matrix.ElementAt(rowIndex).Substring(columnIndex, wordLength);
        }

        private bool IsTopToBottom(string word, int rowIndex, int columnIndex)
        {
            string row = _matrix.ElementAt(rowIndex);
            int wordLength = word.Length;
            bool isTopToBottom = false;

            if ((rowIndex + wordLength <= _numberOfRows) && GetVerticalWord(rowIndex, columnIndex, wordLength) == word)
                isTopToBottom = true;

            return isTopToBottom;
        }

        private string GetVerticalWord(int rowIndex, int columnIndex, int wordLength)
        {
            StringBuilder sb = new StringBuilder("");

            for (int i = rowIndex; i < rowIndex + wordLength; i++)
                sb.Append(_matrix.ElementAt(i).ElementAt(columnIndex));

            return sb.ToString();
        }
    }
}