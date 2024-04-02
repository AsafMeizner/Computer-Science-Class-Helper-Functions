using System;
using Unit4.CollectionsLib;

namespace ConsoleApplication1
{
    class NodeMethods
    {
        // ==========================================================================================
        
        //טענת כניסה: הפעולה מקבלת רשימה של אובייקטים ואובייקט
        // טענת יציאה: הפעולה מחזירה "אמת" אם המספר נמצא ברשימה, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistNode(Node<T> l, T n)
        {
            Node<T> pos = l;
            while (pos != null)
            {
                if (pos.GetValue().Equals(n))
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה של אובייקטים
        // טענת כניסה: הפעולה מחזירה את סכום כל איברי הרשימה
        // סיבוכיות זמן ריצה: O(n)
        public static double SumNode(Node<T> l)
        {
            double sum = 0;
            Node<T> pos = l;
            while (pos != null)
            {
                sum += Convert.ToDouble(pos.GetValue());
                pos = pos.GetNext();
            }
            return sum;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה של אובייקטים
        // טענת יציאה: הפעולה מחזירה את אורך הרשימה - מספר החוליות בה
        // סיבוכיות זמן ריצה: O(n)
        public static int LengthNode(Node<T> l)
        {
            int length = 0;
            Node<T> pos = l;
            while (pos != null)
            {
                length++;
                pos = pos.GetNext();
            }
            return length;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה של אובייקטים ואובייקט
        // טענת יציאה: הפעולה מחזירה את מספר הפעמים שהמספר מופיע ברשימה
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyNode(Node<T> l, T n)
        {
            int count = 0;
            Node<T> pos = l;
            while (pos != null)
            {
                if (pos.GetValue().Equals(n))
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה של אובייקטים ואובייקט
        // טענת יציאה: הפעולה מוחקת את כל מופעי המספר שהתקבל מהרשימה
        // סיבוכיות זמן ריצה: O(n)
        public static void DebugNode(Node<T> l, T n)
        {
            Node<T> pos = l;
            Node<T> prev = null;
            while (pos != null)
            {
                if (pos.GetValue().Equals(n))
                {
                    if (prev != null)
                    {
                        prev.SetNext(pos.GetNext());
                    }
                    else
                    {
                        l = pos.GetNext();
                    }
                }
                else
                {
                    prev = pos;
                }
                pos = pos.GetNext();
            }
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה ממוינת של אובייקטים ואובייקט
        // טענת יציאה: הפעולה מכניסה באופן ממוין את המספר לרשימה
        // סיבוכיות זמן ריצה: O(n)
        public static Node<T> InsertSorted(Node<T> l, T n)
        {
            Node<T> newNode = new Node<T>(n);
            if (l == null || Convert.ToDouble(l.GetValue()) >= Convert.ToDouble(newNode.GetValue()))
            {
                newNode.SetNext(l);
                return newNode;
            }
            else
            {
                Node<T> current = l;
                while (current.GetNext() != null &&
                       Convert.ToDouble(current.GetNext().GetValue()) < Convert.ToDouble(newNode.GetValue()))
                {
                    current = current.GetNext();
                }
                newNode.SetNext(current.GetNext());
                current.SetNext(newNode);
                return l;
            }
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה של אובייקטים
        // טענת יציאה: הפעולה מחזירה "אמת" אם הרשימה ממוינת בסדר עולה, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsSorted(Node<T> l)
        {
            Node<T> pos = l;
            while (pos != null && pos.GetNext() != null)
            {
                if (pos.GetValue().CompareTo(pos.GetNext().GetValue()) > 0)
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            return true;
        }

        // ==========================================================================================
        
        // טענת כניסה: הפעולה מקבלת רשימה לא ממוינת של אובייקטים
        // טענת יציאה: הפעולה מחזירה רשימה המכילה את כל ערכי הרשימה שהתקבלה בסדר ממוין עולה
        // סיבוכיות זמן ריצה: O(n²)
        public static Node<T> Sort(Node<T> l)
        {
            Node<T> sortedList = null;
            Node<T> current = l;
            while (current != null)
            {
                Node<T> next = current.GetNext();
                sortedList = InsertSorted(sortedList, current.GetValue());
                current = next;
            }
            return sortedList;
        }

        // ==========================================================================================

        // טענת כניסה: הפעולה מקבלת רשימה של אובייקטים
        // טענת יציאה: הפעולה מחזירה רשימה חדשה שלא מכילה ערכים כפולים
        // סיבוכיות זמן ריצה: O(n²)
        public static void RemoveDuplicates(Node<T> l)
        {
            Node<T> current = l;
            while (current != null && current.GetNext() != null)
            {
                if (current.GetValue().Equals(current.GetNext().GetValue()))
                {
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }
        }

        // ==========================================================================================
    }
}