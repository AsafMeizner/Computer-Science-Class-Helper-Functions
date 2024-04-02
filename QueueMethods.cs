using System;
using Unit4.CollectionsLib;

namespace ConsoleApplication1
{
    class QueueMethods
    {
        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה תור חדש, שאיבריו זהים בערכם ובסדרם לאיברי התור שהתקבל 
        // סיבוכיות זמן ריצה: O(n)
        public static Queue<T> CloneQueue(Queue<T> q)
        {
            Queue<T> newQ = new Queue<T>();
            Queue<T> tmp = new Queue<T>();
            while (!q.IsEmpty())
            {
                newQ.Insert(q.Head());
                tmp.Insert(q.Remove());
            }
            while (!tmp.IsEmpty())
                q.Insert(tmp.Remove());
            return newQ;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים ואובייקט
        // טענת יציאה: הפעולה מחזירה "אמת" אם המספר קיים בתור, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistQueue(Queue<T> q, T n)
        {
            Queue<T> qCopy = CloneQueue(q);
            while (!qCopy.IsEmpty())
                if (qCopy.Remove() == n)
                    return true;
            return false;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של מספרים 
        // טענת יציאה: הפעולה מחזירה את סכום איברי התור
        // סיבוכיות זמן ריצה: O(n)
        public static T SumQueue(Queue<T> q)
        {
            T sum = default(T);
            Queue<T> qCopy = CloneQueue(q);
            while (!qCopy.IsEmpty())
                sum += qCopy.Remove();
            return sum;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את אורך התור - מספר האיברים בו
        // סיבוכיות זמן ריצה: O(n)
        public static int LengthQueue(Queue<T> q)
        {
            int length = 0;
            Queue<T> qCopy = CloneQueue(q);
            while (!qCopy.IsEmpty())
            {
                length++;
                qCopy.Remove();
            }
            return length;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של איברים ואיבר 
        // טענת יציאה: הפעולה מחזירה את מספר הפעמים שהאיבר מופיע בתור
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyQueue(Queue<T> q, T n)
        {
            T count = 0;
            Queue<T> tmp = CloneQueue(q);
            while (!tmp.IsEmpty())
                if (tmp.Remove() == n)
                    count++;
            return count;
        }
        
        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של אובייקטים ואובייקט 
        // טענת יציאה: הפעולה מוחקת את כל מופעי האובייקט שהתקבל מתוך התור
        // סיבוכיות זמן ריצה: O(n)
        public static void DebugQueue(Queue<T> q, T n)
        {
            Queue<T> tmp = CloneQueue(q);
            while (!q.IsEmpty())
                q.Remove();
            while (!tmp.IsEmpty())
            {
                T x = tmp.Remove();
                if (!x.Equals(n))
                    q.Insert(x);
            }
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של אובייקטים 
        // טענת יציאה: הפעולה מחזירה את התור מסודר
        // סיבוכיות זמן ריצה: O(n^2)
        public static Queue<T> SortQueueSelection(Queue<T> q)
        {
            Queue<T> sortedQueue = new Queue<T>();

            Queue<T> tempQueue = CloneQueue(q);

            while (!tempQueue.IsEmpty())
            {
                T smallest = tempQueue.Head();
                Queue<T> remaining = new Queue<T>();

                while (!tempQueue.IsEmpty())
                {
                    T current = tempQueue.Remove();
                    if (Comparer<T>.Default.Compare(current, smallest) < 0)
                    {
                        remaining.Insert(smallest);
                        smallest = current;
                    }
                    else
                    {
                        remaining.Insert(current);
                    }
                }

                sortedQueue.Insert(smallest);
                tempQueue = CloneQueue(remaining);
            }

            return sortedQueue;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של אובייקטים 
        // טענת יציאה: הפעולה מחזירה את התור מסודר
        // סיבוכיות זמן ריצה: O(n log(n))
        public static Queue<T> QuickSortQueue(Queue<T> q)
        {
            if (q.Length() <= 1)
                return q;

            T pivot = q.Head();
            Queue<T> less = new Queue<T>();
            Queue<T> equal = new Queue<T>();
            Queue<T> greater = new Queue<T>();

            while (!q.IsEmpty())
            {
                T current = q.Remove();
                if (current.CompareTo(pivot) < 0)
                    less.Insert(current);
                else if (current.CompareTo(pivot) == 0)
                    equal.Insert(current);
                else
                    greater.Insert(current);
            }

            Queue<T> sorted = QuickSortQueue(less);
            sorted.Insert(pivot);
            while (!equal.IsEmpty())
            {
                sorted.Insert(equal.Remove());
            }
            Queue<T> greaterSorted = QuickSortQueue(greater);
            while (!greaterSorted.IsEmpty())
            {
                sorted.Insert(greaterSorted.Remove());
            }

            return sorted;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של אובייקטים 
        // טענת יציאה: הפעולה מחזירה תור חדש שלא מכיל ערכים כפולים
        // סיבוכיות זמן ריצה: O(n^2)
        public static Queue<T> RemoveDuplicates(Queue<T> q)
        {
            Queue<T> tempQueue = new Queue<T>();
            Queue<T> cloneQueue = CloneQueue(q);

            while (!cloneQueue.IsEmpty())
            {
                T current = cloneQueue.Remove();
                bool isDuplicate = false;

                foreach (T item in tempQueue)
                {
                    if (Object.Equals(current, item))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    tempQueue.Insert(current);
                }
            }

            return tempQueue;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת שני תורים של אובייקטים
        // טענת יציאה: הפעולה מחזירה תור חדש של איברים שמופיעים בשני התורים
        // סיבוכיות זמן ריצה: O(n + m)
        public static Queue<T> MergeQueue(Queue<T> q1, Queue<T> q2)
        {
            Queue<T> mergedQueue = new Queue<T>();
            Queue<T> cloneQ1 = CloneQueue(q1);
            Queue<T> cloneQ2 = CloneQueue(q2);

            while (!cloneQ1.IsEmpty())
            {
                mergedQueue.Insert(cloneQ1.Remove());
            }

            while (!cloneQ2.IsEmpty())
            {
                mergedQueue.Insert(cloneQ2.Remove());
            }

            return mergedQueue;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של אובייקטים
        // טענת יציאה: הפעולה מחזירה תור חדש של איברים שמופיעים בתור המקורי פעמיים ומעלה
        // סיבוכיות זמן ריצה: O(n^2)

        public static Queue<T> DoubleQueue(Queue<T> q)
        {
            Queue<T> tempQueue = new Queue<T>();
            Queue<T> cloneQueue = CloneQueue(q);

            while (!cloneQueue.IsEmpty())
            {
                T current = cloneQueue.Remove();
                tempQueue.Insert(current);
                tempQueue.Insert(current);
            }

            return tempQueue;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת תור של אובייקטים
        // טענת יציאה: הפעולה מחזירה את התור הפוך
        // סיבוכיות זמן ריצה: O(n)

        public static Queue<T> ReverseQueue(Queue<T> q)
        {
            Queue<T> tempQueue = new Queue<T>();
            Queue<T> cloneQueue = CloneQueue(q);

            while (!cloneQueue.IsEmpty())
            {
                tempQueue.Insert(cloneQueue.Remove());
            }

            return tempQueue;
        }

        // ==========================================================================================
    }
}