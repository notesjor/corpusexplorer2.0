#region

using System;
using System.Collections;

#endregion

namespace CorpusExplorer.Sdk.Utils.Diff
{
  // DiffDelta

  public class Diff
  {
    /// <summary>
    ///   Scan the tables of which lines are inserted and deleted,
    ///   producing an edit script in forward order.
    /// </summary>
    /// dynamic array
    private static DiffDelta[] CreateDiffs(DiffData dataA, DiffData dataB)
    {
      var a = new ArrayList();

      var lineA = 0;
      var lineB = 0;
      while (lineA < dataA.Length ||
             lineB < dataB.Length)
        if (lineA < dataA.Length &&
            !dataA.Modified[lineA] &&
            lineB < dataB.Length &&
            !dataB.Modified[lineB])
        {
          // equal lines
          lineA++;
          lineB++;
        }
        else
        {
          // maybe deleted and/or inserted lines
          var startA = lineA;
          var startB = lineB;

          while (lineA < dataA.Length &&
                 (lineB >= dataB.Length || dataA.Modified[lineA]))
            lineA++;

          while (lineB < dataB.Length &&
                 (lineA >= dataA.Length || dataB.Modified[lineB]))
            lineB++;

          if (startA < lineA ||
              startB < lineB)
            a.Add(
              new DiffDelta
              {
                StartA = startA,
                StartB = startB,
                DeletedA = lineA - startA,
                InsertedB = lineB - startB
              });
        } // if

      var result = new DiffDelta[a.Count];
      a.CopyTo(result);

      return result;
    }

    /// <summary>
    ///   Find the difference in 2 arrays of integers.
    /// </summary>
    /// <param name="arrayA">A-version of the numbers (usualy the old one)</param>
    /// <param name="arrayB">B-version of the numbers (usualy the new one)</param>
    /// <returns>Returns a array of Items that describe the differences.</returns>
    public static DiffDelta[] DiffInt(int[] arrayA, int[] arrayB)
    {
      // The A-Version of the data (original data) to be compared.
      var dataA = new DiffData(arrayA);

      // The B-Version of the data (modified data) to be compared.
      var dataB = new DiffData(arrayB);

      var max = dataA.Length + dataB.Length + 1;
      // vector for the (0,0) to (x,y) search
      var downVector = new int[2 * max + 2];
      // vector for the (u,v) to (N,M) search
      var upVector = new int[2 * max + 2];

      Lcs(dataA, 0, dataA.Length, dataB, 0, dataB.Length, downVector, upVector);
      return CreateDiffs(dataA, dataB);
    }

    /// <summary>
    ///   This is the divide-and-conquer implementation of the longes common-subsequence (LCS)
    ///   algorithm.
    ///   The published algorithm passes recursively parts of the A and B sequences.
    ///   To avoid copying these arrays the lower and upper bounds are passed while the sequences stay constant.
    /// </summary>
    /// <param name="dataA">sequence A</param>
    /// <param name="lowerA">lower bound of the actual range in DataA</param>
    /// <param name="upperA">upper bound of the actual range in DataA (exclusive)</param>
    /// <param name="dataB">sequence B</param>
    /// <param name="lowerB">lower bound of the actual range in DataB</param>
    /// <param name="upperB">upper bound of the actual range in DataB (exclusive)</param>
    /// <param name="downVector">a vector for the (0,0) to (x,y) search. Passed as a parameter for speed reasons.</param>
    /// <param name="upVector">a vector for the (u,v) to (N,M) search. Passed as a parameter for speed reasons.</param>
    private static void Lcs(
      DiffData dataA,
      int lowerA,
      int upperA,
      DiffData dataB,
      int lowerB,
      int upperB,
      int[] downVector,
      int[] upVector)
    {
      // Fast walkthrough equal lines at the start
      while (lowerA < upperA &&
             lowerB < upperB &&
             dataA.Data[lowerA] == dataB.Data[lowerB])
      {
        lowerA++;
        lowerB++;
      }

      // Fast walkthrough equal lines at the end
      while (lowerA < upperA &&
             lowerB < upperB &&
             dataA.Data[upperA - 1] == dataB.Data[upperB - 1])
      {
        --upperA;
        --upperB;
      }

      if (lowerA == upperA)
      {
        // mark as inserted lines.
        while (lowerB < upperB)
          dataB.Modified[lowerB++] = true;
      }
      else if (lowerB == upperB)
      {
        // mark as deleted lines.
        while (lowerA < upperA)
          dataA.Modified[lowerA++] = true;
      }
      else
      {
        // Find the middle snakea and length of an optimal path for A and B
        var smsrd = Sms(dataA, lowerA, upperA, dataB, lowerB, upperB, downVector, upVector);

        // The path is from LowerX to (x,y) and (x,y) to UpperX
        Lcs(dataA, lowerA, smsrd.X, dataB, lowerB, smsrd.Y, downVector, upVector);
        Lcs(dataA, smsrd.X, upperA, dataB, smsrd.Y, upperB, downVector, upVector); // 2002.09.20: no need for 2 points 
      }
    }

