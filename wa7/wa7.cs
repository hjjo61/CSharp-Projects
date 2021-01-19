#nullable enable

using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        // Field 'rGen' and methods NewRandomArray and WriteArrayOneLine are used to
        // generate and display arrays used to test searching and sorting algorithms.

        static Random rGen = new Random( );

        // Create an integer array filled with random values.

        static int[ ] NewRandomArray( int size ) { return NewRandomArray( size, size ); }

        static int[ ] NewRandomArray( int size, int range )
        {
            if( size < 1 ) return new int[ 0 ];

            int[ ] result = new int[ size ];

            for( int i = 0; i < result.Length; i ++ )
            {
                result[ i ] = rGen.Next( 0, range );
            }

            return result;
        }

        // Write up to 10 elements of an integer array, all on one line.
        // The name to display for the index is passed as a string.
        // The name to display for the array is passed as a string.

        static void WriteArrayOneLine( int[ ] a ) { WriteArrayOneLine( a, "i", nameof( a ), true ); }
        static void WriteArrayOneLine( int[ ] a, string indexName, string arrayName, bool showIndex = true )
        {
            if( a == null ) return;
            if( string.IsNullOrEmpty( indexName ) ) indexName = "i";
            if( string.IsNullOrEmpty( arrayName ) ) arrayName = "a";
            int nameLength = Math.Max( indexName.Length, arrayName.Length );
            string fmt = "{0," + nameLength + "}:";

            if( showIndex )
            {
                if( a.Length >  0 ) Write( fmt, indexName );
                if( a.Length >  0 ) Write( $" {0,8}" );
                if( a.Length >  1 ) Write( $" {1,8}" );
                if( a.Length >  2 ) Write( $" {2,8}" );
                if( a.Length >  3 ) Write( $" {3,8}" );
                if( a.Length >  4 ) Write( $" {4,8}" );
                if( a.Length > 10 ) Write( " ..." );
                if( a.Length >  9 ) Write( $" {(a.Length - 5),8}" );
                if( a.Length >  8 ) Write( $" {(a.Length - 4),8}" );
                if( a.Length >  7 ) Write( $" {(a.Length - 3),8}" );
                if( a.Length >  6 ) Write( $" {(a.Length - 2),8}" );
                if( a.Length >  5 ) Write( $" {(a.Length - 1),8}" );
                WriteLine( );
            }

            if( a.Length >  0 ) Write( fmt, arrayName );
            if( a.Length >  0 ) Write( $" {a[ 0 ],8}" );
            if( a.Length >  1 ) Write( $" {a[ 1 ],8}" );
            if( a.Length >  2 ) Write( $" {a[ 2 ],8}" );
            if( a.Length >  3 ) Write( $" {a[ 3 ],8}" );
            if( a.Length >  4 ) Write( $" {a[ 4 ],8}" );
            if( a.Length > 10 ) Write( " ..." );
            if( a.Length >  9 ) Write( $" {a[ a.Length - 5 ],8}" );
            if( a.Length >  8 ) Write( $" {a[ a.Length - 4 ],8}" );
            if( a.Length >  7 ) Write( $" {a[ a.Length - 3 ],8}" );
            if( a.Length >  6 ) Write( $" {a[ a.Length - 2 ],8}" );
            if( a.Length >  5 ) Write( $" {a[ a.Length - 1 ],8}" );
            WriteLine( );
        }

        // Method SelectSort is used to sort an array of integers.

        static void SelectSort(int[] a, out int[] swappity)
        {

            if (a == null)
            {
                swappity = new int[0];
                return;
            }
            if (a.Length < 2)
            {
                swappity = new int[0];
                return;
            }

            swappity = new int[a.Length - 1];

            for ( int firstUnsorted = 0; firstUnsorted < a.Length - 1; firstUnsorted ++ )
            {
                int min = firstUnsorted;
                for( int i = firstUnsorted + 1; i < a.Length; i ++ )
                {
                    if( Compare( a[ i ], a[ min ] ) < 0 ) min = i;
                }
                int temp = a[ min ];
                a[ min ] = a[ firstUnsorted ];
                a[ firstUnsorted ] = temp;
                
                swappity[firstUnsorted] = min;
            }
        }
        
        // Method UndoSelectSort receives an array and the swaps used in sorting it
        // by selection sort. It returns the array to its original unsorted order.
        
        static void UndoSelectSort( int[] b, int[] exchanges )
        {
            if (exchanges == null) throw new ArgumentNullException(nameof(b));
            if (exchanges.Length == 0) throw new ArgumentOutOfRangeException(nameof(b));
            for( int i = exchanges.Length - 1; i >= 0; i--)
            {
                int temp = b[i];
                b[i] = b[exchanges[i]];
                b[exchanges[i]] = temp;
            }
        }

        // Method Main is used to test selection sorting and its undoing.

        static void Main( )
        {
            int[ ] data = NewRandomArray( size: 10, range: 100 );
            
            WriteLine( );
            WriteLine( "Original array" );
            WriteArrayOneLine( data, "i", nameof( data ) );

            SelectSort(data, out int[] swap);

            WriteLine();
            WriteLine("Exchanges array");
            WriteArrayOneLine(swap, "i", nameof(swap));
                        
            WriteLine( );
            WriteLine( "Sorted array" );
            WriteArrayOneLine( data, "i", nameof( data ) );
            
            UndoSelectSort( data, swap );

            WriteLine();
            WriteLine("Unsorted array");
            WriteArrayOneLine(data, "i", nameof(data));
            WriteLine( );
        }

        // Method Compare is the comparison used in sorting.
        
        static int Compare( int a, int b )
        {
            return a.CompareTo( b );
        }
    }
}
