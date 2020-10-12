using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
  public class CustomDictionary <T,V> 
    {      
       List<PairKeyAndValue<T,V>> listForStoragePairKeyAndValue;
       public int count { get; private  set; }

        public CustomDictionary()
        {
           listForStoragePairKeyAndValue = new List<PairKeyAndValue<T, V>>();
           
        }

        public V this[T key]
        {
         get
          {
           PairKeyAndValue<T, V> currentPair;
           foreach (var wantedKey in listForStoragePairKeyAndValue)
           {
           if (wantedKey.key.Equals(key))
           {
             return wantedKey.value;
           }

           }
            throw new KeyNotFoundException();
           }
             
         set
         {
          PairKeyAndValue<T, V> currentPair;
          bool wasSeted = false;
          foreach (var wantedKey in listForStoragePairKeyAndValue)
          {
             if (wantedKey.key.Equals(key))
             {
               wantedKey.value = value;
               wasSeted = true;
               break;                 
             }
          }
          if (!wasSeted)
          {
             throw new KeyNotFoundException();
          }                
            }
        }

        public void Add (T key, V value)
        {
            PairKeyAndValue<T,V> pairKeyAndValue = new PairKeyAndValue<T,V>(key, value);
            listForStoragePairKeyAndValue.Add(pairKeyAndValue);
            count += 1;       
        }

        public bool ContainsKey(T Key)
        {
            bool wantedKeyWasFound = false;
            PairKeyAndValue<T, V> currentPair;
            foreach(var wantedKey in listForStoragePairKeyAndValue)
            {
                if (wantedKey.key.Equals(Key))
                {
                    wantedKeyWasFound = true;
                    break;                    
                }
            }
            return wantedKeyWasFound;            
        }







    }



}
