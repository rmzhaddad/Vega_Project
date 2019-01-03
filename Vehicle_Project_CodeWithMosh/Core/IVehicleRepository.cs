using System.Threading.Tasks;
using Vehicle_Project_CodeWithMosh.Models;

namespace Vehicle_Project_CodeWithMosh.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated =true);

        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);

    }
}