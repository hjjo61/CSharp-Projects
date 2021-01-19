#nullable enable
using System;
using static System.Console;
using MediCal;

namespace Bme121
{
    partial class LinkedList
    {
        // Method used to indicate a target Drug object when searching.
        
        public static bool IsTarget( Drug data ) 
        { 
            return data.Name.StartsWith( "FOSAMAX", StringComparison.OrdinalIgnoreCase ); 
        }
        
        // Method used to compare two Drug objects when sorting.
        // Return is -/0/+ for a<b/a=b/a>b, respectively.
        
        public static int Compare( Drug a, Drug b )
        {
            return string.Compare( a.Name, b.Name, StringComparison.OrdinalIgnoreCase );
        }
        
        // Method used to add a new Drug object to the linked list in sorted order.
        
        public void InsertInOrder( Drug newData )
        {
            Node insert = new Node(newData);
            if(Head == null) // Adding the first element
            {
                Head = insert;
                Tail = insert;
                Count++;
                return;
            }
            if(Compare(insert.Data, Head.Data) < 0) // If insert is less than current Head and will replace it
            {
                AddFirst(insert.Data);
                return;
            }
            Node curNode = Head;
            Node prevNode = Head;
            
            while(curNode != null)
            {
                if(Compare(insert.Data, curNode.Data) < 0) // If insert goes somewhere in between
                {
                    prevNode.Next = insert;
                    insert.Next = curNode;
                    Count++;
                    return;               
                }
                prevNode = curNode;
                curNode = curNode.Next!;
            }
            
            AddLast(newData); // If insert is not less than any of the existing elements and added to the end
                        
        }
    }
    
    static class Program
    {
        // Method to test operation of the linked list.
        
        static void Main( )
        {
            Drug[ ] drugArray = Drug.ArrayFromFile( "RXQT1503-100.txt" );
            
            LinkedList drugList = new LinkedList( );
            foreach( Drug d in drugArray ) drugList.InsertInOrder( d );
            
            WriteLine( "drugList.Count = {0}", drugList.Count );
            foreach( Drug d in drugList.ToArray( ) ) WriteLine( d );
        }
    }
}
