namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        //First variant:

        //public bool AreBalanced(string parentheses)
        //{
        //    if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 != 0)
        //    {
        //        return false;
        //    }

        //    var openBrackets = new Stack<char>(parentheses.Length / 2);

        //    foreach (var currBracket in parentheses)
        //    {
        //        char expectedCharacter = default;

        //        switch (currBracket)
        //        {
        //            case ')':
        //                expectedCharacter = '(';
        //                break;
        //            case ']':
        //                expectedCharacter = '[';
        //                break;
        //            case '}':
        //                expectedCharacter = '{';
        //                break;
        //            default:
        //                openBrackets.Push(currBracket);
        //                break;
        //        }

        //        if (expectedCharacter != default && openBrackets.Pop() != expectedCharacter)
        //        {
        //            return false;
        //        }
        //    }

        //    return openBrackets.Count == 0;
        //}



        // Second variant:

        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 != 0)
            {
                return false;
            }

            while (parentheses.Length > 0)
            {
                var openingBracket = parentheses[0];
                char oppositeBracket = default;

                switch (openingBracket)
                {
                    case '(':
                        oppositeBracket = ')';
                        break;
                    case '[':
                        oppositeBracket = ']';
                        break;
                    case '{':
                        oppositeBracket = '}';
                        break;
                    default:
                        return false;
                }

                bool oppositeIsContained = parentheses.Contains(oppositeBracket);

                if (!oppositeIsContained)
                {
                    return false;
                }

                parentheses = parentheses.Remove(0, 1);
                parentheses = parentheses.Remove(parentheses.IndexOf(oppositeBracket), 1);
            }

            return true;
        }
    }
}
