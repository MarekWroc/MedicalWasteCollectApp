using static MedicalWasteCollectApp.TruckBase;

namespace MedicalWasteCollectApp
{
    public interface ITruck
    {
        string Vin { get; }

        string RegNumber { get; }

        int MaxLoad { get; }

        void AddWaste(int load);

        void AddWaste(string load);

        void AddWaste(float load);

        void AddWaste(double load);

        void UnloadWaste();

        event WasteAddedDelegate WasteAdded;

        public abstract Statistics GetStatistics();
    }
}
