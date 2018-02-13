namespace ZoeProg.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ZoeProg.WebApi.Models;

    public interface ISerializeService
    {
        BookStore Deserialize(string fileName);

        void Serialize(BookStore bookStore, string fileName);
    }
}