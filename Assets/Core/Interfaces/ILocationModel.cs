using Core.Models;

namespace Core.Interfaces {
    public interface ILocationModel {
        LocationState CurrentState { get; }
    }
}