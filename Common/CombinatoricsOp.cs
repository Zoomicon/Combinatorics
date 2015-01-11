//Version: 20111119
//Author: George Birbilis (birbilis@kagi.com)

using System;
using System.Collections.Generic;

namespace Combinatorics
{

  public static class CombinatoricsOp {

    public enum CombinatoricsOpType
    {
      Permutations = 0,
      PermutationsWithRepetition = 1,
      //---
      Combinations = 2,
      CombinationsWithRepetition = 3,
      //---
      Variations = 4,
      VariationsWithRepetition = 5
    }
   
   public static IMetaCollection<string> GetCombinatoricsOp(IList<string> values, CombinatoricsOpType opType, int take){
     switch (opType)
     {
       case CombinatoricsOpType.Permutations:
         return new Permutations<string>(values);
       case CombinatoricsOpType.PermutationsWithRepetition:
         return new Permutations<string>(values,GenerateOption.WithRepetition);
       case CombinatoricsOpType.Combinations:
         return new Combinations<string>(values, take);
       case CombinatoricsOpType.CombinationsWithRepetition:
         return new Combinations<string>(values, take, GenerateOption.WithRepetition);
       case CombinatoricsOpType.Variations:
         return new Variations<string>(values, take);
       case CombinatoricsOpType.VariationsWithRepetition:
         return new Variations<string>(values, take, GenerateOption.WithRepetition);
       default:
         throw new NotImplementedException();
     }
   }

  }
  
}