    /// <summary>
    ///   This is the algorithm to find the Shortest Middle Snake (SMS).
    /// </summary>
    /// <param name="dataA">sequence A</param>
    /// <param name="lowerA">lower bound of the actual range in DataA</param>
    /// <param name="upperA">upper bound of the actual range in DataA (exclusive)</param>
    /// <param name="dataB">sequence B</param>
    /// <param name="lowerB">lower bound of the actual range in DataB</param>
    /// <param name="upperB">upper bound of the actual range in DataB (exclusive)</param>
    /// <param name="downVector">a vector for the (0,0) to (x,y) search. Passed as a parameter for speed reasons.</param>
    /// <param name="upVector">a vector for the (u,v) to (N,M) search. Passed as a parameter for speed reasons.</param>
    /// <returns>a MiddleSnakeData record containing x,y and u,v</returns>
    private static Smsrd Sms(
      DiffData dataA,
      int lowerA,
      int upperA,
      DiffData dataB,
      int lowerB,
      int upperB,
      int[] downVector,
      int[] upVector)
    {
      var max = dataA.Length + dataB.Length + 1;

      var downK = lowerA - lowerB; // the k-line to start the forward search
      var upK = upperA - upperB; // the k-line to start the reverse search

      var delta = upperA - lowerA - (upperB - lowerB);
      var oddDelta = (delta & 1) != 0;

      // The vectors in the publication accepts negative indexes. the vectors implemented here are 0-based
      // and are access using a specific offset: UpOffset UpVector and DownOffset for DownVektor
      var downOffset = max - downK;
      var upOffset = max - upK;

      var maxD = (upperA - lowerA + upperB - lowerB) / 2 + 1;

      // init vectors
      downVector[downOffset + downK + 1] = lowerA;
      upVector[upOffset + upK - 1] = upperA;

      for (var d = 0; d <= maxD; d++)
      {
        // Extend the forward path.
        Smsrd ret;
        for (var k = downK - d; k <= downK + d; k += 2)
        {
          // find the only or better starting point
          int x;
          if (k == downK - d)
          {
            x = downVector[downOffset + k + 1]; // down
          }
          else
          {
            x = downVector[downOffset + k - 1] + 1; // a step to the right
            if (k < downK + d &&
                downVector[downOffset + k + 1] >= x)
              x = downVector[downOffset + k + 1]; // down
          }
          var y = x - k;

          // find the end of the furthest reaching forward D-path in diagonal k.
          while (x < upperA &&
                 y < upperB &&
                 dataA.Data[x] == dataB.Data[y])
          {
            x++;
            y++;
          }
          downVector[downOffset + k] = x;

          // overlap ?
          // ReSharper disable once InvertIf
          if (oddDelta &&
              upK - d < k &&
              k < upK + d)
            if (upVector[upOffset + k] <= downVector[downOffset + k])
            {
              ret.X = downVector[downOffset + k];
              ret.Y = downVector[downOffset + k] - k;
              // ret.u = UpVector[UpOffset + k];      // 2002.09.20: no need for 2 points 
              // ret.v = UpVector[UpOffset + k] - k;
              return ret;
            } // if
        } // for k

        // Extend the reverse path.
        for (var k = upK - d; k <= upK + d; k += 2)
        {
          // find the only or better starting point
          int x;
          if (k == upK + d)
          {
            x = upVector[upOffset + k - 1]; // up
          }
          else
          {
            x = upVector[upOffset + k + 1] - 1; // left
            if (k > upK - d &&
                upVector[upOffset + k - 1] < x)
              x = upVector[upOffset + k - 1]; // up
          } // if
          var y = x - k;

          while (x > lowerA &&
                 y > lowerB &&
                 dataA.Data[x - 1] == dataB.Data[y - 1])
          {
            x--;
            y--; // diagonal
          }
          upVector[upOffset + k] = x;

          // overlap ?
          // ReSharper disable once InvertIf
          if (!oddDelta &&
              downK - d <= k &&
              k <= downK + d)
            if (upVector[upOffset + k] <= downVector[downOffset + k])
            {
              ret.X = downVector[downOffset + k];
              ret.Y = downVector[downOffset + k] - k;
              // ret.u = UpVector[UpOffset + k];     // 2002.09.20: no need for 2 points 
              // ret.v = UpVector[UpOffset + k] - k;
              return ret;
            } // if
        } // for k
      } // for D

      throw new ApplicationException("the algorithm should never come here.");
    }

    /// <summary>
    ///   Data on one input file being compared.
    /// </summary>
    private sealed class DiffData
    {
      /// <summary>Buffer of numbers that will be compared.</summary>
      internal readonly int[] Data;

      /// <summary>Number of elements (lines).</summary>
      internal readonly int Length;

      /// <summary>
      ///   Array of booleans that flag for modified data.
      ///   This is the result of the diff.
      ///   This means deletedA in the first Data or inserted in the second Data.
      /// </summary>
      internal readonly bool[] Modified;

      /// <summary>
      ///   Initialize the Diff-Data buffer.
      /// </summary>
      /// <param name="initData">reference to the buffer</param>
      internal DiffData(int[] initData)
      {
        Data = initData;
        Length = initData.Length;
        Modified = new bool[Length + 2];
      }
    }

    /// <summary>
    ///   Shortest Middle Snake Return Data
    /// </summary>
    private struct Smsrd
    {
      internal int X, Y;
    }
  }
}