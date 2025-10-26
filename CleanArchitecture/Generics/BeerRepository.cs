using System;

namespace Generics
{
    public class BeerRepository : IRepository<string>
    {
        private string[] _beers;
        private int _index;
        private const int QUANTITY = 10;

        public BeerRepository()
        {
            _beers = new string[QUANTITY];
            _index = 0;
        }


        public void Add(string beer)
        {
            if( _index < QUANTITY )
            {
                _beers[_index] = beer;
            }
        }

        public IEnumerable<string> GetAll()
            => _beers;
    }
}

