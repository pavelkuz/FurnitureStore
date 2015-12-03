using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Models
{
    interface IFurnitureTypeRepository
    {
        List<FurnitureType> GetAllFurnitureTypes();

        void Save(FurnitureType furnitureType);

        FurnitureType GetFurnitureTypeById(Guid id);

        void RemoveFurnitureTypeById(Guid id);

        void UpdateFurnitureTypeById(FurnitureType furnitureType);
    }
}
