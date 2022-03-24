using System;
using System.Threading.Tasks;
using TechTest.Models;

namespace TechTest.Core
{
    public interface IStringStatsProcessor
    {
        Task<StringStatsModel> Run(string subject);
    }
}
