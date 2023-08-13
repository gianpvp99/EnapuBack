using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IunitMeasurement
    {
        Task<int> Maintenance(RUnitMeasurementMaintenance unitMeasurement);
        Task<List<UnitMeasurement>> Search(string text);
        Task<List<UnitMeasurement>> List();
        Task<List<UnitMeasurement>> Search(int id);
    }
}
