using System;
using Unit4.CollectionsLib;

namespace ConsoleApplication1
{
    class StackMethods
    {
        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מחזירה מחסנית חדשה, שאיבריה זהים בערכם ובסדרם לאיברי המחסנית שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static Stack<T> CloneStack(Stack<T> s)
        {
            Stack<T> newS = new Stack<T>();
            Stack<T> tmp = new Stack<T>();
            while (!s.IsEmpty())
                tmp.Push(s.Pop());
            while (!tmp.IsEmpty())
            {
                newS.Push(tmp.Top());
                s.Push(tmp.Pop());
            }
            return newS;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מחזירה מחסנית חדשה, שאיבריה מסודרים בסדר הפוך ביחס לאיברי המחסנית שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static Stack<T> FlipStack(Stack<T> s)
        {
            Stack<T> newS = new Stack<T>();
            Stack<T> tmp = CloneStack(s);
            while (!tmp.IsEmpty())
                newS.Push(tmp.Pop());
            return newS;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים ואובייקט  
        // טענת יציאה: המחסנית מחזירה "אמת" אם אובייקט נמצא במחסנית, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistStack(Stack<T> s, T n)
        {
            Stack<T> sCopy = CloneStack(s);
            while (!sCopy.IsEmpty())
                if (sCopy.Pop() == n)
                    return true;
            return false;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים ואובייקט  
        // טענת יציאה: המחסנית מחזירה "אמת" אם אובייקט נמצא במחסנית, אחרת מחזירה "שקר"
        // הערה: הפעולה רקורסיבית, ועדיין שומרת על סדר המחסנית שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistStackRec(Stack<T> s, T n)
        {
            if (s.IsEmpty())
                return false;
            T x = s.Pop();
            bool exists = (x == n || IsExistStackRec(s, n));
            s.Push(x); //לאחר הקריאה הרקורסיבית, האיבר שנשלף נדחף בחזרה אל תוך המחסנית
            return exists;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מחזירה את סכום איברי המחסנית
        // סיבוכיות זמן ריצה: O(n)
        public static T SumStack(Stack<T> s)
        {
            T sum = 0;
            Stack<T> sCopy = CloneStack(s);
            while (!sCopy.IsEmpty())
                sum += sCopy.Pop();
            return sum;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מחזירה את אורך המחסנית - מספר האיברים בה
        // סיבוכיות זמן ריצה: O(n)
        public static int LengthStack(Stack<T> s)
        {
            int length = 0;
            Stack<T> sCopy = CloneStack(s);
            while (!sCopy.IsEmpty())
            {
                length++;
                sCopy.Pop();
            }
            return length;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים ואובייקט  
        // טענת יציאה: הפעולה מחזירה את מספר הפעמים שהאובייקט מופיע במחסנית
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyStack(Stack<T> s, T n)
        {
            int count = 0;
            Stack<T> tmp = CloneStack(s);
            while (!tmp.IsEmpty())
                if (tmp.Pop() == n)
                    count++;
            return count;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים ואובייקט  
        // טענת יציאה: הפעולה מוחקת את כל מופעי המספר שהתקבל מתוך המחסנית
        // סיבוכיות זמן ריצה: O(n)
        public static void DebugStack(Stack<T> s, T n)
        {
            Stack<T> tmp = FlipStack(s);
            while (!s.IsEmpty())
                s.Pop();
            while (!tmp.IsEmpty())
            {
                T x = tmp.Pop();
                if (!x.Equals(n))
                    q.Push(x);
            }
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מסדרת את איברי המחסנית מהקטן לגדול
        // סיבוכיות זמן ריצה: O(n^2) במקרה הגרוע
        public static void SortStack(Stack<T> s)
        {
            Stack<T> sortedStack = new Stack<T>();

            while (!s.IsEmpty())
            {
                T tmp = s.Pop();

                while (!sortedStack.IsEmpty() && sortedStack.Top().CompareTo(tmp) > 0)
                {
                    s.Push(sortedStack.Pop());
                }

                sortedStack.Push(tmp);
            }

            while (!sortedStack.IsEmpty())
            {
                s.Push(sortedStack.Pop());
            }
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מסירה איברים כפולים מהמחסנית, תוך שמירה על סדר המקורי
        // סיבוכיות זמן ריצה: O(n^2) במקרה הגרוע
        public static void RemoveDuplicates(Stack<T> s)
        {
            Stack<T> tmpStack = new Stack<T>();

            while (!s.IsEmpty())
            {
                T current = s.Pop();

                if (!IsExistStack(tmpStack, current))
                {
                    tmpStack.Push(current);
                }
            }

            while (!tmpStack.IsEmpty())
            {
                s.Push(tmpStack.Pop());
            }
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת מחסנית של אובייקטים גנרים 
        // טענת יציאה: הפעולה מחזירה מחסנית חדשה, שבה כל איבר מופיע פעמיים מהמחסנית המקורית
        // סיבוכיות זמן ריצה: O(n)
        public static Stack<T> DoubleStack(Stack<T> s)
        {
            Stack<T> doubledStack = new Stack<T>();
            Stack<T> tmpStack = CloneStack(s);

            while (!tmpStack.IsEmpty())
            {
                T current = tmpStack.Pop();
                doubledStack.Push(current);
                doubledStack.Push(current);
            }

            Stack<T> reversedStack = new Stack<T>();
            while (!doubledStack.IsEmpty())
            {
                reversedStack.Push(doubledStack.Pop());
            }

            return reversedStack;
        }

        // ==========================================================================================
    }
}