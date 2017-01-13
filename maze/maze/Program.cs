using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze
{
    class Program
    {
         public  int N = 4;
         public  int [,] sol;
         public  int [,]mase;
         public Program(int[,] sol, int [,]mase)
	     {
             this.sol = sol;
             this.mase = mase;
             
	   }
    void printSolution()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
               Console.Write(" " + sol[i,j] + " ");
             Console.WriteLine();
        }
    }
 
   
    bool isSafe(int x, int y)
    {
        // if (x,y outside maze) return false
        return (x >= 0 && x < N && y >= 0 && y < N && mase[x,y] == 1);
    }
 
     
    bool solveMaze()
    {
        
 
        if (solveMazeUtil( 0, 0) == false)
        {
           Console.Write("Solution doesn't exist");
            return false;
        }
 
        printSolution();
        return true;
    }
 
 
    bool solveMazeUtil( int x, int y)
    {
        // N-1 IS end or exit 
        if (x == N - 1 && y == N - 1)
        {
            sol[x,y] = 1;
            return true;
        }
 
        // Check if maze[x][y] is valid
        if (isSafe( x, y) == true)
        {
            // mark x,y as part of solution path
            sol[x,y] = 1;
 
            /* Move forward in x direction */
            if (solveMazeUtil(x + 1, y))
                return true;
 
            /*  Move down in y direction */
            if (solveMazeUtil(x, y + 1))
                return true;
 
            
            sol[x,y] = 0;
            return false;
        }
 
        return false;
    }
        static void Main(string[] args)
        {
            int [,] sol = new int [,]  { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            int[,] mase = new int[,] { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 1, 1, 1, 1 } };
            Program m = new Program(sol, mase);
            m.solveMaze();
            Console.ReadLine();
        }
    }
}
