using System;

namespace Services.Inputs
{
    public interface IInputService
    {
        void OnShoot(Action cast);
        void OffShoot(Action offCast);
        void OnActiveControls();
        void InActiveControls();
    }
}